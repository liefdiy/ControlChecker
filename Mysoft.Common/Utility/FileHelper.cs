using System;
using System.IO;
using System.Text;

namespace Mysoft.Common.Utility
{
    /// <summary>
    /// 文件编码探测器
    /// </summary>
    public class EncodingDetector2
    {
        /// <summary>
        /// 最大探测长度 100M
        /// </summary>
        private static readonly int MAX_SIZE = 100 * 1024 * 1024;



        /// <summary>
        /// 文件内容。
        /// 注意：有可能并没有发生读取整个文件的过程，那么返回 null
        /// </summary>
        public byte[] FileBody { get; private set; }


        /// <summary>
        /// 检测到的文件编码
        /// </summary>
        public Encoding FileEncoding { get; private set; }


        /// <summary>
        /// 是否为无BOM头的UTF-8编码
        /// </summary>
        public bool IsNoBomUTF8 { get; private set; }


        public EncodingDetector2(FileStream fs)
            : this(fs, MAX_SIZE)
        {
        }

        public EncodingDetector2(FileStream fs, int maxDetectLength)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");

            FileEncoding = GetFileEncoding(fs, maxDetectLength);
        }


        private Encoding GetFileEncoding(FileStream fs, int maxDetectLength)
        {
            if (fs.Length == 0)
                return Encoding.Default;

            byte[] bomBuffer = new byte[4];

            int size = fs.Read(bomBuffer, 0, 4);
            fs.Seek(0, SeekOrigin.Begin);

            if (size >= 2 && ((bomBuffer[0] == 0xff && bomBuffer[1] == 0xfe) || (bomBuffer[0] == 0xfe && bomBuffer[1] == 0xff)))
                return Encoding.Unicode;

            if (size >= 3 && bomBuffer[0] == 0xef && bomBuffer[1] == 0xbb && bomBuffer[2] == 0xbf)
                return Encoding.UTF8;

            if (size >= 4 && (
                        (bomBuffer[0] == 0x00 && bomBuffer[1] == 0x00 && bomBuffer[2] == 0xfe && bomBuffer[3] == 0xff)
                    || (bomBuffer[0] == 0xff && bomBuffer[1] == 0xfe && bomBuffer[2] == 0x00 && bomBuffer[3] == 0x00)))
                return Encoding.UTF32;

            // 没有检测到有效的BOM头，此时有二种情况：无BOM的UTF-8，或者ANSI

            if (fs.Length <= maxDetectLength)
            {
                FileBody = new byte[fs.Length];
                fs.Read(FileBody, 0, FileBody.Length);
                fs.Seek(0, SeekOrigin.Begin);

                if (IsUTF8Bytes(FileBody, FileBody.Length))
                {
                    IsNoBomUTF8 = true;
                    return Encoding.UTF8;
                }
            }

            return Encoding.Default;
        }



        private static bool IsUTF8Bytes(byte[] data, int len)
        {
            int charByteCounter = 1;　 //计算当前正分析的字符应还有的字节数
            byte curByte; //当前分析的字节.
            bool existBigChar = false;

            for (int i = 0; i < len; i++)
            {
                curByte = data[i];

                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {
                        //判断当前
                        while (((curByte <<= 1) & 0x80) != 0)
                            charByteCounter++;

                        //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X　
                        if (charByteCounter == 1 || charByteCounter > 6)
                            return false;
                    }
                }
                else
                {
                    //若是UTF-8 此时第一位必须为1
                    if ((curByte & 0xC0) != 0x80)
                        return false;
                    charByteCounter--;
                    existBigChar = true;
                }
            }

            if (charByteCounter > 1)
                return false;

            return existBigChar;
        }


    }

    public static class FileHelper
    {
        /// <summary>
        /// 写到文件
        /// </summary>
        /// <param name="path">路径，如果路径不存在会自动创建</param>
        /// <param name="message">要写的内容</param>
        /// <param name="encoding">编码，默认UTF8</param>
        /// <param name="append">是否附加</param>
        public static void Write(string path, string message, Encoding encoding = null, bool append = false)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            FileInfo fi = new FileInfo(path);
            if (fi.Directory != null && !fi.Directory.Exists)
            {
                Directory.CreateDirectory(fi.Directory.FullName);
            }

            FileStream fs = new FileStream(path, append ? FileMode.OpenOrCreate : FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, encoding);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(message);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <param name="encoding">文件编码</param>
        /// <returns></returns>
        public static string Read(string filePath, out Encoding encoding)
        {
            encoding = Encoding.Default;

            if (!File.Exists(filePath))
            {
                return "";
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                EncodingDetector2 dec = new EncodingDetector2(fs);
                encoding = dec.FileEncoding;
            }

            using (TextReader text = new StreamReader(filePath, encoding))
            {
                string content = text.ReadToEnd();
                text.Close();
                return content;
            }
        }

        /// <summary>
        /// 读取文件内容，自动判断编码
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string Read(string filePath)
        {
            Encoding encoding = null;
            return Read(filePath, out encoding);
        }
    }

    #region 编码检测

    public static class EncodingDetector
    {
        private static readonly byte[] _unicodeHeader = new byte[]
            {
                255,    //FF
                254     //FE
            };

        private static readonly byte[] _unicodeBigHeader = new byte[]
            {
                254,    //FE
                255     //FF
            };

        private static readonly byte[] _utf8Header = new byte[]
            {
                239,    //EF
                187,    //BB
                191     //BF
            };

        private static readonly byte[] _ansiHeader = new byte[]
            {
                60, //3C
                63, //3F
                120 //78
            };

        public static Encoding GetEncoding(string path)
        {
            Encoding encoding;
            using (StreamReader streamReader = new StreamReader(path, true))
            {
                encoding = EncodingDetector.GetEncoding(streamReader);
            }
            return encoding;
        }

        public static Encoding GetEncoding(StreamReader sr)
        {
            Encoding encoding = null;
            using (BinaryReader binaryReader = new BinaryReader(sr.BaseStream))
            {
                byte[] array = binaryReader.ReadBytes(3);
                if (array.Length <= 0) return Encoding.UTF8;

                if (array.Length >= 3)
                {
                    if (array[0] == EncodingDetector._utf8Header[0] && array[1] == EncodingDetector._utf8Header[1] &&
                        array[2] == EncodingDetector._utf8Header[2])
                    {
                        encoding = new Utf8EncodingIdentifier(true);
                    }
                    if (array[0] == EncodingDetector._unicodeHeader[0] && array[1] == EncodingDetector._unicodeHeader[1])
                    {
                        encoding = Encoding.Unicode;
                    }
                    if (array[0] == EncodingDetector._unicodeBigHeader[0] &&
                        array[1] == EncodingDetector._unicodeBigHeader[1])
                    {
                        encoding = Encoding.BigEndianUnicode;
                    }
                    if (array[0] == EncodingDetector._ansiHeader[0] &&
                        array[1] == EncodingDetector._ansiHeader[1] &&
                        array[2] == EncodingDetector._ansiHeader[2])
                    {
                        //无BOM的UTF8可能也会被解析成GB2312
                        encoding = Encoding.GetEncoding("GB2312");
                    }
                }

                if (encoding != null) return encoding;

                sr.BaseStream.Seek(0L, SeekOrigin.Begin);
                string charset = EncodingDetector.DetectStream(sr.BaseStream);
                if (charset == "nomatch") charset = Encoding.Default.BodyName;
                try
                {
                    encoding = Encoding.GetEncoding(charset);
                }
                catch (Exception)
                {
                    encoding = Encoding.Default;
                }
            }
            return encoding;
        }

        public static string DetectStream(Stream stream)
        {
            int lang = 2;
            NChardet.Detector det = new NChardet.Detector(lang);

            CharsetDetectionObserver cdo = new CharsetDetectionObserver();
            det.Init(cdo);

            byte[] buf = new byte[1024];
            bool done = false;
            bool isAscii = true;
            int len;
            using (stream)
            {
                while ((len = stream.Read(buf, 0, buf.Length)) != 0)
                {
                    // 探测是否为Ascii编码
                    if (isAscii == true) isAscii = det.isAscii(buf, len);

                    // 如果不是Ascii编码，并且编码未确定，则继续探测
                    if (isAscii == false && done == false)
                        done = det.DoIt(buf, len, false);
                }
            }
            //调用DatEnd方法，
            //如果引擎认为已经探测出了正确的编码，
            //则会在此时调用ICharsetDetectionObserver的Notify方法
            det.DataEnd();

            string charset = Encoding.Default.BodyName;
            if (isAscii == true)
            {
                charset = Encoding.ASCII.BodyName;
            }
            else if (!string.IsNullOrEmpty(cdo.Charset))
            {
                charset = cdo.Charset;
            }
            else
            {
                string[] probable = det.getProbableCharsets();
                if (probable != null && probable.Length >= 1)
                {
                    string probableCharset = probable[0].ToLower();
                    if (probableCharset == "gb2312" || probableCharset == "utf-8")
                    {
                        charset = probableCharset;
                    }
                }
            }
            return charset;
        }

    }

    /// <summary>
    /// Description of CharsetDetectionObserver.
    /// </summary>
    public class CharsetDetectionObserver : NChardet.ICharsetDetectionObserver
    {
        public string Charset = null;

        public void Notify(string charset)
        {
            Charset = charset;
        }
    }

    public class Utf8EncodingIdentifier : System.Text.UTF8Encoding
    {
        private readonly bool encoderShouldEmitUTF8Identifier;

        public Utf8EncodingIdentifier(bool encoderShouldEmitUTF8Identifier)
            : base(encoderShouldEmitUTF8Identifier)
        {
            this.encoderShouldEmitUTF8Identifier = encoderShouldEmitUTF8Identifier;
        }

        public bool EncoderShouldEmitUTF8Identifier
        {
            get { return encoderShouldEmitUTF8Identifier; }
        }
    }
    
    #endregion 编码检测
}
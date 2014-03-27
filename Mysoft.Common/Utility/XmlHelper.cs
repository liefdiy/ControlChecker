namespace Mysoft.Common.Utility
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// 用于XML序列化/反序列化的工具类
    /// </summary>
    public static class XmlHelper
    {
        private static Encoding s_Encoding = Encoding.UTF8;

        private static void XmlSerializeInternal(Stream stream, object o, Encoding encoding)
        {
            if (o == null)
                throw new ArgumentNullException("o");
            if (encoding == null)
                throw new ArgumentNullException("encoding");

            XmlSerializer serializer = new XmlSerializer(o.GetType());

            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineChars = "\r\n";
            settings.Encoding = encoding;
            settings.IndentChars = "    ";

            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, o, xmlns);
                writer.Close();
            }
        }

        /// <summary>
        /// 将一个对象序列化为XML字符串
        /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>序列化产生的XML字符串</returns>
        public static string XmlSerialize(object o, Encoding encoding)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializeInternal(stream, o, encoding);

                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static string XmlSerialize(object o)
        {
            return XmlSerialize(o, s_Encoding);
        }

        /// <summary>
        /// 将一个对象按XML序列化的方式写入到一个文件
        /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="path">保存文件路径</param>
        /// <param name="encoding">编码方式</param>
        public static void XmlSerializeToFile(object o, string path, Encoding encoding)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            FileInfo fileinfo = new FileInfo(path);
            if (fileinfo.Directory != null && !fileinfo.Directory.Exists)
            {
                Directory.CreateDirectory(fileinfo.Directory.FullName);
            }

            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                XmlSerializeInternal(file, o, encoding);
            }
        }

        public static void XmlSerializeToFile(object o, string path)
        {
            XmlSerializeToFile(o, path, s_Encoding);
        }

        /// <summary>
        /// 从XML字符串中反序列化对象
        /// </summary>
        /// <typeparam name="T">结果对象类型</typeparam>
        /// <param name="s">包含对象的XML字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>反序列化得到的对象</returns>
        public static T XmlDeserialize<T>(string s, Encoding encoding)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s");
            if (encoding == null)
                throw new ArgumentNullException("encoding");

            XmlSerializer mySerializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(encoding.GetBytes(s)))
            {
                using (StreamReader sr = new StreamReader(ms, encoding))
                {
                    return (T)mySerializer.Deserialize(sr);
                }
            }
        }

        public static T XmlDeserialize<T>(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return default(T);
            }
            return XmlDeserialize<T>(s, s_Encoding);
        }

        /// <summary>
        /// 读入一个文件，并按XML的方式反序列化对象。
        /// 读取ERP配置文件时，建议使用XmlDeserialize<T>(FileHelper.Read(path))的方式以避免编码问题
        /// </summary>
        /// <typeparam name="T">结果对象类型</typeparam>
        /// <param name="path">文件路径</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>反序列化得到的对象</returns>
        public static T XmlDeserializeFromFile<T>(string path, Encoding encoding)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");
            if (encoding == null)
                throw new ArgumentNullException("encoding");

            string xml = File.ReadAllText(path, encoding);
            return XmlDeserialize<T>(xml, encoding);
        }

        public static T XmlDeserializeFromFile<T>(string path)
        {
            if (!File.Exists(path)) return default(T);
            Encoding encoding = Encoding.Default;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                EncodingDetector2 dec = new EncodingDetector2(fs);
                encoding = dec.FileEncoding;
            }
            return XmlDeserializeFromFile<T>(path, encoding);
        }

        public static string FormatXml(string xml)
        {
            if (string.IsNullOrEmpty(xml)) return "";

            XmlTextWriter w = null;
            StringBuilder sb = new StringBuilder();
            try
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(xml);
                StringWriter writer2 = new StringWriter(sb);
                w = new XmlTextWriter(writer2)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 2,
                    IndentChar = ' '
                };
                document.WriteTo(w);
            }
            finally
            {
                if (w != null)
                {
                    w.Close();
                }
            }
            return sb.ToString();
        }
    }
}
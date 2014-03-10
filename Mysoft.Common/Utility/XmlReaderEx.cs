using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace Mysoft.Common.Utility
{
    public static class XmlReaderEx
    {
        /// <summary>
        /// 扩展读到指定的节点位置
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static bool ReadToDescendantEx(this XmlReader xmlReader, string nodeName)
        {
            do
            {
                if (xmlReader.NodeType == XmlNodeType.Element
                    && xmlReader.LocalName == nodeName)
                    return true;
            }
            while (xmlReader.Read());

            return false;
        }
    }
}

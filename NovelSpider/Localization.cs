using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace NovelSpider
{
    static class Localization
    {
        static Dictionary<string, string> _strTable = new Dictionary<string, string>();
        static readonly string _i18nFilePathName = "i18n.xml";
        static readonly string _noUseI18N = "noi18n";
        static string _strError = string.Empty;
        static bool _undefinedKey = false;
        static bool _bNoUseI18N = false;
        static Localization()
        {
            _bNoUseI18N = File.Exists(_noUseI18N);
            try {
                string strXml = File.ReadAllText(_i18nFilePathName);
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(strXml);
                foreach(XmlNode rootn in xml.ChildNodes) {
                    if (rootn.Name == "stringTable") {
                        foreach (XmlNode n in rootn.ChildNodes) {
                            XmlAttributeCollection ats = n.Attributes;
                            if (ats.Count >= 2) {
                                _strTable[ats[0].Value] = ats[1].Value;
                            }
                        }
                    }
                }
            } catch(Exception e) {
                _strError = e.ToString();
            }
        }
        private static int _idxStr = 0;
        public static string Get(string key)
        {
            if (_strTable.ContainsKey(key)) {
                return _bNoUseI18N ? key : _strTable[key];
            } else {
                _undefinedKey = true;
                _idxStr++;
                string str = key == "宋体" ? "Verdana" : _idxStr.ToString();
                _strTable[key] = str;
                return _bNoUseI18N ? key : str;
            }
        }
        public static void Refresh()
        {
            if (_undefinedKey) {
                File.Delete(_i18nFilePathName);
                XmlDocument xml = new XmlDocument();
                XmlNode descn = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
                xml.AppendChild(descn);

                XmlNode rootn = xml.CreateElement("stringTable");
                XmlAttribute time = xml.CreateAttribute("time");
                time.Value = System.DateTime.Now.ToString();
                rootn.Attributes.Append(time);
                xml.AppendChild(rootn);
                foreach (KeyValuePair<string, string> pair in _strTable) {
                    XmlNode n = xml.CreateElement("string");
                    XmlAttribute aname = xml.CreateAttribute("name");
                    XmlAttribute avalue = xml.CreateAttribute("value");
                    aname.Value = pair.Key;
                    avalue.Value = pair.Value;
                    n.Attributes.Append(aname);
                    n.Attributes.Append(avalue);
                    rootn.AppendChild(n);
                }
                xml.Save(_i18nFilePathName);
            }
        }
    }
}

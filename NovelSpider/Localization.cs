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
        static readonly string _rootName = "stringTable";
        static readonly string _fontAtr = "font";
        static readonly string _timeAtr = "time";
        static readonly string _subName = "string";
        static readonly string _subAtr0 = "name";
        static readonly string _subAtr1 = "value";

        static string _strError = string.Empty;
        static bool _bNeedRefreshI18N = false;
        static bool _bNoUseI18N = false;

        static readonly string _defFont = "宋体";
        static string _font = _defFont;
        public static string Font
        {
            get
            {
                return _font;
            }
            set
            {
                _bNeedRefreshI18N = true;
                _font = value ?? _defFont;
            }
        }

        static Localization()
        {
            _bNoUseI18N = File.Exists(_noUseI18N);
            try {
                string strXml = File.ReadAllText(_i18nFilePathName);
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(strXml);
                foreach(XmlNode rootn in xml.ChildNodes) {
                    if (rootn.Name == _rootName) {
                        XmlAttribute aFont = rootn.Attributes[_fontAtr];
                        _font = aFont != null ? aFont.Value : _defFont;
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
                _bNeedRefreshI18N = true;
                _idxStr++;
                string str = _idxStr.ToString();
                _strTable[key] = str;
                return _bNoUseI18N ? key : str;
            }
        }
        public static void Refresh()
        {
            if (_bNeedRefreshI18N) {
                File.Delete(_i18nFilePathName);
                XmlDocument xml = new XmlDocument();
                XmlNode descn = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
                xml.AppendChild(descn);

                XmlNode rootn = xml.CreateElement(_rootName);
                XmlAttribute font = xml.CreateAttribute(_fontAtr); font.Value = _font; rootn.Attributes.Append(font);
                XmlAttribute time = xml.CreateAttribute(_timeAtr); time.Value = System.DateTime.Now.ToString(); rootn.Attributes.Append(time);
                xml.AppendChild(rootn);
                foreach (KeyValuePair<string, string> pair in _strTable) {
                    XmlNode n = xml.CreateElement(_subName);
                    XmlAttribute aname = xml.CreateAttribute(_subAtr0);
                    XmlAttribute avalue = xml.CreateAttribute(_subAtr1);
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

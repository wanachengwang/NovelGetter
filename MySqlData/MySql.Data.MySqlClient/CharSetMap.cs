using MySql.Data.Common;
using System;
using System.Collections;
using System.Text;

namespace MySql.Data.MySqlClient
{
	internal class CharSetMap
	{
		private static Hashtable mapping;

		static CharSetMap()
		{
			CharSetMap.InitializeMapping();
		}

		public static CharacterSet GetChararcterSet(DBVersion version, string CharSetName)
		{
			CharacterSet characterSet = (CharacterSet)CharSetMap.mapping[CharSetName];
			if (characterSet == null)
			{
				throw new MySqlException("Character set '" + CharSetName + "' is not supported");
			}
			return characterSet;
		}

		public static Encoding GetEncoding(DBVersion version, string CharSetName)
		{
			Encoding encoding;
			try
			{
				CharacterSet chararcterSet = CharSetMap.GetChararcterSet(version, CharSetName);
				encoding = Encoding.GetEncoding(chararcterSet.name);
			}
			catch (NotSupportedException)
			{
				encoding = Encoding.GetEncoding(0);
			}
			return encoding;
		}

		private static void InitializeMapping()
		{
			CharSetMap.LoadCharsetMap();
		}

		private static void LoadCharsetMap()
		{
			CharSetMap.mapping = new Hashtable();
			CharSetMap.mapping.Add("latin1", new CharacterSet("latin1", 1));
			CharSetMap.mapping.Add("big5", new CharacterSet("big5", 2));
			CharSetMap.mapping.Add("dec8", CharSetMap.mapping["latin1"]);
			CharSetMap.mapping.Add("cp850", new CharacterSet("ibm850", 1));
			CharSetMap.mapping.Add("hp8", CharSetMap.mapping["latin1"]);
			CharSetMap.mapping.Add("koi8r", new CharacterSet("koi8-u", 1));
			CharSetMap.mapping.Add("latin2", new CharacterSet("latin2", 1));
			CharSetMap.mapping.Add("swe7", CharSetMap.mapping["latin1"]);
			CharSetMap.mapping.Add("ujis", new CharacterSet("EUC-JP", 3));
			CharSetMap.mapping.Add("eucjpms", CharSetMap.mapping["ujis"]);
			CharSetMap.mapping.Add("sjis", new CharacterSet("sjis", 2));
			CharSetMap.mapping.Add("cp932", CharSetMap.mapping["sjis"]);
			CharSetMap.mapping.Add("hebrew", new CharacterSet("hebrew", 1));
			CharSetMap.mapping.Add("tis620", new CharacterSet("windows-874", 1));
			CharSetMap.mapping.Add("euckr", new CharacterSet("euc-kr", 2));
			CharSetMap.mapping.Add("euc_kr", CharSetMap.mapping["euckr"]);
			CharSetMap.mapping.Add("koi8u", new CharacterSet("koi8-u", 1));
			CharSetMap.mapping.Add("koi8_ru", CharSetMap.mapping["koi8u"]);
			CharSetMap.mapping.Add("gb2312", new CharacterSet("gb2312", 2));
			CharSetMap.mapping.Add("gbk", CharSetMap.mapping["gb2312"]);
			CharSetMap.mapping.Add("greek", new CharacterSet("greek", 1));
			CharSetMap.mapping.Add("cp1250", new CharacterSet("windows-1250", 1));
			CharSetMap.mapping.Add("win1250", CharSetMap.mapping["cp1250"]);
			CharSetMap.mapping.Add("latin5", new CharacterSet("latin5", 1));
			CharSetMap.mapping.Add("armscii8", CharSetMap.mapping["latin1"]);
			CharSetMap.mapping.Add("utf8", new CharacterSet("utf-8", 3));
			CharSetMap.mapping.Add("ucs2", new CharacterSet("UTF-16BE", 2));
			CharSetMap.mapping.Add("cp866", new CharacterSet("cp866", 1));
			CharSetMap.mapping.Add("keybcs2", CharSetMap.mapping["latin1"]);
			CharSetMap.mapping.Add("macce", new CharacterSet("x-mac-ce", 1));
			CharSetMap.mapping.Add("macroman", new CharacterSet("x-mac-romanian", 1));
			CharSetMap.mapping.Add("cp852", new CharacterSet("ibm852", 2));
			CharSetMap.mapping.Add("latin7", new CharacterSet("iso-8859-7", 1));
			CharSetMap.mapping.Add("cp1251", new CharacterSet("windows-1251", 1));
			CharSetMap.mapping.Add("win1251ukr", CharSetMap.mapping["cp1251"]);
			CharSetMap.mapping.Add("cp1251csas", CharSetMap.mapping["cp1251"]);
			CharSetMap.mapping.Add("cp1251cias", CharSetMap.mapping["cp1251"]);
			CharSetMap.mapping.Add("win1251", CharSetMap.mapping["cp1251"]);
			CharSetMap.mapping.Add("cp1256", new CharacterSet("cp1256", 1));
			CharSetMap.mapping.Add("cp1257", new CharacterSet("windows-1257", 1));
			CharSetMap.mapping.Add("ascii", new CharacterSet("us-ascii", 1));
			CharSetMap.mapping.Add("usa7", CharSetMap.mapping["ascii"]);
			CharSetMap.mapping.Add("binary", CharSetMap.mapping["ascii"]);
			CharSetMap.mapping.Add("latin3", new CharacterSet("latin3", 1));
			CharSetMap.mapping.Add("latin4", new CharacterSet("latin4", 1));
			CharSetMap.mapping.Add("latin1_de", new CharacterSet("iso-8859-1", 1));
			CharSetMap.mapping.Add("german1", new CharacterSet("iso-8859-1", 1));
			CharSetMap.mapping.Add("danish", new CharacterSet("iso-8859-1", 1));
			CharSetMap.mapping.Add("czech", new CharacterSet("iso-8859-2", 1));
			CharSetMap.mapping.Add("hungarian", new CharacterSet("iso-8859-2", 1));
			CharSetMap.mapping.Add("croat", new CharacterSet("iso-8859-2", 1));
			CharSetMap.mapping.Add("latvian", new CharacterSet("iso-8859-13", 1));
			CharSetMap.mapping.Add("latvian1", new CharacterSet("iso-8859-13", 1));
			CharSetMap.mapping.Add("estonia", new CharacterSet("iso-8859-13", 1));
			CharSetMap.mapping.Add("dos", new CharacterSet("ibm437", 1));
		}
	}
}

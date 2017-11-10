using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MySql.Data.MySqlClient
{
	internal class Crypt
	{
		private Crypt()
		{
		}

		private static void XorScramble(byte[] from, int fromIndex, byte[] to, int toIndex, byte[] password, int length)
		{
			if (fromIndex < 0 || fromIndex >= from.Length)
			{
				throw new ArgumentException(Resources.IndexMustBeValid, "fromIndex");
			}
			if (fromIndex + length > from.Length)
			{
				throw new ArgumentException(Resources.FromAndLengthTooBig, "fromIndex");
			}
			if (from == null)
			{
				throw new ArgumentException(Resources.BufferCannotBeNull, "from");
			}
			if (to == null)
			{
				throw new ArgumentException(Resources.BufferCannotBeNull, "to");
			}
			if (toIndex < 0 || toIndex >= to.Length)
			{
				throw new ArgumentException(Resources.IndexMustBeValid, "toIndex");
			}
			if (toIndex + length > to.Length)
			{
				throw new ArgumentException(Resources.IndexAndLengthTooBig, "toIndex");
			}
			if (password == null || password.Length < length)
			{
				throw new ArgumentException(Resources.PasswordMustHaveLegalChars, "password");
			}
			if (length < 0)
			{
				throw new ArgumentException(Resources.ParameterCannotBeNegative, "count");
			}
			for (int i = 0; i < length; i++)
			{
				to[toIndex++] = (byte)(from[fromIndex++] ^ password[i]);
			}
		}

		public static byte[] Get410Password(string password, byte[] seedBytes)
		{
			SHA1 sHA = new SHA1CryptoServiceProvider();
			password = password.Replace(" ", "").Replace("\t", "");
			byte[] bytes = Encoding.Default.GetBytes(password);
			byte[] array = sHA.ComputeHash(bytes);
			CryptoStream cryptoStream = new CryptoStream(Stream.Null, sHA, (CryptoStreamMode)1);
			cryptoStream.Write(seedBytes, 0, 4);
			cryptoStream.Write(array, 0, 20);
			cryptoStream.Close();
			byte[] hash = sHA.Hash;
			byte[] array2 = new byte[20];
			Crypt.XorScramble(seedBytes, 4, array2, 0, hash, 20);
			byte[] array3 = new byte[20];
			Crypt.XorScramble(array2, 0, array3, 0, array, 20);
			return array3;
		}

		public static byte[] GetOld410Password(string password, byte[] seedBytes)
		{
			long[] array = Crypt.Hash(password);
			string password2 = string.Format(CultureInfo.InvariantCulture, "{0,8:X}{1,8:X}", new object[]
			{
				array[0],
				array[1]
			});
			int[] saltFromPassword = Crypt.getSaltFromPassword(password2);
			byte[] array2 = new byte[20];
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				int num2 = saltFromPassword[i];
				for (int j = 3; j >= 0; j--)
				{
					array2[j + num] = (byte)(num2 % 256);
					num2 >>= 8;
				}
				num += 4;
			}
			SHA1 sHA = new SHA1CryptoServiceProvider();
			byte[] password3 = sHA.ComputeHash(array2, 0, 8);
			byte[] array3 = new byte[20];
			Crypt.XorScramble(seedBytes, 4, array3, 0, password3, 20);
			string text = Encoding.Default.GetString(array3).Substring(0, 8);
			long[] array4 = Crypt.Hash(password);
			long[] array5 = Crypt.Hash(text);
			long max = 1073741823L;
			byte[] array6 = new byte[20];
			int num3 = 0;
			int length = text.Length;
			int num4 = 0;
			long num5 = (array4[0] ^ array5[0]) % 1073741823L;
			long num6 = (array4[1] ^ array5[1]) % 1073741823L;
			while (num3++ < length)
			{
				array6[num4++] = (byte)(Math.Floor(Crypt.rand(ref num5, ref num6, max) * 31.0) + 64.0);
			}
			byte b = (byte)Math.Floor(Crypt.rand(ref num5, ref num6, max) * 31.0);
			for (int k = 0; k < 8; k++)
			{
				byte[] array7;
				IntPtr intPtr;
				(array7 = array6)[(int)(intPtr = (IntPtr)k)] = (byte)(array7[(int)intPtr] ^ b);
			}
			return array6;
		}

		public static byte[] Get411Password(string password, string seed)
		{
			if (password.Length == 0)
			{
				return new byte[1];
			}
			SHA1 sHA = new SHA1CryptoServiceProvider();
			byte[] array = sHA.ComputeHash(Encoding.Default.GetBytes(password));
			byte[] array2 = sHA.ComputeHash(array);
			byte[] bytes = Encoding.Default.GetBytes(seed);
			CryptoStream cryptoStream = new CryptoStream(Stream.Null, sHA, (CryptoStreamMode)1);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.Write(array2, 0, array2.Length);
			cryptoStream.Close();
			byte[] array3 = new byte[sHA.Hash.Length + 1];
			array3[0] = 20;
			sHA.Hash.CopyTo(array3, 1);
			for (int i = 1; i < array3.Length; i++)
			{
				array3[i] ^= array[i - 1];
			}
			return array3;
		}

		private static int[] getSaltFromPassword(string password)
		{
			int[] array = new int[6];
			if (password != null && password.Length != 0)
			{
				int num = 0;
				int i = 0;
				while (i < password.Length)
				{
					int num2 = 0;
					for (int j = 0; j < 8; j++)
					{
						num2 = (num2 << 4) + Crypt.HexValue(password[i++]);
					}
					array[num++] = num2;
				}
				return array;
			}
			return array;
		}

		private static int HexValue(char c)
		{
			if (c >= 'A' && c <= 'Z')
			{
				return (int)(c - 'A' + '\n');
			}
			if (c >= 'a' && c <= 'z')
			{
				return (int)(c - 'a' + '\n');
			}
			return (int)(c - '0');
		}

		private static double rand(ref long seed1, ref long seed2, long max)
		{
			seed1 = seed1 * 3L + seed2;
			seed1 %= max;
			seed2 = (seed1 + seed2 + 33L) % max;
			return (double)seed1 / (double)max;
		}

		public static string EncryptPassword(string password, string seed, bool new_ver)
		{
			long num = 1073741823L;
			if (!new_ver)
			{
				num = 33554431L;
			}
			if (password != null && password.Length != 0)
			{
				long[] array = Crypt.Hash(seed);
				long[] array2 = Crypt.Hash(password);
				long num2 = (array[0] ^ array2[0]) % num;
				long num3 = (array[1] ^ array2[1]) % num;
				if (!new_ver)
				{
					num3 = num2 / 2L;
				}
				char[] array3 = new char[seed.Length];
				for (int i = 0; i < seed.Length; i++)
				{
					double num4 = Crypt.rand(ref num2, ref num3, num);
					array3[i] = (char)(Math.Floor(num4 * 31.0) + 64.0);
				}
				if (new_ver)
				{
					char c = (char)Math.Floor(Crypt.rand(ref num2, ref num3, num) * 31.0);
					for (int j = 0; j < array3.Length; j++)
					{
						char[] array4;
						IntPtr intPtr;
						(array4 = array3)[(int)(intPtr = (IntPtr)j)] = (char)(array4[(int)intPtr] ^ c);
					}
				}
				return new string(array3);
			}
			return password;
		}

		private static long[] Hash(string P)
		{
			long num = 1345345333L;
			long num2 = 305419889L;
			long num3 = 7L;
			for (int i = 0; i < P.Length; i++)
			{
				if (P[i] != ' ' && P[i] != '\t')
				{
					long num4 = (long)('ÿ' & P[i]);
					num ^= ((num & 63L) + num3) * num4 + (num << 8);
					num2 += (num2 << 8 ^ num);
					num3 += num4;
				}
			}
			return new long[]
			{
				num & 2147483647L,
				num2 & 2147483647L
			};
		}
	}
}

using System;

namespace zlib
{
	internal sealed class Inflate
	{
		private const int MAX_WBITS = 15;

		private const int PRESET_DICT = 32;

		internal const int Z_NO_FLUSH = 0;

		internal const int Z_PARTIAL_FLUSH = 1;

		internal const int Z_SYNC_FLUSH = 2;

		internal const int Z_FULL_FLUSH = 3;

		internal const int Z_FINISH = 4;

		private const int Z_DEFLATED = 8;

		private const int Z_OK = 0;

		private const int Z_STREAM_END = 1;

		private const int Z_NEED_DICT = 2;

		private const int Z_ERRNO = -1;

		private const int Z_STREAM_ERROR = -2;

		private const int Z_DATA_ERROR = -3;

		private const int Z_MEM_ERROR = -4;

		private const int Z_BUF_ERROR = -5;

		private const int Z_VERSION_ERROR = -6;

		private const int METHOD = 0;

		private const int FLAG = 1;

		private const int DICT4 = 2;

		private const int DICT3 = 3;

		private const int DICT2 = 4;

		private const int DICT1 = 5;

		private const int DICT0 = 6;

		private const int BLOCKS = 7;

		private const int CHECK4 = 8;

		private const int CHECK3 = 9;

		private const int CHECK2 = 10;

		private const int CHECK1 = 11;

		private const int DONE = 12;

		private const int BAD = 13;

		internal int mode;

		internal int method;

		internal long[] was = new long[1];

		internal long need;

		internal int marker;

		internal int nowrap;

		internal int wbits;

		internal InfBlocks blocks;

		private static byte[] mark = new byte[]
		{
			default(byte),
			default(byte),
			(byte)SupportClass.Identity(255L),
			(byte)SupportClass.Identity(255L)
		};

		internal int inflateReset(ZStream z)
		{
			if (z != null && z.istate != null)
			{
				z.total_out = 0L;
				z.total_in = 0L;
				z.msg = null;
				z.istate.mode = ((z.istate.nowrap != 0) ? 7 : 0);
				z.istate.blocks.reset(z, null);
				return 0;
			}
			return -2;
		}

		internal int inflateEnd(ZStream z)
		{
			if (this.blocks != null)
			{
				this.blocks.free(z);
			}
			this.blocks = null;
			return 0;
		}

		internal int inflateInit(ZStream z, int w)
		{
			z.msg = null;
			this.blocks = null;
			this.nowrap = 0;
			if (w < 0)
			{
				w = -w;
				this.nowrap = 1;
			}
			if (w >= 8 && w <= 15)
			{
				this.wbits = w;
				z.istate.blocks = new InfBlocks(z, (z.istate.nowrap != 0) ? null : this, 1 << w);
				this.inflateReset(z);
				return 0;
			}
			this.inflateEnd(z);
			return -2;
		}

		internal int inflate(ZStream z, int f)
		{
			if (z != null && z.istate != null && z.next_in != null)
			{
				f = ((f == 4) ? -5 : 0);
				int num = -5;
				while (true)
				{
					switch (z.istate.mode)
					{
					case 0:
						if (z.avail_in == 0)
						{
							return num;
						}
						num = f;
						z.avail_in--;
						z.total_in += 1L;
						if (((z.istate.method = (int)z.next_in[z.next_in_index++]) & 15) != 8)
						{
							z.istate.mode = 13;
							z.msg = "unknown compression method";
							z.istate.marker = 5;
							continue;
						}
						if ((z.istate.method >> 4) + 8 > z.istate.wbits)
						{
							z.istate.mode = 13;
							z.msg = "invalid window size";
							z.istate.marker = 5;
							continue;
						}
						z.istate.mode = 1;
						goto IL_2E6;
					case 1:
						goto IL_2E6;
					case 2:
						goto IL_4C0;
					case 3:
						goto IL_52F;
					case 4:
						goto IL_5A9;
					case 5:
						goto IL_622;
					case 6:
						goto IL_6A6;
					case 7:
						num = z.istate.blocks.proc(z, num);
						if (num == -3)
						{
							z.istate.mode = 13;
							z.istate.marker = 0;
							continue;
						}
						if (num == 0)
						{
							num = f;
						}
						if (num != 1)
						{
							return num;
						}
						num = f;
						z.istate.blocks.reset(z, z.istate.was);
						if (z.istate.nowrap != 0)
						{
							z.istate.mode = 12;
							continue;
						}
						z.istate.mode = 8;
						goto IL_1DE;
					case 8:
						goto IL_1DE;
					case 9:
						goto IL_15D;
					case 10:
						goto IL_DD;
					case 11:
						goto IL_2F;
					case 12:
						return 1;
					case 13:
						return -3;
					}
					return -2;
					IL_2F:
					if (z.avail_in == 0)
					{
						return num;
					}
					num = f;
					z.avail_in--;
					z.total_in += 1L;
					z.istate.need += (long)((ulong)z.next_in[z.next_in_index++] & 255uL);
					if ((int)z.istate.was[0] != (int)z.istate.need)
					{
						z.istate.mode = 13;
						z.msg = "incorrect data check";
						z.istate.marker = 5;
						continue;
					}
					goto IL_6D7;
					IL_DD:
					if (z.avail_in != 0)
					{
						num = f;
						z.avail_in--;
						z.total_in += 1L;
						z.istate.need += ((long)((long)(z.next_in[z.next_in_index++] & 255) << 8) & 65280L);
						z.istate.mode = 11;
						goto IL_2F;
					}
					return num;
					IL_15D:
					if (z.avail_in != 0)
					{
						num = f;
						z.avail_in--;
						z.total_in += 1L;
						z.istate.need += ((long)((long)(z.next_in[z.next_in_index++] & 255) << 16) & 16711680L);
						z.istate.mode = 10;
						goto IL_DD;
					}
					return num;
					IL_1DE:
					if (z.avail_in != 0)
					{
						num = f;
						z.avail_in--;
						z.total_in += 1L;
						z.istate.need = (long)((int)(z.next_in[z.next_in_index++] & 255) << 24 & -16777216);
						z.istate.mode = 9;
						goto IL_15D;
					}
					return num;
					IL_2E6:
					if (z.avail_in == 0)
					{
						return num;
					}
					num = f;
					z.avail_in--;
					z.total_in += 1L;
					int num2 = (int)(z.next_in[z.next_in_index++] & 255);
					if (((z.istate.method << 8) + num2) % 31 != 0)
					{
						z.istate.mode = 13;
						z.msg = "incorrect header check";
						z.istate.marker = 5;
					}
					else
					{
						if ((num2 & 32) != 0)
						{
							goto IL_4B4;
						}
						z.istate.mode = 7;
					}
				}
				return num;
				IL_4B4:
				z.istate.mode = 2;
				IL_4C0:
				if (z.avail_in == 0)
				{
					return num;
				}
				num = f;
				z.avail_in--;
				z.total_in += 1L;
				z.istate.need = (long)((int)(z.next_in[z.next_in_index++] & 255) << 24 & -16777216);
				z.istate.mode = 3;
				IL_52F:
				if (z.avail_in == 0)
				{
					return num;
				}
				num = f;
				z.avail_in--;
				z.total_in += 1L;
				z.istate.need += ((long)((long)(z.next_in[z.next_in_index++] & 255) << 16) & 16711680L);
				z.istate.mode = 4;
				IL_5A9:
				if (z.avail_in == 0)
				{
					return num;
				}
				num = f;
				z.avail_in--;
				z.total_in += 1L;
				z.istate.need += ((long)((long)(z.next_in[z.next_in_index++] & 255) << 8) & 65280L);
				z.istate.mode = 5;
				IL_622:
				if (z.avail_in == 0)
				{
					return num;
				}
				z.avail_in--;
				z.total_in += 1L;
				z.istate.need += (long)((ulong)z.next_in[z.next_in_index++] & 255uL);
				z.adler = z.istate.need;
				z.istate.mode = 6;
				return 2;
				IL_6A6:
				z.istate.mode = 13;
				z.msg = "need dictionary";
				z.istate.marker = 0;
				return -2;
				IL_6D7:
				z.istate.mode = 12;
				return 1;
			}
			return -2;
		}

		internal int inflateSetDictionary(ZStream z, byte[] dictionary, int dictLength)
		{
			int start = 0;
			int num = dictLength;
			if (z != null && z.istate != null)
			{
				if (z.istate.mode == 6)
				{
					if (z._adler.adler32(1L, dictionary, 0, dictLength) != z.adler)
					{
						return -3;
					}
					z.adler = z._adler.adler32(0L, null, 0, 0);
					if (num >= 1 << z.istate.wbits)
					{
						num = (1 << z.istate.wbits) - 1;
						start = dictLength - num;
					}
					z.istate.blocks.set_dictionary(dictionary, start, num);
					z.istate.mode = 7;
					return 0;
				}
			}
			return -2;
		}

		internal int inflateSync(ZStream z)
		{
			if (z == null || z.istate == null)
			{
				return -2;
			}
			if (z.istate.mode != 13)
			{
				z.istate.mode = 13;
				z.istate.marker = 0;
			}
			int num;
			if ((num = z.avail_in) == 0)
			{
				return -5;
			}
			int num2 = z.next_in_index;
			int num3 = z.istate.marker;
			while (num != 0 && num3 < 4)
			{
				if (z.next_in[num2] == Inflate.mark[num3])
				{
					num3++;
				}
				else if (z.next_in[num2] != 0)
				{
					num3 = 0;
				}
				else
				{
					num3 = 4 - num3;
				}
				num2++;
				num--;
			}
			z.total_in += (long)(num2 - z.next_in_index);
			z.next_in_index = num2;
			z.avail_in = num;
			z.istate.marker = num3;
			if (num3 != 4)
			{
				return -3;
			}
			long total_in = z.total_in;
			long total_out = z.total_out;
			this.inflateReset(z);
			z.total_in = total_in;
			z.total_out = total_out;
			z.istate.mode = 7;
			return 0;
		}

		internal int inflateSyncPoint(ZStream z)
		{
			if (z != null && z.istate != null && z.istate.blocks != null)
			{
				return z.istate.blocks.sync_point();
			}
			return -2;
		}
	}
}

﻿using Acmil.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acmil.Core.Reader.FileTypes
{
	public class WDB : DBHeader
	{
		public new string Locale { get; set; }
		public int RecordVersion { get; set; }
		public int CacheVersion { get; set; }
		public int Build { get; set; }
		public override bool CheckRecordCount => false;

		public override void ReadHeader(ref BinaryReader dbReader, string signature)
		{
			Signature = signature;
			Build = dbReader.ReadInt32();

			if (Build >= 4500) // 1.6.0
			{
				Locale = dbReader.ReadString(4).Reverse();
			}

			RecordSize = dbReader.ReadUInt32();
			RecordVersion = dbReader.ReadInt32();

			if (Build >= 9506) // 3.0.8
			{
				CacheVersion = dbReader.ReadInt32();
			}
		}

		public byte[] ReadData(BinaryReader dbReader)
		{
			var data = new List<byte>();

			//Stored as Index, Size then Data
			while (dbReader.BaseStream.Position != dbReader.BaseStream.Length)
			{
				int index = dbReader.ReadInt32();
				if (index == 0 && dbReader.BaseStream.Position == dbReader.BaseStream.Length)
				{
					break;
				}

				int size = dbReader.ReadInt32();
				if (index == 0 && size == 0 && dbReader.BaseStream.Position == dbReader.BaseStream.Length)
				{
					break;
				}

				data.AddRange(BitConverter.GetBytes(index));
				data.AddRange(dbReader.ReadBytes(size));

				RecordCount++;
			}

			return data.ToArray();
		}
	}
}

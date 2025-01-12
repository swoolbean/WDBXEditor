﻿using Acmil.Data.Contracts.Attributes;
using Acmil.Data.Contracts.Models.Items.Enums;

namespace Acmil.Data.Contracts.Models.Items
{
	/// <summary>
	/// Base class for equipable item templates.
	/// </summary>
	public abstract class BaseEquipableItemTemplate : BaseItemTemplate
	{
		/// <summary>
		/// An <see cref="ItemInventoryType"/> value that specifies the slot(s) the item can be equipped in.
		/// </summary>
		[MySqlColumnName("InventoryType")]
		[EnumType(typeof(ItemInventorySlot))]
		[AllowEnumConversionOverride(false)]
		public byte InventoryType { get; set; } = 0;
	}
}

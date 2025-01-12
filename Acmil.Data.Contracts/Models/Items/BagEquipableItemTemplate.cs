﻿
using Acmil.Data.Contracts.Attributes;

namespace Acmil.Data.Contracts.Models.Items
{
	/// <summary>
	/// Item template for a bag-type item.
	/// </summary>
	public class BagEquipableItemTemplate : BaseEquipableItemTemplate
	{
		/// <summary>
		/// The number of item slots in the container.
		/// </summary>
		[MySqlColumnName("ContainerSlots")]
		public byte ContainerSlots { get; set; } = 0;
	}
}

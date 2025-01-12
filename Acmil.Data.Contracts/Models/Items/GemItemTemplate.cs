﻿using Acmil.Data.Contracts.Attributes;
using Acmil.Data.Contracts.Types.Primitives;

namespace Acmil.Data.Contracts.Models.Items
{
	/// <summary>
	/// Item template for Gem-type items.
	/// </summary>
	public class GemItemTemplate : BaseItemTemplate
	{
		/// <summary>
		/// An ID from GemProperties.dbc indicating the effect the gem provides
		/// when placed in a socket.
		/// </summary>
		[MySqlColumnName("GemProperties")]
		public Int24 GemProperties { get; set; } = 0;
	}
}

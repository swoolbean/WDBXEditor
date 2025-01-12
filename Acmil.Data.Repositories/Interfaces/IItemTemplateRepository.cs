﻿using Acmil.Data.Contracts.Models.Items;
using Acmil.Data.Contracts.Types.Primitives;

namespace Acmil.Data.Repositories.Interfaces
{
	/// <summary>
	/// Interface describing a repository class for interacting with Item Templates.
	/// </summary>
	public interface IItemTemplateRepository
	{
		/// <summary>
		/// Reads an Item Template from the database.
		/// </summary>
		/// <param name="entryId">The entry ID of the Item Template.</param>
		/// <returns>An object representing the Item Template.</returns>
		public CompleteItemTemplate ReadItemTemplate(UInt24 entryId);
	}
}

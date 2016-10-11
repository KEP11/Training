#region Header
// 
// Created by: Yevgeniy Kolesnikov
// Created: 2016.10.06
// Copyright © Epam Systems 2016
#endregion

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using TrainingDataServices.Repositories;

namespace TrainingProjectModels.AuthModels
{
	public class UserPermission : IModelIdentity
	{
		public long Id { get; set; }

		[ForeignKey(nameof(Permission_refPermission))]
		public long RefPermission { get; set; }

		[ForeignKey(nameof(User_refUser))]
		public long RefUser { get; set; }

		public virtual Permission Permission_refPermission { get; set; }

		public virtual User User_refUser { get; set; }
	}
}
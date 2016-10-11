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
	public class GroupPermission : IModelIdentity
	{
		public long Id { get; set; }

		[ForeignKey(nameof(Group_refGroup))]
		public long RefGroup { get; set; }

		[ForeignKey(nameof(Permission_refPermission))]
		public long RefPermission { get; set; }

		public virtual Permission Permission_refPermission { get; set; }

		public virtual Group Group_refGroup { get; set; }

	}
}
#region Header
// 
// Created by: Yevgeniy Kolesnikov
// Created: 2016.10.06
// Copyright © Epam Systems 2016
#endregion

using System.ComponentModel.DataAnnotations.Schema;

using TrainingDataServices.Repositories;

namespace TrainingProjectModels.AuthModels
{
	public class UserGroup : IModelIdentity
	{
		public long Id { get; set; }

		[ForeignKey(nameof(Group_refGroup))]
		public long RefGroup { get; set; }

		[ForeignKey(nameof(User_refUser))]
		public long RefUser { get; set; }

		public virtual Group Group_refGroup { get; set; }

		public virtual User User_refUser { get; set; }
	}
}
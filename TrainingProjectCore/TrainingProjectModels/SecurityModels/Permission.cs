#region Header
// 
// Created by: Yevgeniy Kolesnikov
// Created: 2016.10.06
// Copyright © Epam Systems 2016
#endregion

using System.Collections.Generic;

using TrainingDataServices.Repositories;

namespace TrainingProjectModels.AuthModels
{
	public class Permission : IModelIdentity
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public virtual ICollection<GroupPermission> GroupPermission { get; set; }

		public virtual ICollection<UserPermission> UserPermission { get; set; }


	}
}
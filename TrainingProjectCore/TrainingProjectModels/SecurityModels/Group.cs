#region Header
// 
// Created by: Yevgeniy Kolesnikov
// Created: 2016.10.06
// Copyright © Epam Systems 2016
#endregion

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainingProjectModels.AuthModels
{
	public class Group
	{
		public long Id { get; set; }

		public string Name { get; set; }

		//public virtual ICollection<User> Users { get; set; }

		//public virtual ICollection<Permission> Permissions { get; set; }
		

	}
}
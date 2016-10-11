#region Header
// 
// Created by: Yevgeniy Kolesnikov
// Created: 2016.10.06
// Copyright © Epam Systems 2016
#endregion

using System.Data.Entity;

using TrainingProjectModels.EF;

namespace TrainingProjectModels.AuthModels
{
	public class SecurityModel : DbContext
	{
		public SecurityModel()
			: base(SingleDbConnection.Get(nameof(SecurityModel)))
		{
			Configuration.ProxyCreationEnabled = false;
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<UserGroup> UserGroups { get; set; }
		public DbSet<UserPermission> UserPermissions { get; set; }
		public DbSet<GroupPermission> GroupPermissions { get; set; }
	}
}
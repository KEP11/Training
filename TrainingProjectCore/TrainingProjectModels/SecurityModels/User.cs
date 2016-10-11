#region Header
// 
// Created by: Yevgeniy Kolesnikov
// Created: 2016.10.06
// Copyright © Epam Systems 2016
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

using TrainingDataServices.Repositories;

using TrainingProjectModels.Repositories;

namespace TrainingProjectModels.AuthModels
{
	public class User : IModelIdentity
	{
		public string _password;
		
		public long Id { get; set; }

		[Display(Name = "Имя пользователя")]
		[Required]
		[MaxLength(250)]
		public string UserName { get; set; }

		[Display(Name = "Логин")]
		[Required]
		[MaxLength(250)]
		public string Login { get; set; }

		[Display(Name = "Пароль")]
		[Required]
		[MaxLength(250)]
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = UserRepository.GetMd5Hash(value);
			}
		}

		[Display(Name = "Дата создания")]
		public DateTime? CreatedDate { get; set; }

		[Display(Name = "Пользователь онлайн")]
		public bool IsOnline { get; set; }

		[DefaultValue(false)]
		[Display(Name = "Заблокирован")]
		public bool? IsLocked { get; set; }

		public virtual ICollection<UserGroup> UserGroup_refUser { get; set; }

		public virtual ICollection<UserPermission> UserPermission_refUser { get; set; }

	}
}
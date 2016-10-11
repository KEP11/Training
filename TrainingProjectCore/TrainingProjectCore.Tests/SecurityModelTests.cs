using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using Moq.Language.Flow;

using TrainingDataServices.Repositories;

using TrainingProjectModels;
using TrainingProjectModels.AuthModels;
using TrainingProjectModels.Repositories;

namespace TrainingProjectCore.Tests
{
	[TestClass]
	public class SecurityModelTests
	{
		[TestMethod]
		public void CreateDbTest()
		{
			var context = new SecurityModel();
			var isCreated = context.Database.CreateIfNotExists();
			if (!isCreated) isCreated = context.Database.Exists();

			Assert.IsTrue(isCreated);
		}

		[TestMethod]
		public void CreateUserTest()
		{
			var context = new SecurityModel();
			context.Database.CreateIfNotExists();


			User user = new User
							{
								UserName = "Test",
								Password = "Test",
								Login = "Test",
								CreatedDate = DateTime.Now,
								IsLocked = false,
								IsOnline = false
							};

			user.Create();

			var password = context.Users.Where(u => u.UserName == "Test").Select(u => u.Password).FirstOrDefault();

			Assert.AreEqual(UserRepository.GetMd5Hash("Test"), password);

		}

		[TestMethod]
		public void UpdateUserTest()
		{
			var context = new SecurityModel();
			context.Database.CreateIfNotExists();

			var repo = new CommonRepository<User, SecurityModel>(); // new Mock<IRepository<User>>();


			User user = new User
							{
								UserName = "Test1",
								Password = "Test1",
								Login = "Test1",
								CreatedDate = DateTime.Now,
								IsLocked = false,
								IsOnline = false
							};
			repo.Update(user);
			//repo.Setup(r => r.Update(user));

			//user.Create();

			var login = context.Users.Where(u => u.UserName == "Test").Select(u => u.Login).FirstOrDefault();

			Assert.AreEqual(user.Login, login);

		}

		[TestMethod]
		public void DeleteUserTest()
		{
			var context = new SecurityModel();
			context.Database.CreateIfNotExists();

			var repo = new CommonRepository<User, SecurityModel>(); // new Mock<IRepository<User>>();

			var rowId = repo.GetFieldValueByField<long?>(r => r.UserName == "Test", r => r.Id);
			if (rowId != null)
			{
				var res = repo.Remove((long)rowId);
				res.IsTrue();
			}
			else
			{
				Assert.IsNull(rowId, "Record does not exist");
			}
		}

		[TestMethod]
		public void GetUserByAnyFieldValueTest()
		{
			var context = new SecurityModel();
			context.Database.CreateIfNotExists();

			var foundUser = context.GetRowByField<User>(u => u.UserName == "Test");
			Assert.IsNotNull(foundUser, "User not found");

			var foundUser1 = context.GetRowByField<User>(u => u.Login == "Test");
			Assert.IsNotNull(foundUser1, "User not found");

		}

		[TestMethod]
		public void CreateUserPermissionTest()
		{
			var context = new SecurityModel();
			context.Database.CreateIfNotExists();

			Permission permission = new Permission { Name = "MainPage_Read" };

			permission.Create();

			permission.Id.IsNotNull();

			//			var repo = new Mock<IRepository<User>>();
			//
			//			var r11 = repo.Setup(r1 => r1.GetFieldValueByField<long?>(r => r.UserName == "Test", r => r.Id)).Returns(
			//				() => null);

			var repo = new CommonRepository<User, SecurityModel>();

			var userId = repo.GetFieldValueByField<long?>(r => r.UserName == "Test", r => r.Id);
			if (userId != null)
			{
				var userPermission = new UserPermission { RefPermission = permission.Id, RefUser = userId.Value };
				userPermission.Create();
			}

			var userName =
				context.UserPermissions.Where(u => u.Permission_refPermission.Name == "MainPage_Read")
					.Select(u => u.User_refUser.UserName)
					.FirstOrDefault();

			userName.Is("Test");
		}
	}
}

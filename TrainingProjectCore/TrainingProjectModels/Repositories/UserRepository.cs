#region Header
// 
// Created by: Yevgeniy Kolesnikov
// Created: 2016.10.10
// Copyright © Epam Systems 2016
#endregion

using System.Linq;
using System.Security.Cryptography;
using System.Text;

using TrainingDataServices.Repositories;

using TrainingProjectModels.AuthModels;

namespace TrainingProjectModels.Repositories
{
	public class UserRepository : CommonRepository<User, SecurityModel>
	{
//		public override void Create(User row)
//		{
//			row.Password = GetMd5Hash(row.Password);
//			base.Create(row);
//		}

		public static string GetMd5Hash(string value)
		{
			MD5 md5Hasher = MD5.Create();
			byte[] salt = md5Hasher.ComputeHash(Encoding.Default.GetBytes("P@$Sw0Rd_S@LT"));
			byte[] pass = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(value));
			byte[] data = md5Hasher.ComputeHash(salt.Union(pass).ToArray());
			var builder = new StringBuilder();

			foreach (var t in data)
			{
				builder.Append(t.ToString("x2"));
			}

			return builder.ToString();
		}

	}
}
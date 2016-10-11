#region Header
// 
// Created by: Yevgeniy Kolesnikov
// Created: 2016.10.07
// Copyright © Epam Systems 2016
#endregion

using System;
using System.Linq.Expressions;

using TrainingDataServices.Repositories;

using TrainingProjectModels.AuthModels;
using TrainingProjectModels.Repositories;

namespace TrainingProjectModels
{
	public class SecurityRepository<T> : CommonRepository<T, SecurityModel>
		where T : class, IModelIdentity
	{

	}

	public static class SecurityRepositoryExtension
	{
		//		private static CommonRepository<T, TContext> RepositoryInstance = new CommonRepository<T, TContext>();

		public static SecurityRepository<T> Repository<T>(this T modelInstance) where T : class, IModelIdentity
		{
			return new SecurityRepository<T>();
		}


		public static void Create<T>(this T modelInstance) where T : class, IModelIdentity
		{
			var repository = new SecurityRepository<T>();
			repository.Create(modelInstance);

		}

		public static void CreateUser(this User modelInstance)
		{
			var repository = new UserRepository();
			repository.Create(modelInstance);

		}

		public static T GetRowByField<T>(this SecurityModel context, Expression<Func<T, bool>> where ) where T : class, IModelIdentity
		{
			var repository = new CommonRepository<T, SecurityModel>();
			return repository.GetRowByField(where);

		}
	}
}
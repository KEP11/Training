#region Header
// 
// Created by: Yevgeniy Kolesnikov
// Created: 2016.10.07
// Copyright © Epam Systems 2016
#endregion

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TrainingDataServices.Repositories
{
	public interface IRepository<T>
	{
		T GetById(long id);
		void Create(T row);

		bool Update(T row);
		bool Update(long id);

		bool Remove(long id);

		T GetRowByField(Expression<Func<T, bool>> where);
		ICollection<T> GetAll();

		TResult GetFieldValueByField<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

	}
}
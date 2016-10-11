#region Header
// 
// Created by: Yevgeniy Kolesnikov
// Created: 2016.10.07
// Copyright © Epam Systems 2016
#endregion

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using EntityFramework.Extensions;

namespace TrainingDataServices.Repositories
{
	public class CommonRepository<T, TContext> : IRepository<T>
		where TContext : DbContext, new()
		where T : class, IModelIdentity
	{

		private readonly TContext context = new TContext();

		public T GetRowByField(Expression<Func<T, bool>> where)
		{
			var row = this.context.Set<T>().Where(where).FirstOrDefault();
			return row;
		}

		public TResult GetFieldValueByField<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
		{
			var row = this.context.Set<T>().Where(where).Select(select).FirstOrDefault();
			return row;
		}

		public T GetById(long id)
		{
			var row = context.Set<T>().FirstOrDefault(e => e.Id == id);
			return row;

		}

		public virtual void Create(T row)
		{
			context.Set<T>().Add(row);
			context.SaveChanges();
		}

		public bool Update(T row)
		{
			
			var res = this.context.Set<T>().Where(t => t.Id == row.Id).Update(r => r);
			return res != 0;
		}

		public bool Update(long id)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Delete row.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>True, if row was deleted, otherwise false.</returns>
		public bool Remove(long id)
		{
			var res = this.context.Set<T>().Where(t => t.Id == id).Delete();
			return res != 0;
		}

		public ICollection<T> GetAll()
		{
			return this.context.Set<T>().Select(t => t).ToList();
		}
	}
}
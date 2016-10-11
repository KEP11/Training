#region Header
// 
// Created by: Yevgeniy Kolesnikov
// Created: 2016.10.07
// Copyright © Epam Systems 2016
#endregion

using System;
using System.Collections.Generic;

namespace TrainingDataServices.Repositories
{
	public static class ExpressionHelper
	{
		public static void CheckRowExistAndDoAction<T>(this IEnumerable<T> source, Action removeMethod, Action<T> action)
		{
			using (var enumerator = source.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					T element = enumerator.Current;
					removeMethod();
					do
					{
//						T element = enumerator.Current;
						action(element);

					}
					while (enumerator.MoveNext());

				}
			}

		}
	}
}
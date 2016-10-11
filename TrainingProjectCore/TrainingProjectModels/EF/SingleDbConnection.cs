#region Header
// 
// Created by: Yevgeniy Kolesnikov
// Created: 2016.10.06
// Copyright © Epam Systems 2016
#endregion

using System;
using System.Configuration;

namespace TrainingProjectModels.EF
{
	public class SingleDbConnection
	{
		public static string Get(string modelNamespace)
		{
			const string ConnectionName = "DbConnectionString";

			var conString = ConfigurationManager.ConnectionStrings[ConnectionName];
			if (conString == null) throw new InvalidOperationException($"Не найдена строка подключения {ConnectionName}");

//			var str = $"metadata=res://*/{modelNamespace}.csdl|res://*/{modelNamespace}.ssdl|res://*/{modelNamespace}.msl;provider={conString.ProviderName};provider connection string=\"{conString.ConnectionString}\"";

			return conString.ConnectionString;// str;



		}
	}
}
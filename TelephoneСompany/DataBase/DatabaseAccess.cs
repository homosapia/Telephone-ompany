﻿using Dapper;
using Microsoft.Data.Sqlite;

namespace TelephoneСompany.DataBase
{
    public class DatabaseAccess
    {
        private readonly string _connectionString;
        public DatabaseAccess(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public IEnumerable<T> Load<T>(string sql, object parameters = null)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var data = connection.Query<T>(sql, parameters);
                return data;
            }
        }

        public void Save<T>(string sql, T data)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Execute(sql, data);
            }
        }
    }
}

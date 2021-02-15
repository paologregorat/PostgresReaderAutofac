using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using WebAPIPostgresReader.Abstract;

namespace WebAPIPostgresReader.Infracstructure
{
    public class SqlReader : IReader
    {
        private readonly string? _connectionString;

        public SqlReader(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<T>> GetCollectionAsync<T>(string query, object? @params = default)
        {
            await using var connection = new NpgsqlConnection(_connectionString ?? throw new NullReferenceException("ConnectionString cannot be null."));

            await connection.OpenAsync();
            var lines = await connection.QueryAsync<T>(query, @params);

            return lines;
        }

        public async Task<int> CommandAsync(string command, object? @params = default)
        {
            await using var connection = new NpgsqlConnection(_connectionString ??
                                                              throw new NullReferenceException(
                                                                  "ConnectionString cannot be null."));
            await connection.OpenAsync();
            return await connection.ExecuteAsync(command, @params);
        }
    }
}
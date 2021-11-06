using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.Extensions.Configuration;
using Dapper;
namespace backend.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly string _connectionString;

        public DataRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public ManagerSingleResponse GetSingleManager(string username, string password)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.QueryFirstOrDefault<ManagerSingleResponse>(@"EXEC dbo.Manager_GetSingle @username = @manager_username, @password = @manager_password", new { 
                    manager_username = username, manager_password = password
                });
            }
        }

        public PurchasingSingleResponse GetSinglePurchasing(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.QueryFirstOrDefault<PurchasingSingleResponse>(@"EXEC dbo.Search_purchasing @CatCode = @id", new
                {
                    id = id
                });
            }
        }
    }
}

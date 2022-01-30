using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.Models;

using Microsoft.Extensions.Configuration;
using Dapper;
using Npgsql;

namespace DataAccessLayer
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _configuration;
        public CategoryRepository(IConfiguration configuration)
        { 
            _configuration = configuration; 
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Category>("SELECT * FROM Category");
                return result.ToList();
            }
        }

        public async Task<int> AddCategoryAsync(Category entity)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync("Insert into Category (Name, ParentId) VALUES (@Name, @ParentId)", entity);
                return result;
            }
        }

        public async Task<int> UpdateCategoryAsync(Category entity)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync("UPDATE Category SET Name = @Name, ParentId = @ParentId  WHERE Id = @Id", entity);
                return result;
            }
        }
    }
}

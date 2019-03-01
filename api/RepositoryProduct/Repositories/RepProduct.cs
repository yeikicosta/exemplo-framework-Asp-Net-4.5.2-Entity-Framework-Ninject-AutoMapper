using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DomainProduct;
using DomainProduct.Interfaces;

namespace RepositoryProduct.Repositories
{
    public class RepProduct : RepBase<Product>, IRepProduct
    {
        public async Task<IEnumerable<Product>> FindByName(string name)
        {
            var products = new List<Product>();
            var connectionString = ConfigurationManager.ConnectionStrings["dbProductContext"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand("usp_ProductFindByName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@str_Name", name);
                    SqlDataReader sdr = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            products.Add(new Product()
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                Name = sdr["Name"].ToString(),
                                Description = sdr["Description"] != DBNull.Value ? sdr["Description"].ToString() : null,
                                Price = Convert.ToDecimal(sdr["Price"]),
                                Image = sdr["Image"] != DBNull.Value ? sdr["Image"].ToString() : null,
                                IdCategory = Convert.ToInt32(sdr["IdCategory"]),
                                Category = new Category() {
                                    Id = Convert.ToInt32(sdr["IdCategory"]),
                                    Name = sdr["NameCategory"].ToString(),
                                    IdParent = sdr["IdParent"] != DBNull.Value ? (int?)Convert.ToInt32(sdr["IdParent"]) : null
                                },
                                RegisterDate = Convert.ToDateTime(sdr["RegisterDate"])
                            });
                        }
                    }
                }
            }
            return products;
        }
    }
}

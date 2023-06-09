using ADOProductCURD2.Models;
using Microsoft.Data.SqlClient;

namespace ADOProductCURD2.Repository
{
    public class ProductRepo
    {
        string conString = @"Server=RIKESH\SQLEXPRESS;database=mydb; integrated security=SSPI; TrustServerCertificate=true";

        public void AddProduct(Product p)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                string insertQuery = $"INSERT INTO products VALUES({p.Id}, '{p.Name}', {p.price}, '{p.Description}')";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable <Product> GetAllProduct()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection conn = new SqlConnection(conString))
            {
                string insertQuery = "SELECT * from products";

                conn.Open();
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    Product prod = new Product();
                    prod.Id = Convert.ToInt32(rdr["product_id"]);
                    prod.Name = rdr["Product_name"].ToString();
                    prod.price = Convert.ToDouble(rdr["price"]);
                    prod.Description = rdr["Description"].ToString();
                    products.Add( prod );
                }
            }
            return products;
        }
        public Product GetSingleProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                string insertQuery = $" SELECT * FROM products WHERE product_id = {id}";

                conn.Open();
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                Product prod = new Product();
                prod.Id = Convert.ToInt32(rdr["product_id"]);
                prod.Name = rdr["Product_name"].ToString();
                prod.price = Convert.ToDouble(rdr["price"]);
                prod.Description = rdr["description"].ToString();
                return prod;
            }
        }
        // update product...
        public void UpdateProduct(Product p)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                string insertQuery = $"UPDATE products SET product_id={p.Id}," +
                    $"product_name = '{p.Name}',price={p.price},description='{p.Description}'"+
                    $"WHERE product_id = {p.Id}";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(Product p)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                string insertQuery = $"DELETE  FROM products WHERE product_id= {p.Id}";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

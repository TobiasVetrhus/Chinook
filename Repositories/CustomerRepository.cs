using Chinook.Models;
using Microsoft.Data.SqlClient;

namespace Chinook.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool Add(Customer customer)
        {
            bool success = false;

            string sql = "INSERT INTO Customer(FirstName, LastName, Country, PostalCode, Phone, Email)" +
                          " VALUES(@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);

                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return success;
        }

        public IEnumerable<CustomerCountry> CustomerCountry()
        {
            List<CustomerCountry> countryCountList = new List<CustomerCountry>();
            string sql = "SELECT Country, COUNT(CustomerId) AS Count FROM Customer GROUP BY Country ORDER BY Count DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerCountry countryCount = new CustomerCountry();
                                countryCount.Country = reader.IsDBNull(0) ? null : reader.GetString(0);
                                countryCount.Count = reader.GetInt32(1);
                                countryCountList.Add(countryCount);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return countryCountList;
        }

        public IEnumerable<Customer> GetAll()
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                customer.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? null : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? null : reader.GetString(4);
                                customer.Phone = reader.IsDBNull(5) ? null : reader.GetString(5);
                                customer.Email = reader.IsDBNull(6) ? null : reader.GetString(6);
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customerList;
        }

        public Customer GetById(int id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer" +
                        " WHERE CustomerId=@CustomerId";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                customer.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? null : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? null : reader.GetString(4);
                                customer.Phone = reader.IsDBNull(5) ? null : reader.GetString(5);
                                customer.Email = reader.IsDBNull(6) ? null : reader.GetString(6);

                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customer;
        }

        public IEnumerable<Customer> GetByName(string FirstName)
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer" +
                        " WHERE FirstName LIKE @FirstName";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", FirstName);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                customer.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? null : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? null : reader.GetString(4);
                                customer.Phone = reader.IsDBNull(5) ? null : reader.GetString(5);
                                customer.Email = reader.IsDBNull(6) ? null : reader.GetString(6);
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customerList;
        }

        public IEnumerable<Customer> GetPage(int limit, int offset)
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer" +
                        " ORDER BY CustomerId OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Limit", limit);
                        cmd.Parameters.AddWithValue("@Offset", offset);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                customer.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? null : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? null : reader.GetString(4);
                                customer.Phone = reader.IsDBNull(5) ? null : reader.GetString(5);
                                customer.Email = reader.IsDBNull(6) ? null : reader.GetString(6);
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customerList;
        }

        public CustomerGenre TopGenres(int customerId)
        {
            CustomerGenre customerPopularGenres = new CustomerGenre();

            string sql = @"
                WITH GenreCounts AS (
                    SELECT c.FirstName, c.LastName, g.Name AS GenreName, COUNT(t.TrackId) AS TrackCount
                    FROM Customer c
                    INNER JOIN Invoice i ON c.CustomerId = i.CustomerId
                    INNER JOIN InvoiceLine il ON i.InvoiceId = il.InvoiceId
                    INNER JOIN Track t ON il.TrackId = t.TrackId
                    INNER JOIN Genre g ON t.GenreId = g.GenreId
                    WHERE c.CustomerId = @CustomerId
                    GROUP BY c.FirstName, c.LastName, g.Name
                ),
                MaxTrackCount AS (
                    SELECT MAX(TrackCount) AS MaxCount
                    FROM GenreCounts
                )
                SELECT gc.FirstName, gc.LastName, gc.GenreName
                FROM GenreCounts gc
                JOIN MaxTrackCount mtc ON gc.TrackCount = mtc.MaxCount";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            customerPopularGenres.PopularGenres = new List<string>();

                            while (reader.Read())
                            {
                                customerPopularGenres.FirstName = reader.IsDBNull(0) ? null : reader.GetString(0);
                                customerPopularGenres.LastName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                customerPopularGenres.PopularGenres.Add(reader.GetString(2));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customerPopularGenres;
        }

        public IEnumerable<CustomerSpender> TopSpenders()
        {
            List<CustomerSpender> totalSpentList = new List<CustomerSpender>();
            string sql = "SELECT c.FirstName, c.LastName, i.TotalSpent " +
                         "FROM Customer c " +
                         "INNER JOIN (SELECT CustomerId, SUM(Total) AS TotalSpent " +
                         "            FROM Invoice " +
                         "            GROUP BY CustomerId) i ON c.CustomerId = i.CustomerId " +
                         "ORDER BY i.TotalSpent DESC";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSpender customerSpender = new CustomerSpender();
                                customerSpender.FirstName = reader.IsDBNull(0) ? null : reader.GetString(0);
                                customerSpender.LastName = reader.IsDBNull(1) ? null : reader.GetString(1);
                                customerSpender.TotalSpent = reader.IsDBNull(2) ? 0.0 : Convert.ToDouble(reader.GetDecimal(2));
                                totalSpentList.Add(customerSpender);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return totalSpentList;
        }

        public bool Update(Customer customer)
        {
            bool success = false;

            string sql = "UPDATE Customer SET FirstName=@FirstName, LastName=@LastName, Country=@Country," +
                        " PostalCode=@PostalCode, Phone=@Phone, Email=@Email WHERE CustomerId=@CustomerId";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);

                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return success;
        }
    }
}

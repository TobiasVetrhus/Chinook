using Chinook.Models;
using Microsoft.Data.SqlClient;

namespace Chinook.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Adds a new customer to the database.
        /// </summary>
        /// <param name="customer">The customer object to add.</param>
        /// <returns>
        /// True if the customer was successfully added; otherwise, false.
        /// </returns>
        /// <exception cref="SqlException">Thrown if there is an issue with the SQL database.</exception>
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

        /// <summary>
        /// Retrieves a list of customer countries along with the count of customers in each country.
        /// </summary>
        /// <returns>
        /// A list of CustomerCountry objects representing countries and customer counts.
        /// </returns>
        /// <exception cref="SqlException">Thrown if there is an issue with the SQL database.</exception>


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
        /// <summary>
        /// Retrieves a list of all customers from the database.
        /// </summary>
        /// <returns>
        /// A list of Customer objects representing all customers.
        /// </returns>
        /// <exception cref="SqlException">Thrown if there is an issue with the SQL database.</exception>


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
       
        /// <summary>
        /// Retrieves a customer by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <returns>
        /// A Customer object representing the customer with the specified ID.
        /// </returns>
        /// <exception cref="SqlException">Thrown if there is an issue with the SQL database.</exception>
      
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

        /// <summary>
        /// Retrieves a list of customers by their first name.
        /// </summary>
        /// <param name="FirstName">The first name to search for.</param>
        /// <returns>
        /// A list of Customer objects matching the provided first name.
        /// </returns>
        /// <exception cref="SqlException">Thrown if there is an issue with the SQL database.</exception>
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

        /// <summary>
        /// Retrieves a page of customers with a specified limit and offset.
        /// </summary>
        /// <param name="limit">The maximum number of records to retrieve.</param>
        /// <param name="offset">The number of records to skip before retrieving.</param>
        /// <returns>
        /// A list of Customer objects representing the requested page of customers.
        /// </returns>
        /// <exception cref="SqlException">Thrown if there is an issue with the SQL database.</exception>
      

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

        /// <summary>
        /// Retrieves the top genres for a customer based on the number of tracks purchased.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <returns>
        /// A CustomerGenre object containing the customer's first and last name along with a list of top genres.
        /// </returns>
        /// <exception cref="SqlException">Thrown if there is an issue with the SQL database.</exception>

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


        /// <summary>
        /// Retrieves a list of the top spending customers in descending order of their total spent amount.
        /// </summary>
        /// <returns>
        /// A list of CustomerSpender objects representing the top spending customers.
        /// </returns>
        /// <exception cref="SqlException">Thrown if there is an issue with the SQL database.</exception>
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

        /// <summary>
        /// Updates customer information in the database.
        /// </summary>
        /// <param name="customer">The Customer object containing updated information.</param>
        /// <returns>
        /// True if the customer information was successfully updated; otherwise, false.
        /// </returns>
        /// <exception cref="SqlException">Thrown if there is an issue with the SQL database.</exception>
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

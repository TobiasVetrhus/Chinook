using Chinook.Models;
using Chinook.Repositories;

namespace Chinook
{
    class Program
    {
        static void Main(string[] args)
        {

            ICustomerRepository repository = new CustomerRepository();

            TestSelectAll(repository);
            //TestSelect(repository);
            //TestSelectByName(repository);
            //TestInsert(repository);
            //TestUpdate(repository);
            //TestPage(repository);
            //TestCustomerCounty(repository);
            //TestCustomerSpender(repository);
            //TestCustomerGenre(repository);
        }


        /// <summary>
        /// Tests the retrieval of top genres for multiple customers.
        /// </summary>
   
        static void TestCustomerGenre(ICustomerRepository repository)
        {
            int maxCustomerId = 59;

            for (int i = 1; i <= maxCustomerId; i++)
            {
                PrintCustomerGenre(repository.TopGenres(i));
            }
        }
        
        /// <summary>
        /// Tests the retrieval of top spenders.
        /// </summary>
    
        static void TestCustomerSpender(ICustomerRepository repository)
        {
            PrintCustomerSpenders(repository.TopSpenders());
        }

        /// <summary>
        /// Tests the retrieval of customer countries.
        /// </summary>
   
        static void TestCustomerCounty(ICustomerRepository repository)
        {
            PrintCustomerCountries(repository.CustomerCountry());
        }

        static void TestPage(ICustomerRepository repository)
        {
            /// <summary>
            /// Retrieves a page of customers from the repository.
            /// </summary>
            PrintCustomers(repository.GetPage(10, 20));
        }

        static void TestSelectAll(ICustomerRepository repository)
        {
            /// <summary>
            /// Retrieves all customers from the repository.
            /// </summary>
            PrintCustomers(repository.GetAll());
        }

        static void TestSelect(ICustomerRepository repository)
        {
            /// <summary>
            /// Retrieves a specific customer by their ID from the repository.
            /// </summary>
            PrintCustomer(repository.GetById(1));
        }

        static void TestSelectByName(ICustomerRepository repository)
        {
            /// <summary>
            /// Retrieves customers with a specific first name from the repository.
            /// </summary>
            PrintCustomers(repository.GetByName("John"));
        }

        static void TestInsert(ICustomerRepository repository)
        {
            /// <summary>
            /// Inserts a new customer into the repository and retrieves customers with the same first name.
            /// </summary>
            Customer test = new Customer()
            {
                FirstName = "Tobias",
                LastName = "Vetrhus",
                Country = "Norway",
                PostalCode = "4700",
                Phone = "555 00 555",
                Email = "test.email@hotmail.com"
            };

            if (repository.Add(test))
            {
                Console.WriteLine("Insert worked");
                PrintCustomers(repository.GetByName(test.FirstName));
            }
            else
            {
                Console.WriteLine("Insert didn't work");
            }
        }

        static void TestUpdate(ICustomerRepository repository)
        {
            /// <summary>
            /// Updates a customer's information in the repository and retrieves the updated customer.
            /// </summary
            Customer test = new Customer()
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Doe",
                Country = "Sverige",
                PostalCode = "7777",
                Phone = "916 00 000",
                Email = "updated.email@hotmail.com"
            };

            if (repository.Update(test))
            {
                Console.WriteLine("Update worked");
                PrintCustomer(repository.GetById(test.CustomerId));
            }
            else
            {
                Console.WriteLine("Update didn't work");
            }

        }

        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            /// <summary>
            /// Prints a list of customers to the console.
            /// </summary>
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomer(Customer customer)
        {
            /// <summary>
            /// Prints customer information to the console.
            /// </summary>
            Console.WriteLine($" --- {customer.CustomerId} - {customer.FirstName} - {customer.LastName} - {customer.Country} - {customer.PostalCode} - {customer.Phone} - {customer.Email} --- ");
        }

        static void PrintCustomerCountries(IEnumerable<CustomerCountry> countries)
        {
            /// <summary>
            /// Prints a list of customer countries and counts to the console.
            /// </summary>
            foreach (CustomerCountry country in countries)
            {
                PrintCustomerCountry(country);
            }
        }

        static void PrintCustomerCountry(CustomerCountry country)
        {
            /// <summary>
            /// Prints a customer country and count to the console.
            /// </summary>
            Console.WriteLine($" --- {country.Country}: {country.Count}");
        }

        static void PrintCustomerSpenders(IEnumerable<CustomerSpender> customerSpenders)
        {
            /// <summary>
            /// Prints a list of customer spenders to the console.
            /// </summary>
            foreach (CustomerSpender customer in customerSpenders)
            {
                PrintCustomerSpender(customer);
            }
        }

        static void PrintCustomerSpender(CustomerSpender customer)
        {
            /// <summary>
            /// Prints customer spender information to the console.
            /// </summary>
            Console.WriteLine($" --- {customer.FirstName} - {customer.LastName} - {customer.TotalSpent}");
        }

        static void PrintCustomerGenre(CustomerGenre customer)
        {
            /// <summary>
            /// Prints customer genre information to the console.
            /// </summary
            string genres = string.Join(", ", customer.PopularGenres);
            Console.WriteLine($" --- {customer.FirstName} - {customer.LastName} - {genres}");
        }
    }
}
using Chinook.Models;
using Chinook.Repositories;

namespace Chinook
{
    class Program
    {
        static void Main(string[] args)
        {

            ICustomerRepository repository = new CustomerRepository();

            //TestSelectAll(repository); -- WORKS
            //TestSelect(repository); -- WORKS
            //TestSelectByName(repository); -- WORKS
            //TestInsert(repository); -- WORKS
            //TestUpdate(repository); -- WORKS
            //TestPage(repository); -- WORKS
            //TestCustomerCounty(repository); -- WORKS
            //TestCustomerSpender(repository); -- WORKS
            //TestCustomerGenre(repository); -- WORKS
        }

        static void TestCustomerGenre(ICustomerRepository repository)
        {
            int maxCustomerId = 59;

            for (int i = 1; i <= maxCustomerId; i++)
            {
                PrintCustomerGenre(repository.TopGenres(i));
            }
        }

        static void TestCustomerSpender(ICustomerRepository repository)
        {
            PrintCustomerSpenders(repository.TopSpenders());
        }

        static void TestCustomerCounty(ICustomerRepository repository)
        {
            PrintCustomerCountries(repository.CustomerCountry());
        }

        static void TestPage(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetPage(10, 20));
        }

        static void TestSelectAll(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAll());
        }

        static void TestSelect(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetById(1));
        }

        static void TestSelectByName(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetByName("John"));
        }

        static void TestInsert(ICustomerRepository repository)
        {
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
            Customer test = new Customer()
            {
                CustomerId = 64,
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
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($" --- {customer.CustomerId} - {customer.FirstName} - {customer.LastName} - {customer.Country} - {customer.PostalCode} - {customer.Phone} - {customer.Email} --- ");
        }

        static void PrintCustomerCountries(IEnumerable<CustomerCountry> countries)
        {
            foreach (CustomerCountry country in countries)
            {
                PrintCustomerCountry(country);
            }
        }

        static void PrintCustomerCountry(CustomerCountry country)
        {
            Console.WriteLine($" --- {country.Country}: {country.Count}");
        }

        static void PrintCustomerSpenders(IEnumerable<CustomerSpender> customerSpenders)
        {
            foreach (CustomerSpender customer in customerSpenders)
            {
                PrintCustomerSpender(customer);
            }
        }

        static void PrintCustomerSpender(CustomerSpender customer)
        {
            Console.WriteLine($" --- {customer.FirstName} - {customer.LastName} - {customer.InvoiceCount}");
        }

        static void PrintCustomerGenre(CustomerGenre customer)
        {
            string genres = string.Join(", ", customer.PopularGenres);
            Console.WriteLine($" --- {customer.FirstName} - {customer.LastName} - {genres}");
        }
    }
}
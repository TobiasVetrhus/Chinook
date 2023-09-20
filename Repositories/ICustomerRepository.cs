using Chinook.Models;

namespace Chinook.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public IEnumerable<CustomerCountry> CustomerCountry();
        public IEnumerable<CustomerSpender> TopSpenders();
        public CustomerGenre TopGenres(int customerId);
    }
}

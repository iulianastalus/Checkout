using Customer.Domain.Entities;
namespace Customer.Domain.Interfaces
{
    public interface ICustomerRepository :IRepository<Domain.Entities.Customer>
    {
    }
}

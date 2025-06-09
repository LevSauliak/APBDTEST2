using APBDTEST2.DTOs;

namespace APBDTEST2.Repositories;

public interface IDbRepository
{
    public Task<CustomerPurchasesResponse?> GetCustomerPurchases(int customerId);
    public Task AddCustomerWithPurchases(CustomerWithPurchasesDto customerWithPurchases);
    public Task<bool> CustomerExists(int customerId);
    public Task<bool> ConcertExistsByName(string name);

}
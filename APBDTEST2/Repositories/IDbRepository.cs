using APBDTEST2.DTOs;

namespace APBDTEST2.Repositories;

public interface IDbRepository
{
    public Task<CustomerPurchasesResponse?> GetCustomerPurchases(int customerId);
    
}
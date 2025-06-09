using APBDTEST2.Data.Models;
using APBDTEST2.DTOs;

namespace APBDTEST2.Services;

public interface ICustomerService
{
    public Task<CustomerPurchasesResponse> GetCustomerPurchases(int customerId);
}

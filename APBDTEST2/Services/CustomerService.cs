using APBDTEST2.DTOs;
using APBDTEST2.Excetpions;
using APBDTEST2.Repositories;

namespace APBDTEST2.Services;

public class CustomerService: ICustomerService
{
    private readonly IDbRepository _dbRepository;

    public CustomerService(IDbRepository dbRepository)
    {
        _dbRepository = dbRepository;
    }


    public async Task<CustomerPurchasesResponse> GetCustomerPurchases(int customerId)
    {
        var purchases = await  _dbRepository.GetCustomerPurchases(customerId);
        if (purchases == null)
        {
            throw new NotFoundException("Customer not found");
        }
        return purchases;
    }

    
}

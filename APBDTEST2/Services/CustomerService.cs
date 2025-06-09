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

    public async Task AddCustomerWithPurchases(CustomerWithPurchasesDto dto)
    {
        if (await _dbRepository.CustomerExists(dto.CustomerPart.Id))
        {
            throw new ConflictException("Customer with this id already exists");
        }

        if (!ValidatePurchases(dto.Purchases))
        {
            throw new ConflictException("Customer cannot buy more than 5 tickets for one concert");
        }
        
        foreach (var purchase in dto.Purchases) {
            if (!await _dbRepository.ConcertExistsByName(purchase.ConcertName))
            {
                throw new NotFoundException($"No such concert with name: {purchase.ConcertName}");
            }
        }

        await _dbRepository.AddCustomerWithPurchases(dto);
    }

    public bool ValidatePurchases(List<PurchasesPart> purchases)
    {
        var counts = new Dictionary<String, int>();
        foreach (var p in purchases)
        {
            if (!counts.ContainsKey(p.ConcertName))
            {
                counts[p.ConcertName] = 0;
            };
            counts[p.ConcertName]++;
        }

        // checks if customer tries to buy more than 
        foreach (var key in counts.Keys)
        {
            if (counts[key] > 5)
            {
                return false;
            }
        }
        
        return true;
    }
}

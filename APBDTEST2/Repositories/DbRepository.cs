using APBDTEST2.Data;
using APBDTEST2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APBDTEST2.Repositories;

public class DbRepository: IDbRepository
{
    private readonly DatabaseContext _context;

    public DbRepository(DatabaseContext context)
    {
        _context = context;
    }


    public async Task<CustomerPurchasesResponse?> GetCustomerPurchases(int customerId)
    {

        var customerWithPurchases = await _context.Customers
            .Where(c => c.CustomerId == customerId)
            .Include(c => c.PurchasedTickets)
            .ThenInclude(pt => pt.TicketConcert)
            .ThenInclude(tc => tc.Concert)
            .Include(c => c.PurchasedTickets)
            .ThenInclude(pt => pt.TicketConcert)
            .ThenInclude(tc => tc.Ticket).FirstOrDefaultAsync();

        if (customerWithPurchases == null) return null;

        CustomerPurchasesResponse res = new CustomerPurchasesResponse()
        {
            FirstName = customerWithPurchases.FirstName,
            LastName = customerWithPurchases.LastName,
            PhoneNumber = customerWithPurchases.PhoneNumber,
            Purchases = customerWithPurchases.PurchasedTickets.Select(pt => new Purchase()
            {
                Date = pt.PurchaseDate,
                Price = pt.TicketConcert.Price,
                Ticket = new TicketPart()
                {
                    SeatNumber = pt.TicketConcert.Ticket.SeatNumber,
                    Serial = pt.TicketConcert.Ticket.SerialNumber
                },
                Concert = new ConcertPart()
                {
                    Date = pt.TicketConcert.Concert.Date,
                    Name = pt.TicketConcert.Concert.Name,
                }
            }).ToList()
        };
        
        return res;
    }
}
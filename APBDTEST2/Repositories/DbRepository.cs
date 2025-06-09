using System.Text;
using APBDTEST2.Data;
using APBDTEST2.Data.Models;
using APBDTEST2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APBDTEST2.Repositories;

public class DbRepository : IDbRepository
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

    public async Task AddCustomerWithPurchases(CustomerWithPurchasesDto dto)
    {
        var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // add customer
            var customer = new Customer()
            {
                FirstName = dto.CustomerPart.FirstName,
                LastName = dto.CustomerPart.LastName,
                PhoneNumber = dto.CustomerPart.PhoneNumber,
            };
            var result = await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            int customerId = result.Entity.CustomerId;


            foreach (var purchase in dto.Purchases)
            {
                var res = await _context.AddAsync(new Ticket()
                {
                    SerialNumber = GenerateRandomString(10),
                    SeatNumber = purchase.SeatNumber,
                });
                await _context.SaveChangesAsync();

                int concertId = (await _context.Concerts.FirstOrDefaultAsync(c => c.Name == purchase.ConcertName))
                    .ConcertId;
                var concertTicketResult = await _context.AddAsync(new TicketConcert()
                {
                    ConcertId = concertId,
                    TicketId = res.Entity.TicketId,
                    Price = purchase.Price,
                });
                await _context.SaveChangesAsync();

                await _context.AddAsync(new PurchasedTicket()
                {
                    CustomerId = customerId,
                    TicketConcertId = concertTicketResult.Entity.TicketId,
                    PurchaseDate = DateTime.Now,
                });
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception("Internal error");
        }
    }

    public static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var result = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            result.Append(chars[random.Next(chars.Length)]);
        }

        return result.ToString();
    }

    public async Task<bool> CustomerExists(int customerId)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        return customer != null;
    }

    public async Task<bool> ConcertExistsByName(string name)
    {
        var concert = await _context.Concerts.FirstOrDefaultAsync(c => c.Name == name);
        return concert != null;
    }
}
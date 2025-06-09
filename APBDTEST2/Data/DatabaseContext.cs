using APBDTEST2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDTEST2.Data;

public class DatabaseContext: DbContext
{
    public DbSet<PurchasedTicket> PurchasedTickets { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<TicketConcert> TicketConcerts { get; set; }
    
    public DatabaseContext(){}
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Concert>().HasData(new List<Concert>()
        {
            new Concert()
            {
                ConcertId = 1,
                AvailableTickets = 20,
                Date = DateTime.Now,
                Name = "Concert 1"
            },
            new Concert()
            {
                ConcertId = 2,
                AvailableTickets = 30,
                Date = DateTime.Now,
                Name = "Concert 2"
            }
        });

        modelBuilder.Entity<Ticket>().HasData(new List<Ticket>()
        {
            new Ticket()
            {
                TicketId = 1,
                SeatNumber = 20,
                SerialNumber = "asdf/134/asdf",
            },
            new Ticket()
            {
                TicketId = 2,
                SeatNumber = 5,
                SerialNumber = "asdf/134/1234f",
            }
        });

        modelBuilder.Entity<TicketConcert>().HasData(new List<TicketConcert>()
        {
            new TicketConcert()
            {
                TicketConcertId = 1,
                TicketId = 1,
                ConcertId = 1,
                Price = 25.7,
            },
            new TicketConcert()
            {
                TicketConcertId = 2,
                TicketId = 2,
                ConcertId = 2,
                Price = 30,
            }
        });

        modelBuilder.Entity<Customer>().HasData(new List<Customer>()
        {
            new Customer()
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "0123123123123"
            },
            new Customer()
            {
                CustomerId = 2,
                FirstName = "Jane",
                LastName = "Doe",
            }
        });

        modelBuilder.Entity<PurchasedTicket>().HasData(new List<PurchasedTicket>()
        {
            new PurchasedTicket()
            {
                TicketConcertId = 1,
                CustomerId = 1,
                PurchaseDate = DateTime.Now, 
            },
            new PurchasedTicket()
            {
                TicketConcertId = 2,
                CustomerId = 2,
                PurchaseDate = DateTime.Now,
            }
        });
    }
}
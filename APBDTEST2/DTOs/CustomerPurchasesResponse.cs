using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace APBDTEST2.DTOs;
public class CustomerPurchasesResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public List<Purchase> Purchases { get; set; }
}

public class Purchase
{
    public DateTime Date { get; set; }
    public double Price {get; set;}
    public TicketPart Ticket {get; set;}
    public ConcertPart Concert {get; set;}
}

public class TicketPart
{
    public string Serial { get; set; }
    
    public int SeatNumber { get; set; }
}

public class ConcertPart
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
}

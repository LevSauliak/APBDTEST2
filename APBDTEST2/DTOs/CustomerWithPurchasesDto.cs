using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace APBDTEST2.DTOs;

public class CustomerWithPurchasesDto
{   
    public CustomerPart CustomerPart { get; set; }
    public List<PurchasesPart> Purchases { get; set; }
}

public class CustomerPart
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string? PhoneNumber { get; set; }
}

public class PurchasesPart
{
    public int SeatNumber { get; set; }
    [MaxLength(100)]
    public string ConcertName { get; set; }
    [Precision(10, 2)]
    public double Price { get; set; }
}
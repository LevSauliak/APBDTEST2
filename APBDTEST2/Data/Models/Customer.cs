using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDTEST2.Data.Models;
using System.ComponentModel.DataAnnotations;

[Table("Customer")]
public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [MaxLength(100)]
    public string LastName { get; set; } = null!;

    [MaxLength(100)]
    public string? PhoneNumber { get; set; }

    public virtual ICollection<PurchasedTicket> PurchasedTickets { get; set; } = new List<PurchasedTicket>();
}

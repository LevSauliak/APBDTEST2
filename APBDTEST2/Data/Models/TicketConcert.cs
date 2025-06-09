using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBDTEST2.Data.Models;

[Table("Ticket_Concert")]
public class TicketConcert
{
    [Key]
    public int TicketConcertId { get; set; }

    public int TicketId { get; set; }
    public Ticket Ticket { get; set; } = null!;

    public int ConcertId { get; set; }
    public Concert Concert { get; set; } = null!;

    [Precision(10, 2)]
    public double Price { get; set; }

    public virtual ICollection<PurchasedTicket> PurchasedTickets { get; set; } = new List<PurchasedTicket>();
}

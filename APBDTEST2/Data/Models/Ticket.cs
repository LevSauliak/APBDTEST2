using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBDTEST2.Data.Models;

[Table("Ticket")]
public class Ticket
{
    [Key]
    public int TicketId { get; set; }

    [MaxLength(50)]
    public string SerialNumber { get; set; }
    
    public int SeatNumber { get; set; }

    public virtual ICollection<TicketConcert> TicketConcerts { get; set; } = new List<TicketConcert>();
}

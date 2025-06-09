using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDTEST2.Data.Models;

[Table("Concert")]
public class Concert
{
    [Key]
    public int ConcertId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public int AvailableTickets { get; set; }

    public virtual ICollection<TicketConcert> TicketConcerts { get; set; } = new List<TicketConcert>();
}

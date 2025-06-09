using Microsoft.EntityFrameworkCore;

namespace APBDTEST2.Data;

public class DatabaseContext: DbContext
{
    public DatabaseContext(){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
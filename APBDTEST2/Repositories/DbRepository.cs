using APBDTEST2.Data;

namespace APBDTEST2.Repositories;

public class DbRepository: IDbRepository
{
    private readonly DatabaseContext _context;

    public DbRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    
}
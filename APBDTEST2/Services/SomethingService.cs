using APBDTEST2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APBDTEST2.Services;

public class SomethingService: ISomethingService
{
    private readonly IDbRepository _dbRepository;

    public SomethingService(IDbRepository dbRepository)
    {
        _dbRepository = dbRepository;
    }


    public async Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }
}
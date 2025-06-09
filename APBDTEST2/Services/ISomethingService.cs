using Microsoft.AspNetCore.Mvc;

namespace APBDTEST2.Services;

public interface ISomethingService
{
    
    public Task<IActionResult> Get();
}
using Microsoft.AspNetCore.Mvc;

namespace RBS.News.Api.Controllers;

public class NewsController : ControllerBase
{
    public async Task<IActionResult> GetNewsById(int id)
    {
        await Task.FromResult(1);

        return Ok();
    }
    
    public async Task<IActionResult> GetAllNews()
    {
        await Task.FromResult(1);

        return Ok();
    }
    
    public async Task<IActionResult> CreateNews()
    {
        await Task.FromResult(1);

        return Ok();
    }
    
    public async Task<IActionResult> UpdateNews()
    {
        await Task.FromResult(1);

        return Ok();
    }
    
    public async Task<IActionResult> DeleteNews()
    {
        await Task.FromResult(1);

        return Ok();
    }
}
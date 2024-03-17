using MediatR;
using Microsoft.AspNetCore.Mvc;
using RBS.News.Api.Abstractions;
using RBS.News.Api.Models.News;
using RBS.News.Application.News.Commands.CreateNews;

namespace RBS.News.Api.Controllers;

public class NewsController(ISender sender) : ApiController(sender)
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
    
    public async Task<IActionResult> CreateNews(CreateNewsRequest request)
    {
        var command = new CreateNewsCommand(CreateNewsRequest.Map(request));
        
        var result = await Sender.Send(command);
        
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
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
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RBS.News.Api.Abstractions;
using RBS.News.Api.Models.Common;
using RBS.News.Api.Models.News;
using RBS.News.Application.News.Commands.CreateNews;
using RBS.News.Application.News.Queries.GetNewsPartByRecent;

namespace RBS.News.Api.Controllers;

[Route("api/[controller]")]
public class NewsController(ISender sender) : ApiController(sender)
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetNewsById(int id)
    {
        await Task.FromResult(1);

        return Ok();
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetNews([FromQuery] PaginationModel model)
    {
        var command = new GetNewsPartByRecentQuery(model.Page, model.Limit);
        
        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNews(CreateNewsRequest request)
    {
        var command = new CreateNewsCommand(CreateNewsRequest.Map(request));
        
        var result = await Sender.Send(command);
        
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateNews()
    {
        await Task.FromResult(1);

        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteNews()
    {
        await Task.FromResult(1);

        return Ok();
    }
}
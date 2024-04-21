using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RBS.News.Api.Abstractions;
using RBS.News.Api.Models.Common;
using RBS.News.Api.Models.News;
using RBS.News.Application.News.Commands.CreateNews;
using RBS.News.Application.News.Commands.DeleteNews;
using RBS.News.Application.News.Commands.UpdateNews;
using RBS.News.Application.News.Queries.GetNewsById;
using RBS.News.Application.News.Queries.GetNewsPartByRecent;

namespace RBS.News.Api.Controllers;

[Route("api/[controller]")]
public class NewsController(ISender sender) : ApiController(sender)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetNewsById(string id)
    {
        var query = new GetNewsByIdQuery(id);
        
        var result = await Sender.Send(query);
        
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetNews([FromQuery] PaginationModel model)
    {
        var query = new GetNewsPartByRecentQuery(model.Page, model.Limit);
        
        var result = await Sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNews(CreateNewsRequest request)
    {
        var command = new CreateNewsCommand(CreateNewsRequest.Map(request));
        
        var result = await Sender.Send(command);
        
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNews(string id, UpdateNewsRequest request)
    {
        var command = new UpdateNewsCommand(UpdateNewsRequest.Map(id, request));
        
        var result = await Sender.Send(command);
        
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNews(string id)
    {
        var command = new DeleteNewsCommand(id);
        
        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}
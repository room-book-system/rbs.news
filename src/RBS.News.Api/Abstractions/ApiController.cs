using MediatR;
using Microsoft.AspNetCore.Mvc;
using RBS.News.Application.Abstractions.Events;

namespace RBS.News.Api.Abstractions;

[ApiController]
public abstract class ApiController(ISender sender) : ControllerBase
{
    protected readonly ISender Sender = sender;
}
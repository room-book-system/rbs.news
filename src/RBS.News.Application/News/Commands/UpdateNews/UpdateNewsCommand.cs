using RBS.News.Application.Abstractions.Messaging;
using RBS.News.Application.News.Models;

namespace RBS.News.Application.News.Commands.UpdateNews;

public sealed record UpdateNewsCommand(UpdateNewsDto News) : ICommand;
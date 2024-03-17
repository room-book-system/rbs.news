using RBS.News.Application.Abstractions.Messaging;
using RBS.News.Application.News.Models;

namespace RBS.News.Application.News.Commands.CreateNews;

public sealed record CreateNewsCommand(CreateNewsDto News) : ICommand;

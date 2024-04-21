using RBS.News.Application.Abstractions.Messaging;

namespace RBS.News.Application.News.Commands.DeleteNews;

public sealed record DeleteNewsCommand(string Id) : ICommand;
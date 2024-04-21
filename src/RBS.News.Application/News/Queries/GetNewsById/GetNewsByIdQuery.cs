using RBS.News.Application.Abstractions.Messaging;
using RBS.News.Application.News.Queries.GetNewsPartByRecent;

namespace RBS.News.Application.News.Queries.GetNewsById;

public sealed record GetNewsByIdQuery(string Id) : IQuery<GetNewsByIdResponse>;
using MediatR;
using RBS.News.Domain.Shared;

namespace RBS.News.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
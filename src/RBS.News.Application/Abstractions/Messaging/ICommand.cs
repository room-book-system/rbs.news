using MediatR;
using RBS.News.Domain.Shared;

namespace RBS.News.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;
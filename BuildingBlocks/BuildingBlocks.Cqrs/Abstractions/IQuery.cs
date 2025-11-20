using MediatR;

namespace BuildingBlocks.Cqrs.Abstractions;

public interface IQuery<out T> : IRequest<T>
    where T : notnull;
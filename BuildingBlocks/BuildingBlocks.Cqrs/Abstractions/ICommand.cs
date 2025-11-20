using MediatR;

namespace BuildingBlocks.Cqrs.Abstractions;

public interface ICommand : ICommand<Unit>;
public interface ICommand<out T> : IRequest<T>
    where T : notnull;
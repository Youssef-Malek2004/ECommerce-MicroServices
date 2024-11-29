using Abstractions.ResultsPattern;
using MediatR;

namespace Products.Application.CQRS.CommandsAndQueries.Products;

public record DeleteProductCommand(string Id) : IRequest<Result>;

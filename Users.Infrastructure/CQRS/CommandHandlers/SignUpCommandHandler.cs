using Abstractions.ResultsPattern;
using MediatR;
using Users.Application.CQRS.Commands;
using Users.Domain;
using Users.Domain.Entities;
using Users.Domain.Errors;
using Users.Infrastructure.Persistence;

namespace Users.Infrastructure.CQRS.CommandHandlers;

public class SignUpCommandHandler(IUnitOfWork unitOfWork, UsersDbContext dbContext) : IRequestHandler<SignUpCommand, Result<User>>
{
    public async Task<Result<User>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var userExists = await unitOfWork.UserRepository.GetUserByEmailAsync(request.SignUpDto.Email, cancellationToken);
        
        if (userExists.IsSuccess)
        {
            return Result<User>.Failure(UserErrors.UserAlreadyExists(request.SignUpDto.Email));
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.SignUpDto.PasswordHash);

        var registeredRole = await dbContext.Set<Role>().FindAsync(Role.Registered.Id);

        if (registeredRole == null)
        {
            return Result<User>.Failure(new Error("RoleNotFound", "Registered role not found."));
        }
        
        var user = new User
        {
            Username = request.SignUpDto.Username,
            Email = request.SignUpDto.Email,
            PasswordHash = hashedPassword,
            Roles = new List<Role>() { registeredRole }
        };

        var result = await unitOfWork.UserRepository.AddUserAsync(user);
        
        if (result.IsFailure)
        {
            return Result<User>.Failure(result.Error);
        }
            
        await unitOfWork.SaveChangesAsync();
        return Result<User>.Success(user);
    }
}

using Domain.Models;
using Domain.Repositories;
using Domain.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Persistence.Settings;

namespace Persistence.Repositories;

public class DatabaseRepository : IDatabaseRepository
{
    private readonly RepositoryDbContext _repositoryDbContext;
    private readonly IUserAccessor _userAccessor;
    private readonly UserManager<IdentityUser> _userManager;


    public DatabaseRepository(RepositoryDbContext repositoryDbContext, IUserAccessor userAccessor, UserManager<IdentityUser> userManager)
    {
        _repositoryDbContext = repositoryDbContext;
        _userAccessor = userAccessor;
        _userManager = userManager;
    }

    public async Task AddCanvasOptions(CanvasOptions canvasOptions)
    {
        await _repositoryDbContext.CanvasOptions.AddAsync(canvasOptions);
    }

    public async Task UpdateCanvasOptions(CanvasOptions canvasOptions)
    {
        canvasOptions.Id = 1;
        canvasOptions.OwnerId = GetCurrentUserId();
        _repositoryDbContext.CanvasOptions.Update(canvasOptions);
        await _repositoryDbContext.SaveChangesAsync();
    }

    private string? GetCurrentUserId()
    {
        var user = _userAccessor.GetUser();
        var userId = _userManager.GetUserId(user);
        return userId;
    }

    public async Task<CanvasOptions?> GetCanvasOptions()
    {
        var userId = GetCurrentUserId();
        var canvasOptions = await _repositoryDbContext.CanvasOptions.FirstOrDefaultAsync(x => x.OwnerId == userId);
        return canvasOptions;
    }

    public async Task AddOwner(Owner owner)
    {
        await _repositoryDbContext.AddAsync(owner);
    }


}
using Microsoft.EntityFrameworkCore;
using VK.Application.Features.UserFeature.Dtos;
using VK.Application.Repositories;
using VK.Domain.Entities;
using VK.Infrastructure.Persistence.Context;

namespace VK.Infrastructure.Persistence.Repositories;

public class UserRepository: IUserRepository
{
    private readonly DataContext _context;
    
    public UserRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<int> Create(CreateUserDto createUserDto)
    {
        var user = new User();
        user.Login = createUserDto.Login;
        user.Password = createUserDto.Password;
        user.CreatedDate = createUserDto.CreatedDate;

        var userGroup = _context.UserGroups.First(group => group.Id == createUserDto.UserGroupId);
        var userState = _context.UserStates.First(state => state.Id == createUserDto.UserStateId);
        
        user.UserGroup = userGroup;
        user.UserState = userState;
        
        var res = await _context.Users.AddAsync(user);
        _context.SaveChanges();
        return res.Entity.Id;
    }

    public async Task<User?> GetUserById(int id)
    {
        return await _context.Users
            .Include(u => u.UserState)
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User[]> GetAllUsers()
    {
        var res = await  _context.Users
            .Include(u => u.UserState)
            .Include(u => u.UserGroup)
            .OrderBy(u => u.Id)
            .ToArrayAsync();

        return res;
    }

    public async Task DeleteUser(int id, UserState blockedState)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        user.UserState = blockedState;
        _context.SaveChanges();
    }
    
    public async Task<User?> GetAdmin()
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserGroup.Code == "Admin");
    }
}
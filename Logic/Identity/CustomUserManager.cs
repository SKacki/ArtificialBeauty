using Logic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Model.Models;

public class CustomUserManager : UserManager<IdentityUser>
{
    private readonly IUserSvc _userSvc;
    public CustomUserManager(IUserStore<IdentityUser> store, 
        IOptions<IdentityOptions> options, 
        IPasswordHasher<IdentityUser> passwordHasher, 
        IEnumerable<IUserValidator<IdentityUser>> userValidators, 
        IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators, 
        ILookupNormalizer keyNormalizer, 
        IdentityErrorDescriber errors, 
        IServiceProvider services, 
        ILogger<UserManager<IdentityUser>> logger,
        IUserSvc usrSvc)
        : base(store, options, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger) 
        {
            _userSvc = usrSvc;
        }

    public override async Task<IdentityResult> CreateAsync(IdentityUser user, string password)
    {
        var result = await base.CreateAsync(user, password);
        if (result.Succeeded)
        {
            var newUser = new NewUserDTO()
            {
                Uid = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                JoinedDate = DateTime.Now,
            };
            var usrId = await _userSvc.PostUser(newUser);
        }
        return result;
    }
}
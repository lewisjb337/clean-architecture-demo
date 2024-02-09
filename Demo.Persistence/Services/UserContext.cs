﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Demo.Persistence.Services;

public class UserContext
{
    public AuthenticationStateProvider _authenticationStateProvider { get; set; }
    public UserManager<ApplicationUser> _userManager { get; set; }

    public UserContext(AuthenticationStateProvider authenticationStateProvider, UserManager<ApplicationUser> userManager)
    {
        _authenticationStateProvider = authenticationStateProvider;
        _userManager = userManager;
    }

    public async Task<string?> UserId()
    {
        var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = state.User;

        var details = await _userManager.GetUserAsync(user);

        if (details is not null)
            return await _userManager.GetUserIdAsync(details);

        return null;
    }

    public async Task<ApplicationUser?> Username(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user is not null)
            return user;

        return null;
    }
}
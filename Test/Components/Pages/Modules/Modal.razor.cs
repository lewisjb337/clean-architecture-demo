﻿using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

namespace Test.Components.Pages.Modules;

public partial class Modal : IComponent
{
    [Parameter]
    public EventCallback<bool> OnModalClosed { get; set; }

    [Parameter]
    public EventCallback<MouseEventArgs> OnAction { get; set; }

    [Parameter]
    public string Title { get; set; } = string.Empty;

    [Parameter]
    public RenderFragment? BodyContent { get; set; }

    [Parameter]
    public string ButtonColor { get; set; } = string.Empty;

    [Parameter]
    public string ActionName { get; set; } = string.Empty;

    private bool _isDisabled = false;
    private bool _showBackdrop = false;
    private string _modalDisplay = "none";
    private string _modalClass = string.Empty;

    public void ShowModal()
    {
        _modalDisplay = "block";
        _modalClass = "show";
        _showBackdrop = true;
    }

    public async Task Close()
    {
        _modalDisplay = "none";
        _modalClass = string.Empty;
        _showBackdrop = false;

        StateHasChanged();

        await OnModalClosed.InvokeAsync();
    }
}
using Microsoft.AspNetCore.Components;

namespace IcotakuScrapperDocs.Components;

public partial class Alert : ComponentBase
{
    [Parameter]
    public RenderFragment Content { get; set; }
    
    [Parameter]
    public bool IsHidden { get; set; }
    
    [Parameter]
    public AlertMode Mode { get; set; }
    
    [Parameter]
    public AlertIcon IconType { get; set; }

    private string _alertModeClass;
    private string _alertIconClasses;
    
    

    protected override void OnInitialized()
    {
        _alertModeClass = Mode switch
        {
            AlertMode.Success => "alert-success",
            AlertMode.Info => "alert-info",
            AlertMode.Warning => "alert-warning",
            AlertMode.Danger => "alert-danger",
            _ => "alert-info"
        };
        
        _alertIconClasses = IconType switch
        {
            AlertIcon.Success => "fa-solid fa-circle-chec",
            AlertIcon.Info => "fa-solid fa-circle-info",
            AlertIcon.Warning => "fa-solid fa-triangle-exclamation",
            AlertIcon.Danger => "fa-solid fa-circle-exclamation",
            AlertIcon.Spinner => "fa-spinner fa-spin",
            _ => "fa-info-circle"
        };
    }
}

public enum AlertMode
{
    Success,
    Info,
    Warning,
    Danger
}
    
public enum AlertIcon
{
    Success,
    Info,
    Warning,
    Danger,
    Spinner
}
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MyBlazor.Client.Shared.BaseComponent;

namespace MyBlazor.Client.Shared
{
    public partial class BaseDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public string ContentMessage { get; set; }
        [Parameter] public string MainLabelButton { get; set; }
        [Parameter] public string SecondaryLabelButton { get; set; }
        [Parameter] public Color Color { get; set; }
        [Parameter] public ButtonTypeDialog ButtonTypeDialog { get; set; }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();
    }
}
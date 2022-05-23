using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyBlazor.Client.Shared;
using SmartBreadcrumbs.Attributes;

namespace MyBlazor.Client.Pages
{
    public partial class Index
    {
        private async void ShowPopup()
        {
            const string message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi ante sem, aliquet sit amet quam vel, feugiat accumsan metus. Proin lacus nisi, maximus non mollis.";
            var dialogCustom = ShowDialog("Valider", "Header", message, ButtonTypeDialog.TwoButtons, "Annuler");

            var resultDialog = await dialogCustom.Result;

            if (resultDialog.Cancelled)
            {
                ShowAlert("Annulé", Severity.Warning);
            }
            else
            {
                ShowAlert("Validé", Severity.Success);
            }
        }
    }
}
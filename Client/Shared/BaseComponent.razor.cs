using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MyBlazor.Client.Shared
{
    public partial class BaseComponent
    {
        // Alerte
        private readonly Dictionary<int, Alert> _listAlerts = new();
        private int _idAlert;

        // Dialogue
        [Inject]
        public IDialogService Dialog { get; set; }
        public enum ButtonTypeDialog { OneButton, TwoButtons }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="severity"></param>
        public void ShowAlert(string message, Severity severity = Severity.Info)
        {
            _listAlerts.Add(_idAlert++, new Alert() { Message = message, Severity = severity });
            StateHasChanged();
        }

        private void RemoveAlert(int id)
        {
            if (_listAlerts.ContainsKey(id))
            {
                _listAlerts.Remove(id);
            }
            StateHasChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainLabelButton"></param>
        /// <param name="headerMessage"></param>
        /// <param name="contentMessage"></param>
        /// <param name="buttonType"></param>
        /// <param name="secondaryLabelButton"></param>
        /// <param name="options"></param>
        /// <param name="buttonColor"></param>
        /// <returns></returns>
        public IDialogReference ShowDialog(string mainLabelButton, string headerMessage, string contentMessage, ButtonTypeDialog buttonType, 
                                            string secondaryLabelButton = "", DialogOptions options = null, Color buttonColor = Color.Default)
        {
            var parameters = new DialogParameters
            {
                { "ContentMessage", contentMessage },
                { "MainLabelButton", mainLabelButton },
                { "SecondaryLabelButton", secondaryLabelButton },
                { "ButtonTypeDialog", buttonType },
                { "Color", buttonColor }
            };

            if (options == null)
            {
                options = new()
                {
                    DisableBackdropClick = true,
                    MaxWidth = MaxWidth.ExtraSmall
                };
            }

            return Dialog.Show<BaseDialog>(headerMessage, parameters, options);
        }
    }

    public partial class Alert
    {
        public string Message { get; set; }
        public Severity Severity { get; set; }
    }
}
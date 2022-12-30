using HexaArch.Shared.Model;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Collections;

namespace HexaArch.Frontend.Pages.Modal
{
    public partial class AddInterventionCardPage: ComponentBase
    {
        [Parameter] public IEnumerable<string> Contracts { get; set; } = new List<string>();
        [Parameter] public IEnumerable<string> Suppliers { get; set; } = new List<string>();

        private readonly InterventionRequest request = new InterventionRequest();
        DateTime? interventionDate = DateTime.Now;

        public void Ok()
        {
            request.InterventionDate = DateOnly.FromDateTime(interventionDate ?? DateTime.Now);
            dialogService.Close(new DialogResult()
            {
                Button = DialogResultButton.OK,
                Data = request
            });
        }

        public void Cancel()
        {
            dialogService.Close(new DialogResult()
            {
                Button = DialogResultButton.Cancel
            });
        }

        public class DialogResult
        {
            public DialogResultButton Button { get; set; }
            public InterventionRequest? Data { get; set; }
        }

        public enum DialogResultButton
        {
            Cancel, OK
        }
    }
}

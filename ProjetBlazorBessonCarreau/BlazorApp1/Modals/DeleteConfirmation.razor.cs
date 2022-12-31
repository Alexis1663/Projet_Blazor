using BlazorApp1.Services;
using Blazored.Modal.Services;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using BlazorApp1.Models;

namespace BlazorApp1.Modals
{
    public partial class DeleteConfirmation
    {
        [CascadingParameter]
        public BlazoredModalInstance ModalInstance { get; set; }

        [Inject]
        public IDataService DataService { get; set; }

        [Parameter]
        public int Id { get; set; }

        private Tool tool = new Tool();

        protected override async Task OnInitializedAsync()
        {
            // Get the item
            tool = await DataService.GetById(Id);
        }

        void ConfirmDelete()
        {
            ModalInstance.CloseAsync(ModalResult.Ok(true));
        }

        void Cancel()
        {
            ModalInstance.CancelAsync();
        }
    }
}

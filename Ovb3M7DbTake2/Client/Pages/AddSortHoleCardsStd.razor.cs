using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace Ovb3M7Db.Client.Pages
{
    public partial class AddSortHoleCardsStd
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }
        [Inject]
        public AppDbService AppDbService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            sortHoleCardsStd = new Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd();
        }
        protected bool errorVisible;
        protected Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd sortHoleCardsStd;

        protected async Task FormSubmit()
        {
            try
            {
                var result = await AppDbService.CreateSortHoleCardsStd(sortHoleCardsStd);
                DialogService.Close(sortHoleCardsStd);
            }
            catch (Exception ex)
            {
                errorVisible = true;
            }
        }

        protected async Task CancelButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }


        protected bool hasChanges = false;
        protected bool canEdit = true;

        [Inject]
        protected SecurityService Security { get; set; }
    }
}
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using Tailwind.Toast.Configuration;
using Tailwind.Toast.Services;

namespace Tailwind.Toast
{
    public partial class TailwindToasts
    {
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Parameter] public ToastPosition Position { get; set; } = ToastPosition.TopRight;
        [Parameter] public int Timeout { get; set; } = 5;
        [Parameter] public bool RemoveToastsOnNavigation { get; set; }

        protected string PositionClass { get; set; } = "items-start justify-end";
        internal List<ToastInstance> ToastList { get; set; } = new List<ToastInstance>();

        protected override void OnInitialized()
        {
            ToastService.OnShow += ShowToast;

            if (RemoveToastsOnNavigation)
            {
                NavigationManager.LocationChanged += ClearToasts;
            }

            switch (Position)
            {
                case ToastPosition.TopRight:
                    PositionClass = "items-start justify-end";
                    break;
                case ToastPosition.TopCenter:
                    PositionClass = "items-start justify-center";
                    break;
                case ToastPosition.TopLeft:
                    PositionClass = "items-start justify-start";
                    break;
                case ToastPosition.BottomRight:
                    PositionClass = "justify-end items-end";
                    break;
                case ToastPosition.BottomCenter:
                    PositionClass = "justify-center items-end";
                    break;
                case ToastPosition.BottomLeft:
                    PositionClass = "justify-start items-end";
                    break;
            }
        }

        public void RemoveToast(Guid toastId)
        {
            InvokeAsync(() =>
            {
                var toastInstance = ToastList.SingleOrDefault(x => x.Id == toastId);
                ToastList.Remove(toastInstance);
                StateHasChanged();
            });
        }

        private void ClearToasts(object sender, LocationChangedEventArgs args)
        {
            InvokeAsync(() =>
            {
                ToastList.Clear();
                StateHasChanged();
            });
        }

        private void ShowToast(RenderFragment toastFragment)
        {
            InvokeAsync(() =>
            {
                var toast = new ToastInstance
                {
                    Id = Guid.NewGuid(),
                    TimeStamp = DateTime.Now,
                    Toast = toastFragment
                };

                ToastList.Add(toast);

                StateHasChanged();
            });

        }
    }
}

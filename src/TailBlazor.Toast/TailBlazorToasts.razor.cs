using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using TailBlazor.Toast.Configuration;
using TailBlazor.Toast.Services;

namespace TailBlazor.Toast
{
    public partial class TailBlazorToasts
    {
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Parameter] public HeroIcons.IconStyle IconStyle { get; set; } = HeroIcons.IconStyle.Outline;
        [Parameter] public string InfoClass { get; set; } = "text-blue-500 w-7 h-7";
        [Parameter] public HeroIcons.HeroIcon InfoIcon { get; set; } = HeroIcons.HeroIcon.InformationCircle;
        [Parameter] public string SuccessClass { get; set; } = "text-green-500 w-7 h-7";
        [Parameter] public HeroIcons.HeroIcon SuccessIcon { get; set; } = HeroIcons.HeroIcon.Check;
        [Parameter] public string WarningClass { get; set; } = "text-orange-500 w-7 h-7";
        [Parameter] public HeroIcons.HeroIcon WarningIcon { get; set; } = HeroIcons.HeroIcon.Exclamation;
        [Parameter] public string ErrorClass { get; set; } = "text-red-500 w-7 h-7";
        [Parameter] public HeroIcons.HeroIcon ErrorIcon { get; set; } = HeroIcons.HeroIcon.X;
        [Parameter] public bool ShowProgressBar { get; set; }
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

        private ToastSettings BuildToastSettings(ToastLevel level, RenderFragment message, string heading, Action? onclick)
        {
            switch (level)
            {
                case ToastLevel.Custom:
                    return new ToastSettings(message, level);
                case ToastLevel.Error:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Error" : heading, message,
                        IconStyle, ErrorClass, ErrorIcon, ShowProgressBar, onclick, level);

                case ToastLevel.Info:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Info" : heading, message,
                        IconStyle, InfoClass, InfoIcon, ShowProgressBar, onclick, level);

                case ToastLevel.Success:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Success" : heading, message,
                        IconStyle, SuccessClass, SuccessIcon, ShowProgressBar, onclick, level);

                case ToastLevel.Warning:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Warning" : heading, message,
                        IconStyle, WarningClass, WarningIcon, ShowProgressBar, onclick, level);
            }

            throw new InvalidOperationException();
        }

        private void ShowToast(ToastLevel level, RenderFragment toastFragment, string heading, Action? onClick)
        {
            InvokeAsync(() =>
            {
                var settings = BuildToastSettings(level, toastFragment, heading, onClick);
                var toast = new ToastInstance
                {
                    Id = Guid.NewGuid(),
                    TimeStamp = DateTime.Now,
                    ToastSettings = settings
                };

                ToastList.Add(toast);

                StateHasChanged();
            });

        }
    }
}

using System;
using Microsoft.AspNetCore.Components;
using TailBlazor.Toast.Services;

namespace TailBlazor.Toast.Configuration
{
    public class ToastSettings
    {
        public ToastSettings(RenderFragment toast, ToastLevel level, bool includeIcons)
        {
            Message = toast;
            Level = level;
            IncludeIcons= includeIcons;
        }

        public ToastSettings(
            string heading,
            RenderFragment message,
            HeroIcons.IconStyle? iconStyle,
            string Class,
            HeroIcons.HeroIcon? icon,
            bool showProgressBar,
            Action? onClick, ToastLevel level,
            bool includeIcons)
        {
            Heading = heading;
            Message = message;
            IconStyle = iconStyle;
            this.Class = Class;
            Icon = icon;
            ShowProgressBar = showProgressBar;
            OnClick = onClick;
            Level = level;
            IncludeIcons = includeIcons;
        }

        public string Heading { get; set; }
        public RenderFragment Message { get; set; }
        public string Class { get; set; }
        public HeroIcons.HeroIcon? Icon { get; set; }
        public HeroIcons.IconStyle? IconStyle { get; set; }
        public bool ShowProgressBar { get; set; }
        public Action? OnClick { get; set; }
        public ToastLevel Level { get; set; }
        public bool IncludeIcons { get; set; }
    }
}
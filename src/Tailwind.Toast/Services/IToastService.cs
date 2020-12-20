using System;
using Microsoft.AspNetCore.Components;

namespace Tailwind.Toast.Services
{
    public interface IToastService
    {
        /// <summary>
        /// A event that will be invoked when showing a toast
        /// </summary>
        event Action<RenderFragment> OnShow;


        /// <summary>
        /// Shows a toast using the supplied fragment
        /// </summary>
        /// <param name="message">RenderFragment of toast to display</param>
        void ShowToast(RenderFragment toast);
    }
}
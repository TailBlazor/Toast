using System;
using Microsoft.AspNetCore.Components;

namespace TailBlazor.Toast.Services
{
    public class ToastService : IToastService
    {
        /// <summary>
        /// A event that will be invoked when showing a toast
        /// </summary>
        public event Action<RenderFragment> OnShow;

        /// <summary>
        /// Shows a toast using the fragment
        /// </summary>
        /// <param name="toast">RenderFragment of toast to display</param>
        public void ShowToast(RenderFragment toast) => OnShow?.Invoke(toast);
    }
}
using System;
using Microsoft.AspNetCore.Components;

namespace TailBlazor.Toast
{
    public partial class TailBlazorToast : IDisposable
    {
        [CascadingParameter] private TailBlazorToasts ToastsContainer { get; set; }

        [Parameter] public Guid ToastId { get; set; }
        [Parameter] public RenderFragment Toast { get; set; }
        [Parameter] public int Timeout { get; set; }

        private CountdownTimer _countdownTimer;

        protected override void OnInitialized()
        {
            _countdownTimer = new CountdownTimer(Timeout);
            _countdownTimer.OnElapsed += () => { Close(); };
            _countdownTimer.Start();
        }

        private void Close()
        {
            ToastsContainer.RemoveToast(ToastId);
        }

        public void Dispose()
        {
            _countdownTimer.Dispose();
            _countdownTimer = null;
        }
    }
}
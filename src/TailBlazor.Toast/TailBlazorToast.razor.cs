using System;
using Microsoft.AspNetCore.Components;
using TailBlazor.Toast.Configuration;

namespace TailBlazor.Toast
{
    public partial class TailBlazorToast : IDisposable
    {
        [CascadingParameter] private TailBlazorToasts ToastsContainer { get; set; }

        [Parameter] public Guid ToastId { get; set; }
        [Parameter] public ToastSettings ToastSettings { get; set; }
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

        private void ToastClick()
        {
            ToastSettings.OnClick?.Invoke();
        }

        public void Dispose()
        {
            _countdownTimer.Dispose();
            _countdownTimer = null;
        }
    }
}
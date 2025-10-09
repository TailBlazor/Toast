using System;
using Microsoft.AspNetCore.Components;
using TailBlazor.Toast.Configuration;

namespace TailBlazor.Toast
{
    public partial class TailBlazorToast : IDisposable
    {
        [CascadingParameter] private TailBlazorToasts ToastsContainer { get; set; } = default!;

        [Parameter] public Guid ToastId { get; set; }
        [Parameter] public ToastSettings ToastSettings { get; set; } = default!;
        [Parameter] public int Timeout { get; set; }

        private CountdownTimer? _countdownTimer;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _countdownTimer = new CountdownTimer(Timeout);
            _countdownTimer.OnElapsed += Close;
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
            if (_countdownTimer is null)
            {
                return;
            }

            _countdownTimer.OnElapsed = null;
            _countdownTimer.Dispose();
            _countdownTimer = null;
        }
    }
}
using System;
using Microsoft.AspNetCore.Components;

namespace TailBlazor.Toast.Configuration
{
    internal class ToastInstance
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public RenderFragment Toast { get; set; }
    }
}
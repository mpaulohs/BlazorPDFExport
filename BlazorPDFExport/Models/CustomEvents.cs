﻿using Microsoft.AspNetCore.Components;

namespace BlazorPDFExport.Models
{
    [EventHandler("oncustompaste", typeof(CustomPasteEventArgs),
    enableStopPropagation: true, enablePreventDefault: true)]
    public static class EventHandlers
    {
    }

    public class CustomPasteEventArgs : EventArgs
    {
        public DateTime EventTimestamp { get; set; }
        public string? PastedData { get; set; }
    }
}

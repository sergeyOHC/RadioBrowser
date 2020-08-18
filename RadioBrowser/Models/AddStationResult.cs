using System;

namespace RadioBrowser.Models
{
    public class AddStationResult
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public Guid Uuid { get; set; }
    }
}
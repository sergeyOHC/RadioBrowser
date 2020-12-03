using System;

namespace RadioBrowser.Models
{
    public class ClickResult : ActionResult
    {
        public Guid StationUuid { get; set; }
        public string Name { get; set; }
        public Uri Url { get; set; }
    }
}
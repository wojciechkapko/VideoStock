using System;

namespace VideoStock.Domain
{
    public class Video : Content
    {
        public TimeSpan Duration { get; set; }
    }
}
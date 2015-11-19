using System;

namespace Auth0.Core.Models
{
    public class DailyStatistics
    {
        public DateTime Date { get; set; }

        public int Logins { get; set; }

        public int SignUps { get; set; }
    }
}
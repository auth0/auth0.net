namespace Auth0.Core.Exceptions
{
    public class QuotaClientLimit
    {
        public QuotaLimit PerHour { get; set; }
        public QuotaLimit PerDay { get; set; }
    }

    public class QuotaOrganizationLimit
    {
        public QuotaLimit PerHour { get; set; }
        public QuotaLimit PerDay { get; set; }
    }

    public class QuotaLimit
    {
        public int Quota { get; set; }
        public int Remaining { get; set; }
        public int Time { get; set; }
    }
}
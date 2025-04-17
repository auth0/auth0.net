namespace Auth0.Core.Exceptions
{
    public class ClientQuotaLimit
    {
        public QuotaLimit PerHour { get; set; }
        public QuotaLimit PerDay { get; set; }
    }

    public class OrganizationQuotaLimit
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
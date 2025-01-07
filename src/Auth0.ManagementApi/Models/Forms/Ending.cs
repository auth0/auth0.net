using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Forms
{
    public class Ending
    {
        [JsonProperty("redirection")]
        public Redirection Redirection { get; set; }
        
        [JsonProperty("after_submit")]
        public AfterSubmit AfterSubmit { get; set; }
        
        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }
        
        [JsonProperty("resume_flow")]
        public bool? ResumeFlow { get; set; }
    }
}
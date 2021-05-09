using System;


namespace rates.External
{
    public class LogActivityRequest
    {
        public string Service { get; }
        public string Activity { get; }
        public string ActivityDetail { get; }


        public LogActivityRequest(
            string activity,
            string activityDetail)
        {
            this.Service = "rates";
            this.Activity = activity;
            this.ActivityDetail = activityDetail;
        } 
    }
}

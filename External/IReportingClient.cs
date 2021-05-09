using System;


namespace rates.External
{
	public interface IReportingClient
    {
        void LogActivity(
            string requestId,
            string correlationId,
            string activity,
            string activityDetail);
    }
}
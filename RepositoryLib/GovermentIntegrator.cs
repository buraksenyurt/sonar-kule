using ModelLib;

namespace RepositoryLib
{
    public class GovermentIntegrator
    {
        public GovermentIntegrator(string notificationAddress)
        {
            NotificationAddress = notificationAddress;
        }

        public string NotificationAddress { get; }

        public bool Connect(string apiKey, string apiPass)
        {
            throw new NotImplementedException();
        }

        public IntegratorResponse PostWaybill(Waybill waybill)
        {
            throw new NotImplementedException();
        }
    }

    public class IntegratorResponse{
        public string Message { get; set; }
        public IntegratorStatus Status { get; set; }
    }
}
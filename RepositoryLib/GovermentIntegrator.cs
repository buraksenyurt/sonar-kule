using ModelLib;

namespace RepositoryLib
{
    internal class GovermentIntegrator
    {
        public GovermentIntegrator(string notificationAddress)
        {
            NotificationAddress = notificationAddress;
        }

        public string NotificationAddress { get; }

        internal bool Connect(string apiKey, string apiPass)
        {
            throw new NotImplementedException();
        }

        internal IntegratorResponse PostWaybill(Waybill waybill)
        {
            throw new NotImplementedException();
        }
    }

    internal class IntegratorResponse{
        public string Message { get; set; }
        public IntegratorStatus Status { get; set; }
    }
}
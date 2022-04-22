using AOM.FIFA.ManagerPlayer.Gateway.Utils.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Gateway.Utils
{
    public class FIFAGatewayConfig : IFIFAGatewayConfig
    {
        public string FIFAApiKey { get; set; }
        public string FIFAApiToken { get; set; }
    }
}

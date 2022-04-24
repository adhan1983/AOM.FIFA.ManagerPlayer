namespace AOM.FIFA.ManagerPlayer.Gateway.Responses.Base
{
    public abstract class BaseRequest
    {
        public int Page { get; set; }
        public int MaxItemPerPage { get; set; }
    }
}

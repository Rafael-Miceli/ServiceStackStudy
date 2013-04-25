using ServiceStack.CacheAccess;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace WebApplicationServiceStackTest
{
    public class RecordIpFilter: RequestFilterAttribute//, IHasRequestFilter
    {
        public ICacheClient Cach { get; set; }

        public override void Execute(IHttpRequest req, IHttpResponse res, object requestDto)
        {
            Cach.Add("ip", req.UserHostAddress);
        }
    }

    public class LastIpFilter : ResponseFilterAttribute
    {
        public ICacheClient Cach { get; set; }

        public override void Execute(IHttpRequest req, IHttpResponse res, object responseDto)
        {
            var status = responseDto as UnitSoldReponse;

            if (status != null)
            {
                status.Result += " Seu IP é: " + Cach.Get<string>("ip");
            }
        }
    }
}
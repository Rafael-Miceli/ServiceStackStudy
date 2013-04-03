using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
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
            Cach.Add("last ip", req.UserHostAddress);
        }
    }

    public class LastIpFilter : ResponseFilterAttribute
    {
        public ICacheClient Cach { get; set; }

        public override void Execute(IHttpRequest req, IHttpResponse res, object responseDto)
        {
            var status = responseDto as HelloWorldReponse;

            if (status != null)
            {
                status.Result += " Last Ip: " + Cach.Get<string>("last ip");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceInterface;

namespace WebApplicationServiceStackTest
{
    public class HelloWorldService: Service
    {
        public object Any(HelloWorld request)
        {
            return new HelloWorldReponse { Result = "Hello Any " + request.Name };
        }

        public object Get(HelloWorld request)
        {
            return new HelloWorldReponse { Result = "Hello Get " + request.Name };
        }

        public object Post(HelloWorld request)
        {
            return new HelloWorldReponse { Result = "Hello Post " + request.Name };
        }
    }
}
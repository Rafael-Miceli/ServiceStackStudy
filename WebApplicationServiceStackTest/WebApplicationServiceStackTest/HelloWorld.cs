using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;

namespace WebApplicationServiceStackTest
{

    [Route("/hello")]
    [Route("/hello/{Name}")]
    [RecordIpFilter]
    //[Authenticate]
    //[RequiredRole("Associate")]
    //[RequiredPermission("GetStatus")]
    public class HelloWorld
    {
        public string Name { get; set; }
    }

    //Atribute to filter
    //[LastIpFilter]
    public class HelloWorldReponse
    {
        public ResponseStatus ResponseStatus { get; set; }

        public string Result { get; set; }
    }
}
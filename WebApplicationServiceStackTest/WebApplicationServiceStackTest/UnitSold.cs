using System;
using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace WebApplicationServiceStackTest
{

    [Route("/unitsold")]
    [Route("/unitsold/{BlocName}/{UnitSolds}/{DateSold}")]
    //[RecordIpFilter]
    //[Authenticate]
    //[RequiredRole("Employee")]
    //[RequiredPermission("SellUnit")]
    public class UnitSold//: IReturn<UnitSoldReponse>
    {
        //[AutoIncrement]
        //public int Id { get; set; }

        public string BlocName { get; set; }
        public int UnitSolds { get; set; }
        public DateTime DateSold { get; set; }
    }

    //Atribute to filter
    //[LastIpFilter]
    public class UnitSoldReponse
    {
        public ResponseStatus ResponseStatus { get; set; }

        public string Result { get; set; }
    }

    //public class UnitSoldValidator: AbstractValidator<UnitSold>
    //{
    //    public UnitSoldValidator()
    //    {
    //        RuleFor(r => r.DateSold).LessThan(DateTime.Now).WithMessage("Não é possivel prevêr vendas futuras!");
    //    }
    //}

}
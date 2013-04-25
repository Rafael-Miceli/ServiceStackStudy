using ServiceStack.CacheAccess;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;

namespace WebApplicationServiceStackTest
{
    public class UnitSoldService : Service
    {

        //public UnitsRepository UnitsSold { get; set; }

        public object Any(UnitSold request)
        {
            return new UnitSoldReponse { Result = "As " + request.UnitSolds + " unidades do bloco " + request.BlocName + " Foram vendidas em " + request.DateSold.ToShortDateString() };



            //var id = UnitsSold.SellUnit(request);

            //return UnitsSold.GetUnitsSold(id, Session, this.GetSession());
        }
    }




    //public class UnitsRepository
    //{
    //    public IDbConnectionFactory DbConnectionFactory { get; set; }

    //    public int SellUnit(UnitSold unit)
    //    {
    //        unit.DateSold = unit.DateSold.Date;
    //        unit.UnitSolds += unit.UnitSolds;

    //        using (var db = DbConnectionFactory.OpenDbConnection())
    //        {
    //            db.CreateTable<UnitSold>();
    //            db.Insert(unit);
    //            return (int)db.GetLastInsertId();
    //        }
    //    }

    //    public UnitSoldReponse GetUnitsSold(int id, ISession session, IAuthSession authSession)
    //    {
    //        using (var db = DbConnectionFactory.OpenDbConnection())
    //        {
    //            var total = db.First<UnitSold>(e => e.Id == id);
    //            return new UnitSoldReponse { Result = "As " + total.UnitSolds + " unidades do bloco " + total.BlocName + " Foram vendidas em " + total.DateSold.ToShortDateString() };
    //        }
    //    }
    //}
}
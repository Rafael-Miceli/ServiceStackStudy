using System;
using System.Collections.Generic;
using System.Web;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.Validation;
using ServiceStack.WebHost.Endpoints;

namespace WebApplicationServiceStackTest
{

    public class Global : HttpApplication
    {

        public class UnitAppHost : AppHostBase
        {
            public UnitAppHost()
                : base("Unit test", typeof(UnitSoldService).Assembly)
            {
                
            }

            public override void Configure(Funq.Container container)
            {
                //register any dependencies your services use, e.g:
                //container.Register<ICacheClient>(new MemoryCacheClient());

                //register the routes, can be in the configure of the asax too
                //Routes.Add<HelloWorld>("/Path");

                //Add the auth feature
                Plugins.Add(new AuthFeature(
                    () => new AuthUserSession(),
                    new IAuthProvider[] {new BasicAuthProvider(), }));

                //Register the Validation Plugin
                Plugins.Add(new ValidationFeature());
                container.RegisterValidators(typeof(UnitSoldService).Assembly);
                

                //Register users
                Plugins.Add(new RegistrationFeature());

                //Add the cache container for the auth
                //container.Register<ICacheClient>(new MemoryCacheClient());

                
                //Caching with Redis
                //container.Register<IRedisClientsManager>(c => new PooledRedisClientManager());
                //container.Register<ICacheClient>(c => (ICacheClient) c.Resolve<IRedisClientsManager>().GetCacheClient());

                //Defines the user repository
                var userRepository =  new InMemoryAuthRepository();
                container.Register<IUserAuthRepository>(userRepository);


                //Add User

                //create hash and salt from password
                string hash;
                string salt;
                const string password = "password";
                new SaltedHash().GetHashAndSaltString(password, out hash, out salt);

                userRepository.CreateUserAuth(new UserAuth()
                    {
                        Id = 1,
                        DisplayName = "Rafael",
                        Email = "rafael.miceli@hotmail.com",
                        UserName = "rafael",
                        FirstName = "Rafael",
                        LastName = "Miceli",
                        Roles = new List<string> {RoleNames.Admin},
                        //Permissions = new List<string>{"GetStatus"},
                        PasswordHash = hash,
                        Salt = salt
                    }, password);


                //var dbConnectionFactory =
                //    new OrmLiteConnectionFactory(HttpContext.Current.Server.MapPath("~/App_Data/data.txt"), true, SqliteDialect.Provider);

                //container.Register<IDbConnectionFactory>(dbConnectionFactory);

                //container.RegisterAutoWired<UnitsRepository>();
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            new UnitAppHost().Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
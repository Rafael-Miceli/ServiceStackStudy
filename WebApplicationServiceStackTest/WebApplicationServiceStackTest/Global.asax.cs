using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;

namespace WebApplicationServiceStackTest
{

    public class Global : System.Web.HttpApplication
    {

        public class HelloWorldAppHost: AppHostBase
        {
            public HelloWorldAppHost() : base("Hello World test", typeof (HelloWorldService).Assembly)
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
                

                //Register users
                Plugins.Add(new RegistrationFeature());

                //Add the cache container for the auth
                container.Register<ICacheClient>(new MemoryCacheClient());

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
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            new HelloWorldAppHost().Init();
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
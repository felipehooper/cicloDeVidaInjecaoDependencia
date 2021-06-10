using Microsoft.AspNetCore.Mvc;
using POC_DI.Services;
using System;
using System.Text;

namespace POC_DI.Controllers
{
	public class UserController : Controller
    {
        public UserService UserService1 { get; }
        public UserService UserService2 { get; }

        public UserController(UserService userService1, UserService userService2)
        {
            UserService1 = userService1;
            UserService2 = userService2;
        }

        public string Index()
        {
            StringBuilder requisicoes = new StringBuilder();

            requisicoes.AppendLine("Usuário 1: ");
            requisicoes.AppendLine("Transient: " + UserService1.Transient.UserId);
            requisicoes.AppendLine("Scoped: " + UserService1.Scoped.UserId);
            requisicoes.AppendLine("Singleton: " + UserService1.Singleton.UserId);
            requisicoes.AppendLine(Environment.NewLine);
            requisicoes.AppendLine(Environment.NewLine);
            requisicoes.AppendLine("Usuário 2: ");
            requisicoes.AppendLine("Transient: " + UserService2.Transient.UserId);
            requisicoes.AppendLine("Scoped: " + UserService2.Scoped.UserId);
            requisicoes.AppendLine("Singleton: " + UserService2.Singleton.UserId);

            return requisicoes.ToString();
        }
    }
}

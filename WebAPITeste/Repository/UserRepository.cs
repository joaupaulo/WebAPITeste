using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITeste.Models;

namespace WebAPITeste.Repository
{
    public static class UserRepository
    {
       public static User Get(string username, string password)
        {
            //fazer conexao com o banco de dados e verificar se existe os dados
            var users = new List<User>();
            users.Add(new User { UniqueId = 1 , Username = "João Paulo", Passowrd = "admin123", Role = "manager" });
            users.Add(new User { UniqueId = 2, Username = "João Paulo", Passowrd = "admin123", Role = "manager" });

            return users.Where(x => x.Username != null).FirstOrDefault();
        }
    }
    }


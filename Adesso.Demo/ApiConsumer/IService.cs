using Adesso.Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adesso.Demo.ApiConsumer
{
    internal interface IService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        User GetUser(string username);
    }
}

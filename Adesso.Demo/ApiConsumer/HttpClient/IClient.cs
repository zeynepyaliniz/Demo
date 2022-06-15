using Adesso.Demo.Models;
using System.Collections.Generic;

namespace Adesso.Demo.ApiConsumer
{
    public interface IClient
    {
        public IEnumerable<User> GetUsers();
        public User GetUserById(int id);
        public User GetUserByUsername(string username);

    }
}
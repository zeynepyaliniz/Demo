using Adesso.Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adesso.Demo.ApiConsumer
{
    internal class Service : IService
    {
        private readonly IClient _client;
        public Service(IClient client)
        {
            _client =  client ?? throw new ArgumentNullException(nameof(client));
        }

        public User GetUser(int id)
        {
            try
            {
               var user = _client.GetUserById(id);
                return user;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetUser(string username)
        {
            try
            {
                var user =_client.GetUserByUsername(username);
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            try
            {
               var users = _client.GetUsers();
                return users;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

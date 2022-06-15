using Adesso.Demo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Adesso.Demo.ApiConsumer
{
    public class Client : IClient
    {
        private const string url = @"https://jsonplaceholder.typicode.com/users";
        private readonly HttpClient _httpClient;
        public Client()
        {
            _httpClient = new HttpClient();
        }
        public IEnumerable<User> GetUsers()
        {
            var response = _httpClient.GetStringAsync(url).GetAwaiter().GetResult();
            if (response is null)
            {
                return null;
            }
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(response);

            return users;
        }
        public User GetUserById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException($"Id : {id} cannot be lower than and equal zero (0)");
            }
            var _uri = $"{url}/{id}";
            var response = _httpClient.GetStringAsync(_uri).GetAwaiter().GetResult();
            var user = JsonConvert.DeserializeObject<User>(response);
            return user;
        }
        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException($"Username : {username} cannot be null!");
            }
            var _uri = $"{url}/{username}";
            var response = _httpClient.GetStringAsync(_uri).GetAwaiter().GetResult();
            var user = JsonConvert.DeserializeObject<User>(response);
            return user;
        }

    }
}


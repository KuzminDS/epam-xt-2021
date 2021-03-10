using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint
{
    public class UserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>();
        }

        public void Add(User user)
        {
            if (_users.Select(u => u.Name).Contains(user.Name))
                throw new Exception($"User with name {user.Name} already exists");
            _users.Add(user);
        }

        public User GetByName(string name)
        {
            var user = _users.Where(u => u.Name == name).FirstOrDefault();
            if (user == null)
                throw new Exception($"User with name {user.Name} doesn't exist");
            return user;
        }
    }
}

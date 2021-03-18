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
            if (_users.Any(u => u.Name == user.Name))
                throw new Exception($"User with name {user.Name} already exists");
            _users.Add(user);
        }

        public User GetByName(string name)
        {
            return _users.FirstOrDefault(u => u.Name == name);
        }
    }
}

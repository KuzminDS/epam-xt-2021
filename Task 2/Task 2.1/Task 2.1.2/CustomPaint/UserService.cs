using CustomPaint.Entities;
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
            if (user.Name == string.Empty)
                throw new Exception("Имя пользователя не может быть пустым");

            if (_users.Any(u => u.Name == user.Name))
                throw new Exception($"Пользователь с именем {user.Name} уже существует");

            _users.Add(user);
        }

        public User GetByName(string name)
        {
            return _users.FirstOrDefault(u => u.Name == name);
        }

        public User ChangeUser(string name)
        {
            var user = GetByName(name);

            if (user == null)
            {
                user = new User(name, new List<GeometricEntity>());
                Add(user);
            }

            return user;
        }
    }
}

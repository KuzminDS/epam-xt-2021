using CustomPaint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint
{
    public class Painter
    {
        private readonly UserService _userService;

        public Painter(UserService userService)
        {
            _userService = userService;
        }

        public User ChangeUser(string name)
        {
            var user = _userService.GetByName(name);

            if (user == null)
            {
                user = new User
                {
                    Name = name,
                    Shapes = new List<GeometricEntity>()
                };
                _userService.Add(user);
            }

            return user;
        }

        public IEnumerable<GeometricEntity> GetShapes(User user)
        {
            return user.Shapes;
        }

        public void AddShape(User user, GeometricEntity shape)
        {
            user.Shapes.Add(shape);
        }

        public void ClearShapes(User user)
        {
            user.Shapes.Clear();
        }
    }
}

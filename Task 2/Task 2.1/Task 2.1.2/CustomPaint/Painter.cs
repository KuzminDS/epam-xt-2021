using CustomPaint.Entities;
using FluentValidation;
using FluentValidation.Results;
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
            return _userService.ChangeUser(name);
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

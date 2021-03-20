using CustomPaint.Entities;
using CustomPaint.Validators;
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

        public void AddShape(User user, GeometricEntity shape, out ICollection<ValidationFailure> errorList)
        {
            errorList = new List<ValidationFailure>();
            if (shape is Circle circle)
            {
                var validator = new CircleValidator();
                var results = validator.Validate(circle);
                if (results.IsValid)
                    user.Shapes.Add(circle);
                else
                    errorList = results.Errors;
            }
            else if (shape is Rectangle rectangle)
            {
                var validator = new RectangleValidator();
                var results = validator.Validate(rectangle);
                if (results.IsValid)
                    user.Shapes.Add(rectangle);
                else
                    errorList = results.Errors;
            }
            else if (shape is Triangle triangle)
            {
                var validator = new TriangleValidator();
                var results = validator.Validate(triangle);
                if (results.IsValid)
                    user.Shapes.Add(triangle);
                else
                    errorList = results.Errors;
            }
            else
            {
                user.Shapes.Add(shape);
            }
        }

        public void ClearShapes(User user)
        {
            user.Shapes.Clear();
        }
    }
}

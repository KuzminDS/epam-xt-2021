using CustomPaint.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Validators
{
    public class RectangleValidator : AbstractValidator<Rectangle>
    {
        public RectangleValidator()
        {
            RuleFor(rectangle => rectangle.Color).IsInEnum();
            RuleFor(rectangle => rectangle.Height).GreaterThan(0);
            RuleFor(rectangle => rectangle.Width).GreaterThan(0);
        }
    }
}

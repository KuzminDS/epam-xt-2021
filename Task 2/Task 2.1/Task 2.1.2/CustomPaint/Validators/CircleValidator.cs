using CustomPaint.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Validators
{
    public class CircleValidator : AbstractValidator<Circle>
    {
        public CircleValidator()
        {
            RuleFor(circle => circle.Color).IsInEnum();
            RuleFor(circle => circle.Radius).GreaterThan(0);
        }
    }
}

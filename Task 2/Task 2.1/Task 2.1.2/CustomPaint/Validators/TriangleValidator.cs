using CustomPaint.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Validators
{
    public class TriangleValidator : AbstractValidator<Triangle>
    {
        public TriangleValidator()
        {
            RuleFor(tri => tri.Color).IsInEnum();
            RuleFor(tri => tri).Custom((tri, context) =>
                {
                    var p1 = tri.Line1.P1;
                    var p2 = tri.Line2.P1;
                    var p3 = tri.Line3.P1;
                    if ((p3.X - p1.X) / (p2.X - p1.X) == (p3.Y - p1.X) / (p2.Y - p1.X))
                    {
                        context.AddFailure("Точки треугольника лежат на одной прямой");
                    }
                });
        }
    }
}

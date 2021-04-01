﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    public class Player : MovableObject
    {
        public override void Move(Point newPosition)
        {
            Position = newPosition;
        }
    }
}

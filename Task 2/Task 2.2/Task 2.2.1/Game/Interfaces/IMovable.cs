﻿using Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    interface IMovable : ILocated
    {
        void Move(Point newPosition);
    }
}

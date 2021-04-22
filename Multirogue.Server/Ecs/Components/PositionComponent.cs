using System;
using System.Collections.Generic;
using Multirogue.Common;
using Multirogue.Server.Ecs;

namespace Multirogue.Server.Esc.Components
{
    public class PositionComponent : Component
    {
        public PositionComponent(int x, int y) :
            base(ComponentType.Position)
        {
            PosX = x;
            PosY = y;
        }

        public int PosX { get; set; }
        public int PosY { get; set; }
    }
}
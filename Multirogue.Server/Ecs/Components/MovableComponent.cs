using System;
using System.Collections.Generic;
using Multirogue.Common;
using Multirogue.Server.Ecs;

namespace Multirogue.Server.Esc.Components
{
    public class MovableComponent : Component
    {
        public MovableComponent(int moveActionPointCost) :
            base(ComponentType.Movable)
        {
            MoveActionPointCost = moveActionPointCost;
            RequiredComponents = new List<ComponentType>(){ ComponentType.Actor, ComponentType.Position };
        }
        
        public int MoveActionPointCost { get; }
    }
}
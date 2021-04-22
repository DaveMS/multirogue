using System;
using System.Collections.Generic;
using Multirogue.Common;

namespace Multirogue.Server.Ecs
{
    public class Component
    {
        public Component(ComponentType componentType)
        {
            Id = Guid.NewGuid();
            CompType = componentType;
        }

        public Guid Id { get; }
        public ComponentType CompType { get; }
        public Entity OwnerEntity { get; set;}
        public List<ComponentType> RequiredComponents { get; set; } = new List<ComponentType>(); 
    }
}
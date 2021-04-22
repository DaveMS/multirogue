using System;
using Multirogue.Common;
using Multirogue.Server.Ecs;

namespace Multirogue.Server.Esc.Components
{
    public class NameComponent : Component
    {
        public NameComponent(string name) : base(ComponentType.Name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
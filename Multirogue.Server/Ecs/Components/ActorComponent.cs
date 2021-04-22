using System;
using Multirogue.Common;
using Multirogue.Server.Ecs;

namespace Multirogue.Server.Esc.Components
{
    public class ActorComponent : Component
    {
        public ActorComponent(int actionPoints, int initiative, Guid owner) :
            base(ComponentType.Actor)
        {
            ActionPoints = actionPoints;
            MaxActionPoints = actionPoints;
            Initiative = initiative;
            Owner = owner;
        }

        public int ActionPoints { get; set; }
        public int MaxActionPoints { get; set; }
        public int Initiative { get; set; }
        public bool IsOurTurn { get; set; }
        public Guid Owner { get; set; }
    }
}
using System;

namespace Multirogue.Server
{
    public class Player
    {
        public Player(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public Guid Id { get;  }
        public string Name { get; }
    }
}

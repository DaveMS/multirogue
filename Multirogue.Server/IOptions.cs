
using System;
using System.Collections.Generic;
namespace Multirogue.Server
{
    public interface IOptions
    {
        public List<Guid> ExpectedPlayers {get;}
    }
}
using System;
using System.Collections.Generic;

namespace Multirogue.Server
{
    public class Options : IOptions
    {
        public List<Guid> ExpectedPlayers => new() { new Guid("215903d3-88e8-4203-a034-affcbc66af89")};
    }
}
using System;
using Multirogue.Common.Commands;
using Multirogue.Common.Events;

namespace Multirogue.Server.PlayerInterface
{
    public interface IPlayerInterface
    {
        void Start();
        void Stop();
    }
}
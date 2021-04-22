using System;
using Multirogue.Common.Commands;
using Newtonsoft.Json;

namespace Multirogue.Server.PlayerInterface.Networking
{
    public static class JsonCommandDeserialiser
    {
        public static Command DeserialiseMessage(string json)
        {
            dynamic command = JsonConvert.DeserializeObject(json);
            var commandType = (CommandType)command.CommandType;
            
            return commandType switch
            {
                CommandType.JoinGame => JsonConvert.DeserializeObject<JoinGameCommand>(json),
                _ => throw new InvalidOperationException($"Can not deserialise message with command type {command.CommandType}"),
            };
        }
    }
}
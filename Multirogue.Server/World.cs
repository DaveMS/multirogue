using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Multirogue.Server.Ecs;
using Multirogue.Server.WorldMap;

namespace Multirogue.Server
{
    public class World
    {

        public void GenerateMap(MapGenerator mapGenerator)
        {
            var (map, entities) = mapGenerator.CreateMap();
            Map = map;
            _entities = entities;
        }

        public Map Map { get; private set;}

        public ReadOnlyCollection<Entity> Entities { get => _entities.AsReadOnly(); }

        public ReadOnlyCollection<Player> Players { get => _players.AsReadOnly(); }

        private List<Entity> _entities = new List<Entity>();

        private List<Player> _players =  new List<Player>();

        public void AddPlayer(Guid id, string name)
        {
            _players.Add(new Player(id, name));
        }
    }
}
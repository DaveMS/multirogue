using System;
using System.Collections.Generic;
using Multirogue.Common;
using Multirogue.Server.Ecs;
using Multirogue.Server.Esc.Components;

namespace Multirogue.Server.WorldMap
{
    public class MapGenerator
    {
        private MapGenerationParameters _mapGenerationParameters;
        public MapGenerator(MapGenerationParameters mapGenerationParameters)
        {
            _mapGenerationParameters = mapGenerationParameters;
        }

        public (Map map, List<Entity> entities) CreateMap()
        {
            var map = new Map(_mapGenerationParameters.Width, _mapGenerationParameters.Height);
            
            var roomWidth = 8;
            var roomHeight = 5;
            var roomX = 3;
            var roomY = 3;

            for(int x = roomX; x < roomX + roomWidth; x++)
            {
                for(int y = roomY; y < roomY + roomHeight; y++)
                {
                    map.Tiles[x, y].TileType = MapTileType.Wall;
                }
            }

            for (int x = roomX + 1; x < roomX - 1  + roomWidth; x++)
            {
                for (int y = roomY + 1; y < roomY - 1 + roomHeight; y++)
                {
                    map.Tiles[x, y].TileType = MapTileType.Floor;
                }
            }

            var entities = new List<Entity>();

            var playerEntity = new Entity("player_character");
            playerEntity.AddComponent(new NameComponent("Boris"));
            playerEntity.AddComponent(new ActorComponent(15, 10, Guid.Empty));
            playerEntity.AddComponent(new PositionComponent(5, 5));
            playerEntity.AddComponent(new MovableComponent(3));
            
            entities.Add(playerEntity);
            map.Tiles[5, 5].ContainedEntities.Add(playerEntity);
            
            return (map, entities);
        }
    }
}
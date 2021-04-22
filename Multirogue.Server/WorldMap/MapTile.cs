using System.Collections.Generic;
using Multirogue.Server.Ecs;

namespace Multirogue.Server.WorldMap
{
    public class MapTile
    {
        public MapTileType TileType { get; set; } = MapTileType.None;
        public List<Entity> ContainedEntities { get; set; } = new List<Entity>();
    }
}
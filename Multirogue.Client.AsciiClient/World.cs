using System;
using SadConsole.Components;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Multirogue.Client.AsciiClient
{
    // All game state data is stored in World
    // also creates and processes generators
    // for map creation
    public class World
    {
        public List<Player> Players { get; set; } = new List<Player>();
        // map creation and storage data
        private int _mapWidth = 100;
        private int _mapHeight = 100;
        private TileBase[] _mapTiles;
        private int _maxRooms = 100;
        private int _minRoomSize = 4;
        private int _maxRoomSize = 15;
        public Map CurrentMap { get; set; }

        // player data
        public Player Player { get; set; }

        // Creates a new game world and stores it in
        // publicly accessible
        public World()
        {
            // Build a map
            CreateMap();
        }

        // Create a new map using the Map class
        // and a map generator. Uses several 
        // parameters to determine geometry
        private void CreateMap()
        {
            _mapTiles = new TileBase[_mapWidth * _mapHeight];
            for(int i = 0; i < _mapWidth * _mapHeight; i++)
            {
                _mapTiles[i] = new TileFloor();
            }
            CurrentMap = new Map(_mapWidth, _mapHeight);
            CurrentMap.Tiles = _mapTiles;
        }
    }
}
using System;
using Microsoft.Xna.Framework;
using SadConsole;

namespace Multirogue.Client.AsciiClient
{
    // TileWall is based on TileBase
    public class TileWall : TileBase
    {
        // Default constructor
        // Walls are set to block movement and line of sight by default
        // and have a light gray foreground and a transparent background
        // represented by the # symbol
        public TileWall(bool blocksMovement=true, bool blocksLOS=true) : base(Color.LightGray, Color.Transparent, '#', blocksMovement, blocksLOS)
        {
            Name = "Wall";
        }
    }
}
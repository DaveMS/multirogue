namespace Multirogue.Server.WorldMap
{
    public class Map
    {
        public Map(int width, int height)
        {
            Tiles = new MapTile[width, height];
            Width = width;
            Height = height;
            
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    Tiles[i,j] = new MapTile();
                }
            }
        }

        public Map(int width, int height, MapTile[,] tiles)
        {
            Tiles = tiles;
            Width = width;
            Height = height;
        }

        public MapTile[,] Tiles { get; }
        public int Width { get; }
        public int Height { get; }
    }
}
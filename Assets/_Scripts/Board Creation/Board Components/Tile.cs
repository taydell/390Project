namespace Assets._Scripts
{
    public class Tile
    {
        private readonly int _xPosition;
        private readonly int _zPosition;

        public readonly bool isBlack;

        public int GetXPosition()
        {
            return _xPosition;
        }

        public int GetZPosition()
        {
            return _zPosition;
        }

        public Tile(int x, int z)
        {
            _xPosition = x;
            _zPosition = z;

            isBlack = (x + z) % 2 == 0;
        }
    }
}
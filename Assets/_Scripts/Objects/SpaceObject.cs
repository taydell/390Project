using UnityEngine;
using System.Collections;


namespace Assets._Scripts
{
    public class SpaceObject
    {
        private int _xPosition;
        private int _yPosition;
        private int _zPosition;

        private bool _isOccupied;

        public int GetXPosition()
        {
            return _xPosition;
        }
        public void SetXPosition(int xPosition)
        {
            this._xPosition = xPosition;
        }
        public int GetYPosition()
        {
            return _yPosition;
        }
        public void SetYPosition(int yPosition)
        {
            this._yPosition = yPosition;
        }
        public int GetZPosition()
        {
            return _zPosition;
        }
        public void SetZPosition(int zPosition)
        {
            this._zPosition = zPosition;
        }

        public bool GetIsOccupied()
        {
            return _isOccupied;
        }
        public void SetIsOccupied(bool isOccupied)
        {
            this._isOccupied = isOccupied;
        }
    }
}
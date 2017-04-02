using UnityEngine;
using System.Collections;


namespace Assets._Scripts
{
    public class SpaceObject
    {
        private readonly int _xPosition;
        private readonly int _zPosition;
        private bool _isOcuppied;
        private bool _isAvailable;

        public readonly bool isBlack;

        public bool GetIsOcuppied() { 
            return _isOcuppied;
        }
        public bool GetIsAvailable() { 
            return _isAvailable;
        }

        public int GetXPosition(){
            return _xPosition;
        }

        public int GetZPosition(){
            return _zPosition;
        }

        public SpaceObject(int x, int z)
        {
            _xPosition = x;
            _zPosition = z;
            _isOcuppied = false;
            _isAvailable = true;

            isBlack = (x + z) % 2 == 0;
        }

        public void SetOccupied()
        {
            _isOcuppied = true;
            _isAvailable = false;
        }

        public void SetUnoccupied()
        {
            _isOcuppied = false;
        }

        public void SetUnavailable()
        {
            _isAvailable = false;
        }

        public void SetAvailable()
        {
            _isAvailable = true;
        }

    }
}
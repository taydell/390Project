using UnityEngine;
using System.Collections;

    namespace Assets._Scripts
{
    public class QueenObject

    {
        private int _id;
        private int _xPosition;
        private int _yPosition;
        private int _zPosition;

        public int GetId()
        {
            return _id;
        }
        public void SetId(int id)
        {
            this._id = id;
        }
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
    }
}



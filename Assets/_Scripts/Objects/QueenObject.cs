using UnityEngine;
using System.Collections;

namespace Assets._Scripts
{
    public class QueenObject
    {
        private Transform _prefab;
        private int _xPosition;
        private int _zPosition;

        public QueenObject(Transform prefab, int xPosition, int zPosition)
        {
            _prefab = prefab;
            _xPosition = xPosition;
            _zPosition = zPosition;
        }

        public int GetXPosition()
        {
            return _xPosition;
        }

        public int GetZPosition()
        {
            return _zPosition;
        }

        public Transform GetQueenPrefab()
        {
            return _prefab;
        }

        public void SetZPosition(int zPosition)
        {
            _zPosition = zPosition;
        }
    }
}
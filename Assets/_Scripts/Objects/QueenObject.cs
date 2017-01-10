using UnityEngine;
using System.Collections;

namespace Assets._Scripts
{
    public class QueenObject
    {
        private Transform _prefab;
        private Vector3 _position;

        public QueenObject(Transform prefab, Vector3 position)
        {
            _prefab = prefab;
            _position = position;
            new MoveQueen(_position);
        }

        public Vector3 GetPosition()
        {
            return _position;
        }

        public Transform GetQueenPrefab()
        {
            return _prefab;
        }
    }
}
using UnityEngine;
using System.Collections;

namespace Assets._Scripts
{
    public class QueenObject
    {
        private readonly int _id;

        public QueenObject(int id)
        {
            _id = id;
        }
        public int GetId()
        {
            return _id;
        }
    }
}
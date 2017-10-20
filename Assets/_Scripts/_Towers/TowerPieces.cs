using UnityEngine;

public class TowerPieces : MonoBehaviour
{
    private int _pieceNumber;
    private float _ySize;
    public Transform _pieces;

    public TowerPieces(int pieceNumber, float ySize, Transform prefab)
    {
        _pieceNumber = pieceNumber;
        _ySize = ySize;
        _pieces = prefab;
    }

    public int GetPieceNumber()
    {
        return _pieceNumber;
    }

    public float GetYSize()
    {
        return _ySize;
    }
}

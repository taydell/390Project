using UnityEngine;
using System.Collections;
using Assets._Scripts;
using System.Collections.Generic;

public class Row : MonoBehaviour 
{
    private List<SpaceObject> rows = new List<SpaceObject>();
    private static List<QueenObject> _queen = new List<QueenObject>();
    private GameObject chessPieces = GameObject.Find("ChessPieces");
     
    public Row(int rowNum, int size, Transform QueenPrefab)
    {   
        var row = new List<SpaceObject>();

        for (int i = 0; i < size; i++) 
        {
            rows.Add(new SpaceObject(rowNum, i));
        }

        InstantiateQueen(rowNum, QueenPrefab);
    }

    public List<SpaceObject> GetSpaceObjects()
    {
        return rows;
    }

    public static List<QueenObject> GetQueens()
    {
        return _queen;
    }

    void InstantiateQueen( int rowNum, Transform queenPrefab)
    {
        Transform chessPiece = (Instantiate(queenPrefab, new Vector3(rowNum, 0, -2), Quaternion.identity)) as Transform;
        _queen.Add(new QueenObject(queenPrefab,rowNum,-2));
        if (chessPieces != null)
            SetQueenParent(chessPiece);
    }

    void SetQueenParent(Transform chessPiece)
    {
        chessPiece.parent = chessPieces.GetComponent<Transform>();
    }
}

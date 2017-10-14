using UnityEngine;
using System.Collections;
using Assets._Scripts;
using System.Collections.Generic;

public class Row : MonoBehaviour 
{
    public List<Tile> rows = new List<Tile>();
    public Transform rowQueen;

    private GameObject chessPieces = GameObject.Find("ChessPieces");
    private bool hasQueen;
     
    public Row(int rowNum, int size, Transform QueenPrefab)
    {   
        var row = new List<Tile>();

        for (int i = 0; i < size; i++) 
        {
            rows.Add(new Tile(rowNum, i));
        }

        InstantiateQueen(rowNum, QueenPrefab);
    }

    public List<Tile> GetSpaceObjects()
    {
        return rows;
    }

    void InstantiateQueen( int rowNum, Transform queenPrefab)
    {
        Transform chessPiece = (Instantiate(queenPrefab, new Vector3(rowNum, 0, -2), Quaternion.identity)) as Transform;
        rowQueen = chessPiece;

        if (chessPieces != null)
            SetQueenParent(chessPiece);
    }

    void SetQueenParent(Transform chessPiece)
    {
        chessPiece.parent = chessPieces.GetComponent<Transform>();
    }

    public bool DoesRowHaveQueen()
    {
        return hasQueen;
    }

    public void setQueenToRow(bool status)
    {
        hasQueen = status;
    }
}

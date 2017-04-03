using UnityEngine;
using System.Collections;
using Assets._Scripts;
using System.Collections.Generic;

public class Row : MonoBehaviour 
{
    public List<SpaceObject> rows = new List<SpaceObject>();
    public Transform rowQueen;
    private GameObject chessPieces = GameObject.Find("ChessPieces");
    private bool hasQueen;
     
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

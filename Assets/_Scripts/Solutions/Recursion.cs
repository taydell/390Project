using UnityEngine;
using Assets._Scripts;
using System.Collections.Generic;

public class Recursion : MonoBehaviour {

    private List<Row> board;
    int QueensXPos;
    int QueensZPos;
    List<QueenObject> _queens = Row.GetQueens();
    bool moved = false;
    // Use this for initialization
    public void OnClick()
    {
        
        board = CreateBoard.board;
        test();
    }

    void test()
    {
        foreach(var row in board)
        {
            foreach (var space in row.GetSpaceObjects())
            {
                foreach (var queen in _queens) {

                    Debug.Log(queen.GetPosition());
                }
            }
        };
        
    }
    
    void moveQueen()
    {
        if (moved)
        {
            _queens[0].GetQueenPrefab().localPosition = new Vector3(0,0,0);
            moved = false;

        }
    }

    void Update()
    {
        moveQueen();
    }


}

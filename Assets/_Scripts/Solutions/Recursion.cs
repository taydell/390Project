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
                    if (space.GetXPosition() == 0 && queen.GetXPosition() == 0)
                    {

                        _queens[space.GetXPosition()].SetZPosition(0);
                        moved = true;
                    }
                    //Debug.Log(space.GetXPosition());
                }
            }
        };
        
    }
    
    void moveQueen()
    {
        if (moved)
        {
            _queens[0].GetQueenPrefab().Translate(new Vector3(0,0,0));
            moved = false;
        }
    }

    void Update()
    {
       
    }


}

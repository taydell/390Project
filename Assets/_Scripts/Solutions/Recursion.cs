using UnityEngine;
using Assets._Scripts;
using System.Collections;
using System.Collections.Generic;

public class Recursion : MonoBehaviour {

    private List<Row> board;
    int QueensXPos;
    int QueensZPos;
    bool moved;
    bool isMoving;
    //private float speed = 5f;
    private float smoothing = 1f; // speed of queens when moving

    // Use this for initialization
    public void OnClick()
    {
        moved = false;
        isMoving = false;
        board = CreateBoard.board;
        test();
    }

    void test()
    {
        foreach(var row in board)
        {
            foreach (var space in row.GetSpaceObjects())
            {
                if(!space.GetIsOcuppied() && space.GetIsAvailable() &&  moved == false)
                {
                    moved = true;

                    //StartCoroutine(moveQueen(row.rowQueen, new Vector3(space.GetXPosition(), 0, space.GetZPosition()))); // moves 
                    //space.SetOccupied();
                    //SetUnavailable(space);
                }
            }
            moved = false;
        }
        var th = 0;
        
    }

    void SetUnavailable(SpaceObject boardSpace)
    {
        int rowCount = 0;
        bool isCountSet = false;
        foreach (var row in board)
        {
            foreach (var space in row.GetSpaceObjects())
            {
                if(space.GetXPosition() == boardSpace.GetXPosition() && !isCountSet)
                {
                    rowCount = 0; 
                    isCountSet = true;
                }
                if (space.GetIsAvailable() && space.GetXPosition() == boardSpace.GetXPosition() || space.GetZPosition() == boardSpace.GetZPosition() || space.GetZPosition() == boardSpace.GetZPosition() + rowCount ||space.GetZPosition() == boardSpace.GetZPosition() - rowCount)
                {
                    space.SetUnavailable();
                }
            }
            rowCount++;
        }
    }
    
    IEnumerator moveQueen(Transform currentQueen, Vector3 target)
    {
        while (Vector3.Distance(currentQueen.position, target) > .05f)
        {
            currentQueen.position = Vector3.Lerp(currentQueen.position, target, smoothing * Time.deltaTime);
            yield return null;
        }
        yield return null;
    }

    /*
     * loop to find queen positions
     * add(start pos,end pos,row#) to que
     * once calcutions done use que
     * once calculations done use que for movements
     */
}

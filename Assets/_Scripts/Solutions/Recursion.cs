using UnityEngine;
using Assets._Scripts;
using System.Collections;
using System.Collections.Generic;

public class Recursion : MonoBehaviour {

    private List<Row> board;
    private Queue<IEnumerator> queenQueue = new Queue<IEnumerator>();
    int QueensXPos;
    int QueensZPos;
    bool moved;
    bool moving = false;
    bool isSolved;
    const int Size = 4;
    private float smoothing = 1f; // speed of queens when moving

    // Use this for initialization
    public void OnClick()
    {
        //moved = false;
        //isSolved = false;
        board = CreateBoard.board;
        //test();
        GetSolution();

    }

    void test()
    {
        for (int i = 0; i < board.Count; i++) // Loop through List with for
        {
            for (int j = 0; j < board[i].rows.Count; j++) // Loop through List with for
            {
                var row = board[i];
                var space = board[i].rows[j];

                if (!space.GetIsOcuppied() && space.GetIsAvailable() && moved == false)
                {
                    moved = true;

                    //StartCoroutine(moveQueen(row.rowQueen, new Vector3(space.GetXPosition(), 0, space.GetZPosition()))); // moves 
                    //space.SetOccupied();
                    //SetUnavailable(space);
                }
            }
            moved = false;
            if (board[board.Count - 1].DoesRowHaveQueen())
            {
                Debug.Log("Found All Queen Positions!");
            }
        }
        /* while (!isSolved)
         {
             foreach (var row in board)
             {
                 foreach (var space in row.GetSpaceObjects())
                 {
                     if (!space.GetIsOcuppied() && space.GetIsAvailable() && moved == false)
                     {
                         moved = true;

                         //StartCoroutine(moveQueen(row.rowQueen, new Vector3(space.GetXPosition(), 0, space.GetZPosition()))); // moves 
                         //space.SetOccupied();
                         //SetUnavailable(space);
                     }

                     if (space.GetXPosition() == board.Count && space.GetIsOcuppied() == true)
                     {
                         isSolved = true;
                     }
                 }
                 moved = false;
             }
         }*/
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
            //yield return null;
        }
        StartCoroutine(DoLast());
        yield return null;
    }

    IEnumerator DoLast()
    {
        moving = false;
        yield return null;
    }
    public void GetSolution()
    {
        int line = 0, pos = -1;
        bool finished = false;
        int[] positions = new int[Size];
        for (int m = 0; m < positions.Length; m++)
            positions[m] = -1;
        while (true)
        {
            for (pos = positions[line] + 1; pos < Size; pos++)
            {
                int i = 0;
                for (i = 0; i < line; i++)
                {
                    int dis = line - i;
                    if (positions[i] == pos || positions[i] == pos + dis || positions[i] == pos - dis)
                        break;
                }
                if (i == line && !finished)
                {
                    positions[line] = pos;
                    //Debug.Log("Q: (" + line + "," + pos + ")");
                    //queenQueue.Enqueue(new Vector3(line,0,pos));
                    queenQueue.Enqueue(moveQueen(board[line].rowQueen, new Vector3(line,0,pos)));

                    line++;
                    if (line == Size)
                    {
                        foreach (int item in positions)
                        {
                            for (int j = 0; j < Size; j++)
                            {
                                if (j == item) { }  
                            }
                        }
                        line=0;
                        finished = true;
                    }
                    else
                        break;
                }
            }
            if (pos == Size)
            {
                if (line == 0)
                {
                    while (queenQueue.Count > 0)
                    {
                        if (!moving){
                            moving = true;    
                            IEnumerator queenPos = queenQueue.Dequeue();
                            StartCoroutine(queenPos);

                            Debug.Log("here");
                           // moving = false;
                            //WaitForSeconds(10);
                            //Debug.Log("x:" + queenPos.x + " z:" + queenPos.z); 
                        }
                    }

                    //moving = true;
                    Debug.Log("Over");
                    break;
                }
                else
                {
                    Vector3 startingPos = new Vector3(line, 0, -2);
                    positions[line] = -1;
                    if(board[line].rowQueen.position != startingPos)
                        queenQueue.Enqueue(moveQueen(board[line].rowQueen, startingPos));
                    line--;
                }
            }
        }
    }

    void Update()
    {
        if (moving)
        {
            while (queenQueue.Count > 0)
            {
                //Vector3 queenPos = queenQueue.Dequeue();
               
                //StartCoroutine(moveQueen(board[(int)queenPos.x].rowQueen, queenPos));
                //Debug.Log("x:" + queenPos.x + " z:" + queenPos.z);
            }
        }
    }

    /*
     * loop to find queen positions
     * add(start pos,end pos,row#) to que
     * once calcutions done use que
     * once calculations done use que for movements
     */
}

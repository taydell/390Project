using UnityEngine;
using Assets._Scripts;
using System.Collections;
using System.Collections.Generic;

public class RecursiveSolution : MonoBehaviour
{
    private List<Row> board;
    private Queue<IEnumerator> queenQueue = new Queue<IEnumerator>();
    private int _size;
    private MoveQueen _moveQueen;
    private Vector3 startingPos;

    // Use this for initialization
    public void OnClick()
    {
        if (GlobalVariables.algorythmRunning == null)
        {
            GlobalVariables.algorythmRunning = this;
            board = CreateBoard.board;
            _moveQueen = new MoveQueen(this);

            if (!GlobalVariables.isSolved)
            {
                _size = board.Count;

                BruteForceSolution();
            }
        }
        else
        {
            Noty.instance.Display("Warning!", "You Are already running that solution!", 3f);
        }
    }

    public void BruteForceSolution()
    {
        int line = 0, pos = -1;
        bool finished = false;
        int[] positions = new int[_size];
        for (int m = 0; m < positions.Length; m++)
            positions[m] = -1;
        while (true)
        {
            for (pos = positions[line] + 1; pos < _size; pos++)
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
                    queenQueue.Enqueue(_moveQueen.SetMoveCoroutine(board[line].rowQueen, new Vector3(line, 0, pos),board.Count));
                    line++;
                    if (line == _size)
                    {
                        foreach (int item in positions)
                        {
                            for (int j = 0; j < _size; j++)
                            {
                                if (j == item) { }
                            }
                        }
                        line = 0;
                        finished = true;
                    }
                    else
                        break;
                }
            }
            if (pos == _size)
            {
                if (line == 0)
                {
                    _moveQueen.Move(queenQueue);
                    GlobalVariables.isSolved = true;
                    break;
                }
                else
                {
                    startingPos = new Vector3(line, 0, -2);
                    positions[line] = -1;
                    queenQueue.Enqueue(_moveQueen.SetMoveCoroutine(board[line].rowQueen, startingPos, board.Count));
                    line--;
                }
            }
        }
    }
}

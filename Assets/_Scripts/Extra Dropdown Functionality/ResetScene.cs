using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetScene : MonoBehaviour
{
    private List<Row> board;
    private MoveQueen _moveQueen;
    private Queue<IEnumerator> _queenQueue = new Queue<IEnumerator>();
    private static MonoBehaviour m_Owner;
    private static CoroutineQueue _coroutineQueue;

    public ResetScene(MonoBehaviour owner, CoroutineQueue ownersQueue)
    {
        m_Owner = owner;
        _coroutineQueue = ownersQueue;
    }

    public void OnClick()
    {
        if (m_Owner != null)
        {
            _queenQueue = new Queue<IEnumerator>();
            board = CreateBoard.board;
            _moveQueen = new MoveQueen(this, true);
            ResetBoard(board);
            m_Owner = null;
            GlobalVariables.algorythmRunning = null;
        }
    }

    void ResetBoard(List<Row> board)
    {
        _coroutineQueue.StopLoop();
        board.ForEach(row => _queenQueue.Enqueue(_moveQueen.SetMoveCoroutine(row.rowQueen, new Vector3(row.rowQueen.position.x, 0, -2f), .5f)));
        _moveQueen.Move(_queenQueue);
    }
}

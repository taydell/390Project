using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetScene : MonoBehaviour
{
    private List<Row> board;
    private MoveQueen _moveQueen;
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
            board = CreateBoard.board;
            ResetBoard(board);
            m_Owner = null;
        }
    }

    void ResetBoard(List<Row> board)
    {
        _coroutineQueue.StopLoop();
    }
}

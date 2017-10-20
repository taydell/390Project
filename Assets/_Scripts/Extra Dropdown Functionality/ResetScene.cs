using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetScene : MonoBehaviour
{
    private List<Row> board;
    private MoveQueen _moveQueen;
    private Queue<IEnumerator> _queenQueue = new Queue<IEnumerator>();
    private List<TowerPieces> _disks;
    private static MonoBehaviour m_Owner;
    private static CoroutineQueue _coroutineQueue;
    [SerializeField]
    private MonoBehaviour towerBase;
    [SerializeField]
    private MonoBehaviour queenBase;

    public ResetScene(MonoBehaviour owner, CoroutineQueue ownersQueue)
    {
        m_Owner = owner;
        _coroutineQueue = ownersQueue;
    }

    public void OnClick()
    {
        if (m_Owner != null)
        {
            if (m_Owner == towerBase)
            {
                _disks = TowerPieceList.instance.SetUpPieces();
                _moveQueen = new MoveQueen(this, true);
            }
            else if(m_Owner == queenBase)
            {
                _queenQueue = new Queue<IEnumerator>();
                board = CreateBoard.board;
                _moveQueen = new MoveQueen(this, true);
                ResetBoard(board);
                m_Owner = null;
                GlobalVariables.algorythmRunning = null;
            }
           
        }
        else
        {
            Noty.instance.Display("Warning!", "You cannot reset if nothing is running!", 3f);
        }
    }

    void ResetBoard(List<Row> board)
    {
        _coroutineQueue.StopLoop();
        board.ForEach(row => _queenQueue.Enqueue(_moveQueen.SetMoveCoroutine(row.rowQueen, new Vector3(row.rowQueen.position.x, 0, -2f),board.Count, .5f)));
        _moveQueen.Move(_queenQueue);
    }

    void resetDisks(List<TowerPieceList> disks)
    {

    }
}

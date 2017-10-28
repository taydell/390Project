using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetScene : MonoBehaviour
{
    private List<Row> board;
    private MoveQueen _moveQueen;
    private Queue<IEnumerator> _queenQueue = new Queue<IEnumerator>();
    private List<TowerPieces> _disks;
    private Queue<IEnumerator> _diskQueue = new Queue<IEnumerator>();
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
                _diskQueue = new Queue<IEnumerator>();
                _moveQueen = new MoveQueen(this, true);
                resetDisks(_disks);
                m_Owner = null;
                GlobalVariables.algorythmRunning = null;
            }
            else if(m_Owner == queenBase)
            {
                _queenQueue = new Queue<IEnumerator>();
                board = CreateBoard.board;
                _moveQueen = new MoveQueen(this, true);
                ResetBoard(board);
                m_Owner = null;
                GlobalVariables.algorythmRunning = null;
                GlobalVariables.isSolved = false;
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
        foreach (var row in board) {
            if (row.rowQueen != null)
                _queenQueue.Enqueue(_moveQueen.SetMoveCoroutine(row.rowQueen, new Vector3(row.rowQueen.position.x, 0, -2f), board.Count, .5f));
        }
        _moveQueen.Move(_queenQueue);
    }

    void resetDisks(List<TowerPieces> disks)
    {
        _coroutineQueue.StopLoop();
        var yPos = 4f;
        foreach(var disk in disks)
        {
            _diskQueue.Enqueue(_moveQueen.SetMoveCoroutine(disk._pieces, new Vector3(disk._pieces.position.x, yPos, 0), .5f));
            _diskQueue.Enqueue(_moveQueen.SetMoveCoroutine(disk._pieces, new Vector3(-3, yPos, 0), .5f));
            yPos -= .2f;
        }

        for(int i = disks.Count-1; i >= 0; i--)
        {
            _diskQueue.Enqueue(_moveQueen.SetMoveCoroutine(disks[i]._pieces, new Vector3(-3, DiskStartingPointEnum.GetDiskLocationByNumber(i+1), 0), .5f));
        }

        _moveQueen.Move(_diskQueue);
    }
}

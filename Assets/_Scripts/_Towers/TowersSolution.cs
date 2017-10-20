using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._Scripts;

public class TowersSolution : MonoBehaviour
{
    private MoveQueen _move;
    private List<DisksMovementPosition> _diskMovementPattern = new List<DisksMovementPosition>();
    private List<TowerPieces> _disks;
    Queue<IEnumerator> towerPieceQueue = new Queue<IEnumerator>();
    float tower1CurrentY;
    float tower2CurrentY;
    float tower3CurrentY;
    void Awake()
    {
        

    }
    
    public void OnClick()
    {
        if (GlobalVariables.algorythmRunning == null)
        {
            GlobalVariables.algorythmRunning = this;
            _move = new MoveQueen(this);
            _disks = TowerPieceList.instance.SetUpPieces();
            setInitialDiskHeightOnTowers();
            if (!GlobalVariables.isSolved)
            {
                TowersRecursion(_disks, _disks.Count, -3, 3, 0);
                GlobalVariables.isSolved = true;
                enqueueDisksToTowerQueue();
                _move.Move(towerPieceQueue);
            }
        }
        else
        {
            Noty.instance.Display("Warning!", "You Are already running that solution!", 3f);
        }
    }

    public void TowersRecursion(List<TowerPieces> pieces, int n, float from, float to, float other)
    {
        if (n > 0)
        {
            TowersRecursion(pieces, n - 1, from, other, to);
            setDiskPosition(n, from, to);
            TowersRecursion(pieces, n - 1, other, to, from);
        }
    }

    private void enqueueDisksToTowerQueue()
    {
        foreach (var pos in _diskMovementPattern)
        {
            foreach (var disk in _disks)
            {
                if (disk.GetPieceNumber() == pos.diskNumber)
                {
                    towerPieceQueue.Enqueue(_move.SetMoveCoroutine(disk._pieces, new Vector3(pos.towerFrom, 2.5f, 0)));
                    towerPieceQueue.Enqueue(_move.SetMoveCoroutine(disk._pieces, new Vector3(pos.towerTo, 2.5f, 0)));
                    towerPieceQueue.Enqueue(_move.SetMoveCoroutine(disk._pieces, new Vector3(pos.towerTo, getCurrentTowerHeight(pos.towerTo), 0)));
                    setHeightForDisksOnTowers(pos.towerTo, pos.towerFrom, disk.GetYSize());
                }
            }
        }
    }

    private float getCurrentTowerHeight(float towerTo)
    {
        float currentTower;
        if(towerTo == -3)
        {
            currentTower = tower1CurrentY; 
        }
        else if(towerTo == 0)
        {
            currentTower = tower2CurrentY;
        }
        else
        {
            currentTower = tower3CurrentY;
        }

        return currentTower;
    }

    private void setInitialDiskHeightOnTowers()
    {
        tower1CurrentY = 2.23f;
        tower2CurrentY = .5f;
        tower3CurrentY = .5f;
    }

    private void setHeightForDisksOnTowers(float towerTo, float towerFrom, float diskSize)
    {
        if (towerTo == -3)
        {
            tower1CurrentY += diskSize;
        }
        else if (towerTo == 0)
        {
            tower2CurrentY += diskSize;
        }
        else if(towerTo == 3)
        {
            tower3CurrentY += diskSize;
        }

        if (towerFrom == -3)
        {
            tower1CurrentY -= diskSize;
        }
        else if (towerFrom == 0)
        {
            tower2CurrentY -= diskSize;
        }
        else if (towerFrom == 3)
        {
            tower3CurrentY -= diskSize;
        }
    }

    private void setDiskPosition(int number, float from, float to)
    {
        DisksMovementPosition pos = new DisksMovementPosition(number, from, to);
        _diskMovementPattern.Add(pos);
    }
}

public class DisksMovementPosition
{
    public int diskNumber;
    public float towerFrom;
    public float towerTo;
    public float diskHeight;

    public DisksMovementPosition(int number, float from, float to)
    {
        diskNumber = number;
        towerFrom = from;
        towerTo = to;
    }

    public void setDiskHeight(float height)
    {
        diskHeight = height;
    }
}

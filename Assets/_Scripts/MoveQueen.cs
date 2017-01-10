using UnityEngine;
using System.Collections;

public class MoveQueen : MonoBehaviour 
{
    private bool _isMoved = false;
    private bool _isMovedToStart = false;
    public Vector3 _startPosition;
    private Vector3 _movedPosition;

    public MoveQueen( Vector3 startPosition)
    {
        _startPosition = startPosition;
    }

    public void MoveQueenToStart()
    {
        _isMovedToStart = true;
    }
    private void MoveQueenToStartPosition()
    {

    }

    public void MoveQueenToBoardPosition(Vector3 movedPosition)
    {
        _movedPosition = movedPosition;
        _isMoved = true;
    }

    private void MoveQueenToNewPosition(Vector3 Position)
    {

    }

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(_isMovedToStart){
            Debug.Log("start x: "+ _startPosition.x + " z: " + _startPosition.z);
            _isMovedToStart = false;
        }
        else if (_isMoved)
        {
            Debug.Log("new position x: " + _movedPosition.x + " z: " + _movedPosition.z);
            _isMoved = false;

        }
	}
}

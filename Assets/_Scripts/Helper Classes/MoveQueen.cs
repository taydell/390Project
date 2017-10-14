using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveQueen
{
    private CoroutineQueue _coroutineQueue;

    public MoveQueen(MonoBehaviour coroutineOwner)
    {
        _coroutineQueue = new CoroutineQueue(coroutineOwner);
        new ResetScene(coroutineOwner, _coroutineQueue);
        _coroutineQueue.StartLoop();
    }
    public MoveQueen(MonoBehaviour coroutineOwner, bool isReturnToStart)
    {
        _coroutineQueue = new CoroutineQueue(coroutineOwner);
        _coroutineQueue.StartLoop();
    }

    public void Move(Queue<IEnumerator> queenQueue)
    {
        while (queenQueue.Count > 0)
        {
            IEnumerator queenPos = queenQueue.Dequeue();
            _coroutineQueue.EnqueueAction(queenPos);
        }
    }

    public IEnumerator SetMoveCoroutine(Transform transform, Vector3 position, float? timeToMove = null)
    {
        var currentPos = transform.position;
        var time = 0f;
        while (time < 1)
        {
            Debug.Log("speed: " + GlobalVariables.queenSpeed);

            if (timeToMove == .5f)
            {
                time += Time.deltaTime / (float)timeToMove;
            }
            else if (GlobalVariables.queenSpeed == 2 || GlobalVariables.queenSpeed == 0)
            {
                time = 0;
            }
            else
            {
                time += Time.deltaTime / GlobalVariables.queenSpeed;
            }

            transform.position = Vector3.Lerp(currentPos, position, time);
            yield return null;
        }
    }
}

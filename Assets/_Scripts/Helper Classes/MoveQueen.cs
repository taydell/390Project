using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveQueen : MonoBehaviour
{
    private CoroutineQueue _coroutineQueue;

    public MoveQueen(MonoBehaviour coroutineOwner)
    {
        _coroutineQueue = new CoroutineQueue(coroutineOwner);
        new ResetScene(coroutineOwner, _coroutineQueue);
        _coroutineQueue.StartLoop();
    }
    public MoveQueen() { }

    public void Move(Queue<IEnumerator> queenQueue)
    {
        while (queenQueue.Count > 0)
        {
            IEnumerator queenPos = queenQueue.Dequeue();
            _coroutineQueue.EnqueueAction(queenPos);
        }
    }

    public IEnumerator SetMoveCoroutine(Transform transform, Vector3 position, float timeToMove)
    {
        var currentPos = transform.position;
        var time = 0f;
        while (time < 1)
        {
            time += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, time);
            yield return null;
        }
    }
}

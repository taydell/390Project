using UnityEngine;
using System.Collections.Generic;

public class Recursion : MonoBehaviour {

    private CreateBoard board;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void test()
    {
        foreach (var row in board.board)
        {
            foreach(var space in row.GetSpaceObjects())
            {
                Debug.Log(space.GetIsOcuppied());
            }
        }
    }
}

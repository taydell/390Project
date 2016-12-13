using UnityEngine;
using System.Collections;
using Assets._Scripts;
using System.Collections.Generic;

public class CreateQueens : MonoBehaviour {

    public List<QueenObject> QueenList = new List<QueenObject>();
    public Transform QueenPrefab;


    void InstantiateQueen(Transform prefab, int z, int x, int id)
    {
        Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity);

        QueenObject queen = new QueenObject();
        queen.SetId(id);
        queen.SetZPosition(z);
        queen.SetYPosition(0);
        queen.SetXPosition(x);
        QueenList.Add(queen);
    }
}

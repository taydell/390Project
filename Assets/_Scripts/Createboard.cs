using UnityEngine;
using System.Collections;
using Assets._Scripts;
using System.Collections.Generic;

public class Createboard : MonoBehaviour
{
   
    public List<SpaceObject> SpaceList = new List<SpaceObject>();
    public List<QueenObject> QueenList = new List<QueenObject>();
    public Transform MyPrefabWhite;
    public Transform MyPrefabBlack; 
    public Transform QueenPrefab;

    private int Size = 6;
    
	// Use this for initialization
	void Awake() 
    {
       
        DrawBoard();
    }

    void DrawBoard()
    {
        int _count = 0;
        
        for (var z = 1; z <= Size; z++)
        {
            if (Size % 2 == 0)
            {
                _count = 0;
            }
            for (var x = 1; x <= Size; x++)
            {
                if (Size%2 == 0)
                {
                    if (z % 2 == 0 && x==1)
                    {
                        _count = 1;
                    }
                    if (_count % 2 == 0)
                    {
                         InstantiateSpace(MyPrefabWhite, z, x);
                    }
                    else
                    {
                        InstantiateSpace(MyPrefabBlack, z, x);
                    }
                    _count++;
                }
                else
                {
                    if (_count % 2 == 0)
                    {
                        InstantiateSpace(MyPrefabWhite, z, x);
                    }
                    else
                    {
                       InstantiateSpace(MyPrefabBlack,z,x);  
                    }
                    _count++;
                }
                if (x == 1)
                {
                    InstantiateQueen(QueenPrefab, z, (x - 3), _count);
                }
            }    
        }
    }

    void InstantiateSpace(Transform prefab, int z, int x)
    {
        Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity);
        
        SpaceObject space = new SpaceObject();
        space.SetIsOccupied(false);
        space.SetZPosition(z);
        space.SetYPosition(0);
        space.SetXPosition(x);
        SpaceList.Add(space);
    }

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

    // Update is called once per frame
    void Start()
    {
        int counter=0;
        foreach (var space in SpaceList)
        {
            counter++;
            Debug.Log("x: "+space.GetXPosition() +" z: " + space.GetZPosition());
        }
        Debug.Log("counter: " + counter);
    }

	void Update () {
	
	}
}

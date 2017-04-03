using UnityEngine;
using System.Collections;
using Assets._Scripts;
using System.Collections.Generic;

public class CreateBoard : MonoBehaviour
{
    public static List<Row> board = new List<Row>();
    public Transform MyPrefabWhite;
    public Transform MyPrefabBlack;
    public Transform QueenPrefab;
    private GameObject ChessPieces;
    private GameObject ChessBoard;

    private int _size = 4;
    
	// Use this for initialization
	void Awake() 
    {
        MakeParents();
        MakeBoard();
        DrawBoard();
    }

    void MakeBoard()
    {
        for (int i = 0; i < _size; i++)
        {
            board.Add(new Row(i, _size, QueenPrefab));
        }
    }


    void DrawBoard()
    {
        foreach(var row in board){
            foreach(var space in row.GetSpaceObjects()){
                if(space.isBlack)
                {
                    InstantiateSpace(MyPrefabBlack, space.GetXPosition(), space.GetZPosition());
                }
                else{
                    InstantiateSpace(MyPrefabWhite, space.GetXPosition(), space.GetZPosition());
                }
            }
        }
    }

    void InstantiateSpace(Transform prefab, int z, int x)
    {
        Transform ChessSpace = Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity) as Transform;

        if(ChessSpace != null)
            SetSpaceParent(ChessSpace);
    }

    void MakeParents()
    {
        ChessBoard = new GameObject();
        ChessBoard.name = "ChessBoard";

        ChessPieces = new GameObject();
        ChessPieces.name = "ChessPieces";
    }

    void SetSpaceParent(Transform ChessSpace)
    {
        ChessSpace.parent = ChessBoard.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Start()
    {

    }

	void Update () {
	
	}
}

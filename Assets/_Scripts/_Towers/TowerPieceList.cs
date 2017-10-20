using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPieceList : MonoBehaviour
{
    public Transform prefabOne;
    public Transform prefabTwo;
    public Transform prefabThree;
    public Transform prefabFour;
    public Transform prefabFive;
    public Transform prefabSix;

    public static TowerPieceList instance;

    void Awake()
    {
        instance = this;
    }

   public List<TowerPieces> SetUpPieces()
   {
        List<TowerPieces> towerPieces = new List<TowerPieces>();
        TowerPieces pieceOne = new TowerPieces(1, .12f, prefabOne);
        TowerPieces pieceTwo = new TowerPieces(2, .16f, prefabTwo);
        TowerPieces pieceThree = new TowerPieces(3, .22f, prefabThree);
        TowerPieces pieceFour = new TowerPieces(4, .29f, prefabFour);
        TowerPieces pieceFive = new TowerPieces(5, .34f, prefabFive);
        TowerPieces pieceSix = new TowerPieces(6, .6f, prefabSix);

        towerPieces.Add(pieceOne);
        towerPieces.Add(pieceTwo);
        towerPieces.Add(pieceThree);
        towerPieces.Add(pieceFour);
        towerPieces.Add(pieceFive);
        towerPieces.Add(pieceSix);

        return towerPieces;
   }
}

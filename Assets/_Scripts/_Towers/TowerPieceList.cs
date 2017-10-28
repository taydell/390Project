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
        TowerPieces pieceOne = new TowerPieces(1, DiskStartingPointEnum.diskOneStartingLocation, prefabOne);
        TowerPieces pieceTwo = new TowerPieces(2, DiskStartingPointEnum.diskTwoStartingLocation, prefabTwo);
        TowerPieces pieceThree = new TowerPieces(3, DiskStartingPointEnum.diskThreeStartingLocation, prefabThree);
        TowerPieces pieceFour = new TowerPieces(4, DiskStartingPointEnum.diskFourStartingLocation, prefabFour);
        TowerPieces pieceFive = new TowerPieces(5, DiskStartingPointEnum.diskFiveStartingLocation, prefabFive);
        TowerPieces pieceSix = new TowerPieces(6, DiskStartingPointEnum.diskSixStartingLocation, prefabSix);

        towerPieces.Add(pieceOne);
        towerPieces.Add(pieceTwo);
        towerPieces.Add(pieceThree);
        towerPieces.Add(pieceFour);
        towerPieces.Add(pieceFive);
        towerPieces.Add(pieceSix);

        return towerPieces;
   }
}

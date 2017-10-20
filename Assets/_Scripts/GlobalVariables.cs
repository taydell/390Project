using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static MonoBehaviour algorythmRunning;
    public static float queenSpeed = 1.9f;
    public static bool isSolved = false;

    #region SceneControl
    public static string queenDropDownName = "Queens Dropdown";
    public static string towerDropDownName = "Towers Dropdown";
    public static string UIName = "UI";
    #endregion

    #region towers
    public static bool towerIsFinished = false;
    #endregion
}

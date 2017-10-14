using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenSpeedSlider : MonoBehaviour {

    public void Slider(float value)
    {
        GlobalVariables.queenSpeed = value;
    }
}

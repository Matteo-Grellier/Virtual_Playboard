using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bishop : MonoBehaviour
{

    public bool IsRightChessBox(Vector2 initPos, Vector2 reqPos)
    {

        double testXPos = Math.Round(initPos.x, 1) - Math.Round(reqPos.x, 1);
        double testYPos = Math.Round(initPos.y, 1) - Math.Round(reqPos.y, 1);

        if (Math.Abs(testXPos) == Math.Abs(testYPos))
        {
            return true;
        } else
        {
            return false;
        } 
    }
}

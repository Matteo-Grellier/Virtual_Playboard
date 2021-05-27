using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class knight : MonoBehaviour
{
    public bool IsRightChessBox(Vector2 initPos, Vector2 reqPos)
    {

        if (Math.Round(initPos.x, 1) + 2 == reqPos.x && Math.Round(initPos.y, 1) + 1 == reqPos.y || initPos.x + 2 == reqPos.x && Math.Round(initPos.y, 1) - 1 == reqPos.y)
        {
            return true;
        } else if (Math.Round(initPos.x, 1) + 1 == reqPos.x && Math.Round(initPos.y, 1) + 2 == reqPos.y || Math.Round(initPos.x, 1) - 1 == reqPos.x && Math.Round(initPos.y, 1) + 2 == reqPos.y)
        {
            return true;
        } else if (Math.Round(initPos.x, 1) - 2 == reqPos.x && Math.Round(initPos.y, 1) + 1 == reqPos.y || Math.Round(initPos.x, 1) - 2 == reqPos.x && Math.Round(initPos.y, 1) - 1 == reqPos.y)
        {
            return true;
        } else if (Math.Round(initPos.x, 1) + 1 == reqPos.x && Math.Round(initPos.y, 1) - 2 == reqPos.y || Math.Round(initPos.x, 1) - 1 == reqPos.x && Math.Round(initPos.y, 1) - 2 == reqPos.y)
        {
            return true;
        } else
        {
            return false;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class rook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsRightChessBox(Vector2 initPos, Vector2 reqPos)
    {
        Debug.Log(initPos);
        Debug.Log(reqPos);

        if((Math.Round(initPos.y, 1) == Math.Round(reqPos.y, 1)) || (Math.Round(initPos.x, 1) == Math.Round(reqPos.x, 1)))
        {
            return true;
        } else
        {
            return false;
        }
        
    }
}

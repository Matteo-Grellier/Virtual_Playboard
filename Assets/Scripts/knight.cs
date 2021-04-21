using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class knight : MonoBehaviour
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

        Debug.Log("initPos: " + initPos);
        Debug.Log("reqPos: " + reqPos);

/*        initPos.x = (float)Math.Floor(initPos.x);
        initPos.y = (float)Math.Floor(initPos.y);

        reqPos.x = (float)Math.Floor(reqPos.x);
        reqPos.y = (float)Math.Floor(reqPos.x);*/

        if (Math.Round(initPos.x, 1) + 2 == reqPos.x && Math.Round(initPos.y, 1) + 1 == reqPos.y || initPos.x + 2 == reqPos.x && Math.Round(initPos.y, 1) - 1 == reqPos.y)
        {
            Debug.Log("first");
            return true;
        } else if (Math.Round(initPos.x, 1) + 1 == reqPos.x && Math.Round(initPos.y, 1) + 2 == reqPos.y || Math.Round(initPos.x, 1) - 1 == reqPos.x && Math.Round(initPos.y, 1) + 2 == reqPos.y)
        {
            Debug.Log("second");
            return true;
        } else if (Math.Round(initPos.x, 1) - 2 == reqPos.x && Math.Round(initPos.y, 1) + 1 == reqPos.y || Math.Round(initPos.x, 1) - 2 == reqPos.x && Math.Round(initPos.y, 1) - 1 == reqPos.y)
        {
            Debug.Log("third");
            return true;
        } else if (Math.Round(initPos.x, 1) + 1 == reqPos.x && Math.Round(initPos.y, 1) - 2 == reqPos.y || Math.Round(initPos.x, 1) - 1 == reqPos.x && Math.Round(initPos.y, 1) - 2 == reqPos.y)
        {
            Debug.Log("fourth");
            return true;
        } else
        {
            Debug.Log("completly false dude");
            Debug.Log(Math.Round(initPos.x, 1) + 1);
            Debug.Log(Math.Round(initPos.y, 1) + 2);
            return false;
        }

        /*Debug.Log(reqPos + " " + initPos);*/
        //Debug.Log("Hello les gens");
        
    }
}

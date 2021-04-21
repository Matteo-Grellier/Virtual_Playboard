using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class pawn : MonoBehaviour
{
    bool isAlreadyPlayed = false;

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
        Debug.Log("On rentre dans la vérif de position des pions");

        if (isAlreadyPlayed == false)
        {
            Debug.Log("On est dans la condition de isAlreadyPlayed == false");

            isAlreadyPlayed = true;

            if (Math.Round(initPos.y, 1) + 2 == reqPos.y && Math.Round(initPos.x, 1) == reqPos.x || Math.Round(initPos.y, 1) - 2 == reqPos.y && Math.Round(initPos.x, 1) == reqPos.x)
            {
                Debug.Log("Plus précisement quand je veux cliquer sur 2 cases");
                return true;
            } else if (Math.Round(initPos.y, 1) + 1 == reqPos.y && Math.Round(initPos.x, 1) == reqPos.x || Math.Round(initPos.y, 1) - 1 == reqPos.y && Math.Round(initPos.x, 1) == reqPos.x)
            {
                Debug.Log("Plus précisement quand je veux cliquer sur 1 case");
                return true;
            } else
            {
                Debug.Log("Plus précisement quand je veux pas une bonne case");
                isAlreadyPlayed = false;
                return false;
            }


        } else
        {
            if (Math.Round(initPos.y, 1) + 1 == reqPos.y && Math.Round(initPos.x, 1) == reqPos.x || Math.Round(initPos.y, 1) - 1 == reqPos.y && Math.Round(initPos.x, 1) == reqPos.x)
                {
                return true;
            } else
            {
                return false;
            }


            //return true;
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class pawn : MonoBehaviour
{
    bool isAlreadyPlayed = false;
    GameObject Board;

    private void Start()
    {
        Board = GameObject.Find("Board");
    }

    public bool IsRightChessBox(Vector2 initPos, Vector2 reqPos)
    {
        //Debug.Log("On rentre dans la vérif de position des pions");

        double testXPos = Math.Round(reqPos.x, 1) - Math.Round(initPos.x, 1);
        double testYPos = Math.Round(reqPos.y, 1) - Math.Round(initPos.y, 1);

        int verifyEquality = 1;

        string previousColor = Board.GetComponent<board>().previousColor;

        if(previousColor == "whitePieces")
        {
            verifyEquality = Math.Abs(verifyEquality) * -1;
        } else
        {
            verifyEquality = Math.Abs(verifyEquality);
        }


        if(testYPos == verifyEquality && Math.Abs(testXPos) == 1)
        {
            if(Board.GetComponent<board>().CheckMateVerification(this.tag))
            {
                Board.GetComponent<board>().CatchPieces();
            }
            
            bool isCatching = Board.GetComponent<board>().isCatching;
            if(isCatching == true)
            {
                return true;
            }
        }

            if (isAlreadyPlayed == false)
        {
            //Debug.Log("On est dans la condition de isAlreadyPlayed == false");

            isAlreadyPlayed = true;

            //if (Math.Round(initPos.y, 1) + 2 == reqPos.y && Math.Round(initPos.x, 1) == reqPos.x || Math.Round(initPos.y, 1) - 2 == reqPos.y && Math.Round(initPos.x, 1) == reqPos.x)
            //{
            //    //Debug.Log("Plus précisement quand je veux cliquer sur 2 cases");
            //    return true;
            //}
            //else if (Math.Round(initPos.y, 1) + 1 == reqPos.y && Math.Round(initPos.x, 1) == reqPos.x || Math.Round(initPos.y, 1) - 1 == reqPos.y && Math.Round(initPos.x, 1) == reqPos.x)
            //{
            //    //Debug.Log("Plus précisement quand je veux cliquer sur 1 case");
            //    return true;
            //}
            //else
            //{
            //    //Debug.Log("Plus précisement quand je veux pas une bonne case");
            //    isAlreadyPlayed = false;
            //    return false;
            //}

            
            if (testYPos == verifyEquality && testXPos == 0 || testYPos == verifyEquality*2 && testXPos == 0)
            {
                return true;
            }
            else
            {
                isAlreadyPlayed = false;
                return false;
            }

        } else
        {
            //if (Math.Round(initPos.y, 1) + 1 == reqPos.y && Math.Round(initPos.x, 1) == reqPos.x || Math.Round(initPos.y, 1) - 1 == reqPos.y && Math.Round(initPos.x, 1) == reqPos.x)
            //    {
            //    return true;
            //} else
            //{
            //    return false;
            //}


            if (testYPos == verifyEquality && testXPos == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            //return true;
        }

    }

}

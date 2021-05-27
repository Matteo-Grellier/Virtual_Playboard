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

            isAlreadyPlayed = true;
            
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
            if (testYPos == verifyEquality && testXPos == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}

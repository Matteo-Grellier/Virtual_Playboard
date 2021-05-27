using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    GameObject Board;

    // Start is called before the first frame update
    void Start()
    {
        Board = GameObject.Find("Board");
    }

    //va permettre de décider si oui ou non le clique permet un déplacement.
    void OnMouseDown()
    {
        double positionOfPreviousPieceX = Mathf.Round(Board.GetComponent<board>().position.x / 0.1f) * 0.1;
        double positionOfPreviousPieceY = Mathf.Round(Board.GetComponent<board>().position.y / 0.1f) * 0.1;
        double rightVecX = Mathf.Round(Board.GetComponent<board>().rightVec.x / 0.1f) * 0.1;
        double rightVecY = Mathf.Round(Board.GetComponent<board>().rightVec.y / 0.1f) * 0.1;

        bool isRightPos = Board.GetComponent<board>().isRightPos;

        if ((positionOfPreviousPieceX == rightVecX && positionOfPreviousPieceY == rightVecY) || isRightPos == false)
        {

            if (Board.GetComponent<board>().isSelected == false && (this.gameObject.tag).ToString() != Board.GetComponent<board>().previousColor)
            {
                Board.GetComponent<board>().tagOfElement = (this.gameObject.tag).ToString();
                Board.GetComponent<board>().isSelected = true;
                Board.GetComponent<board>().isSelectionClick = true;
                Board.GetComponent<board>().nameOfElement = (this.gameObject.name).ToString();


            } else if (Board.GetComponent<board>().isSelected == true && (this.gameObject.tag).ToString() != Board.GetComponent<board>().previousColor)
            {
                Board.GetComponent<board>().isSelectionClick = true;
                Board.GetComponent<board>().nameOfElement = (this.gameObject.name).ToString();
            }

        }
    }
}

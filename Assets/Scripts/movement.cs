using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //Reference
    GameObject KBOne;
    GameObject KBTwo;
    GameObject KWOne;
    GameObject KWTwo;

    GameObject Board;

    //Coordinates
    Vector2 kbOPos = new Vector2();
    Vector2 kbTPos = new Vector2();
    Vector2 kwOPos = new Vector2();
    Vector2 kwTPos = new Vector2();

    //others
    //string nameOfElement;

    //color
    //private string previousColor;

    // Start is called before the first frame update
    void Start()
    {
        /*KBOne = GameObject.Find("Knight_b1");
        KBTwo = GameObject.Find("Knight_b2");
        KWOne = GameObject.Find("Knight_w1");
        KWTwo = GameObject.Find("Knight_w2");*/

        Board = GameObject.Find("Board");

        //previousColor = "blackPieces";
    }

    // Update is called once per frame
    void Update()
    {
        /*kbOPos = KBOne.transform.position;
        kbTPos = KBTwo.transform.position;
        kwOPos = KWOne.transform.position;
        kwTPos = KWTwo.transform.position;*/
            
    }

    void OnMouseDown()
    {
        //Debug.Log("quand je OnMousDown " + kbOPos);

        // voir si il faut mettre le nom de l'élément cliquer dans une variable et la récup dans le board


        if (Mathf.Round(Board.GetComponent<board>().position.x / 0.1f) * 0.1 == Mathf.Round(Board.GetComponent<board>().rightVec.x / 0.1f) * 0.1 && Mathf.Round(Board.GetComponent<board>().position.y / 0.1f) * 0.1 == Mathf.Round(Board.GetComponent<board>().rightVec.y / 0.1f) * 0.1)
        {
            Debug.Log("Ceci est un test de float et double ?" + 0.05f);

            //print("ceci est la couleur précédente ou pas ? avant la condition qui verifie " + this.previousColor);

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


            //Board.GetComponent<board>().nameOfElementInc++;

            //Board.GetComponent<board>().isMovable = false;
            
            //Board.GetComponent<board>().ToKnowElement();
            //Board.GetComponent<board>().isSelect = false;

            /*this.previousColor = (this.gameObject.tag).ToString();
            print("ceci est la couleur précédente " + previousColor);*/

            // il nous faut une variable isPlayed qui va voir si on a bien joué le bon côté


        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class board : MonoBehaviour
{

    //PourDeplacement 
    public string nameOfElement;
    public string tagOfElement;
    public string previousColor;
    public bool isSelectionClick;
    public bool isSelected;
    public bool isReadyToMove;
    public bool isRightPos;
    //public bool isMovable;

    //Others
    public int nameOfElementInc;
    
    public int rookBuff = 0;

    //pour Board()
    public float toPutX = 0.5f;
    public float toPutY = 0.5f;
    public float[] x = new float[8];
    public float[] y = new float[8];

    //pour récupérer les coordonnées de tous les objets (pour vérification des mouvements possibles)
    public GameObject[] whitePieces = new GameObject[16];
    public GameObject[] blackPieces = new GameObject[16];
    public float[] actualPositionsOfPieces = new float[32];

    //pour RightCoor
    public float rightX;
    public float rightY;
    public float[] verifX = new float[8];
    public float[] verifY = new float[8];

    public float[] right = new float[2];

    public Vector2 rightVec = new Vector2();


    //Pour position souris
    public Vector3 mousePos = new Vector3();


    //Pour faire référence on définit ces 2 "variables"
    GameObject Pieces;
    Rigidbody2D rb;
    //public knight knight;
    //Type NameOfClass;
    //public knight knight;

    public Vector2 position = new Vector2(0f, 0f);
    public float moveSpeed = 0.1f;

    void Start()
    {
        //define cases
        x = new float[8] { 0.5f, 1.5f, 2.5f, 3.5f, 4.5f, 5.5f, 6.5f, 7.5f };
        y = new float[8] { 0.5f, 1.5f, 2.5f, 3.5f, 4.5f, 5.5f, 6.5f, 7.5f };

        nameOfElement = "empty";
        isSelectionClick = false;
        previousColor = "blackPieces";
        isSelected = false;
        isReadyToMove = false;
        //isMovable = false;


        whitePieces = GameObject.FindGameObjectsWithTag("whitePieces");
        blackPieces = GameObject.FindGameObjectsWithTag("blackPieces");

        //allPieces = whitePieces + blackPieces;

        //foreach (GameObject obj in whitePieces)
        //{
        //    obj.transform.position;
        //}

        //foreach (GameObject obj in blackPieces)
        //{

        //}



        //Faire référence
        //Pieces = GameObject.Find(nameOfElement);//Trouver le gameObject correspondant à Unknown
        //rb = Pieces.GetComponent<Rigidbody2D>(); // On prend la component de Pieces (qui est défini juste au dessus) qui est le RigidBody2D

    }
    //pieces Pieces;


    //public void ToKnowElement()
    //{

        //Debug.Log(isSelectClick);

        /*if (isSelectClick == true)
        {
            Pieces = GameObject.Find(nameOfElement);
            rb = Pieces.GetComponent<Rigidbody2D>();
            //Debug.Log(nameOfElement);
            Debug.Log(Pieces.gameObject.name);
        } /*else
        {
            nameOfElement = "Unknown";
            Pieces = GameObject.Find(nameOfElement);
            rb = Pieces.GetComponent<Rigidbody2D>();
        }*/
        
    //}

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
               
            /*if (isSelectionClick == false && nameOfElementInc >= 1)
            {
                //Debug.Log("Je suis un connard");
            
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;

                Debug.Log("ceci est la mousePos :" + mousePos);

                RightCoor(mousePos.x, mousePos.y);

                //nameOfElementInc++;
                //ToKnowElement();
                Debug.Log(Pieces.gameObject.name);
                //isSelectClick = true;


                nameOfElementInc = 0;
                //isMovable = false;
                //ToKnowElement();
            }

            // Dans le cas où on a cliqué sur une pièce
            if (isSelectionClick == true && tagOfElement != previousColor)
            {
                Pieces = GameObject.Find(nameOfElement);
                rb = Pieces.GetComponent<Rigidbody2D>();
                //Debug.Log(nameOfElement);
                Debug.Log(Pieces.gameObject.name);

                isSelectionClick = false;
                previousColor = tagOfElement;
            }*/

            if (isSelected == true)
            {
                if (isSelectionClick == true)
                {
                    Pieces = GameObject.Find(nameOfElement);
                    rb = Pieces.GetComponent<Rigidbody2D>();
                    //Debug.Log(nameOfElement);
                    Debug.Log(Pieces.gameObject.name);

                    isSelectionClick = false;
                    isReadyToMove = false;
                    /*previousColor = tagOfElement;*/
                }else
                {
                    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePos.z = 0;

                    Debug.Log("ceci est la mousePos :" + mousePos);

                    RightCoor(mousePos.x, mousePos.y);

                    Debug.Log("du else: " + Pieces.gameObject.name);

                    /*nameOfElementInc = 0;*/

                    /*position = Vector2.Lerp(Pieces.transform.position, rightVec, moveSpeed);*/

                    //Pieces = GameObject.Find(nameOfElement);

                    /*Type NameOfClass = Pieces.GetType();*/
                    //var coucou = ObjectNames.GetClassName(Pieces);
                    //Debug.Log("class ? " + coucou);
                    //nameOfClass script = Pieces.GetComponent(nameOfClass);


                    //Pieces = GameObject.Find(nameOfElement);                  //il faut peut etre le réactiver
                    Debug.Log("du else: " + Pieces.gameObject.name);
                    Debug.Log("previousCOlor: " + previousColor);
                    isRightPos = VerifyIsMovable(Pieces.gameObject.name);

                    /*Type NameOfClass = Pieces.GetType();
                    Pieces.GetComponent<knight>().IsRightChessBox();*/
                    //knight.IsRightChessBox();
                    //NameOfClass Pieces.GetComponent(NameOfClass).IsRightChessBox();

                    /*var testVar = Pieces.GetComponent(NameOfClass);
                    testVar.IsRightChessBox();*/

                    if (isRightPos == true)
                    {
                        isSelected = false;
                        previousColor = tagOfElement;
                        isReadyToMove = true;
                    } /*else
                    {
                        isSelected = true;
                        isReadyToMove = false;
                    }*/

                    Debug.Log("incompréhension / 20");

                }
            }

        }

        //isSelect = false;

        if (isReadyToMove == true && isRightPos == true)
        {

            //if ()
            //{

            //}

            //vecteur allant de la position Pieces.tr... à rightVec par moveSpeed
            position = Vector2.Lerp(Pieces.transform.position, rightVec, moveSpeed); // Grâce à "Pieces.transform.position" on modifie la position pour l'objet correspondant à pieces (voir plus haut)
            //Debug.Log(position);
        }


    }

    void FixedUpdate()
    {

        /*        if (isSelectionClick == false && nameOfElementInc == 0)
                {
                    rb.MovePosition(position); //On utilise MovePosition (methods de RigidBody2D) à la position (voir plus haut)

                    Debug.Log(position);
                    Debug.Log("is RightVEC" + rightVec);

                    *//*if (position.x == rightVec.x && position.y == rightVec.y)
                    {
                        isMovable = false;
                    }*//*
                }*/

        if (isReadyToMove == true && isRightPos == true)
        {
            rb.MovePosition(position); //On utilise MovePosition (methods de RigidBody2D) à la position (voir plus haut)

            /*Debug.Log(position);
            Debug.Log("is RightVEC" + rightVec);*/

            /*if (position.x == rightVec.x && position.y == rightVec.y)
            {
                //isMovable = false;
            }*/


            /*if (rb.position.x == rightVec.x && rb.position.y == rightVec.y)
            {
                //isMovable = false;
                isReadyToMove = false;
            }*/
    
        }



    }

    // RightCoor() permet de trouver la case correspondant au clique de la souris. Elle return un Vector2
    public Vector2 RightCoor(float mouseX, float mouseY)
    {

        for (int i = 0; i < 8; i++)
        {
            //Debug.Log("Test mouseX" + mouseX);
            verifX[i] = mouseX - x[i];
            verifY[i] = mouseY - y[i];
            //Debug.Log( "Test verifX " + verifX[i]);
        }

        //Debug console
        //Debug.Log("Tableaux : " + verifX[2] + ", " + verifY[2]); //il faut avoir : valeur differente que celle du mouseX et mouseY
        //Debug.Log("X = " + x[1] + x[2] + x[3]); // il faut avoir les bonnes coordonnées

        float previousX = verifX[0];
        float previousY = verifY[0];


        for (int i = 0; i < 8; i++)
        {

            // valeur la plus proche de zéro (car il y a une soustraction dans la partie d'avant)
            if (Math.Abs(previousX) > Math.Abs(verifX[i]) || Math.Abs(previousX) == Math.Abs(verifX[i]))
            {
                previousX = verifX[i];
                rightX = x[i];
            }

            if (Math.Abs(previousY) > Math.Abs(verifY[i]) || Math.Abs(previousY) == Math.Abs(verifY[i]))
            {
                previousY = verifY[i];
                rightY = y[i];
            }

        }

        //Debug concole
        //Debug.Log(rightX);
        //Debug.Log(rightY);

        rightVec.x = rightX;
        rightVec.y = rightY;

        return rightVec;
    }


    //public bool VerifyIsMovable(string name)
    //{
    //    //PiecesInFront();
    //    //TypeOfPieces(name);

    //    if (PiecesInFront() && TypeOfPieces(name)) {
    //        return true;
    //    } else
    //    {
    //        return false;
    //    }
    //}

    public bool VerifyIsMovable(string name)
    {

        bool isRightChessSquare = false;
        bool noPiecesInFront = true;

        if (name.ToLower().Split('_')[0] == "knight")
        {
            isRightChessSquare = Pieces.GetComponent<knight>().IsRightChessBox(rb.position, rightVec);

        } else if (name.ToLower().Split('_')[0] == "bishop")
        {
            isRightChessSquare = Pieces.GetComponent<bishop>().IsRightChessBox(rb.position, rightVec);

        } else if (name.ToLower().Split('_')[0] == "rook")
        {
            isRightChessSquare = Pieces.GetComponent<rook>().IsRightChessBox(rb.position, rightVec);

        } else if (name.ToLower().Split('_')[0] == "queen")
        {
            isRightChessSquare = Pieces.GetComponent<queen>().IsRightChessBox(rb.position, rightVec);

        } else if (name.ToLower().Split('_')[0] == "king")
        {
            isRightChessSquare = Pieces.GetComponent<king>().IsRightChessBox(rb.position, rightVec);

        } else if (name.ToLower().Split('_')[0] == "pawn")
        {
            //return true; // remplacer par une ligne comme ci-dessus

            isRightChessSquare = Pieces.GetComponent<pawn>().IsRightChessBox(rb.position, rightVec);

        }

        noPiecesInFront = VerifyInFront();


        if (isRightChessSquare && noPiecesInFront)
        {
            return true;
        } else
        {
            return false;
        }

        //return true;
    }

    public bool VerifyInFront() 
    {
        double intervalOfX = rightVec.x - Math.Round(rb.position.x, 1);
        double intervalOfY = rightVec.y - Math.Round(rb.position.y, 1);

        double intervalToVerify;
        double otherInterval;
        double rbPositionToVerify;
        double objPositionToVerify;
        double otherObjPositionAxe;
        double otherRbPositionAxe;


        //bool piecesInIntervalX = false;
        //bool piecesInIntervalY = false;


        foreach (GameObject obj in whitePieces)
        {
            if (intervalOfX == 0) // Si c'est une ligne droite (vertical)
            {
                intervalToVerify = intervalOfY;
                rbPositionToVerify = Math.Round(rb.position.y, 1);
                objPositionToVerify = Math.Round(obj.transform.position.y, 1);
                otherInterval = intervalOfX;
                otherRbPositionAxe = Math.Round(rb.position.x, 1);
                otherObjPositionAxe = Math.Round(obj.transform.position.x, 1);
            }
            else if (intervalOfY == 0 || Math.Abs(intervalOfX) == Math.Abs(intervalOfY)) //Si c'est une ligne droite (horizontal) ou une diagonale
            {
                intervalToVerify = intervalOfX;
                rbPositionToVerify = Math.Round(rb.position.x, 1);
                objPositionToVerify = Math.Round(obj.transform.position.x, 1);
                otherInterval = intervalOfY;
                otherRbPositionAxe = Math.Round(rb.position.y, 1);
                otherObjPositionAxe = Math.Round(obj.transform.position.y, 1);
            }
            else // Si c'est un "Knight"
            {
                return true;
            }

            if(!NoPiecesInFront(intervalToVerify, rbPositionToVerify, objPositionToVerify, otherInterval, otherRbPositionAxe, otherObjPositionAxe))
            {
                return false;
            }
            
        }



        //foreach (GameObject obj in whitePieces)
        //{
        //    for(int i = 0; i <= intervalToVerify; i++)
        //    {

        //    }
        //}

        //foreach(GameObject obj in whitePieces)
        //{
        //    if(intervalOfX == 0)
        //    {
        //        piecesInIntervalX = true;
        //    }

            //    if(intervalOfY == 0)
            //    {
            //        piecesInIntervalY = true;
            //    }

            //    for (int i = 1; i <= Math.Abs(intervalOfX); i++)
            //    {
            //        int addingValue = i;

            //        if(intervalOfX < 0)
            //        {
            //            addingValue *= -1;      
            //        } 


            //        if (Math.Round(rb.position.x, 1) + addingValue == Math.Round(obj.transform.position.x, 1))
            //        {
            //            piecesInIntervalX = true;
            //            Debug.Log("piecesInIntervalX" + piecesInIntervalX);
            //            Debug.Log("La valeur qui fait bug : " + obj.transform.position.x);
            //            break;
            //        }
            //    }

            //    for (int i = 1; i <= Math.Abs(intervalOfY); i++)
            //    {

            //        int addingValue = i;

            //        if (intervalOfY < 0)
            //        {
            //            addingValue *= -1;
            //        }

            //        if (Math.Round(rb.position.y, 1) + addingValue == Math.Round(obj.transform.position.y, 1))
            //        {
            //            piecesInIntervalY = true;
            //            Debug.Log("piecesInIntervalY" + piecesInIntervalY);
            //            Debug.Log("La valeur qui fait bug : " + obj.transform.position.y);
            //            break;
            //        }
            //    }


            //    if(piecesInIntervalY && piecesInIntervalX)
            //    {
            //        return false;
            //    } else
            //    {
            //        piecesInIntervalY = false;
            //        piecesInIntervalX = false;
            //    }
            //}

            //foreach (GameObject obj in blackPieces)
            //{
            //    for (int i = 1; i <= Math.Abs(intervalOfX); i++)
            //    {
            //        if (Math.Round(rb.position.x, 1) + i == Math.Round(obj.transform.position.x, 1))
            //        {
            //            piecesInIntervalX = true;
            //            Debug.Log("piecesInIntervalX" + piecesInIntervalX);
            //            Debug.Log("La valeur qui fait bug : " + obj.transform.position.x);
            //            break;
            //        }
            //    }

            //    for (int i = 1; i <= Math.Abs(intervalOfY); i++)
            //    {
            //        if (Math.Round(rb.position.y, 1) + i == Math.Round(obj.transform.position.y, 1))
            //        {
            //            piecesInIntervalY = true;
            //            Debug.Log("piecesInIntervalY" + piecesInIntervalY);
            //            break;
            //        }
            //    }

            //    if (piecesInIntervalY && piecesInIntervalX)
            //    {
            //        return false;
            //    }
            //}


            return true;
    }


    public bool NoPiecesInFront(double intervalToVerify, double rbPositionToVerify, double objPositionToVerify, double otherInterval, double otherRbPositionAxe, double otherObjPositionAxe)
    {

        for(int i = 1; i <= Math.Abs(intervalToVerify); i++)
        {

            int addingValue = i;

            if(intervalToVerify < 0)
            {
                addingValue *= -1;
            }
                 
            //if (Math.Round(rb.position.x, 1) + i == Math.Round(obj.transform.position.x, 1))
            //{
            //    piecesInIntervalX = true;
            //    Debug.Log("piecesInIntervalX" + piecesInIntervalX);
            //    Debug.Log("La valeur qui fait bug : " + obj.transform.position.x);
            //    break;
            //}

            if (rbPositionToVerify + addingValue == objPositionToVerify)
            {
                Debug.Log(objPositionToVerify + " <-- Ceci est la objPositionToVerify");
                if(otherInterval == 0 && otherObjPositionAxe == otherRbPositionAxe)
                {
                    return false;
                } else
                {
                    addingValue = Math.Abs(addingValue);

                    if (otherInterval < 0)
                    {
                        addingValue *= -1;
                    }

                    if (otherRbPositionAxe + addingValue == otherObjPositionAxe)
                    {
                        Debug.Log(otherObjPositionAxe + " <-- Ceci est la otherObjPositionAxe");
                        return false;
                    }
                }
            }
        }


        return true;
    }

}



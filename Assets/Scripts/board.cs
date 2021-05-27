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
    public GameObject[] whitePieces;
    public GameObject[] blackPieces;
    //public float[] actualPositionsOfPieces = new float[32];

    //pour CatchPieces
    public bool isCatching;

    //pour CheckMateVerif
    bool isCheck = false;

    //pour Verification de s'il y a une pièce devant
    double rightVecToVerify;
    double otherRightVecAxe;  

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


                    //redéfini les variables whitePieces et blackPieces pour enlever l'objet qui a été "destroy".
                    if(isCatching == true)
                    {
                        whitePieces = GameObject.FindGameObjectsWithTag("whitePieces");
                        blackPieces = GameObject.FindGameObjectsWithTag("blackPieces");
                    }


                    //Pieces = GameObject.Find(nameOfElement);                  //il faut peut etre le réactiver
                    Debug.Log("du else: " + Pieces.gameObject.name);
                    Debug.Log("previousCOlor: " + previousColor);

                    isRightPos = VerifyIsMovable(Pieces, rb.position, rightVec);
                        
                        if (!isRightPos) {
                            FindObjectOfType<AudioManager>().Play("cant");
                        }



                    /*Type NameOfClass = Pieces.GetType();
                    Pieces.GetComponent<knight>().IsRightChessBox();*/
                    //knight.IsRightChessBox();
                    //NameOfClass Pieces.GetComponent(NameOfClass).IsRightChessBox();

                    /*var testVar = Pieces.GetComponent(NameOfClass);
                    testVar.IsRightChessBox();*/

                    if (isRightPos == true)
                    {

                        FindObjectOfType<AudioManager>().Play("piece");

                        CheckMateVerification(previousColor);

                        if (Pieces.gameObject.name.ToLower().Split('_')[0] != "pawn")
                        {
                            CatchPieces();
                        }
                        
                        //if (isCatching == true) {
                        //    whitePieces = GameObject.FindGameObjectsWithTag("whitePieces");
                        //    blackPieces = GameObject.FindGameObjectsWithTag("blackPieces");
                        //}

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

    public bool VerifyIsMovable(GameObject pieceToVerify, Vector2 positionToVerify, Vector2 reqPos)
    {

        string name = pieceToVerify.gameObject.name;
        //Rigidbody2D rigidBodyOfPiece = pieceToVerify.GetComponent<Rigidbody2D>();

        bool isRightChessSquare = false;
        bool noPiecesInFront = true;
        bool noCheck = true;

        if (name.ToLower().Split('_')[0] == "knight")
        {
            isRightChessSquare = pieceToVerify.GetComponent<knight>().IsRightChessBox(positionToVerify, reqPos);

        } else if (name.ToLower().Split('_')[0] == "bishop")
        {
            isRightChessSquare = pieceToVerify.GetComponent<bishop>().IsRightChessBox(positionToVerify, reqPos);

        } else if (name.ToLower().Split('_')[0] == "rook")
        {
            isRightChessSquare = pieceToVerify.GetComponent<rook>().IsRightChessBox(positionToVerify, reqPos);

        } else if (name.ToLower().Split('_')[0] == "queen")
        {
            isRightChessSquare = pieceToVerify.GetComponent<queen>().IsRightChessBox(positionToVerify, reqPos);

        } else if (name.ToLower().Split('_')[0] == "king")
        {
            isRightChessSquare = pieceToVerify.GetComponent<king>().IsRightChessBox(positionToVerify, reqPos);

        } else if (name.ToLower().Split('_')[0] == "pawn")
        {
            //return true; // remplacer par une ligne comme ci-dessus

            isRightChessSquare = pieceToVerify.GetComponent<pawn>().IsRightChessBox(positionToVerify, reqPos);

        }

        //noPiecesInFront = VerifyInFront(rb.position);

        GameObject[][] allPieces = new GameObject[2][];
        allPieces[0] = whitePieces;
        allPieces[1] = blackPieces;

        noPiecesInFront = true;

        foreach (GameObject[] pieces in allPieces)
        {
            foreach (GameObject obj in pieces)
            {

                if (pieceToVerify.tag == previousColor)
                {

                    Debug.Log("Yo man est ce que tu rentres ici");
                    if (!VerifyInFront(rightVec, positionToVerify, reqPos))
                    {
                        return false;
                    }
                } else
                {
                    if (!VerifyInFront(obj.transform.position, positionToVerify, reqPos))
                    {
                        return false;
                    }
                }



            }
        }


        if (isRightChessSquare && noPiecesInFront)
        {
            //noCheck = VerifyInFront(pieceToVerify, positionToVerify);

            noCheck = CheckMateVerification(pieceToVerify.tag);
        }


        //if (isCheck == true && isRightChessSquare && noPiecesInFront)
        //{
        //    noCheck = CheckMateMovement();
        //}


        if (isRightChessSquare && noPiecesInFront && noCheck)
        {
            return true;
        } else
        {
            return false;
        }

        //return true;
    }

    public bool VerifyInFront(Vector2 obstaclePos, Vector2 positionToVerify, Vector2 reqPos) 
    {
        double intervalOfX = reqPos.x - Math.Round(positionToVerify.x, 1);
        double intervalOfY = reqPos.y - Math.Round(positionToVerify.y, 1);

        double intervalToVerify;
        double otherInterval;
        double rbPositionToVerify;
        double objPositionToVerify;
        double otherObjPositionAxe;
        double otherRbPositionAxe;

        GameObject[][] allPieces = new GameObject[2][];
        allPieces[0] = whitePieces;
        allPieces[1] = blackPieces;


        //bool piecesInIntervalX = false;
        //bool piecesInIntervalY = false;

        if (intervalOfX == 0) // Si c'est une ligne droite (vertical)
        {
            intervalToVerify = intervalOfY;
            rbPositionToVerify = Math.Round(positionToVerify.y, 1);
            objPositionToVerify = Math.Round(obstaclePos.y, 1);
            //rightVecToVerify = rightVec.y;

            otherInterval = intervalOfX;
            otherRbPositionAxe = Math.Round(positionToVerify.x, 1);
            otherObjPositionAxe = Math.Round(obstaclePos.x, 1);
            //otherRightVecAxe = rightVec.x;
        }
        else if (intervalOfY == 0 || Math.Abs(intervalOfX) == Math.Abs(intervalOfY)) //Si c'est une ligne droite (horizontal) ou une diagonale
        {
            intervalToVerify = intervalOfX;
            rbPositionToVerify = Math.Round(positionToVerify.x, 1);
            objPositionToVerify = Math.Round(obstaclePos.x, 1);
            otherInterval = intervalOfY;
            otherRbPositionAxe = Math.Round(positionToVerify.y, 1);
            otherObjPositionAxe = Math.Round(obstaclePos.y, 1);
        }
        else // Si c'est un "Knight"
        {
            return true;
        }

        if (!NoPiecesInFront(intervalToVerify, rbPositionToVerify, objPositionToVerify, otherInterval, otherRbPositionAxe, otherObjPositionAxe))
        {
            return false;
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

        //variable dans le cas ou c'est un pion en ligne droite, lui bloquer l'accès à la case de devant s'il y a un element
        int addBlockMovementForPawn = 0;

        if(Pieces.gameObject.name.ToLower().Split('_')[0] == "pawn" && otherInterval == 0)
        {
            addBlockMovementForPawn = 1;
        }

        for(int i = 1; i < Math.Abs(intervalToVerify) + addBlockMovementForPawn; i++)
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
                //Debug.Log(objPositionToVerify + " <-- Ceci est la objPositionToVerify");
                if(otherInterval == 0)
                {
                    if(otherObjPositionAxe == otherRbPositionAxe)
                    {
                        return false;
                    }
                    
                } else
                {
                    addingValue = Math.Abs(addingValue);

                    if (otherInterval < 0)
                    {
                        addingValue *= -1;
                    }

                    if (otherRbPositionAxe + addingValue == otherObjPositionAxe)
                    {
                        //Debug.Log(otherObjPositionAxe + " <-- Ceci est la otherObjPositionAxe");
                        return false;
                    }
                }
            }
        }


        return true;
    }


    public void CatchPieces()
    {
        GameObject[] oppositeColor;

        if(previousColor == "whitePieces")
        {
            oppositeColor = whitePieces;
        } else
        {
            oppositeColor = blackPieces;
        }

        foreach(GameObject obj in oppositeColor)
        {
            if(Math.Round(obj.transform.position.x, 1) == rightVec.x && Math.Round(obj.transform.position.y, 1) == rightVec.y)
            {
                Debug.Log("Cest bien une autre piece mangeable");
                Destroy(obj);
                isCatching = true;
                return;
            }
        }

        isCatching = false;
    }

    public bool CheckMateVerification(string colorToVerify)
    {
        GameObject verifyKing;
        GameObject[] objectsToVerify;

        double kingPositionX;
        double kingPositionY;
        //double intervalY;
        //double intervalX;

        //bool objIsCheck = false;

        bool objIsCheck = false;
        

        if (colorToVerify == "blackPieces")
        {
            verifyKing = GameObject.Find("king_b");
            objectsToVerify = whitePieces;
            verifyKing.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            Debug.Log("Bonjour je suis bien dans la truc de color");
        } else //if(previousColor == "whitePieces")
        {
            verifyKing = GameObject.Find("king_w");
            objectsToVerify = blackPieces;
            verifyKing.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }

        kingPositionX = Math.Round(verifyKing.transform.position.x, 1);
        kingPositionY = Math.Round(verifyKing.transform.position.y, 1);

        //intervalX = 7.5 - kingPositionX;
        //intervalY = 7.5 - kingPositionY; //attention il faudra changer en fonction de ce que l'on veut test (ligne droite / diago etc...)

        //s'il y a une pièce blanche et noir sur la meme ligne alors faire une vérif de laquelle est la plus proche du roi
        // s'il y a que la couleur opposé au roi, alors directement dire echec
        // s'il y a que la couleur du roi, alors trkl
        //un état d'echec ne justifie pas de ne pas vérif les autres lignes, en effet, s'il y a plusieurs cas d'échec, il faut le savoir.
        // on pourra ajouter une case de couleur rouge sur les pièces qui créés l'échec.

        Vector2 kingPos = verifyKing.transform.position;

        foreach(GameObject obj in objectsToVerify)
        {

            //if(obj.name.ToLower().Split('_')[0] != "king")
            //{
            //Debug.Log(obj);
            //rb = obj.GetComponent<Rigidbody2D>();
            //Debug.Log(rb);

            Rigidbody2D rigidBodyOfPiece = obj.GetComponent<Rigidbody2D>();
            Vector2 posToVerif = rigidBodyOfPiece.position;

            if (isRightPos == true && obj == Pieces)
            {
                posToVerif = rightVec;
            }

            //objIsCheck = VerifyIsMovable(obj, posToVerif, kingPos);
            //}

            if (VerifyIsMovable(obj, posToVerif, kingPos))
            {
                Debug.Log("WTF DUDE ! CHESS STATE ! WARNIIING !");

                objIsCheck = true;

            } 

        }

        if(objIsCheck)
        {
            //if (!isCheck && Pieces.tag == colorToVerify)
            //{
            //    return false;
            //}

            verifyKing.GetComponent<SpriteRenderer>().color = new Color(0.69f, 0, 0, 1);
            isCheck = true;
            FindObjectOfType<AudioManager>().Play("echec");

            return false;

        } else
        {
            //verifyKing.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            isCheck = false;
            return true;
        }

    }

    //pour diago : peut etre 7.5 - initPos          (( ou verif jusqu'a x = 7.5 (mais si y = 7.5 avant, alors break la boucle) ))
    //pour ligne droite : verif que x = 0 ou y = 0, jusqu'a 7.5

    public bool CheckMateMovement(GameObject objToVerify, Vector2 positionToVerify)
    {

        //VerifyInFront(objToVerify, positionToVerify);

        return true;
    }
}



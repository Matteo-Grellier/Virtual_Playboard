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

    //Others
    public int nameOfElementInc;

    //pour Board()
    public float toPutX = 0.5f;
    public float toPutY = 0.5f;
    public float[] x = new float[8];
    public float[] y = new float[8];

    //pour récupérer les coordonnées de tous les objets (pour vérification des mouvements possibles)
    public GameObject[] whitePieces;
    public GameObject[] blackPieces;

    //pour CatchPieces
    public bool isCatching;

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


        whitePieces = GameObject.FindGameObjectsWithTag("whitePieces");
        blackPieces = GameObject.FindGameObjectsWithTag("blackPieces");

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (isSelected == true)
            {
                if (isSelectionClick == true)
                {
                    Pieces = GameObject.Find(nameOfElement);
                    rb = Pieces.GetComponent<Rigidbody2D>();

                    isSelectionClick = false;
                    isReadyToMove = false;
                }else
                {
                    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePos.z = 0;

                    RightCoor(mousePos.x, mousePos.y);


                    //redéfini les variables whitePieces et blackPieces pour enlever l'objet qui a été "destroy".
                    if(isCatching == true)
                    {
                        whitePieces = GameObject.FindGameObjectsWithTag("whitePieces");
                        blackPieces = GameObject.FindGameObjectsWithTag("blackPieces");
                    }

                    isRightPos = VerifyIsMovable(Pieces, rb.position, rightVec);
                        
                    if (!isRightPos) {
                        FindObjectOfType<AudioManager>().Play("cant");
                    }

                    if (isRightPos == true)
                    {

                        FindObjectOfType<AudioManager>().Play("piece");

                        //vérification de s'il y a "échec" pour l'adversaire
                        CheckMateVerification(previousColor);

                        //Attraper des pièces (tout sauf les pions qui ont un fonctionnement bien spécifique)
                        if (Pieces.gameObject.name.ToLower().Split('_')[0] != "pawn")
                        {
                            CatchPieces();
                        }

                        isSelected = false;
                        previousColor = tagOfElement;
                        isReadyToMove = true;
                    }

                }
            }

        }

        if (isReadyToMove == true && isRightPos == true)
        {
            //vecteur allant de la position Pieces.tr... à rightVec par moveSpeed
            position = Vector2.Lerp(Pieces.transform.position, rightVec, moveSpeed); // Grâce à "Pieces.transform.position" on modifie la position pour l'objet correspondant à pieces (voir plus haut)
        }


    }

    void FixedUpdate()
    {

        if (isReadyToMove == true && isRightPos == true)
        {
            rb.MovePosition(position); //On utilise MovePosition (methods de RigidBody2D) à la position (voir plus haut)
        }



    }

    // RightCoor() permet de trouver la case correspondant au clique de la souris. Elle return un Vector2
    public Vector2 RightCoor(float mouseX, float mouseY)
    {

        for (int i = 0; i < 8; i++)
        {
            verifX[i] = mouseX - x[i];
            verifY[i] = mouseY - y[i];
        }

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

        rightVec.x = rightX;
        rightVec.y = rightY;

        return rightVec;
    }

    public bool VerifyIsMovable(GameObject pieceToVerify, Vector2 positionToVerify, Vector2 reqPos)
    {

        string name = pieceToVerify.gameObject.name;

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
            isRightChessSquare = pieceToVerify.GetComponent<pawn>().IsRightChessBox(positionToVerify, reqPos);

        }

        GameObject[][] allPieces = new GameObject[2][];
        allPieces[0] = whitePieces;
        allPieces[1] = blackPieces;

        //Vérifiez s'il y a une pièce devant en regardant chaque pièce de l'échiquier
        noPiecesInFront = true;

        foreach (GameObject[] pieces in allPieces)
        {
            foreach (GameObject obj in pieces)
            {

                if (pieceToVerify.tag == previousColor)
                {
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
            noCheck = CheckMateVerification(pieceToVerify.tag);
        }


        if (isRightChessSquare && noPiecesInFront && noCheck)
        {
            return true;
        } else
        {
            return false;
        }
    }
    
    //VerifyInFront() sert à faire la vérification pour une pièce de l'échiquier pour savoir s'il y a quelque chose devant. 
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

        if (intervalOfX == 0) // Si c'est une ligne droite (vertical)
        {
            intervalToVerify = intervalOfY;
            rbPositionToVerify = Math.Round(positionToVerify.y, 1);
            objPositionToVerify = Math.Round(obstaclePos.y, 1);

            otherInterval = intervalOfX;
            otherRbPositionAxe = Math.Round(positionToVerify.x, 1);
            otherObjPositionAxe = Math.Round(obstaclePos.x, 1);

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

            if (rbPositionToVerify + addingValue == objPositionToVerify)
            {
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
                        return false;
                    }
                }
            }
        }


        return true;
    }

    //Pour attraper les pièces
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

        //Pour chaque pièce, vérification de si la position correspond à celle cliquer (ce fait après avoir vérifié si la pièce qui veut manger, peut bouger)
        foreach(GameObject obj in oppositeColor)
        {
            if(Math.Round(obj.transform.position.x, 1) == rightVec.x && Math.Round(obj.transform.position.y, 1) == rightVec.y)
            {
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

        bool objIsCheck = false;      

        if (colorToVerify == "blackPieces")
        {
            verifyKing = GameObject.Find("king_b");
            objectsToVerify = whitePieces;
            verifyKing.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);

        } else
        {
            verifyKing = GameObject.Find("king_w");
            objectsToVerify = blackPieces;
            verifyKing.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }

        Vector2 kingPos = verifyKing.transform.position;

        //pour chaque pièce on va vérifier si elles peuvent bouger sur la position du roi, si c'est le cas, alors "échec"
        foreach(GameObject obj in objectsToVerify)
        {

            Rigidbody2D rigidBodyOfPiece = obj.GetComponent<Rigidbody2D>();
            Vector2 posToVerif = rigidBodyOfPiece.position;

            if (isRightPos == true && obj == Pieces)
            {
                posToVerif = rightVec;
            }

            if (VerifyIsMovable(obj, posToVerif, kingPos))
            {
                objIsCheck = true;
            } 

        }

        if(objIsCheck)
        {
            //change la couleur + joue le son d'échec.
            verifyKing.GetComponent<SpriteRenderer>().color = new Color(0.69f, 0, 0, 1);
            FindObjectOfType<AudioManager>().Play("echec");

            return false;

        } else
        {
            return true;
        }

    }
}



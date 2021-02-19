using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class board : MonoBehaviour
{

    public int rookBuff = 0;

    //pour Board()
    public int toPutX = 32;
    public int toPutY = 32;
    public int[] x = new int[8] { 32, 96, 160, 224, 288, 352, 416, 480 };
    public int[] y = new int[8] { 32, 96, 160, 224, 288, 352, 416, 480 };

    //pour RightCoor
    public float rightX;
    public float rightY;
    public float[] verifX = new float[8];
    public float[] verifY = new float[8];

    public float[] right = new float[2];


    //Pour position souris
    public Vector2 mouseClick = new Vector2();
    public Vector3 mousePos = new Vector3();





    //pieces Pieces;

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mousedown in x =" + Input.mousePosition.x + " y = " + Input.mousePosition.y);

            mouseClick = Input.mousePosition;


            //Pieces = GameObject.Find("pieces").GetComponent<pieces>();
            Pieces = GameObject.FindGameObjectWithTag("tagPieces").GetComponent<pieces>(); //Récupère une référence au programme pieces.cs grâce au tag "tagPieces" mis sur l'objet ayant le script
            Pieces.ToMove(mouseClick); //Appel la fonction ToMove() se trouvant dans pieces.cs
            
            Debug.Log(mouseClick);
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mousedown in x =" + Input.mousePosition.x + " y = " + Input.mousePosition.y);


            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Debug.Log(mousePos);

            //Pieces = GameObject.FindGameObjectWithTag("tagPieces").GetComponent<pieces>(); //Récupère une référence au programme pieces.cs grâce au tag "tagPieces" mis sur l'objet ayant le script

            //while (mousePos != Pieces.transform.position)
            //{
                //Pieces.ToMove(mousePos); //Appel la fonction ToMove() se trouvant dans pieces.cs
            //}
            //Pieces = GameObject.Find("pieces").GetComponent<pieces>();
            //Pieces = GameObject.FindGameObjectWithTag("tagPieces").GetComponent<pieces>(); //Récupère une référence au programme pieces.cs grâce au tag "tagPieces" mis sur l'objet ayant le script
            //Pieces.ToMove(mousePos); //Appel la fonction ToMove() se trouvant dans pieces.cs

            //Debug.Log(mouseClick);
        }





        /*Vector2 mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Ray ray;
        ray = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10))
        {
            if (hit.point.x < transform.position.x)
                Debug.Log("Left");
            else
                Debug.Log("Right");

            Debug.Log(hit.point);
        }*/

    }


    public float[] RightCoor(float mouseX, float mouseY)
    {

        for (int i = 0; i < 8; i++)
        {
            verifX[i] = mouseX - x[i];
            verifY[i] = mouseY - y[i];
        }

        //Debug console
        Debug.Log("Tableaux : " + verifX[2] + ", " + verifY[2]); //il faut avoir : valeur differente que celle du mouseX et mouseY
        Debug.Log("X = " + x[1] + x[2] + x[3]); // il faut avoir les bonnes coordonnées

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
        Debug.Log(rightX);
        Debug.Log(rightY);

        right[0] = rightX;
        right[1] = rightY;

        return right;
    }
}

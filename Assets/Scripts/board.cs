using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class board : MonoBehaviour
{

    public int rookBuff = 0;

    //pour Board()
    public float toPutX = 0.5f;
    public float toPutY = 0.5f;
    public float[] x = new float[8];
    public float[] y = new float[8];

    //pour RightCoor
    public float rightX;
    public float rightY;
    public float[] verifX = new float[8];
    public float[] verifY = new float[8];

    public float[] right = new float[2];

    public Vector2 rightVec = new Vector2();


    //Pour position souris
    public Vector3 mousePos = new Vector3();


    //Pour faire référence on définis ces 2 "variables"
    GameObject Pieces;
    Rigidbody2D rb;

    Vector2 position = new Vector2(0f, 0f);
    public float moveSpeed = 0.1f;

    void Start()
    {
        //define cases
        x = new float[8] { 0.5f, 1.5f, 2.5f, 3.5f, 4.5f, 5.5f, 6.5f, 7.5f };
        y = new float[8] { 0.5f, 1.5f, 2.5f, 3.5f, 4.5f, 5.5f, 6.5f, 7.5f };

        
        //Faire référence
        Pieces = GameObject.Find("Knight_b1"); //Trouver le gameObject correspondant à Knight_b1
        rb = Pieces.GetComponent<Rigidbody2D>(); // On prend la component de Pieces (qui est défini juste au dessus) qui est le RigidBody2D

    }
    //pieces Pieces;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Debug.Log(mousePos);

            RightCoor(mousePos.x, mousePos.y);
        }

        position = Vector2.Lerp(Pieces.transform.position, rightVec, moveSpeed); //Grâce à "Pieces.transform.position" on modifie la position pour l'objet correspondant à pieces (voir plus haut)

    }

    void FixedUpdate()
    {

        rb.MovePosition(position); //On utilise MovePosition (methods de RigidBody2D) à la position (voir plus haut)

    }

    // RightCoor() permet de trouver la case correspondant au clique de la souris. Elle return un Vector2
    public Vector2 RightCoor(float mouseX, float mouseY)
    {

        for (int i = 0; i < 8; i++)
        {
            Debug.Log("Test mouseX" + mouseX);
            verifX[i] = mouseX - x[i];
            verifY[i] = mouseY - y[i];
            Debug.Log( "Test verifX " + verifX[i]);
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

        rightVec.x = rightX;
        rightVec.y = rightY;

        return rightVec;
    }


}



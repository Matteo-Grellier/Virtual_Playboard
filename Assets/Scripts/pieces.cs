using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieces : MonoBehaviour
{
    //Exernal object/script
    GameObject Board;
    Rigidbody2D rb;

    //For movement
    Vector2 position = new Vector2(0f, 0f);
    public float moveSpeed = 0.1f;

    void Start()
    {

        //Board = GameObject.FindGameObjectWithTag("tagBoard").GetComponent<board>();
        Board = GameObject.Find("Board");
        
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {      
        position = Vector2.Lerp(transform.position, Board.GetComponent<board>().rightVec, moveSpeed);
    }


    void FixedUpdate()
    {

        rb.MovePosition(position);

    }
}

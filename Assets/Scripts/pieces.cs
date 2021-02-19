using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieces : MonoBehaviour
{
    // Start is called before the first frame update

    board Board;
    Rigidbody2D rb;

    Vector2 position = new Vector2(0f, 0f);
    public float moveSpeed = 0.1f;

    void Start()
    {
        //gameObject.GetComponent<board>().mouseClick;


        Board = GameObject.FindGameObjectWithTag("tagBoard").GetComponent<board>();
        rb = GetComponent<Rigidbody2D>();

    }

    //readonly board B;
    // Update is called once per frame

    //private Rigidbody2D rb;   //RB
    //public void ToMove(Vector2 newPosition)
    //{

        //newPosition = new Vector2(newPosition.x / 100, newPosition.y / 100);



        //transform.Translate(newPosition * 100f * Time.deltaTime);

        //while (transform.position.x != newPosition.x && transform.position.y != newPosition.y)
        //{
            //transform.position = new Vector2(transform.position.x + newPosition.x/10, transform.position.y + newPosition.y/10);
        //    transform.position = newPosition;
        //}

        //rb = GetComponent<Rigidbody2D>(); //RB


        //if (rb.velocity != newPosition) {
        //    rb.velocity = newPosition;    //RB
        //}
        

      //  Debug.Log(newPosition);
        //transform.position = boardRef.mouseClick;      
        //transform.Translate(gameObject.GetComponent<board>().mouseClick);
    //}



    void Update()
    {
        
        position = Vector2.Lerp(transform.position, Board.mousePos, moveSpeed);
    }


    void FixedUpdate()
    {

        rb.MovePosition(position);


    }
}

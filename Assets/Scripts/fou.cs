using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class fou : MonoBehaviour
{
    GameObject bishop;
    // Start is called before the first frame update
    void Start()
    {
        bishop = GameObject.Find("bishop_w2");

        bishop.GetComponent<board>().rightVec.x = 2;
    }

    // Update is called once per frame

    void Update()
    {

    }
}

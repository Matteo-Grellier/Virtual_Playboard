using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fou : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject bishop = GameObject.Find("bishop_w2");
        bishop.GetComponent<board>().rightVec.x = 2;
}

// Update is called once per frame

void Update()
{

    if (bishopPos == 2.5)
    {
        Debug.Log("LOL");
    }
}
}

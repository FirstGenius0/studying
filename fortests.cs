using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fortests : MonoBehaviour
{
    float speed = 10;
    Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(move * speed * Time.deltaTime);
    }

}

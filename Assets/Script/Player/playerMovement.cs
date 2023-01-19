using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Fixdirection();
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeGravity();
        }   
    }
    
    void FixedUpdate()
    {
        Horizontalmove();
    }

    void Horizontalmove()
    {
        float horizontalmove;
        horizontalmove = Input.GetAxisRaw("Horizontal");

        float movedirection = Input.GetAxisRaw("Horizontal");

        //player move
        rb.velocity = new Vector2(horizontalmove * movespeed, rb.velocity.y);
    }

    void Fixdirection()
    {
        if(Input.GetAxisRaw("Horizontal") != 0){
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), transform.localScale.y, transform.localScale.z);
        }
        
    }

    void ChangeGravity()
    {
        rb.gravityScale = rb.gravityScale * -1;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
    }

}

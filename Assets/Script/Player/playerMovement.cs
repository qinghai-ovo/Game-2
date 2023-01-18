using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float movespeed;
    
    public bool attack1Able = true;
    public bool attack2Able = true;
    float attack1cd = 0.8f;
    float attack2cd = 1.5f;

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
        if(Input.GetAxis("Fire1") == 1 && attack1Able)
        {
            Attack1();
            
        }
        if(Input.GetAxis("Fire2") == 1 && attack2Able)
        {
            Attack2();
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

    void Attack1()
    {
        attack1Able = false;
        print("Attack1");
        Attack1cd();
    }
    
    void Attack1cd()
    {
        float time1 = 0.0f;
        time1 += Time.deltaTime;
        if(time >= attack1cd)
        {
            time1 = 0f;
            attack1Able = true;
            return;
        }
    }

    void Attack2()
    {
        attack2Able = false;
        print("Attack2");
        Attack2cd();
    }
    
    void Attack2cd()
    {
        float time2 = 0.0f;
        time2 += Time.deltaTime;
        if(time >= attack2cd)
        {
            time = 0f;
            attack2Able = true;
            return;
        }
    }

}

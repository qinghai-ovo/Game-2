using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBookMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float movespeed = 1.5f;

    bool waitStat = true;
    bool attackStat = false;

    public float movetime = 3.0f;
    float time = 0;

    float movedirection = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(waitStat)
        {
            WaitTimer();
        }
    }
    
    void FixedUpdate()
    {
        if(waitStat)
        {
            WaitMode();
        }
        
        if(attackStat)
        {
            AttackMode();
        }
    }

    //waitMode
    void WaitMode()
    {
        rb.velocity = new Vector2(movespeed * movedirection, rb.velocity.y);  
    }

    void WaitTimer()
    {
        time += Time.deltaTime;
        if(time >= movetime)
        {
            movedirection *= -1;
            time = 0;
        }
    }

    //attackMode
    void AttackMode()
    {
        Debug.Log("Attack");
    }

    void Detected()
    {
        Debug.Log("Detected");
        waitStat = false;
        attackStat = true;
    }

    void Undetected()
    {
        Debug.Log("UnDetected");
        waitStat = true;
        attackStat = false;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Detected();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Undetected();
        }
    }


}

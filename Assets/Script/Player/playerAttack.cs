using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float attack1cd = 1.3f;
    public float attack2cd = 3f;

    public bool attackAble = true;
    float attackcd = 0.0f;
    public float time1 = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attackAble)
        {
            if(Input.GetKeyDown(KeyCode.J))
            {
                Attack1();
            }
            if(Input.GetKeyDown(KeyCode.K))
            {
                Attack2();
            }
        }else
        {
            Attackcd();
        }
    }
    
    void Attack1()
    {
        attackAble = false;
        Debug.Log("Attack1");
        attackcd = attack1cd;
    }
    
    void Attack2()
    {
        attackAble = false;
        Debug.Log("Attack2");
        attackcd = attack2cd;
    }

    void Attackcd()
    {
        time1 += Time.deltaTime;
        if(time1 >= attackcd)
        {
            time1 = 0f;
            attackcd = 0f;
            attackAble = true;
        }
    }
}

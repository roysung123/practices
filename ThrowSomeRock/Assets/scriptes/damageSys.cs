using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageSys : MonoBehaviour
{
    public int health_point;
    public health_bar_contral hb;

    // Start is called before the first frame update
    void Start()
    {
        hb.SetMaxHealth(health_point);
    }

    // Update is called once per frame
    void Update()
    {
        if (health_point <= 0)
        {
            Destroy(gameObject);
        }
        //Debug.Log(health_point);
    }

    public void Get_Damage(int d)
    {
        health_point -= d;
        hb.SetHealth(health_point);
    }

    
}

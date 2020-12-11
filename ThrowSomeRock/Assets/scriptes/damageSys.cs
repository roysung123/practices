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

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "ti")
        {
            int damage = (int)col.gameObject.GetComponent<throwableitemScript>().mspower;
            if (damage > 5)
            {
                health_point -= damage;
                hb.SetHealth(health_point);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageSys : MonoBehaviour
{
    public float health_point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health_point <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(health_point);
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "ti")
        {
            health_point -= col.gameObject.GetComponent<throwableitemScript>().mspower;
        }
    }
}

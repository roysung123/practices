using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p = GameObject.Find("Player"))
        {
            if (Vector3.Distance(transform.position, p.transform.position) > 6)
            {
                transform.LookAt(p.transform);
                transform.Translate(Vector3.forward * 3 * Time.deltaTime);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainSysScript : MonoBehaviour
{
    public GameObject ti;

    private GameObject map;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        map = GameObject.Find("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("ti");
        if (gos.Length < 1)
        {
            Vector2 cirpos = Random.insideUnitCircle * map.transform.position.x / 2 + new Vector2(map.transform.position.x, map.transform.position.z);
            Instantiate(ti, new Vector3(cirpos.x, 2, cirpos.y), Random.rotation);
        }
    }
}

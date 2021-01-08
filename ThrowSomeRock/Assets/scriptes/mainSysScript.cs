using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainSysScript : MonoBehaviour
{
    public GameObject ti;
    public GameObject enemies;

    private GameObject map;
    private Vector2 cirpos;
    
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
        if (gos.Length < 3)
        {
            cirpos = Random.insideUnitCircle * map.transform.position.x / 2 + new Vector2(map.transform.position.x, map.transform.position.z);
            Instantiate(ti, new Vector3(cirpos.x, 2, cirpos.y), Random.rotation);
        }
        gos = GameObject.FindGameObjectsWithTag("enemies"); ;
        if (gos.Length < 1)
        {
            cirpos = Random.insideUnitCircle * map.transform.position.x / 2 + new Vector2(map.transform.position.x, map.transform.position.z);
            Instantiate(enemies, new Vector3(cirpos.x, 2, cirpos.y), new Quaternion(0, 0, 0, 0));
        }
    }
}

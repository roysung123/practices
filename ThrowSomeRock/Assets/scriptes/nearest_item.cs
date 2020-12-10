using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nearest_item : MonoBehaviour
{
    public GameObject FindClosestEnemy(Vector3 position,GameObject[] gos)
    {
        //GameObject[] gos;
        //gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        //Vector3 position = self.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}

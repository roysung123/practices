using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwableitemScript : MonoBehaviour
{ 
    GameObject camera_lookat;
    GameObject py;
    public bool beencarry_flag = false;
    Vector3 endpos = Vector3.zero;
    public float mspower;

    private float angularSpeed = 80;//角速度
    private float aroundRadius = 1.5f;//半徑
    private float angled;
    private Color startcolor;
    // Start is called before the first frame update
    void Start()
    {
        camera_lookat = GameObject.Find("Main Camera");
        py = GameObject.Find("Player");
        startcolor = GetComponent<Renderer>().material.color;
        transform.localScale = new Vector3(Random.Range(0.4f,1.2f), Random.Range(0.4f, 1.2f), Random.Range(0.4f, 1.2f));
        GetComponent<Rigidbody>().mass = transform.localScale.x * transform.localScale.y * transform.localScale.z * 4;
        GetComponent<LineRenderer>().enabled = false;
        GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (beencarry_flag)
        {
            //transform.SetPositionAndRotation(new Vector3(py.transform.position.x, 2, py.transform.position.z), new Quaternion(0, 0, 0, 0));
            float posX = aroundRadius * Mathf.Sin(angled * Mathf.Deg2Rad);//計算x位置
            float posZ = aroundRadius * Mathf.Cos(angled * Mathf.Deg2Rad);//計算y位置
            transform.position = new Vector3(posX, 0, posZ) + py.transform.position + new Vector3(0,1.5f,0);
            //Debug.Log(transform.position);
            if (Input.GetKey(KeyCode.Mouse1))
            {
                List<Vector3> poslist = new List<Vector3>();
                Vector3 velocity = Vector3.zero;
                Vector3 pos = transform.position;
                GetComponent<LineRenderer>().enabled = true;
                float time = Time.deltaTime;
                for (int i = 0; i < 100; i++)
                {
                    poslist.Add(pos);
                    if (i > 0)
                    {
                        RaycastHit hit;
                        if (Physics.SphereCast(poslist[i-1],0.1f, poslist[i - 1] - poslist[i], out hit, Vector3.Distance(poslist[i - 1], poslist[i])))
                        {
                            if(hit.transform.gameObject != gameObject)
                            {
                                poslist[i] = hit.point;
                                endpos = hit.point;
                                //Debug.Log(hit.transform.gameObject);
                                break;
                            }
                        }
                    }
                    velocity += Physics.gravity*time;
                    pos += ( (camera_lookat.transform.forward*2 + Vector3.up)*10 + velocity) * time;
                }
                GetComponent<LineRenderer>().positionCount = poslist.Count;
                for (int i = 0; i < poslist.Count; i++)
                {
                    GetComponent<LineRenderer>().SetPosition(i, poslist[i]);
                }
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    beencarry_flag = false;
                    GetComponent<LineRenderer>().enabled = false;
                    GetComponent<Rigidbody>().AddForce((camera_lookat.transform.forward*2 + Vector3.up) * 10, ForceMode.VelocityChange);
                    GetComponent<Rigidbody>().AddTorque(camera_lookat.transform.forward * 10, ForceMode.VelocityChange);
                }
            }
            else
            {
                angled += (angularSpeed * Time.deltaTime) % 360;//累加角度
                GetComponent<LineRenderer>().enabled = false;
            }
        }
        else
        {
            if (py.GetComponent<playerMove>().nestitem == gameObject)//camera_lookat.GetComponent<cameraFollow>().select_item == gameObject)
            {
                GetComponent<Renderer>().material.color = Color.yellow;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Vector3 p = py.transform.rotation * Vector3.forward * aroundRadius;
                    transform.position = new Vector3(p.x, py.transform.position.y + 1, p.z);
                    //transform.SetPositionAndRotation(new Vector3(py.transform.position.x, 3, py.transform.position.z), new Quaternion(0, 0, 0, 0));
                    beencarry_flag = true;
                }
            }
            else
            {
                GetComponent<Renderer>().material.color = startcolor;
            }
        }
        GetComponent<Rigidbody>().useGravity = !beencarry_flag;
        if (transform.position.y < -10) {
            Destroy(gameObject);
        }
    }
    void LateUpdate()
    {
        mspower = Vector3.Distance(new Vector3(0, 0, 0), GetComponent<Rigidbody>().velocity) * GetComponent<Rigidbody>().mass;
        if (mspower / GetComponent<Rigidbody>().mass < 10)
        {
            GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            GetComponent<ParticleSystem>().Play();
        }
            //Debug.Log(mspower);
            //if (py.GetComponent<playerMove>().nestitem == gameObject && Physics.Raycast(transform.position, transform.forward, hit, length)) { }
    }
    void OnCollisionEnter(Collision col)
    {
        if (mspower/GetComponent<Rigidbody>().mass > 10)
        {
            if (col.gameObject.tag == "enemies")
            {
                col.gameObject.GetComponent<damageSys>().Get_Damage((int)mspower);
            }
            if (GetComponent<Rigidbody>().mass > 2.5f)
            {
                GameObject nr = Instantiate(gameObject, transform.position, Random.rotation);
                nr.transform.localScale = new Vector3(Random.Range(0.4f, 0.6f), Random.Range(0.4f, 0.6f), Random.Range(0.4f, 0.6f));
                nr.GetComponent<Rigidbody>().mass = transform.localScale.x * transform.localScale.y * transform.localScale.z * 4;
                nr = Instantiate(gameObject, transform.position, Random.rotation);
                nr.transform.localScale = new Vector3(Random.Range(0.4f, 0.6f), Random.Range(0.4f, 0.6f), Random.Range(0.4f, 0.6f));
                nr.GetComponent<Rigidbody>().mass = transform.localScale.x * transform.localScale.y * transform.localScale.z * 4;
            }
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_bar_contral : MonoBehaviour
{
    public Slider sd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMaxHealth(int hp)
    {
        sd.maxValue = hp;
        sd.value = hp;
    }
    public void SetHealth(int hp)
    {
        sd.value = hp;
    }
}

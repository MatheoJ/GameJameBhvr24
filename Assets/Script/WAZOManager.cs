using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAZOManager : MonoBehaviour
{

    public List<WAZO> wazolist = new();
    public int alertRange = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enregistrement(WAZO wazo)
    {
        wazolist.Add(wazo);
    }


    public void Hit(WAZO wazo)
    {
        foreach(WAZO w in wazolist) 
        {
            if(Vector3.Distance(wazo.transform.position, w.transform.position) < alertRange)
            {
                w.Alert();
            }
        }
    }

    public void Desinscirption(WAZO wazo)
    {
        wazolist.Remove(wazo);
    }

}

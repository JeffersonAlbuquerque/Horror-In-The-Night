using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class flashLight : MonoBehaviour
{
    [Header("FlashLight Setting")]
    public float distance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, distance))
        {
            MonsterIA monster = hitInfo.transform.GetComponent<MonsterIA>();   
            if(monster != null )
            {
                print("Colidindo com objeto");
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float timetospawn = 1f;
    public GameObject enimy;
    public float spawn = 0f;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawn)
        {
           

          
            Instantiate(enimy, Vector3.zero, Quaternion.identity);
            spawn = Time.time + 1f / timetospawn;
        }



    }
}

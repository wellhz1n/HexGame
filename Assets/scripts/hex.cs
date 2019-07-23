using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class hex : MonoBehaviour
{
    public Rigidbody2D rg;
    public float speed = 1f;
    Color[] c = new Color[4];
    Random rand = new Random(Guid.NewGuid().GetHashCode());
    SpriteRenderer s;
    // Start is called before the first frame update
    void Start()
    {
      
        rg.rotation = (float)rand.Next(0, 360);
        transform.localScale = new Vector3(10f,10f,10f);
        c.SetValue(new Color(200f, 10f, 20f), 0);
        c.SetValue(new Color(100f, 200f, 100f), 1);
        c.SetValue(Color.yellow, 2);
        c.SetValue(new Color(20f, 100f, 200f), 3);
       

        

        s = GetComponent<SpriteRenderer>();
        int index = rand.Next(0, 3);

        s.color = c[index];
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.localScale -= Vector3.one * speed * Time.deltaTime;
        if (transform.localScale.x <= 0.50f)
        {
            Global.Score++;
            Destroy(this.gameObject);
        }
    }
}

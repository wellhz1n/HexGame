using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float vel = 10f;
    public SpriteRenderer sr;



    // Start is called before the first frame update
    void Start()
    {
        sr.color = CorShop(Global.Cor);

    }

    private static Color CorShop(string cor)
    {
        Color c = new Color();
        switch (cor)
        {
            case "Blue":
                c = Color.blue;
                break;
            case "Green":
                c = Color.green;
                break;
            case "Red":
                c = Color.red;
                break;
            case "Yellow":
                c = Color.yellow;
                break;
        }
        return c;
    }


    // Update is called once per frame
    void Update()
    {
        if (!Global.paused)
        {
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                if (Input.touchCount > 0 && Input.touchCount < 2)
                {
                    var resolution = Screen.width;
                    var p = Input.GetTouch(0).position.x;
                    if (p >= resolution - resolution && p <= resolution / 2)
                        transform.RotateAround(Vector3.zero, Vector3.forward, vel * Time.fixedDeltaTime * +vel);
                    else if (p >= (resolution / 2) + 1 && p <= resolution)
                        transform.RotateAround(Vector3.zero, Vector3.forward, vel * Time.fixedDeltaTime * -vel);
                }
            }
            if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                if (Input.GetAxis("Horizontal") < 0f)
                    transform.RotateAround(Vector3.zero, Vector3.forward, vel * Time.fixedDeltaTime * +vel);
                else if (Input.GetAxis("Horizontal") > 0f)
                    transform.RotateAround(Vector3.zero, Vector3.forward, vel * Time.fixedDeltaTime * -vel);
            }


        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "hex(Clone)")
        {


            Global.Mostrar(Menu.gameover);
            Global.Stop(Menu.gameover);


            //Global.Score = 0;

            //SceneManager.LoadScene("S1");


        }
    }
    private void FixedUpdate()
    {


    }
}

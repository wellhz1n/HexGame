using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float vel = 10f;




    // Start is called before the first frame update
    void Start()
    {




    }


    // Update is called once per frame
    void Update()
    {
        if (!Global.paused)
        {


            if (Input.touchCount > 0 && Input.touchCount < 2)
            {
                var resolution = Screen.width;
                var p = Input.GetTouch(0).position.x;

                if (p >= resolution - resolution && p <= resolution / 2 || (Input.GetAxis("Horizontal") < 0f))
                {
                    transform.RotateAround(Vector3.zero, Vector3.forward, vel * Time.fixedDeltaTime * +vel);

                }
                else if (p >= (resolution / 2) + 1 && p <= resolution || (Input.GetAxis("Horizontal") > 0f))
                {
                    transform.RotateAround(Vector3.zero, Vector3.forward, vel * Time.fixedDeltaTime * -vel);

                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "hex(Clone)")
        {
            PlayerPrefs.SetInt("Score", Global.Score);

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

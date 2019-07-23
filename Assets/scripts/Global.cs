using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global 
{
    public static int Score = 0;
    public static bool paused = false;
    public static AudioSource a;
    public static void Mostrar(GameObject[] c)
    {
        foreach (GameObject g in c)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public static void Esconder(GameObject[] c)
    {
        foreach (GameObject g in c)
        {
            g.SetActive(false);
        }
    }


    public static void Stop(GameObject[] c)
    {
        a.Pause();
        Debug.Log("Clicou");
        Time.timeScale = 0;
        Global.Mostrar(c);
        Global.paused = true;


    }
  

}
[System.Serializable]
public class SaveClass
{
    public static  int BestScore = 0;
    public  static int Money = 0;
 
}
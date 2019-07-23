using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{




    GameObject[] g;
    public static GameObject[] gameover;
    GameObject[] Shop;

    public TextMeshProUGUI Bestscore;
    public TextMeshProUGUI Money;
    public TextMeshProUGUI MoneyLoja;
    public AudioSource a;

    // Start is called before the first frame update
    void Start()
    {

        Save.LoadBestScore();
        SaveMoney.LoadMoney();
        if (Bestscore != null)
        {


            Bestscore.text = SaveClass.BestScore.ToString();
        }
        else
        {
            Debug.Log("Sem Best TExt");
        }
        if (Money != null)
            Money.text = SaveClass.Money.ToString();
        else
            Debug.Log("Sem  Dinheiro Text");
        if (MoneyLoja != null)
            MoneyLoja.text = SaveClass.Money.ToString();
        else
            Debug.Log("Sem  Dinheiro Text");

        Global.a = a;
        g = GameObject.FindGameObjectsWithTag("Pause");
        Shop = GameObject.FindGameObjectsWithTag("Shop");

        gameover = GameObject.FindGameObjectsWithTag("GameOver");
        Global.Esconder(gameover);
        Global.Esconder(Shop);

        Global.Esconder(g);
    }
    public void CarregaFase(string fase)
    {
        Time.timeScale = 1;


        SceneManager.LoadSceneAsync(fase);
    }
    public void DesCarregaFase(string unload)
    {

        Time.timeScale = 1;
        Global.paused = false;
        if (Global.Score > 0)
        {
            SaveClass.Money += Global.Score;
            SaveMoney.SaveMoneys();

        }
        if (SaveClass.BestScore < Global.Score)
        {
            SaveClass.BestScore = Global.Score;
            Save.SaveBestScore();
        }
        Global.Score = 0;
        Resources.UnloadUnusedAssets();
        SceneManager.LoadSceneAsync(unload);

    }
    public void OpenShop()
    {
        Global.Mostrar(Shop);
    }
    public void EsconderShop()
    {
        Global.Esconder(Shop);
    }
    public void Pausar()
    {
        a.Pause();
        Debug.Log("Clicou");
        Time.timeScale = 0;
        Global.Mostrar(g);
        Global.paused = true;


    }
    public void DesPausar()
    {
        a.UnPause();
        Time.timeScale = 1;
        Global.Esconder(g);
        Global.paused = false;




    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Global.paused == false)
        {
            Pausar();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Global.paused)
        {
            DesPausar();
        }
    }
}

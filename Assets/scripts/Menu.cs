using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;

using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{



    Global glob;
    GameObject[] g;
    public static GameObject[] gameover;
    GameObject[] Shop;
    SaveClass best;

    public TextMeshProUGUI Bestscore;
    public TextMeshProUGUI Money;
    public TextMeshProUGUI MoneyLoja;
    public AudioSource a;

    // Start is called before the first frame update
    void Start()
    {

        Global.a = a;
        g = GameObject.FindGameObjectsWithTag("Pause");
        Shop = GameObject.FindGameObjectsWithTag("Shop");
        gameover = GameObject.FindGameObjectsWithTag("GameOver");
        Global.Esconder(gameover);
        Global.Esconder(Shop);
        Global.Esconder(g);
        CarregaConf();
    }

    private void CarregaConf()
    {
        glob = new Global();
        best = Save.LoadGame<SaveClass>("Gamesettings");
        glob.BestScore = best.BestScore;
        glob.Money = best.Money;
        Global.Bestscr = glob.BestScore;
        Global.Dinheiro = glob.Money;
        if (Bestscore != null)
        {


            Bestscore.text = Global.Bestscr.ToString();
        }
        else
        {
            Debug.Log("Sem Best TExt");
        }
        if (Money != null)
            Money.text = Global.Dinheiro.ToString();
        else
            Debug.Log("Sem  Dinheiro Text");
        if (MoneyLoja != null)
            MoneyLoja.text = Global.Dinheiro.ToString();
        else
            Debug.Log("Sem  Dinheiro Text");


        
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
            Global.Dinheiro += Global.Score;
            glob.Money = Global.Dinheiro;

            if (Global.Bestscr < Global.Score)
            {
                Global.Bestscr = Global.Score;

            }
            glob.BestScore = Global.Bestscr;
            glob.Money = Global.Dinheiro;
            best = new SaveClass(glob);
            Save.SaveGame(best, "Gamesettings");

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

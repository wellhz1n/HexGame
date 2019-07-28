using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Loja : MonoBehaviour
{
    public ScrollRect scrollView;
    public GameObject scrollContent;
    public Sprite[] sprites = new Sprite[2];
    public GameObject prefab;
    private Global glob;
    private SaveClass best;
    private Vector3 position;
    List<Produtos> itens = new List<Produtos>();
    List<GameObject> ite = new List<GameObject>();
    public Menu menu = new Menu();
    // Start is called before the first frame update
    void Start()
    {
        Carregaconf();


        itens = Save.LoadGameList<Produtos>("Shop");


        prefab.gameObject.tag = "Shop";
        // prefab.GetComponentInChildren<SpriteRenderer>().gameObject.tag = "Shop";
        // prefab.GetComponentInChildren<TextMeshPro>().gameObject.tag = "Shop";
        // prefab.GetComponentInChildren<Button>().gameObject.tag = "Shop";
        // prefab.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshPro>().gameObject.tag = "Shop";

        if (itens == null)
        {
            itens = new List<Produtos>();
            itens.Add(new Produtos("Red", 50, true, true));
            itens.Add(new Produtos("Blue", 100, false, false));
            itens.Add(new Produtos("Green", 150, false, false));
            itens.Add(new Produtos("Yellow", 300, false, false));
        }

        //itens.Add(new Produtos("Star", 300));
        foreach (var item in itens)
        {
            switch (item.Cor)
            {
                case "Blue":
                    prefab.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
                    prefab.GetComponentInChildren<SpriteRenderer>().sprite = sprites[0];
                    prefab.GetComponentInChildren<Text>().text = "Blue";
                    break;
                case "Green":
                    prefab.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                    prefab.GetComponentInChildren<SpriteRenderer>().sprite = sprites[0];
                    prefab.GetComponentInChildren<Text>().text = "Green";
                    break;
                case "Red":
                    prefab.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                    prefab.GetComponentInChildren<SpriteRenderer>().sprite = sprites[0];
                    prefab.GetComponentInChildren<Text>().text = item.Cor;
                    break;
                case "Yellow":
                    prefab.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
                    prefab.GetComponentInChildren<SpriteRenderer>().sprite = sprites[0];
                    prefab.GetComponentInChildren<Text>().text = item.Cor;
                    break;
                case "Star":
                    prefab.GetComponentInChildren<SpriteRenderer>().sprite = sprites[1];
                    prefab.GetComponentInChildren<Text>().text = item.Cor;
                    break;

            }
            GameObject f = (GameObject)Instantiate(prefab);
            f.transform.SetParent(scrollContent.transform, false);
            if (item.Comprado)
            {
                f.GetComponentInChildren<Button>().onClick.AddListener(() => Selecionar(item.value));
                f.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text = "Select";
                if (item.Selecionado)
                {
                    f.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                    f.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text = "Selected";
                    Global.Cor = item.Cor;

                    }
                else
                {
                    f.GetComponentInChildren<Button>().onClick.AddListener(() => Selecionar(item.value));
                    f.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text = "Select";
                }
            }

            else
            {
                f.GetComponentInChildren<Button>().onClick.AddListener(() => TiraMoney(item.value));
                f.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text = item.value.ToString();
            }
            f.GetComponentInChildren<TextMeshProUGUI>().text = item.value.ToString();

            f.transform.localScale = new Vector3(3f, 3f, 0f);
            scrollView.verticalNormalizedPosition = 1;
            ite.Add(f.gameObject);



            Save.SaveGameList<Produtos>(itens, "Shop");
        }
    }

    private void Carregaconf()
    {
        glob = new Global();
        best = Save.LoadGame<SaveClass>("Gamesettings");
        glob.BestScore = best.BestScore;
        glob.Money = best.Money;
        Global.Bestscr = glob.BestScore;
        Global.Dinheiro = glob.Money;
    }

    void TiraMoney(int value)
    {
        if (value <= Global.Dinheiro)
        {
            var result = itens.First(v => v.value == value);
            result.Comprado = true;

            foreach (var item in ite)
            {
                if (item.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text == value.ToString())
                {
                    item.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text = "Select";
                    item.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                    item.GetComponentInChildren<Button>().onClick.AddListener(() => Selecionar(value));


                }

            }
            Global.Dinheiro -= value;
            Debug.Log(Global.Dinheiro.ToString());
            Save.SaveGameList<Produtos>(itens, "Shop");
            SaveDinheiro();
            menu.CarregaConfPublic();
        }
    }

    private void SaveDinheiro()
    {
        glob.BestScore = Global.Bestscr;
        glob.Money = Global.Dinheiro;
        best = new SaveClass(glob);
        Save.SaveGame(best, "Gamesettings");
    }

    void Selecionar(int value)
    {
        foreach (var item in ite)
        {
            if (value.ToString() == item.GetComponentInChildren<TextMeshProUGUI>().text)
            {
                var certo =itens.First(t => t.value == value);
                certo.Selecionado = true;

                if (item.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text == "Select")
                {
                    item.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text = "Selected";
                    item.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                    Global.Cor = certo.Cor;


                }
            }
            else
            {
                if (item.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text == "Selected")
                {
                    itens.First(t => t.value != value).Selecionado = false;

                    item.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text = "Select";
                    item.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                    item.GetComponentInChildren<Button>().onClick.AddListener(() => Selecionar(int.Parse(item.GetComponentInChildren<TextMeshProUGUI>().text)));
                }
            }

            //else
            //{

            //var deselecionar = itens.Where(t => t.value.ToString() != value.ToString());
            //if (deselecionar != null)
            //{
            //    foreach (var des in deselecionar)
            //    {

            //        if (des.Comprado && des.Selecionado)
            //        {
            //            des.Selecionado = false;
            //            item.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text = "Select";
            //            item.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
            //            item.GetComponentInChildren<Button>().onClick.AddListener(() => Selecionar(des.value));
            //        }
            //    }



            //}
            //}









        }
        Save.SaveGameList<Produtos>(itens, "Shop");
        menu.CarregaConfPublic();


    }
    // Update is called once per frame
    void Update()
    {


    }
}

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
    private Vector3 position;
    List<Produtos> itens = new List<Produtos>();
    List<GameObject> ite = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if (this.isActiveAndEnabled)
        {



            prefab.gameObject.tag = "Shop";
            // prefab.GetComponentInChildren<SpriteRenderer>().gameObject.tag = "Shop";
            // prefab.GetComponentInChildren<TextMeshPro>().gameObject.tag = "Shop";
            // prefab.GetComponentInChildren<Button>().gameObject.tag = "Shop";
            // prefab.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshPro>().gameObject.tag = "Shop";


            itens.Add(new Produtos("Blue", 100));
            itens.Add(new Produtos("Green", 150));
            itens.Add(new Produtos("Red", 600));
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
                    case "Star":
                        prefab.GetComponentInChildren<SpriteRenderer>().sprite = sprites[1];
                        prefab.GetComponentInChildren<Text>().text = item.Cor;
                        break;

                }
                GameObject f = (GameObject)Instantiate(prefab);
                f.transform.SetParent(scrollContent.transform, false);
                f.GetComponentInChildren<Button>().onClick.AddListener(() => TiraMoney(item.value));
                f.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text = item.value.ToString();
                f.transform.localScale = new Vector3(3f, 3f, 0f);
                scrollView.verticalNormalizedPosition = 1;
                ite.Add(f.gameObject);

            }


        }
    }

    void TiraMoney(int value)
    {
        if (value <= Global.Dinheiro)
        {
            var result = itens.First(v => v.value == value);
            result.comprado = true;
          
            foreach (var item in ite)
            {
                if (item.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text == value.ToString())
                {
                    item.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text = "Select";
                    item.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                    item.GetComponentInChildren<Button>().onClick.AddListener(()=> Selecionar());


                }
               
            }
            Global.Dinheiro -= value;
            Debug.Log(Global.Dinheiro.ToString());
        }
    }
    void Selecionar()
    {

    }
    // Update is called once per frame
    void Update()
    {
       

    }
}

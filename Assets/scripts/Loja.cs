using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{
    public GameObject prefab;
    private Vector3 position;
    List<Produtos> itens = new List<Produtos>();

    // Start is called before the first frame update
    void Start()
    {
        if (this.isActiveAndEnabled)
        {


            position = new Vector3(0f, 0f, 0f);
            prefab.gameObject.tag = "Shop";
            // prefab.GetComponentInChildren<SpriteRenderer>().gameObject.tag = "Shop";
            // prefab.GetComponentInChildren<TextMeshPro>().gameObject.tag = "Shop";
            // prefab.GetComponentInChildren<Button>().gameObject.tag = "Shop";
            // prefab.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshPro>().gameObject.tag = "Shop";


            itens.Add(new Produtos("Blue", 100));
            itens.Add(new Produtos("Green", 150));
            foreach (var item in itens)
            {
                switch (item.Cor)
                {
                    case "Blue":
                        prefab.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
                        prefab.GetComponentInChildren<Text>().text = "Blue";

                        break;
                    case "Green":
                        prefab.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                        prefab.GetComponentInChildren<Text>().text = "Green";
                        

                        break;

                }
                prefab.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<Text>().text = item.value.ToString();
                GameObject f = (GameObject)Instantiate(prefab, position, Quaternion.identity);
                f.transform.parent = transform;
                f.transform.localScale = new Vector3(3f, 3f, 0f);
                
                position.y += 3f;
            }


        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

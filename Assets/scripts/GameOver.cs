using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI hscore;

    // Start is called before the first frame update
    void Start()
    {


        score.text = Global.Score.ToString();
        hscore.text = Global.Bestscr < Global.Score ? Global.Score.ToString() : Global.Bestscr.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        score.text = Global.Score.ToString();

        hscore.text = Global.Bestscr < Global.Score ? Global.Score.ToString() : Global.Bestscr.ToString();


    }
}

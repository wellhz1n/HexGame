using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
     score =  GetComponent<TextMeshProUGUI>();

        score.text = Global.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = Global.Score.ToString();
    }
}

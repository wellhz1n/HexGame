using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRandomizer : MonoBehaviour
{
    public AudioClip[] audios = new AudioClip[6];
    public  int current;
    private int rand;
    private AudioSource audio;
    private static Random.State seedGenerator;
    private static int seedGeneratorSeed = 1337;
    private static bool seedGeneratorInitialized = false;
    // Start is called before the first frame update
    void Awake()
    {
        audio = this.gameObject.GetComponent<AudioSource>();
        current = Global.currentmusicGame;
        RandAudio(current);
    }


    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying &&!Global.paused)
        {
            RandAudio(current);
        }

    }
    private void RandAudio(int cur)
    {

   
        rand = (int)Random.Range(0f, 6f);
        while (cur == rand)
        {
            rand = (int)Random.Range(0f, 6f);

        }
        audio.clip = audios[rand];
        current = rand;
        Global.currentmusicGame = current;
        audio.PlayDelayed(0.3f);
    }
   
   
}

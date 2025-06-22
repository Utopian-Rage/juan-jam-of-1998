using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MoveSFX : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip Clip;
    public AudioClip Clip2;
    public double goaltime;

    // Update is called once per frame
    private void time()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            goaltime = AudioSettings.dspTime + 0.5;
            Source.clip = Clip;
            Source.PlayScheduled(goaltime);
        }
            
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            goaltime = AudioSettings.dspTime + 0.5;
            Source.clip = Clip2;
            Source.PlayScheduled(goaltime);
        }
    }
}

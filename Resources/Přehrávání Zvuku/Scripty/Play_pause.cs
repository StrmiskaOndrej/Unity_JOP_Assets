using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Play_pause : MonoBehaviour
{

    AudioSource sound;

    bool haveItEverPlayed = false;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }


    public void Play()
    {
        if (!haveItEverPlayed)
        {
            haveItEverPlayed = true;
            sound.Play();
        }
        else
        {
            sound.UnPause();
        }
    }

    public void Stop()
    {
        sound.Pause();
    }

	public void Reset()
	{
		sound.Stop();
		haveItEverPlayed = false;
	}
}

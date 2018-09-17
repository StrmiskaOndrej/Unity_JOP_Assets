using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class play : MonoBehaviour {

    //hraje nopr noty nebo pisnicky

    public Sprite[] images = new Sprite[2];

    void Update()
    {
        if (GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<Image>().sprite = images[0];
        }
        else
        {
            GetComponent<Image>().sprite = images[1];
        }
    }

	public void Click () {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
	}
}

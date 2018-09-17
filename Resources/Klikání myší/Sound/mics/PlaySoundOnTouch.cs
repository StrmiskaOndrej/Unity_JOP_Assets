using UnityEngine;
using System.Collections;

public class PlaySoundOnTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown()
	{
		this.gameObject.GetComponent<AudioSource>().Play();
	}
}

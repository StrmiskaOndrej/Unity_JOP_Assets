using UnityEngine;
using System.Collections;

public class gravitace_kruh : MonoBehaviour {
	public bool dotek;
	public bool error;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D (Collision2D col)
	{

		if(col.gameObject.tag == this.gameObject.tag)
		{
			dotek = true;
		}else if(col.gameObject.tag.Contains("Podlaha")){
			error = true;
		}else if(col.gameObject.tag.Contains("kruh")){
			error = true;
		}
	}
}

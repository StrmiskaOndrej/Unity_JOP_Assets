using UnityEngine;
using System.Collections;

public class DTD_bod : MonoBehaviour {
	public bool spojenoSPredchozi;
	public bool spojenoSDalsi;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(spojenoSDalsi && spojenoSPredchozi){
			this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
		}
		if((!spojenoSDalsi && spojenoSPredchozi) || (spojenoSDalsi && !spojenoSPredchozi)){
			this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,0.5f,0);
		}
	}
}

using UnityEngine;
using System.Collections;

public class textMaker : MonoBehaviour {

	// Use this for initialization
	string texty = "Přetáhni zvířátka\n kam patří";
	public TextMesh objekt;
	void Start () {
	objekt.text = texty;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

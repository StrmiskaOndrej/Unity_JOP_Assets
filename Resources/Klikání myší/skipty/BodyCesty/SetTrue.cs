using UnityEngine;
using System.Collections;

public class SetTrue : MonoBehaviour {

	// Use this for initialization
//	public string tag;
	public int pocet;
	GameObject[] polozky;
	public GameObject ovlivnen;
	public int pocetPolozek;
	bool pouzito = false;
//	Renderer[] render;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		polozky = GameObject.FindGameObjectsWithTag(tag);
		pocetPolozek = polozky.Length;
	if(polozky.Length == pocet && pouzito == false)
		{
			ovlivnen.gameObject.SetActive(true);
			pouzito = true;
		}
	}
}

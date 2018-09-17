using UnityEngine;
using System.Collections;

public class Vymaz_na_klik : MonoBehaviour {

	// Use this for initialization
	public GameObject tedy;
	Kontrola_puzzle kp;
	void Start () {
	kp = (Kontrola_puzzle)tedy.GetComponent(typeof(Kontrola_puzzle));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
	kp.spravne = kp.spravne + 1;	
	kp.SimpleKontroluj();
	 this.gameObject.SetActive(false);
	}
}

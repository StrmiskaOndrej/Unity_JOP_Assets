using UnityEngine;
using System.Collections;

public class Kontrola_vysky : MonoBehaviour {
	
	float cas = 3;
	public float odcitac;
	public bool dotek = false;
	public bool mys = false;
	GameObject tedy;
	public string checker;
	Puzzle_checker ch;
	void Start () {
	tedy = GameObject.Find(checker);	
	ch = (Puzzle_checker)tedy.GetComponent(typeof(Puzzle_checker));	
	odcitac = cas;
	}
	
	void Update () {
	if(Input.GetMouseButtonUp(0))
		{
			mys = true;
		}
	if(Input.GetMouseButtonDown(0))
		{
			mys = false;
		}
			if(dotek == true && mys == true)
			{
			odcitac = odcitac - Time.deltaTime;
				if(odcitac <= 0)
				{
				this.GetComponent<Renderer>().material.color = Color.green;
				ch.spravne = 200;
				ch.Kontroluj();
				
				}
			}
			else
				odcitac = cas;
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "target")
		{
			dotek = true;
		}
	}
	void OnTriggerStay(Collider other)
	{
		if(other.tag == "target")
		{
			dotek = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "target")
		{
			dotek = false;
		}
	}
}

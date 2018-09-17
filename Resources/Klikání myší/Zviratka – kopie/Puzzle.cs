using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour {

	// Use this for initialization
	GameObject checker;
	Puzzle_checker check;
	public Texture2D barevna;
	public float minVzdalenost = 0.3f;
	public string puzzleChecker;
	bool pouzito = false;
	public bool nahrad = false;
	public Sprite nahradZa;
	public SpriteRenderer sr;
	public bool pomineni = false;
	bool Upusteno = false;
	void Start () {
	checker = GameObject.Find(puzzleChecker);
	
			
	check = (Puzzle_checker)checker.GetComponent(typeof(Puzzle_checker));
	}
	

	
	void OnMouseUp()
	{
		if(Upusteno == false)
		{
		GameObject pom = GameObject.Find(this.name + "b");
		float vzdalenost = Vector3.Distance(this.transform.position,pom.transform.position);
		if(pomineni == true)
			{
				Podminka po = (Podminka)this.GetComponent(typeof(Podminka));
				if(po.KontrolaPostupu() == false)
				{
				vzdalenost = 30;
				}
				
			}
		
		if(vzdalenost < minVzdalenost)
			{
				Upusteno = true;
				DragDrop DD = (DragDrop)this.GetComponent(typeof(DragDrop));
				DD.enabled = false;
			Vector3 pozice = new Vector3();
			pozice = pom.transform.position;
			pozice.z = pozice.z - 0.001f;
			this.transform.position = pozice;
			if(nahrad == true)
			{
				sr.enabled = true;
				SpriteRenderer sr2 = (SpriteRenderer)this.transform.GetComponent(typeof(SpriteRenderer));
				sr2.enabled = false;
				
			}
			
			if(barevna != null)
			{
			this.GetComponent<Renderer>().material.mainTexture = barevna;
			}
			if(pouzito == false)
			{
			check.spravne++;
			check.Kontroluj();
			}
			pouzito = true;
			
			
			
			}
		}
	}
}
	
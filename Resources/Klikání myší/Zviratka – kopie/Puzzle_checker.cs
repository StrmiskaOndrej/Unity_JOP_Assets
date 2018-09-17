using UnityEngine;
using System.Collections;

public class Puzzle_checker : MonoBehaviour {

	// Use this for initialization
	public int spravne;
	public int Podminka;

    public Sprite happyTedy;
	public GameObject bublina;
    public GameObject bublinaOK;
    public ParticleSystem fireworks;
	
	public GameObject modryPruh;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Kontroluj()
	{
		if(spravne > Podminka)
		{
		//	tedy.gameObject.transform.GetComponent<Renderer>().material.mainTexture = happy;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = happyTedy;


            fireworks.Emit(90);
			if(modryPruh != null)
			modryPruh.SetActive(false);

            bublina.SetActive(false);
            bublinaOK.SetActive(true);

        }
		
			
	}
	public int Spravne {
		get {
			return this.spravne;
		}
		set {
			spravne = value;
		}
	}
}

using UnityEngine;
using System.Collections;

public class Kontrola_puzzle : MonoBehaviour {

	// Use this for initialization
	GameObject[]dilky;
	public int podminka;
	public ParticleSystem ohnostroj;
	public GameObject bublina1;
	public GameObject bublina2;
//	public Texture2D happyTedy;
    public Sprite happyTedy;
    public int spravne;
	public TextMesh pocet;
	OtaceciPuzzle ot;
	void Start () {
	dilky = GameObject.FindGameObjectsWithTag("Puzzle");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SimpleKontroluj()
	{
		if(pocet != null)
		{
			pocet.text = spravne.ToString();
		}
	if(spravne == podminka)
		{
	//		this.gameObject.GetComponent<Renderer>().material.mainTexture = happyTedy;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = happyTedy;

            bublina1.SetActive(false);
			bublina2.SetActive(true);
		ohnostroj.Emit(90);
		}	
	}
	
	public void Kontroluj()
	{
		spravne =0;
		for(int i =0; i < dilky.Length; i++)
		{
			ot = (OtaceciPuzzle)dilky[i].GetComponent(typeof(OtaceciPuzzle));
			if(ot.End == false)
			{
				spravne++;
			}
		}
		if(spravne == podminka)
		{
            //		this.gameObject.GetComponent<Renderer>().material.mainTexture = happyTedy;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = happyTedy;
            bublina1.SetActive(false);
			bublina2.SetActive(true);
			ohnostroj.Emit(90);
			
		}
	}
}

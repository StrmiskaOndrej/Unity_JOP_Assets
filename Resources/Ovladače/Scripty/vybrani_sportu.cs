using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class vybrani_sportu : MonoBehaviour {
	
	

	
	public int[] poradi = {0,1,2,3,4,5,6,7,8,9,10};
    public List<UnityEngine.UI.Toggle> sportytog;

    public GameObject[] sporty;
    public ParticleSystem ohnostroj;
	public bool firework = false;

	
	public GameObject[] bubliny;
	public string[] druhy = {"boj","mic", "zav"};
	public int[] druhypocet = {0, 0, 0};
	public int[] druhyporadi = {0, 1, 2};
	public int pomocna = 0;
	public GameObject ButtonZnovu;

	public GameObject bublinaKonec;
	public GameObject beh;
	public GameObject cykl;
	public GameObject fotbal;	
	public GameObject luk;
	public GameObject gymn;
	public GameObject tenis;
	public GameObject judo;
	public GameObject voll;
	public GameObject skok;
	public GameObject hazena;
	public GameObject karate;
	public int predchoziDruh = -1;
	public int zbyva = 0;
	public UnityEngine.UI.Text zbyvatext;
	
	void  Start (){
	//	UnityEngine.UI.Toggle[] sportytogdocasne = FindObjectsOfType(typeof(UnityEngine.UI.Toggle)) as UnityEngine.UI.Toggle[];
		sporty = GameObject.FindGameObjectsWithTag("sport").OrderBy( go => go.name ).ToArray();
		bubliny = GameObject.FindGameObjectsWithTag("Hra2Bublina").OrderBy( go => go.name ).ToArray();

	//	sportytog = sportytogdocasne.OrderBy( go => go.name ).ToArray();

        for (int i = 0; i < sporty.Length; i++)
        {
            sportytog.Add(sporty[i].transform.Find("toggle").gameObject.GetComponent<UnityEngine.UI.Toggle>());
        }

            inicializace();
	}

	void inicializace(){

		
		
		reshuffleint(poradi);   
		for(int i = 0; i <= 7; i++)
		{          
			for(int z = 0; z < druhy.Length; z++){
				if(sporty[poradi[i]].name.Contains(druhy[druhyporadi[z]])){
					druhypocet[druhyporadi[z]]++;
				}
			}    
		}
		
		
		VyberDruh();
		for(int u = 8; u < sporty.Length; u++)
		{
			sporty[poradi[u]].SetActive(false);    
		}
		zbyva = druhypocet[pomocna];
		pozicuj();	
		
	}


	void  Update (){ // spustí se každý frame
		
		
		if(zbyva > 0){	
			zbyva = druhypocet[pomocna];	
			for(int i = 0; i <= 7; i++){
				if(sporty[poradi[i]].name.Contains(druhy[druhyporadi[pomocna]]) && sportytog[poradi[i]].isOn){
					zbyva--;
				}
				if(!sporty[poradi[i]].name.Contains(druhy[druhyporadi[pomocna]]) && sportytog[poradi[i]].isOn){
					zbyva++;
				}
			}
			zbyvatext.text = "zbývá škrtnout: "+zbyva;
		}
		else{
			bublinaKonec.SetActive(true);
			bubliny[pomocna].GetComponent<SpriteRenderer>().enabled = false;
            if (firework==false){
				ohnostroj.Emit(90);
				firework=true;
				ButtonZnovu.SetActive(true);
				zbyvatext.text = "";
			}

		}
	}
	
	void  VyberDruh (){
		pomocna = Random.Range( 0, 3 );
		if(pomocna != predchoziDruh){
		if(druhypocet[pomocna] == 0){	
	
			VyberDruh();

		}
		predchoziDruh = pomocna;
            bubliny[pomocna].GetComponent<SpriteRenderer>().enabled = true;
		}
		else{
			znovu();
		}
	}
	
	void  pozicuj (){
		
		sporty[poradi[0]].transform.localPosition = new Vector3(-3.92f, 2.7f, 0);
		sporty[poradi[1]].transform.localPosition = new Vector3(-1.75f, 2.7f, 0);
		sporty[poradi[2]].transform.localPosition = new Vector3(0.25f, 2.7f, 0);
		sporty[poradi[3]].transform.localPosition = new Vector3(2.5f, 2.7f, 0);
		sporty[poradi[4]].transform.localPosition = new Vector3(-3.92f, 0.41f, 0);
		sporty[poradi[5]].transform.localPosition = new Vector3(-1.75f, 0.41f, 0);
		sporty[poradi[6]].transform.localPosition = new Vector3(0.25f, 0.41f, 0);
		sporty[poradi[7]].transform.localPosition = new Vector3(2.5f, 0.41f, 0);
		
		
	}

	public void znovu(){
		for(int u = 0; u < sporty.Length; u++)
		{
			sporty[poradi[u]].SetActive(true); 
			sportytog[u].isOn = false;
		}

		for(int i = 0; i < druhypocet.Length; i++){
			druhypocet[i] = 0;
			bubliny[i].GetComponent<SpriteRenderer>().enabled = false;

        }
		bublinaKonec.SetActive(false);
		zbyva = 0;
		pomocna = 0;
		inicializace();
		firework=false;
		ButtonZnovu.SetActive(false);

	}
	
	
	void reshuffleint(int[] texts)
	{
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < texts.Length; t++ )
		{
			int tmp = texts[t];
			int r = Random.Range(t, texts.Length);
			texts[t] = texts[r];
			texts[r] = tmp;
		}
	}
	
	void reshuffle(string[] texts)
	{
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < texts.Length; t++ )
		{
			string tmp = texts[t];
			int r = Random.Range(t, texts.Length);
			texts[t] = texts[r];
			texts[r] = tmp;
		}
	}
	

}
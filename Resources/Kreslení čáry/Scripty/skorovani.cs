using UnityEngine;
using System.Collections;
using System.Linq;

public class skorovani : MonoBehaviour {
	public GameObject bublina1;
	public GameObject bublinaKonec;
	public GameObject button;
	public bool  firework = false;
	public ParticleSystem ohnostroj;
	public GameObject[] mice;
	public GameObject[] branky;
	public GameObject[] liky;
	public GameObject[] mice_s;
	public int[] poradiMice = {0,1,2,3,4};
	public int[] poradiBL = {0,1,2,3,4};
	public int pocetHotovych;

	// Use this for initialization
	void Start () {
		mice = GameObject.FindGameObjectsWithTag("sporty_mic").OrderBy( go => go.name ).ToArray();
		branky = GameObject.FindGameObjectsWithTag("sporty_branka").OrderBy( go => go.name ).ToArray();
		liky = GameObject.FindGameObjectsWithTag("sporty_like").OrderBy( go => go.name ).ToArray();
		mice_s = GameObject.FindGameObjectsWithTag("sporty_small").OrderBy( go => go.name ).ToArray();
		inicializace();

	
	}

	void inicializace(){
		reshuffleint(poradiMice);
		reshuffleint(poradiBL);
		napozicuj();

	}

	void napozicuj(){
		mice[poradiMice[0]].transform.localPosition= new Vector2(-3.33f ,-2.75f);
		mice[poradiMice[1]].transform.localPosition= new Vector2(-1.54f ,-2.75f);
		mice[poradiMice[2]].transform.localPosition= new Vector2(0.46f ,-2.75f);
		mice[poradiMice[3]].transform.localPosition= new Vector2(2.651686f ,-2.75f);
		mice[poradiMice[4]].transform.localPosition= new Vector2(4.43f ,-2.75f);

		branky[poradiBL[0]].transform.localPosition= new Vector2(-3.33f ,0.3f);
		branky[poradiBL[1]].transform.localPosition= new Vector2(-1.54f ,0.3f);
		branky[poradiBL[2]].transform.localPosition= new Vector2(0.46f ,0.3f);
		branky[poradiBL[3]].transform.localPosition= new Vector2(2.651686f ,0.3f);
		branky[poradiBL[4]].transform.localPosition= new Vector2(4.43f ,0.3f);

		liky[poradiBL[0]].transform.localPosition= new Vector2(-3.33f ,3);
		liky[poradiBL[1]].transform.localPosition= new Vector2(-1.54f ,3);
		liky[poradiBL[2]].transform.localPosition= new Vector2(0.46f ,3);
		liky[poradiBL[3]].transform.localPosition= new Vector2(2.651686f ,3);
		liky[poradiBL[4]].transform.localPosition= new Vector2(4.43f ,3);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(pocetHotovych<5){
			pocetHotovych = 0;
			for( int i = 0; i<mice.Length; i++){
				if(mice[poradiMice[i]].GetComponent<sporty>().konec){
					pocetHotovych++;
				}

			} 
		
		
		}else{
			bublina1.SetActive(false);
			bublinaKonec.SetActive(true);
			button.SetActive(true);

			if(firework==false){
				ohnostroj.Emit(90);
				firework=true;
			}



		}
	}

	public void znovu(){
		pocetHotovych = 0;
		for( int i = 0; i<mice.Length; i++){
            liky[i].GetComponent<SpriteRenderer>().enabled = false;
			mice_s[i].transform.localScale = new Vector2(0,0);
			mice[i].GetComponent<sporty>().konec = false;
			mice[i].GetComponent<sporty>().line.positionCount = 0;
            mice[i].GetComponent<sporty>().line.startColor = Color.black;
            mice[i].GetComponent<sporty>().line.endColor = Color.black;
            //	line.SetVertexCount (1);
            mice_s[i].GetComponent<small_obj>().kol.isTrigger = false;
			}

		bublina1.SetActive(true);
		bublinaKonec.SetActive(false);
		button.SetActive(false);
		firework=false;
		inicializace();

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

}

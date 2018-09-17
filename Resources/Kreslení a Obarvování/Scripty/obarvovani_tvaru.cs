using UnityEngine;
using System.Collections;
using System.Linq;

public class obarvovani_tvaru : MonoBehaviour {
	public Color vybranaBarva;
	public UnityEngine.UI.Image zobrazenaBarva;

//	public GameObject picker;
//	public ColorPicker picker2;

	public bool hotovo = false;

	public GameObject BublinaStart1;
	public GameObject BublinaStart2;
	public GameObject BublinaKonec;
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public GameObject[] tvaryOBJ;
	public int zbyva = 14;
	public GameObject dum;
	public GameObject garaz;
	public GameObject ButtonZnovu;
	public GameObject Image;
	public bool  firework = false;
	public ParticleSystem ohnostroj;
	public int krok = 0;
	public float myTimer = 3;
	public Sprite dumsprite;
	public Sprite garazsprite;
	public bool barvaVybrana;

	
	// Use this for initialization
	void Start () {
		vybranaBarva = Color.white;
		tvaryOBJ = GameObject.FindGameObjectsWithTag("tvar").OrderBy( go => go.name ).ToArray();
//		picker2.onValueChanged.AddListener(color =>
//		                                  {
//			vybranaBarva = color;
//
//		});
		inicializace();
	}
	public void inicializace(){
		krok = 1;
		BublinaStart1.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(krok == 1){
			if(myTimer >0){	// spustí se krátký odpočet, poté se vyprázdní text. pole
				myTimer -= Time.deltaTime;
			}
			else{
				myTimer = 3;
				krok = 2;
				BublinaStart1.SetActive(false);
				BublinaStart2.SetActive(true);

			}


		}
		zobrazenaBarva.color = vybranaBarva;
		if(zbyva != 0){
			zbyva = 14;
			for(int i = 0; i < tvaryOBJ.Length; i++){
				if(tvaryOBJ[i].GetComponent<tvary>().hotovo == true){
					zbyva--;
				}
			}
		}else{
			hotovo=true;
			ButtonZnovu.SetActive(true);

			Image.SetActive(false);
			dum.GetComponent<SpriteRenderer>().color = new Color (1,1,0);
			dum.GetComponent<SpriteRenderer>().sprite = dumsprite;

			garaz.GetComponent<SpriteRenderer>().color = new Color (0.5f,0.5f,0.5f);
			garaz.GetComponent<SpriteRenderer>().sprite = garazsprite;
			BublinaStart1.SetActive(false);
			BublinaKonec.SetActive(true);
			if(firework==false){
				ohnostroj.Emit(90);
				firework=true;
			}
			

		}
	
	}

	public void Znovu(){
		BublinaStart1.SetActive(true);
		BublinaKonec.SetActive(false);
		dum.GetComponent<SpriteRenderer>().color = new Color (1,1,1);
		dum.GetComponent<SpriteRenderer>().sprite = null;
		garaz.GetComponent<SpriteRenderer>().color = new Color (1,1,1);
		garaz.GetComponent<SpriteRenderer>().sprite = null;
		Image.SetActive(true);
		ButtonZnovu.SetActive(false);
		for(int i = 0; i < tvaryOBJ.Length; i++){
			tvaryOBJ[i].GetComponent<tvary>().hotovo = false;
		//	tvaryOBJ[i].GetComponent<tvary>().barva = new Color (1,1,1);
			tvaryOBJ[i].GetComponent<tvary>().zmenNaPuvodni();
		}
		inicializace();
		zbyva = 14;
		hotovo = false;
		firework=false;


			



	}

	public void NastavCervenouBarvu(){
		vybranaBarva = new Color(1,0,0);
		barvaVybrana = true;

	}
	public void NastavCernouBarvu(){
		vybranaBarva = new Color(0,0,0);
		barvaVybrana = true;
		
	}
	public void NastavModrouBarvu(){
		vybranaBarva = new Color(0,0,1);
		barvaVybrana = true;
		
	}
	public void NastavZelenouBarvu(){
		vybranaBarva = new Color(0,1,0);
		barvaVybrana = true;
		
	}
	public void NastavZlutouBarvu(){
		vybranaBarva = new Color(1,1,0);
		barvaVybrana = true;
		
	}
	public void NastavHnedouBarvu(){
		vybranaBarva = new Color(0.5f,0.25f,0);
		barvaVybrana = true;
		
	}

	public void NastavSedouBarvu(){
		vybranaBarva = new Color(0.5f,0.5f,0.5f);
		barvaVybrana = true;
		
	}
	public void NastavRuzovouBarvu(){
		vybranaBarva = new Color(1,0.764f,0.796f);
		barvaVybrana = true;
		
	}
	public void NastavAquaBarvu(){
		vybranaBarva = new Color(0,1,1);
		barvaVybrana = true;
		
	}
	public void NastavOranzovouBarvu(){
		vybranaBarva = new Color(1,0.5f,0);
		barvaVybrana = true;
		
	}

	public void NastavTmZelenouBarvu(){
		vybranaBarva = new Color(0,0.392f,0);
		barvaVybrana = true;
		
	}
	public void NastavBilouBarvu(){
		vybranaBarva = new Color(1,1,1);
		barvaVybrana = true;
		
	}
	public void NastavFialovaBarvu(){
		vybranaBarva = new Color(1,0,1);
		barvaVybrana = true;
		
	}
	public void NastavSvSedaBarvu(){
		vybranaBarva = new Color(0.784f,0.784f,0.784f);
		barvaVybrana = true;
		
	}



}

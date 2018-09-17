using UnityEngine;
using System.Collections;
using System.Linq;

public class motyl_script : MonoBehaviour {
	public bool lajna;
	public bool kbelik;
	public Color vybranaBarva;
	public bool tvorim;
	public GameObject objekt;
	public GameObject objToSpawn;
	public Vector2 startPos;
	public Vector2 endPos;
	public bool  firework = false;
	public ParticleSystem ohnostroj;
	public bool  dobry = false;
	public UnityEngine.UI.Image zobrazenaBarva;
	public string barvaNazev;
	public bool dira1;
	public bool dira2;
	public bool dira3;
	public GameObject m1;
	public GameObject m5;
	public GameObject m6;
	public GameObject m9;
	public GameObject m11;
	public GameObject m12;
	public int chybi;
	public GameObject[] castiMotyla;
	public GameObject ButtonZnovu;
	public GameObject panel1;
	public GameObject panel2;
	public GameObject bublinaStart;
	public GameObject bublina4_2;
	public GameObject bublina4_konec;
	public int pocetLajn = 0;

	
	// Use this for initialization
	void Start () {
		vybranaBarva = Color.black;
		castiMotyla = GameObject.FindGameObjectsWithTag("castMotyla").OrderBy( go => go.name ).ToArray();

	}
	
	// Update is called once per frame
	void Update () {
		if(chybi>0){
		if(lajna == true){
			if(tvorim == false)
			{
				objekt = Instantiate(objToSpawn);
				objekt.transform.parent = gameObject.transform;
				objekt.tag = "lajnaMotyl";
				tvorim = true;
                objekt.GetComponent<lajna_nova>().line.startWidth = 0.04f;
                objekt.GetComponent<lajna_nova>().line.endWidth = 0.04f;
                objekt.GetComponent<lajna_nova>().SortingOrder = 2;
			}
			if(objekt.GetComponent<lajna_nova>().konec){
				startPos = objekt.GetComponent<lajna_nova>().startPos;
				endPos = objekt.GetComponent<lajna_nova>().endPos;
				//díra1
				if(startPos.x > 37.211f && startPos.x < 37.388f && startPos.y > 0.929f && startPos.y < 1.091f){
					if(endPos.x > 37.502f && endPos.x < 37.6314f && endPos.y > 0.945f && endPos.y < 1.026f){
						dobry = true;
						m1.GetComponent<castMotyla>().dira = true;
						m12.GetComponent<castMotyla>().dira = true;
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(37.55f, 0.994f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(37.34f, 1.01f));
					}
				}else if(endPos.x > 37.211f && endPos.x < 37.388f && endPos.y > 0.929f && endPos.y < 1.091){
					if(startPos.x > 37.502f && startPos.x < 37.6314f && startPos.y > 0.945f && startPos.y < 1.026f){
						dobry = true;							
						m1.GetComponent<castMotyla>().dira = true;
						m12.GetComponent<castMotyla>().dira = true;
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(37.55f, 0.994f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(37.34f, 1.01f));
					}
				}//díra2
				else if(startPos.x > 39.343f && startPos.x < 39.466f && startPos.y > -0.654f && startPos.y < -0.541f){
					if(endPos.x > 39.490f && endPos.x < 39.587f && endPos.y > -0.444f && endPos.y < -0.379f){

						dobry = true;							
						m6.GetComponent<castMotyla>().dira = true;
						m9.GetComponent<castMotyla>().dira = true;
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(39.539f, -0.428f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(39.426f, -0.557f));
					}
				}else if(endPos.x > 39.343f && endPos.x < 39.466f && endPos.y > -0.644f && endPos.y < -0.541f){
					if(startPos.x > 39.490f && startPos.x < 39.587f && startPos.y > -0.444f && startPos.y < -0.379f){

						dobry = true;							
						m6.GetComponent<castMotyla>().dira = true;
						m9.GetComponent<castMotyla>().dira = true;
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(39.539f, -0.428f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(39.426f, -0.557f));
					}
				}//díra3
				else if(startPos.x > 37.411f && startPos.x < 37.534f && startPos.y > -1.446f && startPos.y < -1.323f){
					if(endPos.x > 37.534f && endPos.x < 37.657f && endPos.y > -1.222f && endPos.y < -1.155f){


						dobry = true;
						m5.GetComponent<castMotyla>().dira = true;
						m11.GetComponent<castMotyla>().dira = true;
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(37.469f, -1.333f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(37.582f, -1.204f));
					}
				}else if(endPos.x > 37.411f && endPos.x < 37.534f && endPos.y > -1.446f && endPos.y < -1.323f){
					if(startPos.x > 37.534f && startPos.x < 37.657f && startPos.y > -1.222f && startPos.y < -1.155f){

						dobry = true;
						m5.GetComponent<castMotyla>().dira = true;
						m11.GetComponent<castMotyla>().dira = true;
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(37.469f, -1.333f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(37.582f, -1.204f));
					}
				}
				
				if(dobry==false){
					Object.Destroy(objekt);
					
					}else{
						pocetLajn++;
					}
				tvorim = false;
				dobry = false;

			}

		}
			if(pocetLajn >=3){
				bublinaStart.SetActive(false);
				bublina4_2.SetActive(true);
			}
			overeni();
		}else{

			if(firework==false){
				ohnostroj.Emit(90);
				firework=true;
			}
			ButtonZnovu.SetActive(true);
			panel1.SetActive(false);
			panel2.SetActive(false);

			lajna = false;
			kbelik = false;
			bublina4_2.SetActive(false);
			bublina4_konec.SetActive(true);
		}
	
	}

	public void znovu(){
		ButtonZnovu.SetActive(false);
		panel1.SetActive(true);
		panel2.SetActive(true);
		chybi = 18;

		GameObject[] objs = GameObject.FindGameObjectsWithTag("lajnaMotyl");
		for (int i=0; i<objs.Length; i++){
			Destroy(objs[i]);
		}

		for(int i = 0; i<castiMotyla.Length;i++){
			castiMotyla[i].GetComponent<SpriteRenderer>().color = Color.white;
			castiMotyla[i].GetComponent<castMotyla>().barvaOK = false;
			castiMotyla[i].GetComponent<castMotyla>().dira = false;
			castiMotyla[i].GetComponent<castMotyla>().inicializace();

		}
		tvorim = false;
		firework = false;
		pocetLajn = 0;
		bublina4_konec.SetActive(false);
		bublinaStart.SetActive(true);
	}

	public void overeni(){
		chybi = 18;
		for(int i = 0; i <castiMotyla.Length; i++){
			if(castiMotyla[i].GetComponent<castMotyla>().barvaOK){
				chybi--;
			}
		}


	}

	public void prepniNaLajnu(){
		lajna = true;
		kbelik = false;
	}

	public void prepniNaKbelik(){
		kbelik = true;
		lajna = false;
		zobrazenaBarva.color = vybranaBarva;
	}

	public void NastavTmOranzovouBarvu(){
		vybranaBarva = new Color(0.949f,0.419f,0.168f);
		barvaNazev = "tmaveOranzova";
		prepniNaKbelik();
		
	}
	public void NastavCernouBarvu(){
		vybranaBarva = new Color(0,0,0);
		prepniNaKbelik();
		barvaNazev = "cerna";
				
	}
	public void NastavModrouBarvu(){
		vybranaBarva = new Color(0,0,1);
		prepniNaKbelik();
		barvaNazev = "modra";

		
	}
	public void NastavZelenouBarvu(){
		vybranaBarva = new Color(0.651f,0.807f,0.223f);
		prepniNaKbelik();
		barvaNazev = "zelena";

		
	}
	public void NastavZlutouBarvu(){
		vybranaBarva = new Color(1,0.788f,0.137f);
		prepniNaKbelik();
		barvaNazev = "zluta";
		
	}
	public void NastavHnedouBarvu(){
		vybranaBarva = new Color(0.5f,0.25f,0);
		prepniNaKbelik();
		barvaNazev = "hneda";
		
	}
	
	public void NastavSedouBarvu(){
		vybranaBarva = new Color(0.5f,0.5f,0.5f);
		prepniNaKbelik();
		barvaNazev = "seda";

		
	}

	public void NastavAquaBarvu(){
		vybranaBarva = new Color(0,1,1);
		prepniNaKbelik();
		barvaNazev = "aqua";

		
	}
	public void NastavOranzovouBarvu(){
		vybranaBarva = new Color(0.968f,0.5552f,0.16f);
		prepniNaKbelik();
		barvaNazev = "oranzova";
			
	}
	

	public void NastavBilouBarvu(){
		vybranaBarva = new Color(1,1,1);
		prepniNaKbelik();
		barvaNazev = "bila";

		
	}



}

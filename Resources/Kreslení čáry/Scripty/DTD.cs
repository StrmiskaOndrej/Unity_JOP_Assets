using UnityEngine;
using System.Collections;
using System.Linq;

public class DTD : MonoBehaviour {
	public GameObject objToSpawn;
	public GameObject[] body;
	public GameObject[] bodyText;
	public bool tvorim;
	public bool dobry;
	public GameObject objekt;
	public GameObject kachna;
	public GameObject motorka;
	public GameObject dortik;
	public GameObject ButtonZnovu;
	public float vzdalenost1;
	public float vzdalenost2;
	public int zbyva = 24;
	public bool  firework = false;
	public ParticleSystem ohnostroj;
	public GameObject bublinaStart;
	public GameObject bublinaKonec;
	public int scenar = 0;
	public int[] scenare  = {0,1,2};


	// Use this for initialization
	void Start () {
		body = GameObject.FindGameObjectsWithTag("bod").OrderBy( go => go.name ).ToArray();
		bodyText = GameObject.FindGameObjectsWithTag("bodText").OrderBy( go => go.name ).ToArray();
		reshuffleint(scenare);

		inicializace();
	
	}
	
	// Update is called once per frame
	void Update () {
//		if(body.Length ==0){
//			inicializace();
//		}
		if(zbyva >0){
			if(tvorim == false)
			{
				objekt = Instantiate(objToSpawn);
				objekt.transform.parent = gameObject.transform;
				objekt.tag = "lajna";
				tvorim = true;
			}


			if(objekt.GetComponent<lajna_nova>().konec){
				for(int i = 0; i < body.Length; i++){
					int pom;
					if(i == body.Length -1){
						pom =0;
					}else{
						pom = i+1;
					}

					vzdalenost1 = Vector3.Distance(body[i].transform.position,objekt.GetComponent<lajna_nova>().startPos); 
					vzdalenost2 = Vector3.Distance(body[pom].transform.position,objekt.GetComponent<lajna_nova>().endPos);
					if(vzdalenost1 <= 0.1 && vzdalenost2 <= 0.1 && body[i].GetComponent<DTD_bod>().spojenoSDalsi == false){
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, body[i].transform.position);
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, body[pom].transform.position);
                        objekt.GetComponent<lajna_nova>().line.startColor = Color.yellow;
                        objekt.GetComponent<lajna_nova>().line.endColor = Color.yellow;
                        body[i].GetComponent<DTD_bod>().spojenoSDalsi = true;
						body[pom].GetComponent<DTD_bod>().spojenoSPredchozi = true;
						dobry = true;
						zbyva--;
					}
					vzdalenost1 = Vector3.Distance(body[i].transform.position,objekt.GetComponent<lajna_nova>().endPos); 
					vzdalenost2 = Vector3.Distance(body[pom].transform.position,objekt.GetComponent<lajna_nova>().startPos);
					if(vzdalenost1 <= 0.1 && vzdalenost2 <= 0.1 && body[pom].GetComponent<DTD_bod>().spojenoSPredchozi ==false){
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, body[i].transform.position);
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, body[pom].transform.position);
                        objekt.GetComponent<lajna_nova>().line.startColor = Color.yellow;
                        objekt.GetComponent<lajna_nova>().line.endColor = Color.yellow;
                        body[i].GetComponent<DTD_bod>().spojenoSDalsi = true;
						body[pom].GetComponent<DTD_bod>().spojenoSPredchozi = true;
						dobry = true;
						zbyva--;
					}

					
				}

				if(dobry == false){
					Object.Destroy(objekt);
				}
				tvorim = false;
				dobry = false;
			}
		}else{
			ButtonZnovu.SetActive(true);
			bublinaStart.SetActive(false);
			bublinaKonec.SetActive(true);
			if(scenare[scenar] == 0){
				kachna.SetActive(true);
			}else if(scenare[scenar] == 1){
				motorka.SetActive(true);
			}else{
				dortik.SetActive(true);
			}

			GameObject[] objs = GameObject.FindGameObjectsWithTag("lajna");
			for (int i=0; i<objs.Length; i++){
				Destroy(objs[i]);
			}
			for(int i = 0; i<body.Length; i++){
				body[i].GetComponent<DTD_bod>().spojenoSDalsi =false;
				body[i].GetComponent<DTD_bod>().spojenoSPredchozi =false;
				body[i].GetComponent<SpriteRenderer>().color = Color.black;

				body[i].SetActive(false);

			}
			if(firework==false){
				ohnostroj.Emit(90);
				firework=true;
			}
			

			
		}
		
	}
	public void inicializace(){

		for(int i = 0; i<body.Length; i++){
			body[i].SetActive(true);
			
		}
		pozicuj();
	}

	public void pozicuj(){
		if(scenare[scenar] == 0)//kachna
		{
			body[0].transform.localPosition = new Vector2 (0.85f,0.53f);
			body[1].transform.localPosition = new Vector2 (1.83f,0.36f);
			body[2].transform.localPosition = new Vector2 (2.7f,1.07f);
			body[3].transform.localPosition = new Vector2 (3.73f,1.67f);
			body[4].transform.localPosition = new Vector2 (4.67f,1.787f);
			body[5].transform.localPosition = new Vector2 (5.72f,1.335f);
			body[6].transform.localPosition = new Vector2 (6.76f,0.682f);
			body[7].transform.localPosition = new Vector2 (6.46f,1.954f);
			body[8].transform.localPosition = new Vector2 (6.54f,2.816f);			
			body[9].transform.localPosition = new Vector2 (7.04f,3.492f);

			body[10].transform.localPosition = new Vector2 (7.61f,3.525f);
			body[11].transform.localPosition = new Vector2 (8.23f,3.072f);
			body[12].transform.localPosition = new Vector2 (8.56f,2.409f);
			body[13].transform.localPosition = new Vector2 (9.42f,1.705f);
			body[14].transform.localPosition = new Vector2 (8.23f,1.96f);
			body[15].transform.localPosition = new Vector2 (7.65f,1.792f);
			body[16].transform.localPosition = new Vector2 (7.65f,1.102f);
			body[17].transform.localPosition = new Vector2 (7.89f,0.45f);
			body[18].transform.localPosition = new Vector2 (7.97f,-0.202f);
			body[19].transform.localPosition = new Vector2 (7.39f,-1.321f);
			body[20].transform.localPosition = new Vector2 (6.42f,-1.24f);

			body[21].transform.localPosition = new Vector2 (4.9f,-1.41f);
			body[22].transform.localPosition = new Vector2 (2.68f,-1.38f);
			body[23].transform.localPosition = new Vector2 (1.6f,-0.69f);


			bodyText[0].transform.localPosition = new Vector2 (-1.5f,11.5f);
			bodyText[1].transform.localPosition = new Vector2 (-1.5f,11.5f);
			bodyText[2].transform.localPosition = new Vector2 (-1.5f,11.5f);
			bodyText[3].transform.localPosition = new Vector2 (-1.5f,11.5f);
			bodyText[4].transform.localPosition = new Vector2 (-1.5f,11.5f);
			bodyText[5].transform.localPosition = new Vector2 (-1.5f,11.5f);
			bodyText[6].transform.localPosition = new Vector2 (-1.5f,-3.31f);
			bodyText[7].transform.localPosition = new Vector2 (3.86f,2.82f);
			bodyText[8].transform.localPosition = new Vector2 (-5.14f,9.58f);
			bodyText[9].transform.localPosition = new Vector2 (-4f,11.5f);

			bodyText[10].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[11].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[12].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[13].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[14].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[15].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[16].transform.localPosition = new Vector2 (-10.43f,3.61f);
			bodyText[17].transform.localPosition = new Vector2 (3.37f,4.43f);
			bodyText[18].transform.localPosition = new Vector2 (3.37f,4.43f);
			bodyText[19].transform.localPosition = new Vector2 (6.02f, 4.31f);
			bodyText[20].transform.localPosition = new Vector2 (-4f,11.5f);

			bodyText[21].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[22].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[23].transform.localPosition = new Vector2 (-3.97f,-4.01f);
            bodyText[24].transform.localPosition = new Vector2(-13.6f, 4f);
        }
		if(scenare[scenar] ==1){//Motorka
			body[0].transform.localPosition = new Vector2 (0.82f,0.53f);
			body[1].transform.localPosition = new Vector2 (1.07f,1.18f);
			body[2].transform.localPosition = new Vector2 (1.27f,1.73f);
			body[3].transform.localPosition = new Vector2 (1.66f,2.47f);
			body[4].transform.localPosition = new Vector2 (1.98f,3.24f);
			body[5].transform.localPosition = new Vector2 (2.11f,2.89f);
			body[6].transform.localPosition = new Vector2 (2.76f,3.45f);
			body[7].transform.localPosition = new Vector2 (3.01f,3.09f);
			body[8].transform.localPosition = new Vector2 (2.75f,2.59f);			
			body[9].transform.localPosition = new Vector2 (3.42f,2.41f);
			
			body[10].transform.localPosition = new Vector2 (4.65f,2.72f);
			body[11].transform.localPosition = new Vector2 (5.55f,2.22f);
			body[12].transform.localPosition = new Vector2 (6.98f,2.17f);
			body[13].transform.localPosition = new Vector2 (8.65f,2.79f);
			body[14].transform.localPosition = new Vector2 (9.18f,0.99f);
			body[15].transform.localPosition = new Vector2 (9.09f,-0.38f);
			body[16].transform.localPosition = new Vector2 (8.54f, -1.2f);
			body[17].transform.localPosition = new Vector2 (7.28f, -1.35f);
			body[18].transform.localPosition = new Vector2 (6.55f,-0.71f);
			body[19].transform.localPosition = new Vector2 (5.1f,-0.83f);
			body[20].transform.localPosition = new Vector2 (3.03f,-0.87f);
			
			body[21].transform.localPosition = new Vector2 (2.52f,-1.29f);
			body[22].transform.localPosition = new Vector2 (1.3f,-1.28f);
			body[23].transform.localPosition = new Vector2 (0.63f,-0.54f);
			
			
			bodyText[0].transform.localPosition = new Vector2 (-10f,4f);
			bodyText[1].transform.localPosition = new Vector2 (-10f,4f);
			bodyText[2].transform.localPosition = new Vector2 (-10f,4f);
			bodyText[3].transform.localPosition = new Vector2 (-10f,4f);
			bodyText[4].transform.localPosition = new Vector2 (-1.5f,11.5f);
			bodyText[5].transform.localPosition = new Vector2 (-1.5f,-5f);
			bodyText[6].transform.localPosition = new Vector2 (-1.5f,11.5f);
			bodyText[7].transform.localPosition = new Vector2 (3.86f,10f);
			bodyText[8].transform.localPosition = new Vector2 (-1.5f,-5f);
			bodyText[9].transform.localPosition = new Vector2 (-4f,-5f);
			
			bodyText[10].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[11].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[12].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[13].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[14].transform.localPosition = new Vector2 (3.6f,4.4f);
			bodyText[15].transform.localPosition = new Vector2 (3.6f,4.4f);
			bodyText[16].transform.localPosition = new Vector2 (4.9f,-2.9f);
			bodyText[17].transform.localPosition = new Vector2 (0, 11.6f);
			bodyText[18].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[19].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[20].transform.localPosition = new Vector2 (-4f,11.5f);

			bodyText[21].transform.localPosition = new Vector2 (-7f,11.5f);
			bodyText[22].transform.localPosition = new Vector2 (0f,11.5f);
			bodyText[23].transform.localPosition = new Vector2 (5.3f,10.7f);
            bodyText[24].transform.localPosition = new Vector2(6.6f, 4f);
        }
		if(scenare[scenar] == 2){//dortik
			body[0].transform.localPosition = new Vector2 (2.6f,0.954f);
			body[1].transform.localPosition = new Vector2 (2.206f,1.4f);
			body[2].transform.localPosition = new Vector2 (2.096f,1.889f);
			body[3].transform.localPosition = new Vector2 (2.538f,2.318f);
			body[4].transform.localPosition = new Vector2 (2.526f,2.907f);
			body[5].transform.localPosition = new Vector2 (2.777f,3.481f);
			body[6].transform.localPosition = new Vector2 (3.321f,4.079f);
			body[7].transform.localPosition = new Vector2 (3.814f,4.575f);
			body[8].transform.localPosition = new Vector2 (3.477f,4.718f);			
			body[9].transform.localPosition = new Vector2 (3.935f,4.985f);
				
			body[10].transform.localPosition = new Vector2 (5.002f,4.961f);
			body[11].transform.localPosition = new Vector2 (5.91f,4.58f);
			body[12].transform.localPosition = new Vector2 (6.59f,3.98f);
			body[13].transform.localPosition = new Vector2 (6.99f,3.4f);
			body[14].transform.localPosition = new Vector2 (7.19f,2.62f);
			body[15].transform.localPosition = new Vector2 (7.54f,1.87f);
			body[16].transform.localPosition = new Vector2 (7.18f,1.31f);
			body[17].transform.localPosition = new Vector2 (7.12f,0.48f);
			body[18].transform.localPosition = new Vector2 (6.68f,-0.66f);
			body[19].transform.localPosition = new Vector2 (5.94f,-1f);
			body[20].transform.localPosition = new Vector2 (4.9f,-1.16f);
				
			body[21].transform.localPosition = new Vector2 (3.85f,-1.01f);
			body[22].transform.localPosition = new Vector2 (3.22f,-0.66f);
			body[23].transform.localPosition = new Vector2 (2.9f,-0.03f);
			
			
			bodyText[0].transform.localPosition = new Vector2 (-10f,4f);
			bodyText[1].transform.localPosition = new Vector2 (-10f,4f);
			bodyText[2].transform.localPosition = new Vector2 (-10f,4f);
			bodyText[3].transform.localPosition = new Vector2 (-8f,7f);
			bodyText[4].transform.localPosition = new Vector2 (-8f,7f);
			bodyText[5].transform.localPosition = new Vector2 (-8f,7f);
			bodyText[6].transform.localPosition = new Vector2 (-8f,7f);
			bodyText[7].transform.localPosition = new Vector2 (5f,0f);
			bodyText[8].transform.localPosition = new Vector2 (-1.5f,11.5f);
			bodyText[9].transform.localPosition = new Vector2 (-4f,11.5f);
			
			bodyText[10].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[11].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[12].transform.localPosition = new Vector2 (3.6f,7f);
			bodyText[13].transform.localPosition = new Vector2 (3.6f,7f);
			bodyText[14].transform.localPosition = new Vector2 (3.6f,7f);
			bodyText[15].transform.localPosition = new Vector2 (3.6f,4.4f);
			bodyText[16].transform.localPosition = new Vector2 (4f,-3f);
			bodyText[17].transform.localPosition = new Vector2 (4f,-3f);
			bodyText[18].transform.localPosition = new Vector2 (-8f,11.5f);
			bodyText[19].transform.localPosition = new Vector2 (-4f,11.5f);
			bodyText[20].transform.localPosition = new Vector2 (-4f,11.5f);
		
			bodyText[21].transform.localPosition = new Vector2 (4f,11.5f);
			bodyText[22].transform.localPosition = new Vector2 (4f,11.5f);
			bodyText[23].transform.localPosition = new Vector2 (4f,11.5f);
            bodyText[24].transform.localPosition = new Vector2(6.6f, 4f);
        }
	}
	public void znovu(){
		bublinaStart.SetActive(true);
		bublinaKonec.SetActive(false);
		ButtonZnovu.SetActive(false);
		zbyva = 24;
		kachna.SetActive(false);
		motorka.SetActive(false);
		dortik.SetActive(false);
		inicializace();
		firework=false;
		if(scenar == 2){
			scenar = 0;
		}else{
		scenar++;
		}
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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class gravitace : MonoBehaviour {
	public Vector2 mousePos;
	private List<Vector2> pointsList;
	public bool isPressed;
	public bool tvorim;
	public GameObject bublina_start;
	public GameObject bublina_start1;
	public GameObject bublina_start2;
	public GameObject bublina_spravne;
	public GameObject bublina_spatne;
	public GameObject bublina_konec;
	public GameObject objToSpawnTuzka;
	public GameObject objekt;

	public bool spusteno;
	public bool nastaveno;
	public bool vyhodnoceno;
	public GameObject objToSpawnKruh;
	public GameObject kruh;
	public List<GameObject> kruhy;
	public bool bezPohybu;
	public int gravitaceCislo = 0;
	public Sprite spDrink;
	public Sprite spJidlo;
	public Sprite spLehatko;
	public Sprite spPalmy;
	public Sprite spPlaz;
	public float speedTemp;
	public List<float> speed;
	public float kratkyOdpocet = 1;
	public float kratkyOdpocet2Temp = 5;
	public List<float> kratkyOdpocet2;
	public List<bool> zastaveno;
	public bool error;
	public UnityEngine.UI.Text levelText;
	public UnityEngine.UI.Button spustButton;
	public UnityEngine.UI.Button znovuButton;
	public UnityEngine.UI.Button dalsiLevelButton;
	public int level = 1;
	public bool  firework = false;
	public ParticleSystem ohnostroj;



	// Use this for initialization
	void Start () {
		pointsList = new List<Vector2>();
		kruhy = new List<GameObject>();
		levelText.text = "úroveň: "+level;
		dalsiLevelButton.interactable = false;
		znovuButton.interactable = false;
		spustButton.interactable = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!spusteno){
			if(!nastaveno){
				nastav();
			}
			var v3 = Input.mousePosition;
			v3.z = 8.5f;
			v3 = Camera.main.ScreenToWorldPoint(v3);
			
			mousePos = v3;
			if(Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0 && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
			{

					isPressed = true;
				
			}
			if(Input.GetMouseButtonUp(0)){
				isPressed = false;
				tvorim = false;
			}
			if(isPressed == true){
				if(tvorim == false)
				{
					objekt = Instantiate(objToSpawnTuzka);
					objekt.transform.parent = gameObject.transform;
					objekt.tag = "gravitaceTuzka";
                    objekt.GetComponent<KreslimeLajnu_s_colliderem>().line.startWidth = 0.1f;
                    objekt.GetComponent<KreslimeLajnu_s_colliderem>().line.endWidth = 0.1f;

                    objekt.GetComponent<KreslimeLajnu_s_colliderem>().line.startColor = Color.black;
                    objekt.GetComponent<KreslimeLajnu_s_colliderem>().line.endColor = Color.black;

                    tvorim = true;
					pointsList.RemoveRange(0,pointsList.Count);
					znovuButton.interactable = true;
					spustButton.interactable = true;
				}

				if (!pointsList.Contains (mousePos)) 
				{
					pointsList.Add (mousePos);
					objekt.GetComponent<KreslimeLajnu_s_colliderem>().line.positionCount = pointsList.Count;
					objekt.GetComponent<KreslimeLajnu_s_colliderem>().line.SetPosition (pointsList.Count - 1, mousePos);
					
					
					
					if(pointsList.Count > 2){
						objekt.GetComponent<KreslimeLajnu_s_colliderem>().objekt = Instantiate(objekt.GetComponent<KreslimeLajnu_s_colliderem>().colliderToSpawn);
						objekt.GetComponent<KreslimeLajnu_s_colliderem>().objekt.GetComponent<kreslime_collider>().tloustka = 0.1f;
						objekt.GetComponent<KreslimeLajnu_s_colliderem>().objekt.transform.parent = objekt.transform;

						objekt.GetComponent<KreslimeLajnu_s_colliderem>().objekt.GetComponent<kreslime_collider>().startPos = pointsList[pointsList.Count - 2];				
						objekt.GetComponent<KreslimeLajnu_s_colliderem>().objekt.GetComponent<kreslime_collider>().endPos = pointsList[pointsList.Count -1];
						objekt.GetComponent<KreslimeLajnu_s_colliderem>().objekt.GetComponent<kreslime_collider>().addColliderToLine();
					}
				}
			}
		}else{
			int pocetKruhu = kruhy.Count;		
			if(!bezPohybu){
				if(kratkyOdpocet >0){  
					kratkyOdpocet -= Time.deltaTime;
				}else{

					for(int i =0;i<kruhy.Count; i++){
						speed[i] = kruhy[i].GetComponent<Rigidbody2D>().velocity.magnitude;
						if(speed[i]<1f){
							if(speed[i]<0.05f){
								kratkyOdpocet2[i] = kratkyOdpocet2[i] - 0.5f;
							}
							if(kratkyOdpocet2[i] > 0){
								kratkyOdpocet2[i] -= Time.deltaTime;
							}else{								
								if(speed[i]<1f){
									zastaveno[i] = true;
								}else{
									zastaveno[i] = false;
								}								
							}
						}else{
							zastaveno[i] = false;
							kratkyOdpocet2[i] = 5;

						}
					}
				
					bezPohybu = true;
					for(int i =0;i<kruhy.Count; i++){
						if(!zastaveno[i]){
							bezPohybu = false;
						}
						if(kruhy[i].GetComponent<gravitace_kruh>().error){
							kruhy[i].GetComponent<SpriteRenderer>().color = Color.red;
							error = true;
							bezPohybu = true;
						}
					}
				}
			}else{
				if(!vyhodnoceno){

					bublina_start.SetActive(false);
					bublina_start1.SetActive(false);
					bublina_start2.SetActive(false);
					int pocetSpojeno = 0;
					for(int i =0;i<kruhy.Count; i++){
						if(kruhy[i].GetComponent<gravitace_kruh>().dotek){
							pocetSpojeno++;
						}else{
							kruhy[i].GetComponent<SpriteRenderer>().color = Color.gray;
						}
						if(kruhy[i].GetComponent<gravitace_kruh>().error){
							kruhy[i].GetComponent<SpriteRenderer>().color = Color.red;
						}
					}

					if(pocetKruhu == pocetSpojeno && !error){
						if(level == 12){
							bublina_konec.SetActive(true);
                            firework = true;

						}else{
							bublina_spravne.SetActive(true);
						}
						dalsiLevelButton.interactable = true;
						spustButton.interactable = false;
						znovuButton.interactable = false;

					}else{
						bublina_spatne.SetActive(true);
					}
					vyhodnoceno = true;
				}
			}
		}

		if(firework){
			ohnostroj.Emit(90);
		}
	}




	public void spust(){
		gravitaceCislo = 1;
		spustButton.interactable = false;
		spusteno = true;
		zmenGravitaci();
	}
	public void zmenGravitaci(){

		GameObject[] objs = GameObject.FindGameObjectsWithTag("kruhDrink");
		for (int i=0; i<objs.Length; i++){
			objs[i].GetComponent<Rigidbody2D>().isKinematic = false;
			objs[i].GetComponent<Rigidbody2D>().gravityScale = gravitaceCislo;
		}
		objs = GameObject.FindGameObjectsWithTag("kruhJidlo");
		for (int i=0; i<objs.Length; i++){
			objs[i].GetComponent<Rigidbody2D>().isKinematic = false;
			objs[i].GetComponent<Rigidbody2D>().gravityScale = gravitaceCislo;
		}
		objs = GameObject.FindGameObjectsWithTag("kruhLehatko");
		for (int i=0; i<objs.Length; i++){
			objs[i].GetComponent<Rigidbody2D>().isKinematic = false;
			objs[i].GetComponent<Rigidbody2D>().gravityScale = gravitaceCislo;
		}
		objs = GameObject.FindGameObjectsWithTag("kruhPlaz");
		for (int i=0; i<objs.Length; i++){
			objs[i].GetComponent<Rigidbody2D>().isKinematic = false;
			objs[i].GetComponent<Rigidbody2D>().gravityScale = gravitaceCislo;
		}
		objs = GameObject.FindGameObjectsWithTag("kruhPalmy");
		for (int i=0; i<objs.Length; i++){
			objs[i].GetComponent<Rigidbody2D>().isKinematic = false;
			objs[i].GetComponent<Rigidbody2D>().gravityScale = gravitaceCislo;

		}
	}

	public void nastavZnovu(){
		bublina_spravne.SetActive(false);
		bublina_spatne.SetActive(false);
		if(level == 1){
			bublina_start.SetActive(true);
		}
		if(level == 2){
			bublina_start1.SetActive(true);
		}
		if(level == 3){
			bublina_start2.SetActive(true);
		}


		znovuButton.interactable = false;
		gravitaceCislo = 0;
		kratkyOdpocet = 1;
		error = false;
		vyhodnoceno = false;
		spusteno = false;
		bezPohybu = false;
		zmenGravitaci();
		smazKruhy();
		smazCary();
		nastaveno=false;

	}

	public void smazKruhy(){
		for(int i =0;i<kruhy.Count; i++){
			Destroy (kruhy[i]);
		}
		kruhy.RemoveRange(0, kruhy.Count);
		speed.RemoveRange(0, speed.Count);
		kratkyOdpocet2.RemoveRange(0, kratkyOdpocet2.Count);
		zastaveno.RemoveRange(0, zastaveno.Count);
	}

	public void smazCary(){
		GameObject[] objs1 = GameObject.FindGameObjectsWithTag("gravitaceTuzka");
		for (int i=0; i<objs1.Length; i++){
			Destroy(objs1[i]);
		}
	}

	public void dalsiLevel(){

		dalsiLevelButton.interactable = false;
	//	spustButton.interactable = true;
	//	znovuButton.interactable = true;
		if(level<12){
			level++;
		}else{
			level = 1;
			firework = false;
		}
		levelText.text = "Úroveň: "+level;
		nastavZnovu();
	}

	public void nastav(){
		if(level ==1){
			nastav1();
		}
		if(level ==2){
			nastav2();
		}
		if(level ==3){
			nastav3();
		}
		if(level ==4){
			nastav4();
		}
		if(level ==5){
			nastav5();
		}
		if(level ==6){
			nastav6();
		}
		if(level ==7){
			nastav7();
		}
		if(level ==8){
			nastav8();
		}
		if(level ==9){
			nastav9();
		}
		if(level ==10){
			nastav10();
		}
		if(level ==11){
			nastav11();
		}
		if(level ==12){
			nastav12();
		}

	}
	public void pridejDoPole(){
		kratkyOdpocet2.Add(kratkyOdpocet2Temp);
		speed.Add(speedTemp);		
		kruhy.Add (kruh);
		zastaveno.Add(bezPohybu);
	}
	public void nastav1(){

		nastavkruhy();
		nastavPalmy();
		kruh.transform.localPosition = new Vector2 (1.759f,2.04f);
		kruh.GetComponent<gravitace_kruh>().dotek = true;
		nastaveno = true;

	}
	public void nastav2(){

		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (-0.184f,2.6605f);
		
			
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (3.96f,2.6605f);
		nastaveno = true;
	}
	public void nastav3(){

		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (-0.184f,2.6605f);
		kruh.GetComponent<gravitace_kruh>().dotek = true;


		nastavkruhy();
		nastavPalmy();
		kruh.transform.localPosition = new Vector2 (3.96f,2.6605f);
		kruh.GetComponent<gravitace_kruh>().dotek = true;
		nastaveno = true;
	}
	public void nastav4(){
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (-0.184f,2.6605f);
				
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (3.96f,2.6605f);

		nastavkruhy();
		nastavJidlo();
		kruh.transform.localPosition = new Vector2 (2f,2.6605f);
		kruh.GetComponent<gravitace_kruh>().dotek = true;

		nastaveno = true;
	}
	public void nastav5(){
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (-0.184f,2.6605f);
				
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (3.96f,2.6605f);
		
		nastavkruhy();
		nastavJidlo();
		kruh.transform.localPosition = new Vector2 (2f,2.6605f);
		kruh.GetComponent<gravitace_kruh>().dotek = true;

		nastavkruhy();
		nastavLehatko();
		kruh.transform.localPosition = new Vector2 (2f,1f);
		kruh.GetComponent<gravitace_kruh>().dotek = true;
		nastaveno = true;

	}

	public void nastav6(){
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (-1.2f,2.6605f);
		
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (4.8f,2.6605f);
		
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (1.8f,-1.3f);
		
		nastavkruhy();
		nastavPlaz();
		kruh.transform.localPosition = new Vector2 (1.8f,1.3f);
		kruh.GetComponent<gravitace_kruh>().dotek = true;
		
		nastaveno = true;
	}
	public void nastav7(){
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (-1.2f,2.6605f);
		
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (4.8f,2.6605f);
				
		nastavkruhy();
		nastavJidlo();
		kruh.transform.localPosition = new Vector2 (0.3f,2.6605f);
		
		nastavkruhy();
		nastavJidlo();
		kruh.transform.localPosition = new Vector2 (3.3f,2.6605f);

		nastavkruhy();
		nastavLehatko();
		kruh.GetComponent<gravitace_kruh>().dotek = true;
		kruh.transform.localPosition = new Vector2 (1.8f,2.6605f);


		nastaveno = true;
	}
	public void nastav8(){
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (1.8f,2.6605f);
		
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (1.8f,0f);
				
		nastavkruhy();
		nastavLehatko();
		kruh.GetComponent<gravitace_kruh>().dotek = true;
		kruh.transform.localPosition = new Vector2 (1.8f,1.3f);


		
		nastaveno = true;
	}
	public void nastav9(){
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (1.8f,2.6605f);
				
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (1.8f,0f);
		
		nastavkruhy();
		nastavLehatko();
		kruh.transform.localPosition = new Vector2 (1.8f,1.3f);

		nastavkruhy();
		nastavLehatko();
		kruh.transform.localPosition = new Vector2 (1.8f,-1.3f);

		nastaveno = true;
	}
	public void nastav10(){
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (1.8f,2.6605f);
		
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (1.8f,0f);
		
		nastavkruhy();
		nastavLehatko();
		kruh.transform.localPosition = new Vector2 (1.8f,1.3f);
		
		nastavkruhy();
		nastavLehatko();
		kruh.transform.localPosition = new Vector2 (1.8f,-1.3f);

		nastavkruhy();
		nastavPalmy();
		kruh.transform.localPosition = new Vector2 (-0.3f,1.3f);
		kruh.GetComponent<gravitace_kruh>().dotek = true;
		
		nastavkruhy();
		nastavPlaz();
		kruh.transform.localPosition = new Vector2 (3.9f,1.3f);
		kruh.GetComponent<gravitace_kruh>().dotek = true;
		
		nastaveno = true;
	}

	public void nastav11(){
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (1.8f,2.6605f);
		
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (1.8f,0f);
		
		nastavkruhy();
		nastavLehatko();
		kruh.transform.localPosition = new Vector2 (1.8f,1.3f);
		
		nastavkruhy();
		nastavLehatko();
		kruh.transform.localPosition = new Vector2 (1.8f,-1.3f);
		
		nastavkruhy();
		nastavPalmy();
		kruh.transform.localPosition = new Vector2 (-0.3f,1.3f);
		
		nastavkruhy();
		nastavPalmy();
		kruh.transform.localPosition = new Vector2 (3.9f,1.3f);

		nastavkruhy();
		nastavJidlo();
		kruh.transform.localPosition = new Vector2 (3.9f,-1.3f);
		kruh.GetComponent<gravitace_kruh>().dotek = true;

		
		nastaveno = true;
	}
	public void nastav12(){
		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (1.8f,2.7605f);
		
		nastavkruhy();
		nastavPlaz();
		kruh.transform.localPosition = new Vector2 (1.8f,0f);
		
		nastavkruhy();
		nastavPlaz();
		kruh.transform.localPosition = new Vector2 (5f,2.6605f);
		
		nastavkruhy();
		nastavPalmy();
		kruh.transform.localPosition = new Vector2 (1.8f,-1.3f);
		
		nastavkruhy();
		nastavPalmy();
		kruh.transform.localPosition = new Vector2 (-0.3f,1.3f);
		
		nastavkruhy();
		nastavJidlo();
		kruh.transform.localPosition = new Vector2 (3.9f,1.4f);
		
		nastavkruhy();
		nastavLehatko();
		kruh.transform.localPosition = new Vector2 (3.5f,-1.3f);
		kruh.GetComponent<gravitace_kruh>().dotek = true;

		nastavkruhy();
		nastavJidlo();
		kruh.transform.localPosition = new Vector2 (0.3f,0f);

		nastavkruhy();
		nastavPiti();
		kruh.transform.localPosition = new Vector2 (5f,-1.3f);
		
		
		nastaveno = true;
	}

	private void nastavkruhy(){
		kruh = Instantiate(objToSpawnKruh);
		kruh.transform.parent = gameObject.transform;
		kruh.GetComponent<Rigidbody2D>().isKinematic = true;
		pridejDoPole();
	}
	private void nastavPiti(){
		kruh.tag = "kruhDrink";
		kruh.GetComponent<SpriteRenderer>().sprite = spDrink;
	}
	private void nastavJidlo(){
		kruh.tag = "kruhJidlo";
		kruh.GetComponent<SpriteRenderer>().sprite = spJidlo;
	}
	private void nastavLehatko(){
		kruh.tag = "kruhLehatko";
		kruh.GetComponent<SpriteRenderer>().sprite = spLehatko;
	}
	private void nastavPlaz(){
		kruh.tag = "kruhPlaz";
		kruh.GetComponent<SpriteRenderer>().sprite = spPlaz;
	}
	private void nastavPalmy(){
		kruh.tag = "kruhPalmy";
		kruh.GetComponent<SpriteRenderer>().sprite = spPalmy;
	}
}

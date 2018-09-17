using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class protinani : MonoBehaviour {
	public float ax;
	public float ay;
	public float bx;
	public float by;
	public float sx;
	public float sy;
	public float xx;
	public float xy;
	public float t1;
	public float t2;
	public float slope;
	public float YIntersect;
	public float lStrana;
	public float pStrana;
	public List<Vector2> pozice;
	public int pocetLajn;
	public GameObject buttonZnovu;
	public GameObject buttonZnovuUlohu;
	public int chybi = 9;
	public UnityEngine.UI.Text ZbyvaText;
	public GameObject napoveda;
	public GameObject bodyNapoveda;
	public GameObject reseni;
	public GameObject bublinaStart;
	public GameObject bublinaChybiVice;
	public GameObject bublinaChybi1;
	public GameObject bublinaVyborne;
	public GameObject bublinaPocetLajn;
	public GameObject bublinaZkusMene;
	public GameObject bublinaZkus4;
	public GameObject bublina3tahy;
	public bool  firework = false;
	public ParticleSystem ohnostroj;
	public int scenar = 0;
	public int pocetPokusu = 0;
	public Animator animNapoveda;
	public Animator animReseni;
	public UnityEngine.UI.Text napovedaButton;
	public UnityEngine.UI.Text reseniButton;

	public GameObject objToSpawn;
	public GameObject objekt;
	public Vector2 mousePos;

	public bool isPressed;
	public bool tvorim;
	public GameObject[] body;


	// Use this for initialization
	void Start () {
		body = GameObject.FindGameObjectsWithTag("bodPropojeni").OrderBy( go => go.name ).ToArray();
		pozice = new List<Vector2>();


		
		ax = 0.5f;
		ay = 1;
		bx = -1f;
		by = -0.5f;
		xx = 0.51f;
		xy = 1.0f;
		sx = bx - ax;
		sy = by - ay;
		t1 = (xx - ax)/sx;
		t2 = (xy - ay)/sy;

		slope = (ay-by) / (ax-bx);
		YIntersect = -slope * ax + ay;
		lStrana = xy;
		pStrana = slope * xx + YIntersect;


	
	}
	
	// Update is called once per frame
	void Update () {

		var v3 = Input.mousePosition;
		v3.z = 8.5f;
		v3 = Camera.main.ScreenToWorldPoint(v3);
		
		mousePos = v3;

		if(pozice.Count > pocetLajn){
			
			pozice.RemoveAt(pocetLajn);
		}
		pozice.Insert(pocetLajn, mousePos);

		if(scenar ==0){
			if(chybi > 0){
				if(tvorim){
					if(!objekt.GetComponent<lajna_nova_tahem>().konec){
						
						objekt.GetComponent<lajna_nova_tahem>().line.positionCount = 2;
						objekt.GetComponent<lajna_nova_tahem>().line.SetPosition (1, pozice[pocetLajn]);
					}
				}
				if(isPressed){


					if(pocetLajn !=0){
						buttonZnovu.SetActive(true);
						objekt.GetComponent<lajna_nova_tahem>().konec = true;
						
						spocitej();
						

					}
					isPressed = false;
					pocetChybejicich();
					if(chybi >0){
						objekt = Instantiate(objToSpawn);
						objekt.transform.parent = gameObject.transform;
						objekt.tag = "lajnaTahem";
						objekt.GetComponent<lajna_nova_tahem>().line.positionCount = 1;
						objekt.GetComponent<lajna_nova_tahem>().line.SetPosition (0, pozice[pocetLajn]);
						tvorim = true;
						pocetLajn++;
					}
				}

				if(pocetLajn>0){
					bublinaPocetLajn.SetActive(true);

					ZbyvaText.text = ""+(pocetLajn);
					bublinaZkusMene.SetActive(false);
					bublinaStart.SetActive(false);

				}
			}else{
				bublinaPocetLajn.SetActive(false);
				ZbyvaText.text = "";
				if(pocetLajn>5){
					bublinaZkusMene.SetActive(true);
				}if(pocetLajn==5){
					bublinaZkus4.SetActive(true);
					scenar=1;
				}else if(pocetLajn==4){


					bublinaVyborne.SetActive(true);
					if(firework==false){
						ohnostroj.Emit(90);
						firework=true;
					}

					buttonZnovu.SetActive(false);
					buttonZnovuUlohu.SetActive(true);
				}else if(pocetLajn==3){
					bublina3tahy.SetActive(true);

						ohnostroj.Emit(90);

					
					buttonZnovu.SetActive(false);
					buttonZnovuUlohu.SetActive(true);
				}

			}

		}

		if (scenar == 1){
		if(pocetLajn < 5 && pocetLajn >= 0){
				if(pocetLajn == 4){
					pocetChybejicich();
					if(chybi ==0){
						vyhodnoceni();
					}
				}
			

			if(tvorim){
				if(!objekt.GetComponent<lajna_nova_tahem>().konec){

					objekt.GetComponent<lajna_nova_tahem>().line.positionCount = 2;
					objekt.GetComponent<lajna_nova_tahem>().line.SetPosition (1, pozice[pocetLajn]);
				}
			}
			if(isPressed){
				if(napoveda.activeInHierarchy){
					animNapoveda.SetBool("Zobrazeno", false);
					napovedaButton.text = "Zobrazit Nápovědu";
				}
				if(reseni.activeInHierarchy){
					animReseni.SetBool("Zobrazeno", false);
					reseniButton.text = "Zobrazit řešení";

				}
				bodyNapoveda.SetActive(false);
				if(pocetLajn !=0){
						buttonZnovu.SetActive(true);
						objekt.GetComponent<lajna_nova_tahem>().konec = true;

						spocitej ();
						
						if(pocetLajn ==4 && scenar ==1){
							pocetLajn++;
						}
				}
				isPressed = false;
				if(pocetLajn <4){
					objekt = Instantiate(objToSpawn);
					objekt.transform.parent = gameObject.transform;
					objekt.tag = "lajnaTahem";
					objekt.GetComponent<lajna_nova_tahem>().line.positionCount = 1;
					objekt.GetComponent<lajna_nova_tahem>().line.SetPosition (0, pozice[pocetLajn]);
					tvorim = true;
					pocetLajn++;
				}
			}
				if(pocetLajn == 5){
					
					vyhodnoceni();
				}
		}
		
		}else if(pocetLajn == -1){
			pocetLajn =0;
			isPressed = false;
		}
		
		if(Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0 && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
		{
			if(pocetLajn == -1){
				pocetLajn++;
				isPressed = false;

			}else{
			isPressed = true;
			}


		

		}
	}
	public void spocitej(){
		ax = pozice[pocetLajn-1].x; //pozice bodu A, na ose X
		ay = pozice[pocetLajn-1].y; //pozice bodu A, na ose Y
        bx = pozice[pocetLajn].x;   //pozice bodu B, na ose X
        by = pozice[pocetLajn].y;   //pozice bodu B, na ose Y
        sx = bx - ax; //směrový vektor na ose X
		sy = by - ay; //směrový vektor na ose Y
        slope = (ay-by) / (ax-bx); // Úhel přímky
		YIntersect = -slope * ax + ay; // Y Inteselect je vypočítán pomocí úhlu a pozice bodu A
		for(int i = 0; i < body.Length; i++){
			xx = body[i].transform.position.x; // pozice bodu na ose X
			xy = body[i].transform.position.y; // pozice bodu na ose Y
            lStrana = xy; // dosadí se levá strana rovnice
			pStrana = slope * xx + YIntersect; // doplní se pravá strana rovnice
			float rozdil = lStrana - pStrana; //porovnání rovnice, ideálně by měl být rozdíl 0
			
			
			if(sx < 2.5f && sx > -2.5f && rozdil < 0.11f && rozdil > -0.11f){
				rozdil =0;
			}
			if(sx < 1.5f && sx > -1.5f && rozdil < 0.13f && rozdil > -0.13f){
				rozdil =0;
			}
			if(sx < 0.8f && sx > -0.8f && rozdil < 0.15f && rozdil > -0.15f){
				rozdil =0;
			}
			if(sx < 0.7f && sx > -0.7f && rozdil < 0.2f && rozdil > -0.2f){
				rozdil =0;
			}
			if(sx < 0.6f && sx > -0.6f && rozdil < 0.22f && rozdil > -0.22f){
				rozdil =0;
			}
			if(sx < 0.5f && sx > -0.5f && rozdil < 0.24f && rozdil > -0.24f){
				rozdil =0;
			}
			if(sx < 0.4f && sx > -0.4f && rozdil < 0.26f && rozdil > -0.26f){
				rozdil =0;
			}
			if(sx < 0.3f && sx > -0.3f && rozdil < 0.32f && rozdil > -0.32f){
				rozdil =0;
			}
			if(sx < 0.25f && sx > -0.25f && rozdil < 0.7f && rozdil > -0.7f){
				rozdil =0;
			}
			if(sx < 0.2f && sx > -0.2f && rozdil < 1f && rozdil > -1f){
				rozdil =0;
			}
			if(sx < 0.15f && sx > -0.15f && rozdil < 1.4f && rozdil > -1.4f){
				rozdil =0;
			}
			if(sx < 0.1f && sx > -0.1f){
				if(ax>=bx && ax+0.1f >= xx && bx-0.1f <= xx){
					rozdil = 0;
				}
				if(bx>=ax && ax-0.1f <= xx && bx+0.1f >= xx){
					rozdil = 0;
				}
			}
			
			
		//	Debug.Log (body[i].name +", rozdíl = "+rozdil);
			if(rozdil < 0.1f && rozdil > -0.1f){
			//	Debug.Log (body[i].name +", rozdílOK = "+rozdil);
				if(ax>=bx && xx <= ax+0.1f && xx >= bx-0.1f){
					if(ay>by && xy < ay+0.1f && xy > by-0.1f){
						body[i].GetComponent<bodPropojeni>().propojeno = true;
						body[i].GetComponent<SpriteRenderer>().color = Color.green;								
					}
					if(ay<=by && xy >= ay-0.1f && xy <= by+0.1f){
						body[i].GetComponent<bodPropojeni>().propojeno = true;
						body[i].GetComponent<SpriteRenderer>().color = Color.green;	
					}
				}
				if(bx>=ax && xx >= ax-0.1f && xx <= bx+0.1f){
					if(ay>by && xy < ay+0.1f && xy > by-0.1f){
						body[i].GetComponent<bodPropojeni>().propojeno = true;
						body[i].GetComponent<SpriteRenderer>().color = Color.green;								
					}
					if(ay<=by && xy >= ay-0.1f && xy <= by+0.1f){
						body[i].GetComponent<bodPropojeni>().propojeno = true;
						body[i].GetComponent<SpriteRenderer>().color = Color.green;	
					}
				}
				
				
			}
			
		}
	}
	public void pocetChybejicich(){
		chybi = 9;
		for(int i = 0; i < body.Length; i++){
			if(body[i].GetComponent<bodPropojeni>().propojeno){
				chybi--;
			}
		}

	}
	public void vyhodnoceni(){
		tvorim = false;
		pocetChybejicich();


		bublinaStart.SetActive(false);
		bublinaZkus4.SetActive(false);
		if(chybi > 1){
			pocetPokusu++;
			bublinaChybiVice.SetActive(true);
		}else if(chybi == 1){
			bublinaChybi1.SetActive(true);
			pocetPokusu++;
		}else if(chybi == 0){
			if(pocetLajn ==4){
				bublina3tahy.SetActive (true);
				ohnostroj.Emit(90);
			}else{
				bublinaVyborne.SetActive(true);
			if(firework==false){
				ohnostroj.Emit(90);
				firework=true;
			}
			}
			buttonZnovu.SetActive(false);
			buttonZnovuUlohu.SetActive(true);
		}
		if(pocetPokusu > 0){
			napoveda.SetActive(true);

		}
		if(pocetPokusu > 1){
			reseni.SetActive(true);
			
		}

	}
	public void znovu(){

		buttonZnovu.SetActive(false);
		bublinaChybi1.SetActive(false);
		bublinaChybiVice.SetActive(false);
		bublinaVyborne.SetActive(false);
		bublina3tahy.SetActive(false);
	//	bublinaStart.SetActive(true);
		chybi = 9;
		firework=false;
		pocetLajn =0;
		tvorim = false;
		for(int i = 0; i < body.Length; i++){
			body[i].GetComponent<bodPropojeni>().propojeno = false;
			body[i].GetComponent<SpriteRenderer>().color = Color.red;
		}
		GameObject[] objs = GameObject.FindGameObjectsWithTag("lajnaTahem");
		for (int i=0; i<objs.Length; i++){
			Destroy(objs[i]);
		}
		ZbyvaText.text="";

	}
	public void znovuUlohu(){
		buttonZnovuUlohu.SetActive(false);
		napoveda.SetActive(false);
		reseni.SetActive(false);
		znovu ();
		scenar = 0;
		bublinaStart.SetActive(true);
		bodyNapoveda.SetActive(false);
		pocetPokusu = 0;
		
	}

}

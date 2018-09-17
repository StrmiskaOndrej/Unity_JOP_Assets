using UnityEngine;
using System.Collections;

public class kolejnice : MonoBehaviour {

	public GameObject objekt;
	public bool tvorim;
	public GameObject objToSpawn;
	public GameObject buttonZnovu;
	public bool  firework = false;
	public bool  dobry = false;
	public ParticleSystem ohnostroj;
	public GameObject bublinaStart;
	public GameObject bublinaKonec;
	public GameObject bublinaKHotovo;
	public GameObject bublinaPHotovo;
	public float tloustka = 0.05f;
	public Color barva;
	public bool d1;
	public bool d2;
	public bool d3;
	public bool m1;
	public bool m2;
	public bool m3;
	public bool m4;
	public bool m5;
	public bool h1;
	public bool h2;
	public int zbyva;
	public int zbyvaK = 5;
	public int zbyvaP = 5;
	public int Varianta = 1;
	public Vector2 startPos;
	public Vector2 endPos;
	public int SO = 6;
	public GameObject lokomotiva;

	// Use this for initialization
	void Start () {
		barva = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		zbyvaF();
		if(zbyva >0){
			if(tvorim == false)
			{
				objekt = Instantiate(objToSpawn);
				objekt.transform.parent = gameObject.transform;
				objekt.tag = "lajnaKolej";
				tvorim = true;
                objekt.GetComponent<lajna_nova>().line.startColor = barva;
                objekt.GetComponent<lajna_nova>().line.endColor = barva;
                objekt.GetComponent<lajna_nova>().line.startWidth = tloustka;
                objekt.GetComponent<lajna_nova>().line.endWidth = tloustka;
                objekt.GetComponent<lajna_nova>().SortingOrder = SO;
			}


			if(objekt.GetComponent<lajna_nova>().konec){
				startPos = objekt.GetComponent<lajna_nova>().startPos;
				endPos = objekt.GetComponent<lajna_nova>().endPos;
				if (Varianta ==1){ //D1
					if(startPos.x > 16.0f && startPos.x < 16.5f && startPos.y > -3.25f && startPos.y < -3.15f){
							if(endPos.x > 17.4f && endPos.x < 17.9f && endPos.y > -3.25f && endPos.y < -3.15f){
							dobry = true;
							d1 = true;	
							objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(16.5f, -3.2f));
							objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(17.4f, -3.2f));
						}
					}else if(endPos.x > 16.0f && endPos.x < 16.5f && endPos.y > -3.25f && endPos.y < -3.15f){
						if(startPos.x > 17.4f && startPos.x < 17.9f && startPos.y > -3.25f && startPos.y < -3.15f){
							dobry = true;
							d1 = true;	
							objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(16.5f, -3.2f));
							objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(17.4f, -3.2f));
						}//D2
					}else if(endPos.x > 19.0f && endPos.x < 19.5f && endPos.y > -3.25f && endPos.y < -3.15f){
						if(startPos.x > 20.4f && startPos.x < 20.9f && startPos.y > -3.25f && startPos.y < -3.15f){
							dobry = true;
							d2 = true;	
							objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(19.5f, -3.2f));
							objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(20.4f, -3.2f));
						}
					}else if(startPos.x > 19.0f && startPos.x < 19.5f && startPos.y > -3.25f && startPos.y < -3.15f){
						if(endPos.x > 20.4f && endPos.x < 20.9f && endPos.y > -3.25f && endPos.y < -3.15f){
							dobry = true;
							d2 = true;	
							objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(19.5f, -3.2f));
							objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(20.4f, -3.2f));
						}//D3
					}else if(startPos.x > 22.0f && startPos.x < 22.5 && startPos.y > -3.25f && startPos.y < -3.15f){
						if(endPos.x > 23.4f && endPos.x < 23.9f && endPos.y > -3.25f && endPos.y < -3.15f){
							dobry = true;
							d3 = true;	
							objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(22.5f, -3.2f));
							objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(23.4f, -3.2f));
						}
					}else if(endPos.x > 22.0f && endPos.x < 22.5 && endPos.y > -3.25f && endPos.y < -3.15f){
						if(startPos.x > 23.4f && startPos.x < 23.9f && startPos.y > -3.25f && startPos.y < -3.15f){
							dobry = true;
							d3 = true;	
							objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(22.5f, -3.2f));
							objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(23.4f, -3.2f));
						}//H1
					}else if(startPos.x > 17.1f && startPos.x < 17.6 && startPos.y > -3.05f && startPos.y < -2.95f){
						if(endPos.x > 18.5f && endPos.x < 19f && endPos.y > -3.05f && endPos.y < -2.95f){
							dobry = true;
							h1 = true;	
							objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(17.6f, -3f));
							objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(18.5f, -3f));
						}
					}
					else if(endPos.x > 17.1f && endPos.x < 17.6 && endPos.y > -3.05f && endPos.y < -2.95f){
						if(startPos.x > 18.5f && startPos.x < 19f && startPos.y > -3.05f && startPos.y < -2.95f){
							dobry = true;
							h1 = true;	
							objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(17.6f, -3f));
							objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(18.5f, -3f));
						}//H2
					}else if(endPos.x > 21.0f && endPos.x < 21.5f && endPos.y > -3.05f && endPos.y < -2.95f){
						if(startPos.x > 22.4f && startPos.x < 22.9f && startPos.y > -3.05f && startPos.y < -2.95f){
							dobry = true;
							h2 = true;	
							objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(21.5f, -3f));
							objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(22.4f, -3f));
						}
					}
					else if(startPos.x > 21.0f && startPos.x < 21.5f && startPos.y > -3.05f && startPos.y < -2.95f){
						if(endPos.x > 22.4f && endPos.x < 22.9f && endPos.y > -3.05f && endPos.y < -2.95f){
							dobry = true;
							h2 = true;	
							objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(21.5f, -3f));
							objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(22.4f, -3f));
						}
					}
				}else
				if(endPos.x > 18.7f && endPos.x < 18.9 && endPos.y > -3.4f && endPos.y < -3.2f){
					if(startPos.x > 19.1f && startPos.x < 19.3f && startPos.y > -3.0f && startPos.y < -2.8f){
						dobry = true;
						m1 = true;	
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(18.8f, -3.3f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(19.2f, -2.9f));
					}
				}else if(startPos.x > 18.7f && startPos.x < 18.9 && startPos.y > -3.4f && startPos.y < -3.2f){
					if(endPos.x > 19.1f && endPos.x < 19.3f && endPos.y > -3.0f && endPos.y < -2.8f){
						dobry = true;
						m1 = true;	
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(18.8f, -3.3f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(19.2f, -2.9f));
					}
				}else if(startPos.x > 20.5f && startPos.x < 20.7 && startPos.y > -3.4f && startPos.y < -3.2f){
					if(endPos.x > 20.9f && endPos.x < 21.1f && endPos.y > -3.0f && endPos.y < -2.8f){
						dobry = true;
						m2 = true;	
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(20.6f, -3.3f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(21f, -2.9f));
					}
				}else if(endPos.x > 20.5f && endPos.x < 20.7 && endPos.y > -3.4f && endPos.y < -3.2f){
					if(startPos.x > 20.9f && startPos.x < 21.1f && startPos.y > -3.0f && startPos.y < -2.8f){
						dobry = true;
						m2 = true;	
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(20.6f, -3.3f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(21f, -2.9f));
					}
				}else if(endPos.x > 22f && endPos.x < 22.2 && endPos.y > -3.4f && endPos.y < -3.2f){
					if(startPos.x > 22.4f && startPos.x < 22.6f && startPos.y > -3.0f && startPos.y < -2.8f){
						dobry = true;
						m3 = true;	
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(22.1f, -3.3f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(22.5f, -2.9f));
					}
				}else if(startPos.x > 22f && startPos.x < 22.2 && startPos.y > -3.4f && startPos.y < -3.2f){
					if(endPos.x > 22.4f && endPos.x < 22.6f && endPos.y > -3.0f && endPos.y < -2.8f){
						dobry = true;
						m3 = true;	
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(22.1f, -3.3f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(22.5f, -2.9f));
					}
				}else if(startPos.x > 16.3f && startPos.x < 16.5f && startPos.y > -3.4f && startPos.y < -3.2f){
					if(endPos.x > 16.7f && endPos.x < 16.9f && endPos.y > -3.0f && endPos.y < -2.8f){

						dobry = true;
						m4 = true;	
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(16.4f, -3.3f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(16.8f, -2.9f));
					}
				}else if(endPos.x > 16.3f && endPos.x < 16.5f && endPos.y > -3.4f && endPos.y < -3.2f){
					if(startPos.x > 16.7f && startPos.x < 16.9f && startPos.y > -3.0f && startPos.y < -2.8f){
						dobry = true;
						m4 = true;	
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(16.4f, -3.3f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(16.8f, -2.9f));
					}
				}else if(endPos.x > 17.2f && endPos.x < 17.4f && endPos.y > -3.4f && endPos.y < -3.2f){					
					if(startPos.x > 17.6f && startPos.x < 17.8f && startPos.y > -3.0f && startPos.y < -2.8f){
						dobry = true;
						m5 = true;	
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(17.3f, -3.3f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(17.7f, -2.9f));
					}
				}
				else if(startPos.x > 17.2f && startPos.x < 17.4f && startPos.y > -3.4f && startPos.y < -3.2f){					
					if(endPos.x > 17.6f && endPos.x < 17.8f && endPos.y > -3.0f && endPos.y < -2.8f){
						dobry = true;
						m5 = true;	
						objekt.GetComponent<lajna_nova>().line.SetPosition (0, new Vector2(17.3f, -3.3f));
						objekt.GetComponent<lajna_nova>().line.SetPosition (1, new Vector2(17.7f, -2.9f));
					}
				}

				if(dobry==false){
					Object.Destroy(objekt);
					
				}
				tvorim = false;
				dobry = false;
			}
			if(zbyvaK ==0){
				bublinaStart.SetActive(false);
				bublinaKHotovo.SetActive(true);
				
			}
			if(zbyvaP ==0){
				bublinaStart.SetActive(false);
				bublinaPHotovo.SetActive(true);
			}
		

		}else{
			buttonZnovu.SetActive(true);
			bublinaStart.SetActive(false);
			bublinaPHotovo.SetActive(false);
			bublinaKHotovo.SetActive(false);
			bublinaKonec.SetActive(true);
			lokomotiva.SetActive(true);
			Varianta = 0;
			if(firework==false){
				ohnostroj.Emit(90);
				firework=true;
			}
		}
	}

	public void Hneda(){
		barva = new Color(0.5f,0.25f,0);
		tloustka = 0.1f;
		Varianta = 2;
		SO = 5;
	}
	public void Cerna(){
		barva = Color.black;
		tloustka = 0.05f;
		Varianta = 1;
		SO = 6;
	}

	public void znovu(){

		bublinaStart.SetActive(true);
		bublinaKonec.SetActive(false);
		buttonZnovu.SetActive(false);
		firework=false;
		GameObject[] objs = GameObject.FindGameObjectsWithTag("lajnaKolej");
		for (int i=0; i<objs.Length; i++){
			Destroy(objs[i]);
		}
		lokomotiva.SetActive(false);
		h1 = false;
		h2 = false;
		m1 = false;
		m2 = false;
		m3 = false;
		m4 = false;
		m5 = false;
		d1 = false;
		d2 = false;
		d3 = false;
		Varianta = 1;

	
	}

	public void zbyvaF(){
		zbyva =0;
		zbyvaK = 5;
		zbyvaP = 5;
		if(h1){
			zbyvaK--;
		}
		if(h2){
			zbyvaK--;
		}

		if(d1){
			zbyvaK--;
		}
		if(d2){
			zbyvaK--;
		}
		if(d3){
			zbyvaK--;
		}

		if(m1){
			zbyvaP--;
		}
		if(m2){
			zbyvaP--;
		}
		if(m3){
			zbyvaP--;
		}
		if(m4){
			zbyvaP--;
		}
		if(m5){
			zbyvaP--;
		}
		zbyva = zbyvaP + zbyvaK;

	}
}

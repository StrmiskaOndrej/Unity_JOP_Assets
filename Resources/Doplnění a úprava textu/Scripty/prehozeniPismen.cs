using UnityEngine;
using System.Collections;

public class prehozeniPismen : MonoBehaviour {
	public string[] text1 = {"meč","tam","batoh","parník","slovník","kopat","kecal","sluha","kat","opak","duben","kopa" ,"jde","klap","dones", "láska","breč","kopa","byla","jaro"};
	public string[] text2 = {"čem","mat","boha","knír","losík","pak","klec","uhasl","tak","okap","bude","opak" ,"dej","plak","seno", "skála","erb","pako","aby","roj"};
	public string[] cislo = {"321","321","1452","6453","23167","341","1523","34512","321","1432","3214","2341" ,"231","4231","5432", "34215","321","3412","412","341"};
	public int[] poradi = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19};
	public GameObject BublinaStart;
	public GameObject BublinaSpravne;
	public GameObject BublinaSpatne;
	public int aktualni;
	public GameObject napoveda;
	public UnityEngine.UI.InputField iF;
	public UnityEngine.UI.Text textovePole1;
	public UnityEngine.UI.Text textovePole2;
	public bool odpocet;
	public float myTimer = 1.5f;
	public bool spravne;
    public ParticleSystem ohnostroj;

    // Use this for initialization
    void Start () {
		inicializace();

	}

	public void inicializace(){
		spravne = false;
		reshuffleint(poradi);
		aktualni = 0;
		textovePole1.text = text1[poradi[aktualni]];
		textovePole2.text = text2[poradi[aktualni]];
		iF.Select();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			iF.Select ();			
		}
		if(odpocet){
			if(myTimer > 0){
				myTimer -= Time.deltaTime;
			}else{
				if(spravne){
					BublinaSpravne.SetActive(false);
					spravne = false;
					napoveda.SetActive(false);
                    
                    if (aktualni < poradi.Length-1){
						aktualni++;}
					else{
						inicializace();
					}
					textovePole1.text = text1[poradi[aktualni]];
					textovePole2.text = text2[poradi[aktualni]];
					iF.text = "";
					iF.enabled = true;
		
				}else if(!spravne){
					BublinaSpatne.SetActive(false);

				}
				iF.image.color = Color.white;
				myTimer = 1.5f;
				odpocet = false;
				iF.Select();
			}
		}
	
	}

	public void iField(string str){
		if(iF.text.Length == cislo[poradi[aktualni]].Length){

			if(iF.text == cislo[poradi[aktualni]]){
				iF.image.color = Color.green;
				iF.DeactivateInputField();
				iF.enabled = false;
                ohnostroj.Emit(90);
                BublinaSpravne.SetActive(true);
				spravne = true;

						
			}else{
				iF.image.color = Color.red;
				napoveda.SetActive(true);
				BublinaSpatne.SetActive(true);
			}
			odpocet = true;
			BublinaStart.SetActive(false);
		}
		
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

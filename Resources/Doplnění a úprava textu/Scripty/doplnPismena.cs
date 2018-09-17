using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;


public class doplnPismena : MonoBehaviour {
	public List<int> poradi;	
	public GameObject[] seznamObrazku;
	public List<UnityEngine.UI.InputField> iF;
	public bool  firework = false;
	public ParticleSystem ohnostroj;
	public int zbyva = 8;
	public int cisloPole;
	public GameObject BublinaStart;
	public GameObject BublinaKonec;
	public GameObject buttonZnovu;
	public GameObject buttonZacitZnovu;

    public Image[] enemies;


    void Start()
    {
        seznamObrazku = GameObject.FindGameObjectsWithTag("upravSlovo").OrderBy(go => go.name).ToArray();

        for (int i = 0; i < seznamObrazku.Length; i++)
        {
            poradi.Add(i);
            iF.Add(seznamObrazku[i].GetComponent<doplnPismenaObr>().iF);
        }
        inicializace();

        enemies = new Image[seznamObrazku.Length];

        for (int i = 0; i < seznamObrazku.Length; i++)
        {
            enemies[i] = seznamObrazku[i].GetComponent<Image>();
        }

    }


    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			oznacDalsi();			
		}
	
	}
	public void iField(string str){

		if(iF[poradi[cisloPole]].text == seznamObrazku[poradi[cisloPole]].GetComponent<doplnPismenaObr>().SpravneSlovo){
				iF[poradi[cisloPole]].image.color = Color.green;
				iF[poradi[cisloPole]].enabled = false;
				zbyva--;
				oznacDalsi();	
				
				if(zbyva ==0){
					BublinaKonec.SetActive(true);
					BublinaStart.SetActive(false);
					buttonZnovu.SetActive(true);
					buttonZacitZnovu.SetActive(false);
					if(firework==false){
						ohnostroj.Emit(90);
						firework=true;
					}
				}		
				
			}
		

	}
	public void iFieldEnd(string str){
		if(iF[poradi[cisloPole]].text != seznamObrazku[poradi[cisloPole]].GetComponent<doplnPismenaObr>().SpravneSlovo  && iF[poradi[cisloPole]].text.Length >0 ){
			iF[poradi[cisloPole]].image.color = Color.red;
		}
	}



	public void inicializace(){

		for (int i = 0; i < poradi.Count; i++) {
			int temp = poradi[i];
			int randomIndex = Random.Range(i, poradi.Count);
			poradi[i] = poradi[randomIndex];
			poradi[randomIndex] = temp;
		}
		for (int i = 0; i <poradi.Count; i++){
			seznamObrazku[poradi[i]].GetComponent<doplnPismenaObr>().poradi = i;
		}
		for(int u = 8; u < seznamObrazku.Length; u++)
		{
			seznamObrazku[poradi[u]].SetActive(false);    
		}
		pozicuj();
		nastavSpatnaSlova();

	}
	public void nastavI(int i){
		cisloPole = i;
	}

	void pozicuj(){

			
		seznamObrazku[poradi[0]].transform.localPosition = new Vector2(-22, 300);
		seznamObrazku[poradi[1]].transform.localPosition = new Vector2(-22, 150);
		seznamObrazku[poradi[2]].transform.localPosition = new Vector2(-22, 0);
		seznamObrazku[poradi[3]].transform.localPosition = new Vector2(-22, -150);
		seznamObrazku[poradi[4]].transform.localPosition = new Vector2(300, 300);
		seznamObrazku[poradi[5]].transform.localPosition = new Vector2(300, 150);
		seznamObrazku[poradi[6]].transform.localPosition = new Vector2(300, 0);
		seznamObrazku[poradi[7]].transform.localPosition = new Vector2(300, -150);
	}

	public void nastavSpatnaSlova(){
		for(int i = 0; i < seznamObrazku.Length; i++){

			iF[i].text = seznamObrazku[i].GetComponent<doplnPismenaObr>().SpatneSlovo;
			iF[i].image.color = Color.white;
			iF[i].enabled = true;
		}
	}
	public void restartujHru(){

		nastavSpatnaSlova();
		zbyva = 8;
		cisloPole = -1;
	}

	public void spustitZnovu(){
		for(int u = 0; u < seznamObrazku.Length; u++)
		{
			seznamObrazku[poradi[u]].SetActive(true); 
		}

		buttonZnovu.SetActive(false);
		buttonZacitZnovu.SetActive(true);
		BublinaKonec.SetActive(false);
		BublinaStart.SetActive(true);

		firework=false;

		nastavSpatnaSlova();
		zbyva = 8;
		cisloPole = -1;
		inicializace();
	}

	public void oznacDalsi(){
		if(cisloPole < iF.Count -1){
			iF[poradi[cisloPole+1]].Select();
			cisloPole++;

		}else{
			iF[poradi[0]].Select();
			cisloPole = 0;
		}
	}





}

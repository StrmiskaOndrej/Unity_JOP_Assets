using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class upravVPosloupnosti : MonoBehaviour {
	public GameObject[] seznamIF;
	public List<UnityEngine.UI.InputField> iF;
	public int scenar;
	public int[] poradiMesice = {0,1,2,3,4,5,6,7,8,9,10,11};
	public int[] poradiDny = {0,1,2,3,4,5,6};
	public string[] mesiceSpravne = {"leden","únor","březen","duben","květen","červen","červenec","srpen","září","říjen","listopad","prosinec"};
	public string[] mesiceSpatne = {"leTend","ůn0r","břýzeN","důbAn","květon","čeRvín","čarovnec","srPín","Záříš","říJn","listpadl","pr0sinc"};
	public string[] dnySpravne = {"pondělí","úterý","středa","čtvrtek","pátek","sobota","neděle"};
	public string[] dnySpatne = {"p0dělí","ůter","střídat","štvrte","páreK","Sob0ta","nEdělej"};
	public int cisloPole = -1;
	public int zbyva;
	public GameObject BublinaStart0;
	public GameObject BublinaStart1;
	public GameObject BublinaKonec;
	public bool  firework = false;
	public ParticleSystem ohnostroj;
	public GameObject ButtonZnovu;

	// Use this for initialization
	void Start () {
		seznamIF = GameObject.FindGameObjectsWithTag("IFPosloupnost").OrderBy( go => go.name ).ToArray();
		for(int i = 0; i < seznamIF.Length; i++){
//			poradi.Add (i);
			iF.Add (seznamIF[i].GetComponent<UnityEngine.UI.InputField>());
		}

		scenar = Random.Range(0,2);
		inicializace();
	
	}
	public void inicializace(){
		reshuffleint(poradiDny);
		reshuffleint(poradiMesice);
		nastavSpatnaSlova();

	}

	public void iField(string str){
		if((scenar == 0 && iF[cisloPole].text == mesiceSpravne[poradiMesice[cisloPole]]) || (scenar == 1 && iF[cisloPole].text == dnySpravne[poradiDny[cisloPole]])){
				iF[cisloPole].image.color = Color.green;
				iF[cisloPole].enabled = false;
				zbyva--;

				oznacDalsi();	
				
				if(zbyva ==0){
                    BublinaStart0.GetComponent<SpriteRenderer>().enabled = false;
					BublinaStart1.GetComponent<SpriteRenderer>().enabled = false;
					BublinaKonec.SetActive(true);
					ButtonZnovu.SetActive(true);
					if(firework==false){
						ohnostroj.Emit(90);
						firework=true;
					}
				}
				
				

		}
	}
	public void iFieldEnd(string str){
		if((scenar == 0 && iF[cisloPole].text != mesiceSpravne[poradiMesice[cisloPole]] && iF[cisloPole].text.Length >0) || (scenar == 1 && iF[cisloPole].text != dnySpravne[poradiDny[cisloPole]] && iF[cisloPole].text.Length >0)){
			iF[cisloPole].image.color = Color.red;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			oznacDalsi();			
		}
	}

	public void oznacDalsi(){
		if((scenar == 0 && cisloPole < iF.Count -1) || (scenar == 1 && cisloPole < 6)){
			iF[cisloPole+1].Select();
			cisloPole++;
		}else{
			iF[0].Select();
			cisloPole = 0;
		}
	}

	public void nastavI(int i){
		cisloPole = i;
	}

	public void nastavSpatnaSlova(){
		if(scenar ==0){//měsíce
			for(int i = 0; i < mesiceSpravne.Length; i++){
				iF[i].text = mesiceSpatne[poradiMesice[i]];
			}
			BublinaStart0.GetComponent<SpriteRenderer>().enabled = true;
            zbyva = 12;
		}else if(scenar ==1){//dny
			
			for(int i = dnySpravne.Length; i < mesiceSpatne.Length; i++){
				seznamIF[i].SetActive(false);
			}
			for(int i = 0; i < dnySpravne.Length; i++){
				iF[i].text = dnySpatne[poradiDny[i]];
			}
			BublinaStart1.GetComponent<SpriteRenderer>().enabled = true;
            zbyva = 7;
		}
		cisloPole = -1;
	}

	public void spustitZnovu(){
		if(scenar ==0){
			scenar++;
		}else{
			scenar =0;
			for(int i = dnySpravne.Length; i < mesiceSpatne.Length; i++){
				seznamIF[i].SetActive(true);
			}
		}
		nastavSpatnaSlova();
		firework = false;
		ButtonZnovu.SetActive(false);
		BublinaKonec.SetActive(false);
		cisloPole = -1;
		for(int i=0; i<iF.Count; i++){
			iF[i].image.color = Color.white;
			iF[i].enabled = true;
			
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

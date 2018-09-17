using UnityEngine;
using System.Collections;

public class nastaveni_pruhu : MonoBehaviour {
	


	public string[] staty = {"Irsko", "Francie", "Itálie", "Belgie", "Rumunsko"}; // pole obsahující možné hodnoty, které mohou být požadobány
	public string nahodnyStat;
	public int i = 0;
	public bool  posun = false;
	public bool  overeni = false;
	public bool  firework = false;
	public UnityEngine.UI.Text text;
	public float myTimer = 1.5f; // lrátký odpočet
	public UnityEngine.UI.Text zbyvaText;
	public int zbyva = 5;
	public GameObject like;
	public GameObject bublina1;
	public GameObject bublina1Spravne;
	public GameObject bublina1Zbyva;
	public GameObject bublina1Konec;
	public ParticleSystem ohnostroj;
	public GameObject ButtonZnovu;
	public GameObject panel;
	
	
	public UnityEngine.UI.Toggle tlacitko1_1;
	public UnityEngine.UI.Toggle tlacitko1_2;
	public UnityEngine.UI.Toggle tlacitko1_3;
	public UnityEngine.UI.Toggle tlacitko2_1;
	public UnityEngine.UI.Toggle tlacitko2_2;
	public UnityEngine.UI.Toggle tlacitko2_3;
	public UnityEngine.UI.Toggle tlacitko3_1;
	public UnityEngine.UI.Toggle tlacitko3_2;
	public UnityEngine.UI.Toggle tlacitko3_3;
	
	void  Start (){ // aktivuje se při spuštění
		inicializace();
	}

	void inicializace(){
		reshuffle(staty);
		nahodnyStat = staty[i];
	}
	
	void  Update (){ // aktivuje se každý frame
		if(i<staty.Length && i >=0){
			text.text = nahodnyStat;
			if(overeni==false){
				over();}
			if(overeni==true){
				
				if(myTimer >0){	// spustí se krátký odpočet, poté se vyprázdní text. pole
					bublina1Zbyva.SetActive(false);
					bublina1.SetActive(false);
					bublina1Spravne.SetActive(true);
					zbyvaText.text = "";
					text.text = "";
					myTimer -= Time.deltaTime;
				}
				if(myTimer <= 0){
					zbyva--;
					posun = true;
					bublina1Spravne.SetActive(false);
					bublina1Zbyva.SetActive(true);

					zbyvaText.text = ""+zbyva;
					vygeneruj();	
					myTimer = 1.5f;
					
				}
			}}else{
			text.text = "";

			bublina1Zbyva.SetActive(false);
			bublina1Konec.SetActive(true);
			ButtonZnovu.SetActive(true);
			panel.SetActive(false);
			if(firework==false){
				ohnostroj.Emit(90);
				firework=true;
			}
			zbyvaText.text = "";
			
			
		}
		
	}
	
	void  over (){
		if(nahodnyStat=="Francie" && tlacitko1_1.isOn && tlacitko2_2.isOn && tlacitko3_2.isOn){
			overeni = true;
		}
		else if(nahodnyStat=="Irsko" && tlacitko1_2.isOn && tlacitko2_2.isOn && tlacitko3_3.isOn){
			overeni = true;
		}
		else if(nahodnyStat=="Itálie" && tlacitko1_2.isOn && tlacitko2_2.isOn && tlacitko3_2.isOn){
			overeni = true;
		}
		else if(nahodnyStat=="Belgie" && tlacitko1_3.isOn && tlacitko2_1.isOn && tlacitko3_2.isOn){
			overeni = true;
		}
		else if(nahodnyStat=="Rumunsko" && tlacitko1_1.isOn && tlacitko2_1.isOn && tlacitko3_2.isOn){
			overeni = true;
		}
		else{
			overeni = false;
			
		}
		
	}
	
	void  vygeneruj (){	
		if(posun == true){
			if(i<staty.Length-1){
				i++;
				nahodnyStat = staty[i];
				posun = false;
				overeni = false;}
			else{
				i = -2;
			}
			
			// slovo se vybírá z již zamíchaného 1. pole, z i pozice
		}}
	
	
	public void znovu(){
		zbyva = 5;
		i = 0;
		inicializace();
		ButtonZnovu.SetActive(false);
		panel.SetActive(true);
		bublina1Konec.SetActive(false);
		bublina1.SetActive(true);
		overeni = false;
		posun = false;
		firework = false;

	}
	
	
	void reshuffle(string[] texts)
	{
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < texts.Length; t++ )
		{
			string tmp = texts[t];
			int r = Random.Range(t, texts.Length);
			texts[t] = texts[r];
			texts[r] = tmp;
		}
	}

	
}
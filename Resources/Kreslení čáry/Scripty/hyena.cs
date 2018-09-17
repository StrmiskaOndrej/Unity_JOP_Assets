using UnityEngine;
using System.Collections;

public class hyena : MonoBehaviour {
	public GameObject objekt; // pomocná proměnná pro budoucí objekt
	public bool tvorim; // Je lajna tvořena?
	public GameObject objToSpawn; // Prefab ze kterého se bude čára tvořit
	public GameObject buttonZnovu;
	Color seda = new Color(0.77f,0.78f,0.823f); // Nastavená barva
	public bool h1;
	public bool h2;
	public bool h3;
	public bool l1;
	public bool l2;
	public bool l3;
	public bool p1;
	public bool p2;
	public bool p3;
	public bool d1;
	public bool d2;
	public bool d3;
	public int zbyva;
	public bool  firework = false;
	public bool  dobry = false;
	public ParticleSystem ohnostroj;
	public GameObject bublinaStart;
	public GameObject bublinaKonec;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		zbyvaF();
		if(zbyva >0){
			if(tvorim == false) //Pokud se již čára netvoří
			{
                tvorim = true; // čára se tvoří
                objekt = Instantiate(objToSpawn); // Vytvoří nový objekt z prefabu
				objekt.transform.parent = gameObject.transform; //objekt se stane podobjektem objektu ke kterému je přiřazen tento scriptu
				objekt.tag = "lajna2"; // nastaví tag objektu
                objekt.GetComponent<lajna_nova>().line.startColor = seda; // nastaví první barvu čáry
                objekt.GetComponent<lajna_nova>().line.endColor = seda; // nastaví poslední barvu čáry
                objekt.GetComponent<lajna_nova>().line.startWidth = 0.1f; // nastaví první šířku čáry
                objekt.GetComponent<lajna_nova>().line.endWidth = 0.1f; // nastaví poslední šířku čáry
            }

			if(objekt.GetComponent<lajna_nova>().konec){ // Pokud je v objektu aktivovaná proměnná konec
				if(objekt.GetComponent<lajna_nova>().startPos.x >= 1.8f && objekt.GetComponent<lajna_nova>().startPos.x <= 5.7f && objekt.GetComponent<lajna_nova>().startPos.y >= 1.3f && objekt.GetComponent<lajna_nova>().startPos.y <= 1.6f ){
					if(objekt.GetComponent<lajna_nova>().endPos.x >= 1.8f && objekt.GetComponent<lajna_nova>().endPos.x <= 5.7f && objekt.GetComponent<lajna_nova>().endPos.y >= -3.2f && objekt.GetComponent<lajna_nova>().endPos.y <= -2.7f ){
						horniDolni();
						dobry = true;
					}
				}
				if(objekt.GetComponent<lajna_nova>().endPos.x >= 1.8f && objekt.GetComponent<lajna_nova>().endPos.x <= 5.7f && objekt.GetComponent<lajna_nova>().endPos.y >= 1.3f && objekt.GetComponent<lajna_nova>().endPos.y <= 1.6f ){
					if(objekt.GetComponent<lajna_nova>().startPos.x >= 1.8f && objekt.GetComponent<lajna_nova>().startPos.x <= 5.7f && objekt.GetComponent<lajna_nova>().startPos.y >= -3.2f && objekt.GetComponent<lajna_nova>().startPos.y <= -2.7f ){
						dolniHorni();
						dobry = true;
					}
				}
				if(objekt.GetComponent<lajna_nova>().startPos.x >= 1.5f && objekt.GetComponent<lajna_nova>().startPos.x <= 1.9f && objekt.GetComponent<lajna_nova>().startPos.y >= -2.9f && objekt.GetComponent<lajna_nova>().startPos.y <= 1.4f ){
					if(objekt.GetComponent<lajna_nova>().endPos.x >= 5.6f && objekt.GetComponent<lajna_nova>().endPos.x <= 6f && objekt.GetComponent<lajna_nova>().endPos.y >= -2.9f && objekt.GetComponent<lajna_nova>().endPos.y <= 1.4f ){
						levaPrava();
						dobry = true;
					}
				}
				if(objekt.GetComponent<lajna_nova>().endPos.x >= 1.5f && objekt.GetComponent<lajna_nova>().endPos.x <= 1.9f && objekt.GetComponent<lajna_nova>().endPos.y >= -2.9f && objekt.GetComponent<lajna_nova>().endPos.y <= 1.4f ){
					if(objekt.GetComponent<lajna_nova>().startPos.x >= 5.6f && objekt.GetComponent<lajna_nova>().startPos.x <= 6f && objekt.GetComponent<lajna_nova>().startPos.y >= -2.9f && objekt.GetComponent<lajna_nova>().startPos.y <= 1.4f ){
						pravaLeva();
						dobry = true;
					}
				}
			
				if(dobry==false){
					Object.Destroy(objekt);
				
				}
				tvorim = false;
				dobry = false;
			}
		}else{
			buttonZnovu.SetActive(true);
			bublinaStart.SetActive(false);
			bublinaKonec.SetActive(true);
			if(firework==false){
				ohnostroj.Emit(90);
				firework=true;
			}
		}
	}
	public void horniDolni(){
		if(objekt.GetComponent<lajna_nova>().startPos.x >= 1.8f && objekt.GetComponent<lajna_nova>().startPos.x <= 3.0f){
			h1=true;
		}else if(objekt.GetComponent<lajna_nova>().startPos.x > 3f && objekt.GetComponent<lajna_nova>().startPos.x <= 4.6f){
			h2= true;
		}else{
			h3=true;
		}
		if(objekt.GetComponent<lajna_nova>().endPos.x >= 1.8f && objekt.GetComponent<lajna_nova>().endPos.x <= 3f){
			d1=true;
		}else if(objekt.GetComponent<lajna_nova>().endPos.x > 3f && objekt.GetComponent<lajna_nova>().endPos.x <= 4.6f){
			d2=true;
		}else{
			d3=true;
		}
	}

	public void dolniHorni(){
		if(objekt.GetComponent<lajna_nova>().startPos.x >= 1.8f && objekt.GetComponent<lajna_nova>().startPos.x <= 3.0f){
			d1=true;
		}else if(objekt.GetComponent<lajna_nova>().startPos.x > 3f && objekt.GetComponent<lajna_nova>().startPos.x <= 4.6f){
			d2= true;
		}else{
			d3=true;
		}
		if(objekt.GetComponent<lajna_nova>().endPos.x >= 1.8f && objekt.GetComponent<lajna_nova>().endPos.x <= 3f){
			h1=true;
		}else if(objekt.GetComponent<lajna_nova>().endPos.x > 3f && objekt.GetComponent<lajna_nova>().endPos.x <= 4.6f){
			h2=true;
		}else{
			h3=true;
		}
	}

	public void levaPrava(){
		if(objekt.GetComponent<lajna_nova>().startPos.y >= 0.1f && objekt.GetComponent<lajna_nova>().startPos.y <= 1.4f){
			l1=true;
		}else if(objekt.GetComponent<lajna_nova>().startPos.y > -1.4f && objekt.GetComponent<lajna_nova>().startPos.y <= 0.1f){
			l2= true;
		}else{
			l3=true;
		}
		if(objekt.GetComponent<lajna_nova>().endPos.y >= 0.1f && objekt.GetComponent<lajna_nova>().endPos.y <= 1.4f){
			p1=true;
		}else if(objekt.GetComponent<lajna_nova>().endPos.y > -1.4f && objekt.GetComponent<lajna_nova>().endPos.y <= 0.1f){
			p2=true;
		}else{
			p3=true;
		}
	}

	public void pravaLeva(){
		if(objekt.GetComponent<lajna_nova>().startPos.y >= 0.1f && objekt.GetComponent<lajna_nova>().startPos.y <= 1.4f){
			p1=true;
		}else if(objekt.GetComponent<lajna_nova>().startPos.y > -1.4f && objekt.GetComponent<lajna_nova>().startPos.y <= 0.1f){
			p2= true;
		}else{
			p3=true;
		}
		if(objekt.GetComponent<lajna_nova>().endPos.y >= 0.1f && objekt.GetComponent<lajna_nova>().endPos.y <= 1.4f){
			l1=true;
		}else if(objekt.GetComponent<lajna_nova>().endPos.y > -1.4f && objekt.GetComponent<lajna_nova>().endPos.y <= 0.1f){
			l2=true;
		}else{
			l3=true;
		}
	}
	public void znovu(){
		bublinaStart.SetActive(true);
		bublinaKonec.SetActive(false);
		buttonZnovu.SetActive(false);
		zbyva = 12;
		firework=false;
		GameObject[] objs = GameObject.FindGameObjectsWithTag("lajna2");
		for (int i=0; i<objs.Length; i++){
			Destroy(objs[i]);
		}
		h1 = false;
		h2 = false;
		h3 = false;
		l1 = false;
		l2 = false;
		l3 = false;
		p1 = false;
		p2 = false;
		p3 = false;
		d1 = false;
		d2 = false;
		d3 = false;
	}
	public void zbyvaF(){
		zbyva=12;
		if(h1){
			zbyva--;
		}
		if(h2){
			zbyva--;
		}
		if(h3){
			zbyva--;
		}
		if(d1){
			zbyva--;
		}
		if(d2){
			zbyva--;
		}
		if(d3){
			zbyva--;
		}
		if(l1){
			zbyva--;
		}
		if(l2){
			zbyva--;
		}
		if(l3){
			zbyva--;
		}
		if(p1){
			zbyva--;
		}
		if(p2){
			zbyva--;
		}
		if(p3){
			zbyva--;
		}

	}
}

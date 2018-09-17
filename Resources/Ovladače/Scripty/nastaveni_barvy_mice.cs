using UnityEngine;
using System.Collections;
using System.Linq;

public class nastaveni_barvy_mice : MonoBehaviour {
	public string[] barvy1 = {"červená", "Zelená", "Modrá"};
	public string[] barvy2 = {"Fialová", "žlutá"};
	public string[] barvy3 = {"Bílá", "černá"};
	public string[] barvy4 = {"šedá", "Oranžová", "Hnědá"};

	public GameObject mic;
	public GameObject[] patra1;
	public GameObject[] patra2;
	public GameObject[] patra3;
	public GameObject[] patra4;
	public GameObject[] patradocasne;
	public Color barva = Color.white;
	public Color barva2;
	public string nahodnaBarva;
	public string barvaMice;
	public string FunkcnibarvaMice;	
	public int i = 0;
	public float r = 172;
	public float g = 251;
	public float b = 251;	
	public float rf = 0.674f;
	public float gf = 0.984f;
	public float bf = 0.984f;
	public UnityEngine.UI.Text textR;
	public UnityEngine.UI.Text textG;
	public UnityEngine.UI.Text textB;
	public GameObject bublina3_1;
	public GameObject bublina3_2;
	public GameObject bublina3_3;
	public GameObject bublina3konec;
	public GameObject sipka;
	public ParticleSystem ohnostroj;
	public bool firework = false;
	public int krok = 1;
	public float myTimer = 7;
	public GameObject ButtonZnovu;
	public UnityEngine.UI.Slider sliderR;
	public UnityEngine.UI.Slider sliderG;
	public UnityEngine.UI.Slider sliderB;



	void  Start (){
//		patradocasne = GameObject.FindGameObjectsWithTag("patro");
		patra1 = GameObject.FindGameObjectsWithTag("patro1").OrderBy( go => go.name ).ToArray();
		patra2 = GameObject.FindGameObjectsWithTag("patro2").OrderBy( go => go.name ).ToArray();
		patra3 = GameObject.FindGameObjectsWithTag("patro3").OrderBy( go => go.name ).ToArray();
		patra4 = GameObject.FindGameObjectsWithTag("patro4").OrderBy( go => go.name ).ToArray();
		inicializace();

	}

	void inicializace(){
		reshuffle(barvy1);
		reshuffle(barvy2);
		reshuffle(barvy3);
		reshuffle(barvy4);
		upravPatra();
		mic.transform.GetComponent<Renderer> ().material.color = new Color(0.674f,0.984f,0.984f);
	}

	void  Update (){
		
		textR.text = ""+r;
		textG.text = ""+g;
		textB.text = ""+b;
		rf = r/255;
		gf = g/255;
		bf = b/255;
		
		barva = new Color(rf, gf, bf);

		mic.transform.GetComponent<Renderer> ().material.color = barva;

		if(krok ==1){
			if(r > 190 || r < 150 || g < 200 || b < 200){
				krok=2;
				bublina3_1.SetActive(false);
				bublina3_2.SetActive(true);
				sipka.SetActive(true);

			}

		}else if(krok == 2){
			if(myTimer >0){	// spustí se krátký odpočet, poté se vyprázdní text. pole
				myTimer -= Time.deltaTime;
			}
			else{
				myTimer = 7f;
				krok = 3;
				bublina3_3.SetActive(true);
				bublina3_2.SetActive(false);
				sipka.SetActive(false);


			}
		}
		
		zjistiBarvu();

		for(i= 0; i < 10; i++){ 
			if(i<3){
				for(int u = 0; u<3; u++){
					if(barvaMice.Equals(barvy1[u])){
						if(patra1[u].GetComponent<dotekSMicem>().dotek){
							Physics2D.IgnoreCollision(mic.GetComponent<Collider2D>(), patra1[u].GetComponent<Collider2D>());
                            myTimer = 0;
				//			bublina3.SetActive(false);
						}				
					}
				}
			}
			else if(i>2 && i<5){
				for(int u = 0; u<2; u++){
					if(barvaMice.Equals(barvy2[u])){
						if(patra2[u].GetComponent<dotekSMicem>().dotek){
							Physics2D.IgnoreCollision(mic.GetComponent<Collider2D>(), patra2[u].GetComponent<Collider2D>());
				//			bublina3.SetActive(false);
						}				
					}
				}
			}else if(i>4 && i<7){
				for(int u = 0; u<2; u++){
					if(barvaMice.Equals(barvy3[u])){
						if(patra3[u].GetComponent<dotekSMicem>().dotek){
							Physics2D.IgnoreCollision(mic.GetComponent<Collider2D>(), patra3[u].GetComponent<Collider2D>());
				//			bublina3.SetActive(false);
						}				
					}
				}
			}else if(i>6 && i<10){
				for(int u = 0; u<3; u++){
					if(barvaMice.Equals(barvy4[u])){
						if(patra4[u].GetComponent<dotekSMicem>().dotek){
							Physics2D.IgnoreCollision(mic.GetComponent<Collider2D>(), patra4[u].GetComponent<Collider2D>());
			//				bublina3.SetActive(false);
						}				
					}
				}
			}
		}



		if(mic.transform.localPosition.y < -6.5){
			bublina3konec.SetActive(true);
            bublina3_3.SetActive(false);

			if(firework==false){
				ohnostroj.Emit(90);
			//	firework=true;
			}
			ButtonZnovu.SetActive(true);

		}
	}
	
	
	void  upravPatra (){

		int pom1 = 0;
		int pom2 = 0;
		int pom3 = 0;
		int pom4 = 0;

		for(i= 0; i < patra1.Length; i++){ 	
			nahodnaBarva = barvy1[pom1];
			nastavBarvu();
			pom1++;
			patra1[i].transform.GetComponent<Renderer> ().material.color = barva2;
			if(i!=0){
				patra1[i].transform.Rotate(0, 0, Random.Range(-10, 10));
			}
		}
		for(i= 0; i < patra2.Length; i++){ 	
			nahodnaBarva = barvy2[pom2];
			nastavBarvu();
			pom2++;
			patra2[i].transform.Rotate(0, 0, Random.Range(-10, 10));
			patra2[i].transform.GetComponent<Renderer> ().material.color = barva2;
		}
		for(i= 0; i < patra3.Length; i++){ 	
			nahodnaBarva = barvy3[pom3];
			nastavBarvu();
			pom3++;
			patra3[i].transform.Rotate(0, 0, Random.Range(-10, 10));
			patra3[i].transform.GetComponent<Renderer> ().material.color = barva2;
		}
		for(i= 0; i < patra4.Length; i++){ 	
			nahodnaBarva = barvy4[pom4];
			nastavBarvu();
			pom4++;
			patra4[i].transform.Rotate(0, 0, Random.Range(-10, 10));
			patra4[i].transform.GetComponent<Renderer> ().material.color = barva2;
		}

					

			

		
	}
	
	void  zjistiBarvu (){
		if(r > 220 && g > 220 && b > 220){			
			barvaMice="Bílá";
		}
		else if(r < 35 && g < 35 && b < 35){
			barvaMice="černá";
		}
		else if((r > 200 && g < 55 && b < 35)||(r > 180 && g < 20 && b < 20)){
			barvaMice="červená";
		}
		else if((r < 100 && g > 200 && b < 100)||(r < 30 && g > 100 && b < 30)||(r < 55 && g > 150 && b < 55)){
			barvaMice="Zelená";
		}
		else if((r < 35 && g < 50 && b > 170)||(r < 60 && g < 120 && b > 220)||(r < 30 && g < 110 && b > 180)||(r < 50 && g < 50 && b > 170)){
			barvaMice="Modrá";
		}
		else if((r > 200 && g > 200 && b < 35)|| (r > 230 && g > 230 && b < 55)){
			barvaMice="žlutá";
		}
		else if((r > 150 && g < 50 && b > 150)||(r > 80 && g < 30 && b > 80 && r < 150 && b < 150)||(r > 210 && g < 80 && b > 210)){
			barvaMice="Fialová";
		}
		else if(r > 100 && g > 100 && b > 100 && r < 150 && g < 150 && b < 150){
			barvaMice="šedá";
		}
		else if(r > 220 && g > 50 && g < 150 && b < 30){
			barvaMice="Oranžová";
		}
		else if((r > 90 && g > 50 && r < 150 && g < 90 && b < 20)||(r > 75 && g > 70 && r < 170 && g < 30 && b < 20)){
			barvaMice="Hnědá";
		}
		
		
		
	}
	void  nastavBarvu (){
		if(nahodnaBarva=="Bílá"){
			barva2 = new Color(1,1,1);
		}
		if(nahodnaBarva=="černá"){
			barva2 = new Color(0,0,0);
		}		
		if(nahodnaBarva=="červená"){
			barva2 = new Color(1,0,0);
		}
		if(nahodnaBarva=="Zelená"){
			barva2 = new Color(0,1,0);
		}
		if(nahodnaBarva=="Modrá"){
			barva2 = new Color(0,0,1);
		}
		if(nahodnaBarva=="žlutá"){
			barva2 = new Color(1,1,0);
		}
		if(nahodnaBarva=="Fialová"){
			barva2 = new Color(1,0,1);
		}
		if(nahodnaBarva=="šedá"){
			barva2 = new Color(0.5f,0.5f,0.5f);
		}
		if(nahodnaBarva=="Oranžová"){
			barva2 = new Color(1,0.5f,0);
		}
		if(nahodnaBarva=="Hnědá"){
			barva2 = new Color(0.5f,0.25f,0);
		}		
	}

	public void znovu(){
		krok = 1;
		i = 0;

		bublina3_1.SetActive(true);
		bublina3konec.SetActive(false);
		ButtonZnovu.SetActive(false);
		firework=false;
		mic.transform.localPosition = new Vector3(0.2f, 4.145f, 0);
		r = 172;
		g = 251;
		b = 251;	
		rf = 0.674f;
		gf = 0.984f;
		bf = 0.984f;

		for(i= 0; i < patra1.Length; i++){ 
			patra1[i].transform.localEulerAngles = new Vector3(0,0,0);
			Physics2D.IgnoreCollision(mic.GetComponent<Collider2D>(), patra1[i].GetComponent<Collider2D>(), false);
			patra1[i].GetComponent<dotekSMicem>().dotek = false;
		}
		for(i= 0; i < patra2.Length; i++){ 	
			patra2[i].transform.localEulerAngles = new Vector3(0,0,0);
			Physics2D.IgnoreCollision(mic.GetComponent<Collider2D>(), patra2[i].GetComponent<Collider2D>(), false);
			patra2[i].GetComponent<dotekSMicem>().dotek = false;
		}
		for(i= 0; i < patra3.Length; i++){ 
			patra3[i].transform.localEulerAngles = new Vector3(0,0,0);
			Physics2D.IgnoreCollision(mic.GetComponent<Collider2D>(), patra3[i].GetComponent<Collider2D>(), false);
			patra3[i].GetComponent<dotekSMicem>().dotek = false;

		}
		for(i= 0; i < patra4.Length; i++){ 	
			patra4[i].transform.localEulerAngles = new Vector3(0,0,0);
			Physics2D.IgnoreCollision(mic.GetComponent<Collider2D>(), patra4[i].GetComponent<Collider2D>(), false);
			patra4[i].GetComponent<dotekSMicem>().dotek = false;

		}
		sliderR.value = 172;
		sliderG.value = 251;
		sliderB.value = 251;
		inicializace();

	}
	
	
	public void  ZmenR ( float newR  ){
		r = newR;
	}
	public void  ZmenG ( float newG  ){
		g = newG;
	}
	public void  ZmenB ( float newB  ){
		b = newB;
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
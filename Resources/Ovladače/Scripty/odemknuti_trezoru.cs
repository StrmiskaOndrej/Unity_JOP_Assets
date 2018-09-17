using UnityEngine;
using System.Collections;

public class odemknuti_trezoru : MonoBehaviour {
		
	public int cislo1 = 0;
	public int cislo2 = 0;
	public int cislo3 = 0;
	public UnityEngine.UI.Text textCislo1;
	public UnityEngine.UI.Text textCislo2;
	public UnityEngine.UI.Text textCislo3;
	public int celkoveCislo = 0;
	public GameObject trezor;
	public GameObject[] zobrazeneKombinace;	
	public float myTimer = 2;
	public GameObject tlacitkoOdemknout;
	public int[] pozice = {0,1,2,3,4,5,6,7};
	public int[] nahodneCislo = {0,0,0};	
	public int temp = -1;
	public Sprite trezorplny;
	public Sprite trezorzavreny;
	public GameObject bublina4;
	public GameObject bublina4konec;
	public ParticleSystem ohnostroj;
	public GameObject ButtonZnovu;
	public GameObject odemknout;
	
	void  Start (){
		inicializace();

		
	}
	public void inicializace(){

		nahodneCislo[0] = Random.Range( 0, 10 );
		nahodneCislo[1] = Random.Range( 0, 10 );
		nahodneCislo[2] = Random.Range( 0, 10 );
		reshuffleint(pozice); 
		seradCisla();
		zobrazeneKombinace = GameObject.FindGameObjectsWithTag("kombinace");
		pozicuj();


	}
	
	void  Update (){

		textCislo1.text = ""+cislo1;
		textCislo2.text = ""+cislo2;
		textCislo3.text = ""+cislo3;
	}
	
	public void  vyzkousej (){
		if(nahodneCislo[0] == cislo1 && nahodneCislo[1] == cislo2 && nahodneCislo[2] == cislo3){
			bublina4.SetActive(false);
			bublina4konec.SetActive(true);
			trezor.GetComponent<SpriteRenderer>().sprite = trezorplny;
			odemknout.SetActive(false);
			ButtonZnovu.SetActive(true);
			ohnostroj.Emit(90);
			
			
		}else {

			tlacitkoOdemknout.GetComponent<Animation>().Play("tlacitko_shake");
			
		}
	}
	
	void  pozicuj (){
		for(int i=0; i <=2; i++){
			funkce(i);
			
			
		}
	}
	
	void  funkce ( int neco  ){
		if(pozice[neco] == 0){ //1. mrak
			zobrazeneKombinace[neco].GetComponent<TextMesh>().text = ""+nahodneCislo[neco];
			zobrazeneKombinace[neco].transform.localPosition = new Vector3(-1199.4f, 612f, 168.171f);
			zobrazeneKombinace[neco].GetComponent<TextMesh>().characterSize = 25;
			zobrazeneKombinace[neco].GetComponent<TextMesh>().color = new Color(1, 0.835f, 1);
			
		}
		if(pozice[neco] == 1){ //2. mrak
			zobrazeneKombinace[neco].GetComponent<TextMesh>().text = ""+nahodneCislo[neco];
			zobrazeneKombinace[neco].transform.localPosition = new Vector3(-303, 673, 168.1719f);
			zobrazeneKombinace[neco].GetComponent<TextMesh>().characterSize = 25;
			zobrazeneKombinace[neco].GetComponent<TextMesh>().color = new Color(1, 0.835f, 1);
			
		}
		if(pozice[neco] == 2){ //3. mrak
			zobrazeneKombinace[neco].GetComponent<TextMesh>().text = ""+nahodneCislo[neco];
			zobrazeneKombinace[neco].transform.localPosition = new Vector3(342, 548, 168.1719f);
			zobrazeneKombinace[neco].GetComponent<TextMesh>().characterSize = 25;
			zobrazeneKombinace[neco].GetComponent<TextMesh>().color = new Color(1, 0.835f, 1);
			
		}
		if(pozice[neco] == 3){ //slunce
			zobrazeneKombinace[neco].GetComponent<TextMesh>().text = ""+nahodneCislo[neco];
			zobrazeneKombinace[neco].transform.localPosition = new Vector3(110, 1250f, 309.2064f);
			zobrazeneKombinace[neco].GetComponent<TextMesh>().characterSize = 50;
			zobrazeneKombinace[neco].GetComponent<TextMesh>().color = new Color(1,0.807f,0);
		}
		if(pozice[neco] == 4){ // strom
			zobrazeneKombinace[neco].GetComponent<TextMesh>().text = ""+nahodneCislo[neco];
			zobrazeneKombinace[neco].transform.localPosition = new Vector3(54.7f, 31.1f, 0);
			zobrazeneKombinace[neco].GetComponent<TextMesh>().characterSize = 1.3f;
			zobrazeneKombinace[neco].GetComponent<TextMesh>().color = new Color(0.192f, 0.839f, 0.109f);
		}	
		if(pozice[neco] == 5){ // kůra
			zobrazeneKombinace[neco].GetComponent<TextMesh>().text = ""+nahodneCislo[neco];
			zobrazeneKombinace[neco].transform.localPosition = new Vector3(41.78f, 1.1f, 0);
			zobrazeneKombinace[neco].GetComponent<TextMesh>().characterSize = 1.3f;
			zobrazeneKombinace[neco].GetComponent<TextMesh>().color = new Color(0.596f, 0.556f, 0.349f);
		}
		if(pozice[neco] == 6){ // tráva 1
			zobrazeneKombinace[neco].GetComponent<TextMesh>().text = ""+nahodneCislo[neco];
			zobrazeneKombinace[neco].transform.localPosition = new Vector3(-20.5f, -12.9f, 0);
			zobrazeneKombinace[neco].GetComponent<TextMesh>().characterSize = 1.3f;
			zobrazeneKombinace[neco].GetComponent<TextMesh>().color = new Color(0.074f,1,0);
		}	
		if(pozice[neco] == 7){ // tráva 2
			zobrazeneKombinace[neco].GetComponent<TextMesh>().text = ""+nahodneCislo[neco];
			zobrazeneKombinace[neco].transform.localPosition = new Vector3(31.9f, -14.8f, 0);
			zobrazeneKombinace[neco].GetComponent<TextMesh>().characterSize = 1.3f;
			zobrazeneKombinace[neco].GetComponent<TextMesh>().color = new Color(0.074f,1,0);
		}	
	}
	
	void  seradCisla (){
		if(nahodneCislo[2] > nahodneCislo[0]){
			temp = nahodneCislo[0];
			nahodneCislo[0] = nahodneCislo[2];
			nahodneCislo[2] = temp;
		}
		if(nahodneCislo[1] > nahodneCislo[0]){
			temp = nahodneCislo[0];
			nahodneCislo[0] = nahodneCislo[1];	
			nahodneCislo[1] = temp;	
		}
		if(nahodneCislo[2] > nahodneCislo[1]){
			temp = nahodneCislo[1];
			nahodneCislo[1] = nahodneCislo[2];	
			nahodneCislo[2] = temp;	
		}
	}
	
	public void  pridejCislo1 (){
		cislo1++;
		if(cislo1 > 9){
			cislo1 = 0;
		}
	}
	
	public void  pridejCislo2 (){
		cislo2++;
		if(cislo2 > 9){
			cislo2 = 0;
		}
	}
	
	public void  pridejCislo3 (){
		cislo3++;
		if(cislo3 > 9){
			cislo3 = 0;
		}
	}
	public void  uberCislo1 (){
		cislo1--;
		if(cislo1 < 0){
			cislo1 = 9;
		}
	}
	public void  uberCislo2 (){
		cislo2--;
		if(cislo2 < 0){
			cislo2 = 9;
		}
	}
	public void  uberCislo3 (){
		cislo3--;
		if(cislo3 < 0){
			cislo3 = 9;
		}
	}
	public void znovu(){
		bublina4.SetActive(true);
		bublina4konec.SetActive(false);
		trezor.GetComponent<SpriteRenderer>().sprite = trezorzavreny;
		ButtonZnovu.SetActive(false);
		odemknout.SetActive(true);
		cislo1 = 0;
		cislo2 = 0;
		cislo3 = 0;
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
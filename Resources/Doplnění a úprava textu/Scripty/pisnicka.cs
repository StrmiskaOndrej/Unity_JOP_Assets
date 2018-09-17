
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Linq;

public class pisnicka : MonoBehaviour {
	public int chybi = 8;
	public UnityEngine.UI.InputField[] iF;
	public UnityEngine.UI.InputField[] iFdocasne;
	public string[] spravnaSlova;
	public string[] neniNutnoS = {"veselo","brečelo","kamarády","neštěstí","nevadí","vadí","nutno","smutno"};
	public string[] delaniS = {"cihle","zed","ted","díže","vstřebá","zahání","zachrání","lék"};
	public string[] pramenS = {"den","jedině","zdraví","dítěti","Posázaví","bledému","mléčné","marné"};
	public int cisloPole;
	public GameObject BublinaStart;
	public GameObject BublinaKonec;
	public GameObject ButtonZnovu;
	public bool  firework = false;
	public ParticleSystem ohnostroj;

	public GameObject neniNutno;
	public GameObject Delani;
	public GameObject pramen;

	public int scenar = 0;
	public int[] scenare  = {0,1,2};

	


	// Use this for initialization
	void Start () {


		reshuffleint(scenare);
		inicializace();
	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			oznacDalsi();			
		}
	}

	public void inicializace(){
		Delani.SetActive(false);
		neniNutno.SetActive(false);
		pramen.SetActive(false);
		if(scenare[scenar] == 0){
			Delani.SetActive(true);
			spravnaSlova = delaniS;
		}
		if(scenare[scenar] ==1){
			neniNutno.SetActive(true);
			spravnaSlova = neniNutnoS;
		}
		if(scenare[scenar] ==2){
			pramen.SetActive(true);
			spravnaSlova = pramenS;
		}

		UnityEngine.UI.InputField[] iFdocasne = FindObjectsOfType(typeof(UnityEngine.UI.InputField)) as UnityEngine.UI.InputField[];
		iF = iFdocasne.OrderBy( go => go.name ).ToArray();
		
	}

	public void oznacDalsi(){
		if(cisloPole < 7){
			iF[cisloPole+1].Select();
			cisloPole++;
		}else{
			iF[0].Select();
			cisloPole = 0;
		}
	}

	public void iField(string str){
		if(cisloPole > -1){

			if(iF[cisloPole].text == spravnaSlova[cisloPole]){
				iF[cisloPole].image.color = Color.green;
				iF[cisloPole].enabled = false;
				chybi--;
				oznacDalsi();	

				if(chybi ==0){
					BublinaKonec.SetActive(true);
					BublinaStart.SetActive(false);
					ButtonZnovu.SetActive(true);
					if(firework==false){
						ohnostroj.Emit(90);
						firework=true;
					}
				}
	

			}
		}
	}
	public void iFieldEnd(string str){
		if(iF[cisloPole].text != spravnaSlova[cisloPole] && iF[cisloPole].text.Length >0){
			iF[cisloPole].image.color = Color.red;
		}
	}



	public void nastavI(int i){
		cisloPole = i;
	//	iF[cisloPole].textComponent.GetComponent<RectTransform>().pivot = new Vector2(0.5f,0.6f);
	}
	public void znovu(){
		BublinaKonec.SetActive(false);
		BublinaStart.SetActive(true);
		ButtonZnovu.SetActive(false);
		for(int i=0; i<iF.Length; i++){
			iF[i].image.color = Color.white;
			iF[i].text = "";
			iF[i].enabled = true;

		}
		chybi = 8;
		if(scenar == 2){
			scenar = 0;
		}else{
			scenar++;
		}
		firework = false;
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

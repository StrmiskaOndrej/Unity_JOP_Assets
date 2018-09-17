using UnityEngine;
using System.Collections;
using System.Linq;


public class vtip : MonoBehaviour {

	public UnityEngine.UI.InputField[] iF;
	public UnityEngine.UI.InputField[] iFdocasne;
	public string[] spravnaSlova;
	public bool  firework = false;
	public ParticleSystem ohnostroj;
	public GameObject[] seznamVtipu;
	public int cisloVtipu;
	public GameObject textCast;
	public GameObject textCely;
	public int cisloPole;
	public int chybi = 2;
	public GameObject BublinaStart;
	public GameObject BublinaKonec;
	public GameObject buttonDalsi;


	// Use this for initialization
	void Start () {
		seznamVtipu = GameObject.FindGameObjectsWithTag("vtip").OrderBy( go => go.name ).ToArray();
		reshuffleobjects(seznamVtipu);
		for(int i = 0;i < seznamVtipu.Length; i++){
			seznamVtipu[i].transform.localPosition = new Vector2(320, 28.25f);
			seznamVtipu[i].SetActive(false);
		}

		nastavVtip();
	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			oznacDalsi();			
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
					buttonDalsi.SetActive(true);
					textCast.SetActive(false);
					textCely.SetActive(true);
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

	public void dalsiVtip(){
		buttonDalsi.SetActive(false);
		BublinaKonec.SetActive(false);
		BublinaStart.SetActive(true);
		firework=false;
		textCast.SetActive(true);
		textCely.SetActive(false);
		for(int i=0; i<iF.Length; i++){
			iF[i].image.color = Color.white;
			iF[i].text = "";
			iF[i].enabled = true;
			
		}
		seznamVtipu[cisloVtipu].SetActive(false);
		if(cisloVtipu < seznamVtipu.Length - 1){
			cisloVtipu++;
		}else{
			cisloVtipu = 0;
		}
		nastavVtip();



	}


	
	
	
	public void nastavI(int i){
		cisloPole = i;
//		iF[cisloPole].textComponent.GetComponent<RectTransform>().pivot = new Vector2(0.5f,0.6f);
	}


	public void nastavVtip(){
		seznamVtipu[cisloVtipu].SetActive(true);
		spravnaSlova = seznamVtipu[cisloVtipu].GetComponent<vtip_pom>().spravnaSlova;
		textCast = seznamVtipu[cisloVtipu].GetComponent<vtip_pom>().textCast;
		textCely = seznamVtipu[cisloVtipu].GetComponent<vtip_pom>().textCely;
		textCely.SetActive(false);
		UnityEngine.UI.InputField[] iFdocasne = FindObjectsOfType(typeof(UnityEngine.UI.InputField)) as UnityEngine.UI.InputField[];
		iF = iFdocasne.OrderBy( go => go.name ).ToArray();
		chybi = iF.Length;
		cisloPole = -1;
	}

	public void oznacDalsi(){
		if(cisloPole < iF.Length -1){
			iF[cisloPole+1].Select();
			cisloPole++;
		}else{
			iF[0].Select();
			cisloPole = 0;
		}
	}

	void reshuffleobjects(GameObject[] objs)
	{
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < objs.Length; t++ )
		{
			GameObject tmp = objs[t];
			int r = Random.Range(t, objs.Length);
			objs[t] = objs[r];
			objs[r] = tmp;
		}
	}
}

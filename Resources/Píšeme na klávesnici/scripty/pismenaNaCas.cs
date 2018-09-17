using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class pismenaNaCas : MonoBehaviour {

	public UnityEngine.UI.InputField textovePole; // textové pole
	public GameObject TextovePole;
	public UnityEngine.UI.Text textDisplay; // Zobrazení požadovaného textu
	public UnityEngine.UI.Text cas1Text; // Zobrazení skore
	public UnityEngine.UI.Text cas2Text; // Zobrazení skore
	public string[] obtiznost1 = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}; // pole obsahující možné hodnoty, které mohou být požadobány
	public string[] obtiznost2 = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
	public string[] obtiznost3 = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "?", ",", ".", "!"};
	public string[] obtiznost4 = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "ě", "š", "č", "ř", "ž", "ý", "á", "í", "é", "ů", "ú", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "?", ",", ".", "!"};
	public string[] obtiznost5 = {"Ú", "Ů", "ó", "Ó", "ť", "Ť", "ď", "Ď", "ň", "Ň", "Ě", "Š", "Č", "Ř", "Ž", "Ý", "Á", "Í", "É", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "ě", "š", "č", "ř", "ž", "ý", "á", "í", "é", "ů", "ú", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "?", ",", ".", "!"};
    public string[] obtiznost6 = {"Ú", "Ů", "ó", "Ó", "ť", "Ť", "ď", "Ď", "ň", "Ň", "Ě", "Š", "Č", "Ř", "Ž", "Ý", "Á", "Í", "É", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "ě", "š", "č", "ř", "ž", "ý", "á", "í", "é", "ů", "ú", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "?", ",", ".", "!", "@", "€", ";", "+", "=", "-", "/", ")", "(", "%", "?", ":", "_", "[", "]", "{", "}", "<", ">", "*", "°", "ö", "ä", "ü", "" };
    public List<string> vybranaObtiznost;	
	public int[,] poleObtiznosti = new int[6,7]{{65,47,32,21,10,5,2},{61,47,29,17,8,4,2},{57,41,26,16,8,4,1},{53,49,32,18,7,4,1},{45,36,27,15,6,3,1},{38,31,21,12,5,2,1}};	
	public string[] zvirata = {"Gepard", "Kůň", "Lev", "Pes", "slepice", "Želva", "Šnek"};
	public GameObject[] poradiObjekty;
	public List<UnityEngine.UI.Text> cisloText;
	public List<UnityEngine.UI.Text> jmenoText;
	public List<UnityEngine.UI.Text> skoreText;
	public GameObject tabulka;
	public bool prekonano = false;
	public string nahodneSlovo; // slovo, které budou vyžadováno
	public float cas = 60; 
	public bool  overeni = false; // ověření zda uživatel zadal správné písmeno
	public UnityEngine.UI.Text vyhodnoceni;
	public int skore= -1; // skore uživatele se nastaví na -1 protože při spuštění hry na startu uživatel napíše automaticky správné písmeno (prázdné slovo) až poté se vygeneruje nahodneSlovo
	public int finalniPoradi;
	public int obtiznost = 0; // pomocná proměná, která určuje, jakou si uživatel vybral obtížnost
	public int obt = 0;
	public GameObject button1; // objekty tlačítek
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;
	public GameObject button5;
	public GameObject button6;
	public GameObject ukonci;
	public GameObject hodiny; 
	public GameObject bublina3;
	public GameObject bublina3p; 
	public GameObject bublina30;
	public GameObject bublina31;
	public GameObject bublina32;
	public GameObject bublina33;
	public GameObject bublina34;
	public GameObject bublina35;
	public GameObject bublina36;
	public GameObject bublina37;
	public GameObject lev; 
	public GameObject snek;
	public GameObject zelva;
	public GameObject slepice;
	public GameObject gepard;
	public GameObject kun;

	public GameObject pes;
	public GameObject svicka;
	public int cas1;
	public bool  posun = false;
	public int i = 0;

    public ParticleSystem ohnostroj;
    public bool firework = false;


    void  Start (){
			poradiObjekty = GameObject.FindGameObjectsWithTag("poradi").OrderBy( go => go.name ).ToArray();
			for(int i = 0; i < poradiObjekty.Length; i++){
				cisloText.Add (poradiObjekty[i].transform.Find("Cislo").transform.Find("PoradiCislo").GetComponent<UnityEngine.UI.Text>());
				jmenoText.Add (poradiObjekty[i].transform.Find("Jmeno").transform.Find("PoradiJmeno").GetComponent<UnityEngine.UI.Text>());
				skoreText.Add (poradiObjekty[i].transform.Find("Skore").transform.Find("PoradiSkore").GetComponent<UnityEngine.UI.Text>());
			}
			tabulka.SetActive(false);

		}
		
		
		void  Update (){
			
			cas1 = (int) cas;
			if(obtiznost != 0){
				
				vyhodnoceni.text = "skóre: " + skore;
				cas2Text.text = cas1 + " s";
				zapniCas(); // spustí se funkce				
				
				if(cas > 0){ // pokud ještě nevypršel čas
					textDisplay.fontSize = 80;
					textDisplay.text = nahodneSlovo;	// zobrazí se požadované slovo
					if(textovePole.text == nahodneSlovo){	// ověření zda uživatel napsal požadované slovo
						overeni = true;
					}
					else{
						overeni = false;
					}
					if (overeni == true){	// pokud uživatel napsal požadované slovo
						posun = true;
						vygeneruj();			// uživateli se vygeneruje nové nahodneSlovo
						
						
						skore++; // zvětší se skore
						textovePole.text = ""; // textové pole se vyprázdní
						
						
					}
					
					
					
				}else{	// pokud uživateli vypršel čas
					animaces();
					vyhodnoceni.text = "";
					obrazky();
					button1.SetActive (true);	// znovu se aktivují tlačítka
					button2.SetActive (true);
					button3.SetActive (true);
					button4.SetActive (true);
					button5.SetActive (true);
					button6.SetActive (true);
					ukonci.SetActive (false);
					obtiznost = 0; // změní se obtížnost na 1. Hra se dostane na svůj začátek
					cas = 60; // resetuje se čas
					i = 0;
					skore = -1; // resetuje se skóre
					textovePole.text = "";	// textové pole se vyprázdní 
					nahodneSlovo = "";	// náhodné slovo se resetuje na prázdné, nebýt tento krok, tak uživatel při zvolení jiné obtížnosti by měl 1. požadované písmeno ještě z předchozí obtížnosti
					textDisplay.text = "Obtížnosti:";
	//				textovePole.DeactivateInputField();
					textovePole.enabled = false;
					textDisplay.fontSize = 50;

					cas1Text.text = "";
					cas2Text.text = "";
				}
		}

        if (firework)
        {
            ohnostroj.Emit(90);
        }
    }
		void  zapniCas (){ // spustí se odpočet 60s
			if(cas >0){  
				cas -= Time.deltaTime;
			}
			
		}
	void  vygeneruj (){ // generuje náhodné slovo

		nahodneSlovo = vybranaObtiznost[i];
		if(posun == true){
			i++;
			posun = false;
		}
		if(i==vybranaObtiznost.Count){
			namichejList();
			i = 0;
		}
	}
					
	public void  Ukonci (){
		cas = 0;	
		i = 0;
	}

	public void nastavObtiznost(int i){
		obtiznost = i;

		for(int u = 0; u<cisloText.Count; u++){
			cisloText[u].color = Color.black;
			jmenoText[u].color = Color.black;
			skoreText[u].color = Color.black;

		}
		namichejList();
		tabulka.SetActive(false);
		button1.SetActive (false);	// Po vybrání obtížnost se všechny tlačítka uživateli schovají
		button2.SetActive (false);
		button3.SetActive (false);
		button4.SetActive (false);
		button5.SetActive (false);
		button6.SetActive (false);
		bublina3.SetActive (false);
		bublina30.SetActive (false);
		bublina31.SetActive (false);	
		bublina32.SetActive (false);
		bublina33.SetActive (false);
		bublina34.SetActive (false);
		bublina35.SetActive (false);
		bublina36.SetActive (false);
		bublina37.SetActive (false);
		bublina3p.SetActive (true);
		ukonci.SetActive (true);
		lev.SetActive (false);
		snek.SetActive (false);
		gepard.SetActive (false);
		zelva.SetActive (false);
		slepice.SetActive (false);
		kun.SetActive (false);
		pes.SetActive (false);	
		textovePole.enabled = true;
		textovePole.Select();
		obt = obtiznost;
		cas1Text.text = "Zbývající čas:";
		animace();
	}
	public void namichejList(){

		vybranaObtiznost.RemoveRange(0,vybranaObtiznost.Count);
		if(obtiznost ==1){
			reshuffle(obtiznost1);
			vybranaObtiznost.AddRange(obtiznost1);
		}
		if(obtiznost ==2){
			reshuffle(obtiznost2);
			vybranaObtiznost.AddRange(obtiznost2);
		}
		if(obtiznost ==3){
			reshuffle(obtiznost3);
			vybranaObtiznost.AddRange(obtiznost3);
		}
		if(obtiznost ==4){
			reshuffle(obtiznost4);
			vybranaObtiznost.AddRange(obtiznost4);
		}
		if(obtiznost ==5){
			reshuffle(obtiznost5);
			vybranaObtiznost.AddRange(obtiznost5);
		}
		if(obtiznost ==6){
			reshuffle(obtiznost6);
			vybranaObtiznost.AddRange(obtiznost6);
		}
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

	void  obrazky (){
		bublina3p.SetActive(false);
		if(skore < poleObtiznosti [obt - 1, 6]){
			finalniPoradi = 8;
			bublina32.SetActive (true);
		}else if(skore < poleObtiznosti [obt - 1, 5]){
			snek.SetActive (true);
			bublina31.SetActive (true);
			finalniPoradi = 7;
		}else if(skore >= poleObtiznosti [obt - 1, 5] && skore < poleObtiznosti [obt - 1, 4]){
			zelva.SetActive (true);
			bublina30.SetActive (true);
			finalniPoradi = 6;
		}else if(skore >= poleObtiznosti [obt - 1, 4] && skore < poleObtiznosti [obt - 1, 3]){
			slepice.SetActive (true);
			bublina33.SetActive (true);
			finalniPoradi = 5;
		}else if(skore >= poleObtiznosti [obt - 1, 3] && skore < poleObtiznosti [obt - 1, 2]){
			pes.SetActive (true);
			bublina34.SetActive (true);
			finalniPoradi = 4;
		}else if(skore >= poleObtiznosti [obt - 1, 2] && skore < poleObtiznosti [obt - 1, 1]){
			lev.SetActive (true);
			bublina35.SetActive (true);
			finalniPoradi = 3;
		}else if(skore >= poleObtiznosti [obt - 1, 1] && skore < poleObtiznosti [obt - 1, 0]){
			kun.SetActive (true);
			bublina36.SetActive (true);
			finalniPoradi = 2;
		}else if(skore >= poleObtiznosti [obt - 1, 0]){
			gepard.SetActive (true);
			bublina37.SetActive (true);
			finalniPoradi = 1;
		}

        if (finalniPoradi < 7)
        {
            ohnostroj.Emit(90);
        }
        if (finalniPoradi == 1)
        {
            firework = true;
        }

        vytvorTabulku();
		}

	void vytvorTabulku(){
		tabulka.SetActive(true);
		for(int i = 0; i<=zvirata.Length; i++){
			if(finalniPoradi != i+1 && !prekonano){
				if(i != zvirata.Length){
					jmenoText[i].text = zvirata[i];
					skoreText[i].text = ""+poleObtiznosti[obt - 1, i];
				}
			}if(finalniPoradi != i+1 && prekonano){
				if(i!=0){
					jmenoText[i].text = zvirata[i-1];
					skoreText[i].text = ""+poleObtiznosti[obt - 1, i-1];
				}
			}else if(finalniPoradi == i+1){
				cisloText[finalniPoradi-1].color = Color.red;
				jmenoText[finalniPoradi-1].color = Color.red;
				skoreText[finalniPoradi-1].color = Color.red;
				jmenoText[finalniPoradi-1].text = "Ty";
				skoreText[finalniPoradi-1].text = ""+skore;
				prekonano = true;
			}

		}
		prekonano = false;


	}
	

	void  animace (){
			hodiny.GetComponent<Animation>().Play("60s");
	}
	void  animaces (){
			hodiny.GetComponent<Animation>().Stop("60s");
	}
}
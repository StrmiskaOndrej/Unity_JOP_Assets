using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class slovaNaCas : MonoBehaviour {

	public UnityEngine.UI.InputField textovePole; // textové pole
	public GameObject TextovePole;
	public UnityEngine.UI.Text textDisplay; // Zobrazení požadovaného textu
	public UnityEngine.UI.Text cas1Text; // Zobrazení skore
	public UnityEngine.UI.Text cas2Text; // Zobrazení skore
	public string[] obtiznost1 = {"koš", "rým", "gól", "sen", "myš", "děs", "tma", "býk", "rak", "dar", "kry", "syn", "týl", "sok","jez",  "muž", "bok",  "srb", "bod",  "daň", "vlk", "tým", "lež", "kov", "řeč", "cíl", "míč", "ret", "děj", "elf", "líc", "lov", "čas", "akt", "sýr", "bůh","krb","běh","ráj","kly","kuš","nos","ex","den", "pán", "pes", "zem", "ar", "op", "oř", "kus", "úd", "úl", "um", "oko", "oči", "uši", "rod", "vir", "hra", "vor", "bor", "dům", "drb", "zub", "had", "med", "jed", "bit", "byt"}; // pole obsahující možné hodnoty, které mohou být požadobány
	public string[] obtiznost2 = {"tělo", "hovor", "loďka", "písmo","dýmka", "císař", "župan", "plus", "opona", "lékař", "krám", "linka", "chlad", "král", "čidlo","krab", "topol", "chlup", "rosa", "datle", "střep",  "konto", "aura", "pasta","mlok", "vědec", "říše", "hlas", "helma", "bláto","šepot",  "kříž",   "duch", "kakao", "stav", "datel", "moře", "ocas", "kabel", "žánr", "hřib","touha", "kačer", "mrak", "holka", "muška", "hluk", "dlaň","otlak", "noha", "ocel", "čočka","červ", "sáček", "bazar", "kmen", "prst", "pruh", "svit", "puma", "sklo", "sako", "role", "rosa", "ruda", "pusa", "ryba", "seno", "mzda", "kost", "slon", "ovce", "snob", "koza", "sova", "nuda", "spoj", "srna", "stud", "sval", "svoz", "tisk", "mraky", "nitra", "rundy", "olivy", "pojmy", "sliny", "cihly", "atomy", "barvy", "lahve", "fauly", "klany", "bitvy", "vlohy", "vzory", "preso", "pokec", "triky", "houby", "lejna", "chmat", "jekot", "zvony", "fiola", "fotky", "lhota", "prkna"};
	public string[] obtiznost3 = {"kalendář", "štědrost", "procházka", "poražený", "medvídek", "tajemství", "učebnice", "krabička", "horolezec", "vidlička", "houpačka", "tabletka", "rodokmen", "inspirace", "srdečnost", "mikrofon", "aligátor", "televize", "bezdomovec", "stabilita", "sklenice", "karavan", "královna",  "rosnička", "detektiv", "fotograf", "charakter", "herectví", "prstýnek", "zahrádka", "průkazka", "spisovatel", "schodiště", "kosmonaut", "pesimista", "nohejbal", "kilogram", "obyvatel", "ordinace", "odstavec", "orchidej", "brusnice", "motivace", "muzikant", "myslivec", "samoobsluha", "samospoušť", "puntičkář", "posuvník", "pošťačka", "podnikatel", "legalizace", "kytarista", "klenotnice", "kalamita", "jedničkářka", "ingredience", "chirurgie", "hvězdárna", "housenka", "gramatika", "geometrie", "fotbalista", "experiment", "eskalátor", "důchodkyně", "dokument", "destrukce", "centrála", "bramborák","astronaut", "vyhláška", "učitelka", "trumpeta", "světluška", "rozdvojka", "příšerka", "profesionál", "poslankyně", "omalovánka" };

    public string[] obtiznost4 = {"Adamov","Bavorov", "Bechyně","Bělčice","Benešov","Bílina","Boskovice","Brno","Březnice","Bruntál","Břeclav","Blansko","Blšany","Bystřice","Bystré","Bzenec", "Beroun","Čáslav","Černošín","Dačice","Deštná","Dobřany","Fryšták","Havířov","Hlinsko","Holešov","Hořice","Hrádek","Humpolec","Cheb","Chomutov","Jeseník","Jičín","Janov","Jaroměř", "Cvikov", "Děčín", "Frýdlant", "Hodonín", "Chrudim", "Jihlava", "Kladno","Kadaň","Kaplice","Karviná","Klatovy","Kolín","Kouřim","Kraslice","Kyjov","Kroměříž", "Krnov","Letohrad","Lišov","Litoměřice","Litomyšl","Litvínov","Lovosice","Luhačovice","Mikulov","Liberec", "Mělník","Milevsko","Milovice","Modřice","Most","Napajedla","Nepomuk","Nymburk","Odry","Opava", "Ostrava","Osečná","Pardubice","Pelhřimov","Písek","Plzeň","Podivín","Prostějov","Příbram", "Náchod", "Olomouc", "Praha", "Rokycany","Rudolfov","Rýmařov","Říčany","Sokolov","Slušovice","Sedlčany","Svitavy","Strážnice","Strakonice","Šumperk", "Tábor","Telč","Třinec","Třebíč","Třeboň","Vimperk","Vlašim","Vyškov","Velešín","Žatec", "Svitavy", "Teplice", "Vsetín", "Znojmo"};
	public List<string> vybranaObtiznost;
	public int[,] poleObtiznosti = new int[4,7]{{40,28,18,8,4,2,1},{36,25,16,7,4,2,1},{23,17,11,5,3,2,1},{26,18,12,6,4,2,1}};	
	public string[] zvirata = {"Gepard", "Kůň", "Lev", "Pes", "Slepice", "Želva", "Šnek"};
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
	public GameObject ukonci;
	public GameObject hodiny;
	public GameObject bublina5;
	public GameObject bublina5p; 
	public GameObject bublina50;
	public GameObject bublina51;
	public GameObject bublina52;
	public GameObject bublina53;
	public GameObject bublina54;
	public GameObject bublina55;
	public GameObject bublina56;
	public GameObject bublina57;
	public GameObject lev; 
	public GameObject snek;
	public GameObject zelva;
	public GameObject slepice;
	public GameObject gepard;
	public GameObject kun;	
	public GameObject pes;
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
			zapniCas(); // spustí se funkce
			cas2Text.text = cas1 + " s";
			
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
				ukonci.SetActive(false);
				obtiznost = 0; // změní se obtížnost na 1. Hra se dostane na svůj začátek
				cas = 60; // resetuje se čas
				skore = -1; // resetuje se skore
				i = 0;
				textovePole.text = "";	// textové pole se vyprázdní 
				nahodneSlovo = "";	// náhodné slovo se resetuje na prázdné, nebýt tento krok, tak uživatel při zvolení jiné obtížnosti by měl 1. požadované písmeno ještě z předchozí obtížnosti
				textovePole.enabled = false;
				textDisplay.fontSize = 50;
				textDisplay.text = "Obtížnosti:";	
				cas1Text.text = "";
				cas2Text.text = "";
			}
		}

        if (firework) {
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
		cas1Text.text = "Zbývající čas:";
        firework = false;
		ukonci.SetActive (true);
		lev.SetActive (false);
		snek.SetActive (false);
		gepard.SetActive (false);
		zelva.SetActive (false);
		slepice.SetActive (false);		
		kun.SetActive (false);
		pes.SetActive (false);
		bublina5.SetActive (false);
		bublina50.SetActive (false);
		bublina51.SetActive (false);
		bublina52.SetActive (false);
		bublina53.SetActive (false);
		bublina54.SetActive (false);
		bublina55.SetActive (false);
		bublina56.SetActive (false);
		bublina57.SetActive (false);
		bublina5p.SetActive (true);
		obt = obtiznost;
		cas1Text.text = "Zbývající čas:";
		textovePole.enabled = true;
		textovePole.Select();
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
		bublina5p.SetActive(false);
		if(skore < poleObtiznosti [obt - 1, 6]){
			finalniPoradi = 8;
			bublina52.SetActive (true);
		}else if(skore < poleObtiznosti [obt - 1, 5]){
			snek.SetActive (true);
			bublina51.SetActive (true);
			finalniPoradi = 7;
		}else if(skore >= poleObtiznosti [obt - 1, 5] && skore < poleObtiznosti [obt - 1, 4]){
			zelva.SetActive (true);
			bublina50.SetActive (true);
			finalniPoradi = 6;
		}else if(skore >= poleObtiznosti [obt - 1, 4] && skore < poleObtiznosti [obt - 1, 3]){
			slepice.SetActive (true);
			bublina53.SetActive (true);
			finalniPoradi = 5;
		}else if(skore >= poleObtiznosti [obt - 1, 3] && skore < poleObtiznosti [obt - 1, 2]){
			pes.SetActive (true);
			bublina54.SetActive (true);
			finalniPoradi = 4;
		}else if(skore >= poleObtiznosti [obt - 1, 2] && skore < poleObtiznosti [obt - 1, 1]){
			lev.SetActive (true);
			bublina55.SetActive (true);
			finalniPoradi = 3;
		}else if(skore >= poleObtiznosti [obt - 1, 1] && skore < poleObtiznosti [obt - 1, 0]){
			kun.SetActive (true);
			bublina56.SetActive (true);
			finalniPoradi = 2;
		}else if(skore >= poleObtiznosti [obt - 1, 0]){
			gepard.SetActive (true);
			bublina57.SetActive (true);
			finalniPoradi = 1;
		}

        if (finalniPoradi <7) {
            ohnostroj.Emit(90);
        }
        if (finalniPoradi == 1) {
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
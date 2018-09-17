using UnityEngine;
using System.Collections;

public class nalezeni_pismena : MonoBehaviour {

	public UnityEngine.UI.Text textDisplay; // text obsahující požadované písmeno
	public int[] mojeCisla = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}; // pole ukazující pozici v poli
	public string[] mojePismenaVelka = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}; // pole obsahující velká písmena, která mohou být požadovány
	public int nahodneCislo; // číslo, ukazující pozici v poli 
	public string nahodneSlovoVelke; // písmeno na určité pozici mojePismenaVelka
	public string nahodneKlavesnice; // písmeno na určité pozici mojePismenaVelka
	public float myTimer = 1.0f; // prodleva po odpovědi
	public bool  overeni = false; // ověření zda uživatel zadal správné písmeno
	public GameObject like; // objekt like
	public GameObject dislike; // objekt dislike
	public GameObject bublina1; // objekt dislike
	public GameObject bublina1ok; // objekt dislike
	public GameObject bublina1ko; // objekt dislike
    public GameObject bublina1konec;
    public bool  posun = false;  //zajištuje posun pozice
	public bool  spatne = false;  //zajištuje posun pozice
	public int i = 0; // číslo aktuální pozice
    public GameObject plamenObjekt;
    public GameObject SyrovaBrambora;
    public GameObject pecenaBrambora;
    public ParticleSystem.MainModule plamenMain;
    public ParticleSystem plamen;

    public bool zmenaOhen;
    public float lifePuvodni;
    public float sizePuvodni;
    public bool konec;

    public GameObject button;

    public ParticleSystem ohnostroj;
    public bool firework = false;


    void  Start (){ // aktivuje se při spuštění
		
		reshuffleint(mojeCisla); //náhodně zamíchá pole
		like.SetActive(false); // deaktivuje like
		dislike.SetActive(false); // deaktivuje dislike
        lifePuvodni = 0.7f;
        sizePuvodni = 1.2f;
        plamenMain = plamen.main;
        zmenaOhen = true;

	}
	
	
	void  Update (){ // aktivuje se každý frame

        if (!konec)
        {

            vygeneruj(); // funkce zajištující aktuální požadované písmeno
            textDisplay.text = nahodneSlovoVelke; // zobrazí se požadované písmeno 

            over();


            // pokud je overeni true spustí se několik příkazů
            if (overeni == true)
            {
                bublina1.SetActive(false);
                //		bublina1ko.SetActive(false);
                bublina1ok.SetActive(true);

                if (zmenaOhen)
                {
                    lifePuvodni += 0.2f;
                    sizePuvodni += 0.2f;
                    zmenaOhen = false;
                    
                }

                like.SetActive(true); // ukáže se like
                dislike.SetActive(false); // ukáže se like
                textDisplay.text = "";

                if (myTimer > 0)
                {   // spustí se krátký odpočet
                    myTimer -= Time.deltaTime;
                }
                if (myTimer <= 0)
                {
                    overeni = false;
                    posun = true; // povolí posun na další hodnotu
                    zmenaOhen = true;

                    vygeneruj(); // vygeneruje se další písmeno
                    myTimer = 1.0f;
                    if (lifePuvodni >= 2.5f)
                    {
                        konec = true;
                    }
                }   // resetuje se hodnota odpočtu

            }
            else if (overeni == false && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Z)))
            { // pokud uživatel něco zadal a je to špatně
                spatne = true;
            }


            else
            {

                like.SetActive(false); // deaktivuje se like
                dislike.SetActive(false); // deaktivuje se dislike
                                          //	bublina1.SetActive(true);
                
                bublina1ok.SetActive(false);
            }

            if (spatne == true)
            {
                //	bublina1.SetActive(false);
                if (zmenaOhen)
                {
                    lifePuvodni -= 0.2f;
                    sizePuvodni -= 0.2f;
                    zmenaOhen = false;
                    if (lifePuvodni == 2.5f) {
                        konec = true;
                    }
                }
                bublina1ok.SetActive(false);
                bublina1.SetActive(false);
                bublina1ko.SetActive(true);
                dislike.SetActive(true); // ukáže se dislike
                like.SetActive(false); // deaktivuje like, pokud uživatel zadá správné písmeno a ještě před dokončením odpočtu tuto možnost změní.
                textDisplay.text = "";

                if (myTimer > 0)
                {   // spustí se krátký odpočet
                    myTimer -= Time.deltaTime;
                }
                if (myTimer <= 0)
                {
                    spatne = false;
                    bublina1ko.SetActive(false);
                    zmenaOhen = true;
                    myTimer = 1.0f;
                } // resetuje se hodnota odpočtu
            }

            plamenMain.startLifetime = lifePuvodni;
            plamenMain.startSize = sizePuvodni;
        }
        else {
            plamenObjekt.SetActive(false);
            pecenaBrambora.SetActive(true);
            SyrovaBrambora.SetActive(false);
            bublina1konec.SetActive(true);
            button.SetActive(true);
            like.SetActive(false);
            bublina1ok.SetActive(false);

            if (firework == false)
            {
                ohnostroj.Emit(90);
                firework = true;
            }
        }
    }

    public void znovu() {
        plamenObjekt.SetActive(true);
        pecenaBrambora.SetActive(false);
        SyrovaBrambora.SetActive(true);
        bublina1konec.SetActive(false);
        button.SetActive(false);
        bublina1.SetActive(true);
        konec = false;
        lifePuvodni = 0.7f;
        sizePuvodni = 1.2f;
        firework = false;

    }

	void  vygeneruj (){ // zajištuje vygenerování písmena
		nahodneCislo = mojeCisla[i]; // zajištuje kolikátá pozice se právě používá
		nahodneSlovoVelke = mojePismenaVelka[nahodneCislo]; // z čísla na pozici zjistí potřebné velké písmeno
		
		if(posun == true){ 
			i++;	// pokud je posun povolen, tak se zvětší i a posun se opět zakáže
			posun = false;
		}
		if(i==26){	// pokud uživatel došel na konec pole, resetuje se i a znova se vygeneruje pole
			reshuffleint(mojeCisla);
			i = 0;}
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
	
	void  over (){
		if(nahodneCislo == 0 && Input.GetKeyDown (KeyCode.A)){	//	pokud slovo odpovídá požadovanému písmenu (uživatel může zadat velké i malé písmeno), overení se změní na true
			overeni = true;
			
		}
		else if(nahodneCislo == 1 && Input.GetKeyDown (KeyCode.B)){	
			overeni = true;}
		else if(nahodneCislo == 2 && Input.GetKeyDown (KeyCode.C)){	
			overeni = true;}
		else if(nahodneCislo == 3 && Input.GetKeyDown (KeyCode.D)){
			overeni = true;}	
		else if(nahodneCislo == 4 && Input.GetKeyDown (KeyCode.E)){	
			overeni = true;}
		else if(nahodneCislo == 5 && Input.GetKeyDown (KeyCode.F)){	
			overeni = true;}
		else if(nahodneCislo == 6 && Input.GetKeyDown (KeyCode.G)){	
			overeni = true;}	
		else if(nahodneCislo == 7 && Input.GetKeyDown (KeyCode.H)){	
			overeni = true;}
		else if(nahodneCislo == 8 && Input.GetKeyDown (KeyCode.I)){
			overeni = true;}	
		else if(nahodneCislo == 9 && Input.GetKeyDown (KeyCode.J)){	
			overeni = true;}
		else if(nahodneCislo == 10 && Input.GetKeyDown (KeyCode.K)){	
			overeni = true;}
		else if(nahodneCislo == 11 && Input.GetKeyDown (KeyCode.L)){	
			overeni = true;}
		else if(nahodneCislo == 12 && Input.GetKeyDown (KeyCode.M)){
			overeni = true;}		
		else if(nahodneCislo == 13 && Input.GetKeyDown (KeyCode.N)){
			overeni = true;}	
		else if(nahodneCislo == 14 && Input.GetKeyDown (KeyCode.O)){
			overeni = true;}	
		else if(nahodneCislo == 15 && Input.GetKeyDown (KeyCode.P)){
			overeni = true;}	
		else if(nahodneCislo == 16 && Input.GetKeyDown (KeyCode.Q)){
			overeni = true;}	
		else if(nahodneCislo == 17 && Input.GetKeyDown (KeyCode.R)){	
			overeni = true;}	
		else if(nahodneCislo == 18 && Input.GetKeyDown (KeyCode.S)){
			overeni = true;}	
		else if(nahodneCislo == 19 && Input.GetKeyDown (KeyCode.T)){
			overeni = true;}	
		else if(nahodneCislo == 20 && Input.GetKeyDown (KeyCode.U)){
			overeni = true;}	
		else if(nahodneCislo == 21 && Input.GetKeyDown (KeyCode.V)){	
			overeni = true;}
		else if(nahodneCislo == 22 && Input.GetKeyDown (KeyCode.W)){	
			overeni = true;}
		else if(nahodneCislo == 23 && Input.GetKeyDown (KeyCode.X)){	
			overeni = true;}
		else if(nahodneCislo == 24 && Input.GetKeyDown (KeyCode.Y)){	
			overeni = true;}
		else if(nahodneCislo == 25 && Input.GetKeyDown (KeyCode.Z)){	
			overeni = true;}
		
		
	}
	
}
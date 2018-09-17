using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class vytvor_slovo : MonoBehaviour {
	
	public UnityEngine.UI.InputField textovePole; // textové pole
	//GameObject txtpole;
	public UnityEngine.UI.Text textDisplay; // Zobrazení slovo, případně vyhodnocení
	public GameObject TextovePole; // objekt textového pole (může se odstranit)
	public bool  casovac; // ověření zda uživatel zadal správné písmeno
	//UnityEngine.UI.Text vyhodnoceni; // ukazuje kolik zbývá možností

	public UnityEngine.UI.Text skoreText; // Zobrazení skore
	public int skore= 0; // číslo skore
    public int spravne = 0;
    public GameObject skoreObj;
	public GameObject dalsi;
	public GameObject znovu;
    public GameObject odhal;
    public GameObject bublina2;
	public GameObject bublina2ok;
    public GameObject bublina2pokracuj;
    public GameObject bublina2j;
	public GameObject bublina2v0;
	public GameObject bublina2v1;
	public GameObject bublina2v2;
	public GameObject bublina2v3;
	public GameObject bublina2v4;
	public GameObject bublina2v5;
	public GameObject bublina2v6;
	public int slovo = 0; // pomocná proměná, která určuje, jaké je zobrazeno slovo
	
	public int zbyva; // počet zbývajících možností
	public float myTimer = 0.5f; // lrátký odpočet

    public string[] slovaVzory = { "_es", "stra_a", "do_y", "_rak", "l_s", "du_y", "o_el" };
    public string[] slovo1Pismena = { "l", "p", "v"};
    public string[] slovo1Cela = { "les", "pes", "ves" };
    public string[] slovo2Pismena = { "k", "n", "v" };
    public string[] slovo2Cela = { "straka", "strana", "strava" };
    public string[] slovo3Pismena = { "b", "k", "m", "g","l" };
    public string[] slovo3Cela = { "doby", "doky", "domy", "dogy", "doly" };
    public string[] slovo4Pismena = { "b", "d", "f","z","m","p","v" };
    public string[] slovo4Cela = { "brak", "drak", "frak", "zrak", "mrak", "prak", "vrak" };
    public string[] slovo5Pismena = { "e", "i", "o" };
    public string[] slovo5Cela = { "les", "lis", "los" };
    public string[] slovo6Pismena = { "n", "b", "h","d" };
    public string[] slovo6Cela = { "duny", "duby", "duhy", "dudy" };
    public string[] slovo7Pismena = { "r", "c", "s" };
    public string[] slovo7Cela = { "orel", "ocel", "osel" };
    public List<UnityEngine.UI.Text> poleTextu;
    public GameObject[] pomocnePoleTextu;
    public GameObject[] jablka;
    public GameObject[] jablkaP;
    public int[] jablkaPoradi = { 0, 1, 2,3,4,5,6,7};
    public List<string> vybranaPismena;
    public List<string> vybranaSlova;
    public string vybraneSlovo;
    public int pocetSlov;
    public int pocetNatrhanych;
    public bool dobre;
    public int pocetChyb;
    public ParticleSystem ohnostroj;
    public bool firework = false;

    void Start (){ // při startu scriptu
        pomocnePoleTextu = GameObject.FindGameObjectsWithTag("vytvorSlovoText").OrderBy(go => go.name).ToArray();
        jablka = GameObject.FindGameObjectsWithTag("jablka").OrderBy(go => go.name).ToArray();
        jablkaP = GameObject.FindGameObjectsWithTag("jablkaP").OrderBy(go => go.name).ToArray();

        for (int i = 0; i < pomocnePoleTextu.Length; i++)
        {
            poleTextu.Add(pomocnePoleTextu[i].GetComponent<UnityEngine.UI.Text>());
        }
        //    poleTextu = GameObject.FindGameObjectsWithTag("vytvorSlovoText").OrderBy(go => go.name).ToArray();
        //	txtpole.Pivot = new Vector2(0, 1.2ff);
        textovePole.enabled = true; // povolí se text. pole
		textDisplay.fontSize = 80; // nastaví se veliksot písma

		
		znovu.SetActive (false);
		dalsi.SetActive (false);
		
		
		
		bublina2ok.SetActive (false);
        bublina2pokracuj.SetActive(false);
        bublina2v0.SetActive (false);
		bublina2v1.SetActive (false);
		bublina2v2.SetActive (false);
		bublina2v3.SetActive (false);
		bublina2v4.SetActive (false);
		bublina2v5.SetActive (false);
		bublina2v6.SetActive (false);
		skoreText.text = "";
		


		textDisplay.text = ""; // vyprázdní se texty
		//	vyhodnoceni.text = "";
		textovePole.text = "";
		
		textovePole.Select(); // aktivuje se text. pole
		zbyva = 3;	//nastaví se proměnná
        pocetSlov = 3;
        reshuffleint(jablkaPoradi);
        nastavJablka();

        vybraneSlovo = slovaVzory[slovo];
        vybranaPismena.AddRange(slovo1Pismena);
        vybranaSlova.AddRange(slovo1Cela);
        textDisplay.text = vybraneSlovo;

    }
	
	
	void  Update (){ // spustí se každý frame
		if(skore == 0 && slovo <= 6 && slovo >= 0){
			bublina2.SetActive (true);
			skoreText.text = "";
            
        }
        else if(slovo != -1){
			bublina2.SetActive (false);
			skoreText.text = "" + skore;
			skoreText.fontSize = 45;
			skoreObj.transform.localPosition = new Vector3(-323, 49, 0);
			bublina2j.SetActive (true);
        }
        if (slovo != -1)
        {
            slovoFunkce();
        }

        if (casovac)
        {
            if (myTimer > 0)
            {   // spustí se krátký odpočet, poté se vyprázdní text. pole
                myTimer -= Time.deltaTime;
            }
            if (myTimer <= 0)
            {
                //    textovePole.enabled = true;
                textovePole.ActivateInputField();
                textovePole.image.color = Color.white ;
                textovePole.text = "";
         //       textovePole.Select();
                myTimer = 0.5f;
                casovac = false;
                dobre = false;


            }
        }

        if (firework)
        {
            ohnostroj.Emit(90);
        }
    }



    void slovoFunkce()
    {

        for (int i = 0; i < pocetSlov; i++) {

            if (textovePole.text == vybranaPismena[i] && poleTextu[i].text=="") {
                poleTextu[i].text = vybranaSlova[i];
                casovac = true;
                zbyva--;
                skore++;
                spravne++;
                dobre = true;
                jablka[jablkaPoradi[i]].GetComponent<SpriteRenderer>().enabled = true;
                jablkaP[jablkaPoradi[i]].GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (textovePole.text != "" && !dobre && !casovac)
        {
            casovac = true;
            dobre = true;
            textovePole.DeactivateInputField();
       //     textovePole.enabled = false;
            myTimer = 2.5f;
            textovePole.image.color = Color.red;
            pocetChyb++;

            if (pocetChyb > 1)
            {
                odhal.SetActive(true);
            }

        }

        if (zbyva == 0)
        { // pokud uživateli nic nechybí
            TextovePole.SetActive(false);
            bublina2.SetActive(false);
            bublina2j.SetActive(false);
            skoreText.text = "";
            odhal.SetActive(false);
            dalsi.SetActive(true);
            pocetChyb = 0;
            if (spravne == vybranaSlova.Count)
            {
                bublina2ok.SetActive(true);
            }
            else {
                bublina2pokracuj.SetActive(true);
            }
        }


    }

    public void odhalSlova() {
        for (int i = 0; i < vybranaSlova.Count; i++) {
            poleTextu[i].text = vybranaSlova[i];
        }
        zbyva = 0;
        
    }


        void nastavJablka() {
        for (int i = 0; i < jablka.Length; i++) {
            jablka[jablkaPoradi[i]].GetComponent<SpriteRenderer>().enabled = false;
        }
        for (int i = 0; i < zbyva; i++)
        {
            jablkaP[jablkaPoradi[i]].GetComponent<SpriteRenderer>().enabled = true;
        }
        for (int i = pocetSlov; i < jablka.Length; i++) {
            jablkaP[jablkaPoradi[i]].GetComponent<SpriteRenderer>().enabled = false;
        }
    }


    	void  konec (){ // pokud je uživatel na konci
        		
		TextovePole.SetActive (false);
		znovu.SetActive (true);
		dalsi.SetActive (false);
		bublina2.SetActive (false);
		bublina2j.SetActive (false);
		bublina2ok.SetActive (false);
        bublina2pokracuj.SetActive(false);
        textDisplay.text = "";
        
		
		skoreText.text = "";

		if(skore == 0){
			bublina2v0.SetActive (true);
            pocetNatrhanych = 0;
        }
		if(skore == 1){
            pocetNatrhanych = 0;
            bublina2v1.SetActive (true);}
		if(skore < 5 && skore > 1){
			skoreObj.transform.localPosition = new Vector3(-254, 90, 0);
			skoreText.text = "" + skore;
			skoreText.fontSize = 17;
            pocetNatrhanych = 1;
            bublina2v2.SetActive (true);
        }		
		if(skore < 12 && skore > 4){
			skoreObj.transform.localPosition = new Vector3(-252, 90, 0);
			skoreText.text = "" + skore;
			skoreText.fontSize = 17;
            bublina2v3.SetActive(true);
            pocetNatrhanych = 3;
        }
		if(skore >= 12 && skore < 24){
			skoreObj.transform.localPosition = new Vector3(-255.1f, 89.2f, 0);
			skoreText.text = "" + skore;
			skoreText.fontSize = 17;
            pocetNatrhanych = 5;
            bublina2v4.SetActive (true);}
		if(skore >= 24 && skore < 28){
            pocetNatrhanych = 7;
            skoreObj.transform.localPosition = new Vector3(-229.8f, 51.3f, 0);
			skoreText.fontStyle = FontStyle.Bold;
			skoreText.text = "" + skore;
			skoreText.fontSize = 17;
			bublina2v5.SetActive (true);}
		if(skore == 28){
            pocetNatrhanych = 8;
            bublina2v6.SetActive (true);}

        for (int i = 0; i < pocetNatrhanych; i++) {
            jablka[jablkaPoradi[i]].GetComponent<SpriteRenderer>().enabled = true;
            jablkaP[jablkaPoradi[i]].GetComponent<SpriteRenderer>().enabled = false;
        }
        for (int i = pocetNatrhanych; i < jablka.Length; i++)
        {
            jablka[jablkaPoradi[i]].GetComponent<SpriteRenderer>().enabled = false;
            jablkaP[jablkaPoradi[i]].GetComponent<SpriteRenderer>().enabled = true;
        }
        

        if (skore > 7)
        {
            ohnostroj.Emit(90);
        }
        if (skore == 28)
        {
            firework = true;
        }
        skore = 0;
        slovo = -1; // při další slovo, bude zase 1. slovo
    }
	

    public void dalsiSlovo() { // funkce pro button, která posune slovo
        vybranaPismena.RemoveRange(0, vybranaPismena.Count);
        vybranaSlova.RemoveRange(0, vybranaSlova.Count);
        

        for (int i = 0; i < poleTextu.Count; i++) {
            poleTextu[i].text = "";
        }

        if (slovo < 6)
        {
            slovo++;
        }
        else {
            slovo = -1;
            konec();
        }
        if (slovo != -1)
        {
            firework = false;
            znovu.SetActive(false);
            dalsi.SetActive(false);
            TextovePole.SetActive(true);
            textovePole.Select();
            vybraneSlovo = slovaVzory[slovo];
            spravne = 0;
            textDisplay.text = vybraneSlovo;
            bublina2ok.SetActive(false);
            bublina2pokracuj.SetActive(false);

            if (slovo == 0)
            {
                vybranaPismena.AddRange(slovo1Pismena);
                vybranaSlova.AddRange(slovo1Cela);
            }
            if (slovo == 1)
            {
                vybranaPismena.AddRange(slovo2Pismena);
                vybranaSlova.AddRange(slovo2Cela);
            }
            if (slovo == 2)
            {
                vybranaPismena.AddRange(slovo3Pismena);
                vybranaSlova.AddRange(slovo3Cela);
            }
            if (slovo == 3)
            {
                vybranaPismena.AddRange(slovo4Pismena);
                vybranaSlova.AddRange(slovo4Cela);
            }
            if (slovo == 4)
            {
                vybranaPismena.AddRange(slovo5Pismena);
                vybranaSlova.AddRange(slovo5Cela);
            }
            if (slovo == 5)
            {
                vybranaPismena.AddRange(slovo6Pismena);
                vybranaSlova.AddRange(slovo6Cela);
            }
            if (slovo == 6)
            {
                vybranaPismena.AddRange(slovo7Pismena);
                vybranaSlova.AddRange(slovo7Cela);
            }
            pocetSlov = vybranaPismena.Count;
            zbyva = pocetSlov;
            reshuffleint(jablkaPoradi);
            nastavJablka();
            
        }
	}
    void reshuffleint(int[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            int tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }
}
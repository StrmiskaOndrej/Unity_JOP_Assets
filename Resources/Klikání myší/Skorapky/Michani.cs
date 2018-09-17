using UnityEngine;
using System.Collections;

public class Michani : MonoBehaviour {

	// Use this for initialization
	public float pomoc;
	public int co;
	public int kam;
	public int pocet;
	public AudioClip selest;
	int PomocnyPocet;
	public GameObject[] skorapky = new GameObject[3];
    public Vector3[]polePozic = new Vector3[3];
	public int pocet_korabek = 3;

	public GameObject CamPos;
	
	public float vzdalenost;
	float rychlost;
	
	bool zapnout = false;
	bool zapnout2 = false;
	public float cas = -1f;
	public int cas2;
	bool isPlayedQuestion = false;
	public GameObject CilovaSkorapka;
	Transform GrafickaSkorapka;
//	Vector3 poziceCilove;
	public float casUkazani = 2.5f;
	CameraSlerp cs;
	public int KonecneMichani;
    public GameObject button;
    public bool spusteno;


	void Start () {
	PomocnyPocet = pocet;
	pocet = -1;
//	poziceCilove = CilovaSkorapka.transform.position;	
	skorapky = GameObject.FindGameObjectsWithTag("Skorapky");
	cs = (CameraSlerp)GameObject.Find("Main Camera").GetComponent(typeof(CameraSlerp));
	}

	//Resetuje pole pozic, aby se
	//123456
	//123456 takhle je to zprávně
	
	//123456
	//135624 špatně
	void SetPozition(int cislo)
	{
	for(int i = 0; i < cislo; i ++)
		{
		polePozic[i] = skorapky[i].transform.position;	
		}
	
	}
	//Zajištuje animaci do strany
	void Uhni()
	{
		foreach(Transform child in skorapky[kam].transform)
			{
			child.GetComponent<Animation>().Play("dozadu");
			this.gameObject.GetComponent<AudioSource>().PlayOneShot(selest);
			this.gameObject.GetComponent<AudioSource>().pitch = 1.9f;
			}
			
			foreach(Transform child in skorapky[co].transform)
			{
				child.GetComponent<Animation>().Play("dopredu");
			}
	}
	void PlayQuestionOnce()
	{
		
		if(isPlayedQuestion == false)
		{
			this.gameObject.GetComponent<AudioSource>().Stop();
			this.gameObject.GetComponent<AudioSource>().pitch = 1;
			this.gameObject.GetComponent<AudioSource>().Play();
			isPlayedQuestion = true;
		}
	}
	
	//void Intro()
	//{
		

		
	//	if(cs.Pozice == CamPos && pocet < 0 && intro == false)
	//	{
	//		if(odpocetIntra >= 0)
	//		odpocetIntra = odpocetIntra - Time.deltaTime;
			
	//		if(odpocetIntra <= 0.1f)
	//		{
	//		cas = -1;
	//		foreach(Transform child in CilovaSkorapka.transform)
	//		{
	//			if(child.name == "skorabka_obj1")
	//			GrafickaSkorapka = child;
	//		}
 //               GrafickaSkorapka.GetComponent<Animation>().Play();
 //               pocet = PomocnyPocet;
 //               zapnout2 = true;
 //               intro = true;
 //           }
 //       }
 //   }

    public void spust() {
        cas = -1;
        foreach (Transform child in CilovaSkorapka.transform)
        {
            if (child.name == "skorabka_obj1")
                GrafickaSkorapka = child;
        }
        GrafickaSkorapka.GetComponent<Animation>().Play();
        pocet = PomocnyPocet;
        zapnout2 = true;
        button.SetActive(false);
        spusteno = true;
    }
	
	// Update is called once per frame
	void Update ()
	{
        //	Intro();
        //Bez téhle podmínky se to nepustí
        if (Input.GetMouseButtonDown(0) && pocet < 0 && cs.Pozice.Equals(CamPos) && pocet < 8 && spusteno)
        {
            cas = -1;
            foreach (Transform child in CilovaSkorapka.transform)
            {
                if (child.name == "skorabka_obj1")
                    GrafickaSkorapka = child;
            }
            GrafickaSkorapka.GetComponent<Animation>().Play();
            pocet = PomocnyPocet;
            zapnout2 = true;


        }
        if (cs.Pozice != CamPos && pocet > 7)
		{
			zapnout = false;
		}
		//kontroluju kolikrát se to zamíchalo
		if(zapnout2 == true && pocet >= 0 && pocet < 8)
		{
			//Jestli už se ukázalo kde je poklad může začít míchání
			if(GrafickaSkorapka.GetComponent<Animation>().IsPlaying("Ukaz") == false)
			{
			Zapni();
			}
			
		}
		else
		{
			zapnout2 = false;
			
		}
	}

	//Zajištuje pohyb a jeho časování
	void Zapni()
	{
		foreach(Transform child in skorapky[pocet_korabek - 1].transform)
			{
				foreach(Transform dite in child)
				{
					dite.gameObject.GetComponent<Renderer>().enabled = true;
				}
			}
		if(cs.Pozice == CamPos)
		cas = cas - Time.deltaTime;
		//cas2 = (int)cas;
		if(cas < 0 && zapnout == false)
		{
			pocet--;
			zapnout = true;
			cas = 1.0f;
			zamichej(8.0f);
			Uhni();
			
		}
		vzdalenost = Vector3.Distance(skorapky[co].transform.position,polePozic[kam]);	
		if(vzdalenost > 0.001f && pocet > 0)
		{
		Presun(skorapky[kam],polePozic[co],rychlost);
		Presun2(skorapky[co],polePozic[kam],rychlost);
		}
		else
		{zapnout = false;
					
		}
	}
	//zajištuje která skořápka se má prohodit s jakou
	void zamichej(float rychlost)
	{
		
		co = Random.Range(0,pocet_korabek);
		do
		{
			kam = Random.Range(0,pocet_korabek);
		}while(kam == co);//tady se zjištuje jestli se nevygenerovala stejná skořápka
		
		this.rychlost = rychlost;
		//puvodniVyska = polePozic[kam].y;
		SetPozition(pocet_korabek);
		
			
		
	}
	//Metody na samotný pohyb skořápky
	void Presun(GameObject objekt, Vector3 kam, float rychlost)
	{
		if(objekt != null && kam != Vector3.zero && rychlost != 0.0f)
		{
		objekt.transform.position = Vector3.Slerp(objekt.transform.position,kam,rychlost * Time.deltaTime);
		}
	}
	void Presun2(GameObject objekt, Vector3 kam, float rychlost)
	{	
		if(objekt != null && kam != Vector3.zero && rychlost != 0.0f)
		{
		
		objekt.transform.position = Vector3.Slerp(objekt.transform.position,kam,rychlost * Time.deltaTime);
		}
	}

	public int PocetKorabek {
		get {
			return this.pocet_korabek;
		}
		set {
			pocet_korabek = value;
		}
	}	
	public float getCas()
	{
		return cas;
	}
	
	public int GetPocet()
	{
		return pocet;
	}
	public void SetPocet(int pocet)
	{
		this.PomocnyPocet = pocet;
	}
	
}

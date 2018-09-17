using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class paprsky : MonoBehaviour {
	public GameObject objekt;
	public bool tvorim;
	public GameObject objToSpawn;
	public GameObject bublinaStart;
    public GameObject bublinaKonec;
    public Color barva;
	public int so = -500;
    public List<GameObject> cary;
    public int tipPaprsku;
    public bool sPreruseny;
    public bool mPreruseny;
    public bool konec;
    public ParticleSystem ohnostroj;
    public GameObject Duha;
    public bool naLajne;

    Color barvaNebe = new Color(0f,0.066f,0.7568f);

	public CursorMode cursorMode = CursorMode.Auto;
	public CursorMode force = CursorMode.ForceSoftware;
	public Texture2D caraModraKurzor;
	// Use this for initialization
	void Start () {
		Cursor.SetCursor(caraModraKurzor, Vector2.zero, cursorMode);
	}
	
	// Update is called once per frame
	void Update () {
		if(tvorim == false)
		{
            tipPaprsku = 0;
			barva = barvaNebe;
			objekt = Instantiate(objToSpawn);
			objekt.transform.parent = gameObject.transform;
			objekt.tag = "lajnaPaprsek";
			tvorim = true;
            objekt.GetComponent<nova_lajna_paprsky>().line.startColor = barva;
            objekt.GetComponent<nova_lajna_paprsky>().line.endColor = barva;
            objekt.GetComponent<nova_lajna_paprsky>().line.startWidth = 0.15f;
            objekt.GetComponent<nova_lajna_paprsky>().line.endWidth = 0.15f;
            objekt.GetComponent<nova_lajna_paprsky>().SortingOrder = so;
			so++;
		}
		if(objekt.GetComponent<nova_lajna_paprsky>().konec){
			bublinaStart.SetActive(false);
			tvorim = false;
            if (cary.Count > 0 && tipPaprsku == 0 && !konec)
            {
                zjistiZdaSeProtina();
            }
            cary.Add(objekt);
		}

	}

	public void zmenBarvu(Color col){
        objekt.GetComponent<nova_lajna_paprsky>().line.startColor = col;
        objekt.GetComponent<nova_lajna_paprsky>().line.endColor = col;
  
	}

    public void nastavPaprsek(int i)
    {
        if (i == 1)
        {
            tipPaprsku = 1;
            objekt.GetComponent<nova_lajna_paprsky>().pS = true;
        }
        else if (i == 2)
        {
            tipPaprsku = 2;
            objekt.GetComponent<nova_lajna_paprsky>().pD = true;
        }

    }

    public void vycisti(){
		tvorim = false;
        cary.RemoveRange(0, cary.Count);
		bublinaStart.SetActive(true);
		GameObject[] objs = GameObject.FindGameObjectsWithTag("lajnaPaprsek");
		for (int i=0; i<objs.Length; i++){
			Destroy(objs[i]);
		}
        sPreruseny = false;
        mPreruseny = false;
        konec = false;
        bublinaKonec.SetActive(false);
        Duha.SetActive(false);
            
        
	}

    public void zjistiZdaSeProtina() {
        Vector2 p1 = new Vector2(objekt.GetComponent<nova_lajna_paprsky>().startPos.x, objekt.GetComponent<nova_lajna_paprsky>().startPos.y);
        Vector2 p2 = new Vector2(objekt.GetComponent<nova_lajna_paprsky>().endPos.x, objekt.GetComponent<nova_lajna_paprsky>().endPos.y);
        for (int i = 0; i < cary.Count; i++) {
            Vector2 p3 = new Vector2(cary[i].GetComponent<nova_lajna_paprsky>().startPos.x, cary[i].GetComponent<nova_lajna_paprsky>().startPos.y);
            Vector2 p4 = new Vector2(cary[i].GetComponent<nova_lajna_paprsky>().endPos.x, cary[i].GetComponent<nova_lajna_paprsky>().endPos.y);
            float denominator = (p4.y - p3.y) * (p2.x - p1.x) - (p4.x - p3.x) * (p2.y - p1.y);
 //           Debug.Log(denominator);
            if (denominator != 0)
            {
                float u_a = ((p4.x - p3.x) * (p1.y - p3.y) - (p4.y - p3.y) * (p1.x - p3.x)) / denominator;
                float u_b = ((p2.x - p1.x) * (p1.y - p3.y) - (p2.y - p1.y) * (p1.x - p3.x)) / denominator;

                //Is intersecting if u_a and u_b are between 0 and 1
                if (u_a >= 0 && u_a <= 1 && u_b >= 0 && u_b <= 1)
                {
                    if (cary[i].GetComponent<nova_lajna_paprsky>().pS) {
                        sPreruseny = true;
                    }
                    else if (cary[i].GetComponent<nova_lajna_paprsky>().pD)
                    {
                        mPreruseny = true;
                    }
                    if (mPreruseny && sPreruseny) {
                        konec = true;
                        bublinaKonec.SetActive(true);
                        ohnostroj.Emit(90);
                        Duha.SetActive(true);
                    }
                }
            }

        }


    }

}

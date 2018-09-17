using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

public class CameraSlerp_kresleni : MonoBehaviour {
	
	
	public GameObject Pozice;
	public GameObject Kamera;
	public int SpeedOfTranslation;
	public int SpeedOfRotation;
	public GameObject hra1;
	public GameObject hra2;
	public GameObject hra3;
	public GameObject hra4;
	public GameObject hra5;
	public GameObject hra6;
	public GameObject slunce;
	public GameObject hvezdy;
	public GameObject osy;
	public GameObject kresleni;
	public GameObject gravitace;
	public GameObject motyl;

    public GameObject[] pozice;
    public int citac = 0;
    public GameObject levaSipka;
    public GameObject pravaSipka;

    public Animation setmeni;
	public Animation setmeni_obloha;
	public Animation setmeni_hvezdy;
	public float vzdalenost;
	public float rychlost;

	public CursorMode cursorMode = CursorMode.Auto;
	public CursorMode force = CursorMode.ForceSoftware;

	public Texture2D kbelikKurzor;
	public Texture2D caraKurzor;
	public Texture2D tuzkaKurzor;
	public Texture2D gumaKurzor;


	public bool noc = false;
	public bool presunuto = false;

    // Use this for initialization



    void Start () {

        

        //		setmeni_obloha = slunce.GetComponent<Animation>();
        //		setmeni_hvezdy = hvezdy.GetComponent<Animation>();
        //		setmeni = gameObject.GetComponent<Animation>();

        pozice = GameObject.FindGameObjectsWithTag("PoziceKamery").OrderBy(go => go.name).ToArray();
        setmeni["setmeni"].speed = 0;
		setmeni_obloha["setmeni_obloha"].speed = 0;
		setmeni_hvezdy["setmeni_hvezdy"].speed = 0;
		slunce.GetComponent<Animation>().Play("setmeni_obloha");
		gameObject.GetComponent<Animation>().Play("setmeni");
		hvezdy.GetComponent<Animation>().Play("setmeni_hvezdy");

		
		
	}
	void spust(){

		if(citac == 1 && presunuto){
				hra1.SetActive (true);
	        	Cursor.SetCursor(null, Vector2.zero, cursorMode);
				
			}

		if(citac != 1){
			hra1.SetActive (false);}

		if(citac == 2 && presunuto){
			hra2.SetActive (true);
			osy.SetActive(true);
			Cursor.SetCursor(tuzkaKurzor, new Vector2(0,0), cursorMode);

			
		}
		
		if(citac != 2){
			hra2.SetActive (false);
			osy.SetActive(false);

		}

		if(citac == 3){
			if(hra3.GetComponent<obarvovani_tvaru>().barvaVybrana && !hra3.GetComponent<obarvovani_tvaru>().hotovo){
			Cursor.SetCursor(kbelikKurzor, Vector2.zero, cursorMode);
			}else{
				Cursor.SetCursor(null, Vector2.zero, cursorMode);
			}

				//if(noc == false){
			if(setmeni["setmeni"].time < 1 && hra3.GetComponent<obarvovani_tvaru>().hotovo == false){
						rychlost = 0.5f;}

				if(setmeni["setmeni"].time >= 1){
					rychlost = 0;			
					hra3.SetActive (true);			
					noc = true;
				}
				

				
			}
		if(citac != 3 || (citac == 3 && hra3.GetComponent<obarvovani_tvaru>().hotovo == true)){

	

				if(setmeni["setmeni"].time > 0){
					rychlost = -0.5f;}

				
				if(setmeni["setmeni"].time <= 0){
				rychlost = 0;
				noc = false;
			}
		
		}



		if(citac ==3 && hra3.GetComponent<obarvovani_tvaru>().hotovo == true && presunuto){
			hra3.SetActive (true);
		}
		if(citac !=3){
			hra3.SetActive (false);
		}

		if(citac == 4 && presunuto){
				hra4.SetActive (true);
			if(motyl.GetComponent<motyl_script>().lajna){
				Cursor.SetCursor(caraKurzor, Vector2.zero, cursorMode);
			}else if(motyl.GetComponent<motyl_script>().kbelik){
				Cursor.SetCursor(kbelikKurzor, Vector2.zero, cursorMode);
			}else{
				Cursor.SetCursor(null, Vector2.zero, cursorMode);
			}
	

				
		}

		if(citac != 4){
			hra4.SetActive (false);
		

		}
		if(citac != 5){
			kresleni.SetActive(false);
			hra5.SetActive (false);}
		if(citac == 5 && presunuto){{
			hra5.SetActive (true);
			kresleni.SetActive(true);
				if(kresleni.GetComponent<kresleni_script>().tuzkaZapnuta){
					Cursor.SetCursor(tuzkaKurzor, Vector2.zero, cursorMode);
				}else if(kresleni.GetComponent<kresleni_script>().lajnaZapnuta){
					Cursor.SetCursor(caraKurzor, Vector2.zero, cursorMode);
				}else if(kresleni.GetComponent<kresleni_script>().gumaZapnuta){
					Cursor.SetCursor(gumaKurzor, Vector2.zero, cursorMode);
				}else{
					Cursor.SetCursor(null, Vector2.zero, cursorMode);
				}

				


			}
		}
		if(citac == 6 && presunuto){
			hra6.SetActive (true);
			if(!gravitace.GetComponent<gravitace>().spusteno){
				Cursor.SetCursor(tuzkaKurzor, Vector2.zero, cursorMode);
			}else{
				Cursor.SetCursor(null, Vector2.zero, cursorMode);
			}
			gravitace.SetActive(true);
			
		}
		
		if(citac != 6){
			hra6.SetActive (false);
			gravitace.SetActive(false);
		}

		if(!presunuto){
			Cursor.SetCursor(null, Vector2.zero, cursorMode);
		}
	}
	
	
	
	
	// Update is called once per frame
	void Update () {
//		Debug.Log(setmeni["setmeni"].time);
		vzdalenost = Vector3.Distance(this.transform.position,Pozice.transform.position);

		if(vzdalenost < 0.5f){
			presunuto = true;

		}else{
			presunuto = false;
		}
		presun ();
		spust();
		setmeni["setmeni"].speed = rychlost;
		setmeni_obloha["setmeni_obloha"].speed = rychlost;
		setmeni_hvezdy["setmeni_hvezdy"].speed = rychlost;

        if (citac == 0)
        {
            levaSipka.SetActive(false);
        }
        else
        {
            levaSipka.SetActive(true);
        }
        if (citac == pozice.Length - 1)
        {
            pravaSipka.SetActive(false);
        }
        else
        {
            pravaSipka.SetActive(true);
        }

    }
	public void setNextPozition(GameObject pozice)
	{
		Pozice = pozice;
		
	}
    public void predchoziPozice()
    {
        citac--;
        Pozice = pozice[citac];
    }

    public void dalsiPozice()
    {
        citac++;
        Pozice = pozice[citac];
    }
    public void ukonci()
    {
        SceneManager.LoadScene(0);
    }
    void presun()
	{

		Kamera.transform.position = Vector3.Slerp(Kamera.transform.position,Pozice.transform.position,SpeedOfTranslation * Time.deltaTime);
	//	Kamera.transform.rotation = Quaternion.Slerp(Kamera.transform.rotation,Pozice.transform.rotation,SpeedOfRotation * Time.deltaTime);

	}

	public GameObject GetPozice()
	{
		return Pozice;
	}
	
	
}

using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

public class CameraSlerp_KresleniCary : MonoBehaviour {
	
	
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
	public GameObject paprsky;
	public GameObject mraky;
	public GameObject dtd;
	public GameObject hyena;
	public GameObject koleje;
	public GameObject protinani;

	public Animation zatmeni;
	public Animation zatmeni_mraky;
	public float vzdalenost;
	public float rychlost;
    public GameObject levaSipka;
    public GameObject pravaSipka;

    public CursorMode cursorMode = CursorMode.Auto;
	public CursorMode force = CursorMode.ForceSoftware;
	
	public Texture2D caraSedaKurzor;
	public Texture2D caraHnedaKurzor;
	public Texture2D caraCernaKurzor;

	public bool zatazeno = false;
	public bool presunuto = false;

    // Use this for initialization
    public GameObject[] pozice;
    public int citac = 0;

    

    void Start () {

        pozice = GameObject.FindGameObjectsWithTag("PoziceKamery").OrderBy(go => go.name).ToArray();
        zatmeni_mraky = mraky.GetComponent<Animation>();
		zatmeni = gameObject.GetComponent<Animation>();

		zatmeni["zatmeni"].speed = 0;
		zatmeni_mraky["zatmeni_mraky"].speed = 0;
		gameObject.GetComponent<Animation>().Play("zatmeni");
		mraky.GetComponent<Animation>().Play("zatmeni_mraky");

		
		
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
			hyena.SetActive(true);
			Cursor.SetCursor(caraSedaKurzor, Vector2.zero, cursorMode);
			
		}
		
		if(citac != 2){
			hra2.SetActive (false);
			hyena.SetActive(false);
		}



		if(citac ==3 && presunuto){
			hra3.SetActive (true);
			koleje.SetActive (true);
			if(koleje.GetComponent<kolejnice>().Varianta == 1){
				Cursor.SetCursor(caraCernaKurzor, Vector2.zero, cursorMode);
			}else if(koleje.GetComponent<kolejnice>().Varianta == 2){
				Cursor.SetCursor(caraHnedaKurzor, Vector2.zero, cursorMode);
			}else{
				Cursor.SetCursor(null, Vector2.zero, cursorMode);
			}
		}
		if(citac !=3){
			hra3.SetActive (false);
			koleje.SetActive (false);
		}

		if(citac == 4 && presunuto){
				hra4.SetActive (true);
				dtd.SetActive(true);
				Cursor.SetCursor(caraCernaKurzor, Vector2.zero, cursorMode);
		}

		if(citac != 4){
			hra4.SetActive (false);
			dtd.SetActive(false);

		}
		if(citac != 5){
			
            paprsky.SetActive(false);
            hra5.SetActive(false);
            if (zatmeni["zatmeni"].time > 0)
            {
                rychlost = -0.5f;
            }


            if (zatmeni["zatmeni"].time <= 0)
            {
                rychlost = 0;
                zatazeno = false;
            }
        }
		if(citac == 5){
			

            if (zatmeni["zatmeni"].time < 1)
            {
                rychlost = 0.5f;
            }

            if (zatmeni["zatmeni"].time >= 1)
            {
                rychlost = 0;
                paprsky.SetActive(true);
                hra5.SetActive(true);
                zatazeno = true;
            }

        }
			if(citac != 6){
            protinani.SetActive(false);
            hra6.SetActive(false);


        }

			if(citac == 6 && presunuto){
              hra6.SetActive(true);
              protinani.SetActive(true);
              Cursor.SetCursor(caraCernaKurzor, Vector2.zero, cursorMode);

        }
			if(!presunuto){
				Cursor.SetCursor(null, Vector2.zero, cursorMode);
			}
		
	}
	
	
	
	
	// Update is called once per frame
	void Update () {
//		Debug.Log(zatmeni["zatmeni"].time);
		vzdalenost = Vector3.Distance(this.transform.position,Pozice.transform.position);

		if(vzdalenost < 0.5f){
			presunuto = true;

		}else{
			presunuto = false;
		}
		presun ();
		spust();
		zatmeni["zatmeni"].speed = rychlost;
		zatmeni_mraky["zatmeni_mraky"].speed = rychlost;

        if (citac == 0)
        {
            levaSipka.SetActive(false);
        }
        else {
            levaSipka.SetActive(true);
        }
        if (citac == pozice.Length - 1)
        {
            pravaSipka.SetActive(false);
        }
        else {
            pravaSipka.SetActive(true);
        }
	}

    public void predchoziPozice()
    {
        citac--;
        Pozice = pozice[citac];
    }

    public void dalsiPozice() {
        citac++;
        Pozice = pozice[citac];
    }
    public void ukonci() {
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

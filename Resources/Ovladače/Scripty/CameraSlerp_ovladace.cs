using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

public class CameraSlerp_ovladace : MonoBehaviour {
	
	
	public GameObject Pozice;
	public GameObject Kamera;
	public int SpeedOfTranslation;
	public int SpeedOfRotation;
	public GameObject hra1;
	public GameObject hra2;
	public GameObject hra3;
	public GameObject hra4;
	public GameObject hra5;
	public GameObject cisla;

	public float vzdalenost;
	public bool presunuto = false;

    public GameObject[] pozice;
    public int citac = 0;
    public GameObject levaSipka;
    public GameObject pravaSipka;


    // Use this for initialization

    void Start () {
        pozice = GameObject.FindGameObjectsWithTag("PoziceKamery").OrderBy(go => go.name).ToArray();


    }
	void spust(){
		if(citac == 1 && presunuto){
			hra1.SetActive (true);				
		}
		if(citac != 1){
			hra1.SetActive (false);}
		
		
		if(citac == 2 && presunuto){
			hra2.SetActive (true);
					}
		if(citac != 2){
			hra2.SetActive (false);
		}
		if(citac == 3 && presunuto){
			hra3.SetActive (true);
		}
		if(citac != 3){
			hra3.SetActive (false);
		}
		if(citac == 4 && presunuto){
			hra4.SetActive (true);
			cisla.SetActive(true);
				
		}
		if(citac != 4){
			hra4.SetActive (false);
			cisla.SetActive (false);
		}

		if(citac == 5 && presunuto){
			hra5.SetActive (true);
		}

		if(citac != 5){
			hra5.SetActive (false);}
		}
	
	
	
	
	// Update is called once per frame
	void Update () {
		
		vzdalenost = Vector3.Distance(this.transform.position,Pozice.transform.position);
		
		if(vzdalenost < 0.5f){
			presunuto = true;
			
		}else{
			presunuto = false;
		}
		presun ();
		spust();

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
	void presun()
	{
		
		Kamera.transform.position = Vector3.Slerp(Kamera.transform.position,Pozice.transform.position,SpeedOfTranslation * Time.deltaTime);
		//	Kamera.transform.rotation = Quaternion.Slerp(Kamera.transform.rotation,Pozice.transform.rotation,SpeedOfRotation * Time.deltaTime);
		
	}
	
	public GameObject GetPozice()
	{
		return Pozice;
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

}

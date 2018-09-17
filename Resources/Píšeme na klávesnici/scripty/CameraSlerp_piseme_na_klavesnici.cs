using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

public class CameraSlerp_piseme_na_klavesnici : MonoBehaviour {
	
	
	public GameObject Pozice;
	public GameObject Kamera;
	public int SpeedOfTranslation;
	public int SpeedOfRotation;
	public GameObject hra1;
	public GameObject hra2;
	public GameObject hra3;
	public GameObject hra4;
	public GameObject tp2;
	public GameObject tp3;
	public GameObject tp4;

    public GameObject[] pozice;
    public int citac = 0;
    public GameObject levaSipka;
    public GameObject pravaSipka;

    public float vzdalenost;
	public bool presunuto = false;
	
	public double myTimer = 1.1;


    //	Mince min;
    //	GameObject minobj;

    //	GameObject[] plamen;
    // Use this for initialization

    

    void Start () {
        pozice = GameObject.FindGameObjectsWithTag("PoziceKamery").OrderBy(go => go.name).ToArray();

    }
	void spust(){
		if(citac == 1 && presunuto){
			hra1.SetActive (true);
		}
		if(citac != 1){
			hra1.SetActive (false);
		}
		
		
		if(citac == 2 && presunuto){
				hra2.SetActive (true);
				tp2.transform.localPosition = new Vector3(7, 189, 0);				

		}
		if(citac != 2){
			tp2.transform.localPosition = new Vector3(7, 900, 0);
			hra2.SetActive (false);
			

		}
		if(citac == 3 && presunuto){
				hra3.SetActive (true);
			if(hra3.GetComponent<pismenaNaCas>().obtiznost != 0){
				tp3.transform.localPosition = new Vector3(7, 93, 0);
			}else{
				tp3.transform.localPosition = new Vector3(7, 900, 0);
			}
				
		}
		if(citac != 3){
			hra3.SetActive (false);
			tp3.transform.localPosition = new Vector3(7, 900, 0);
		}
		if(citac == 4 && presunuto){
			hra4.SetActive (true);
			if(hra4.GetComponent<slovaNaCas>().obtiznost !=0){
				tp4.transform.localPosition = new Vector3(7, 93, 0);
			}else{
				tp4.transform.localPosition = new Vector3(7, 900, 0);
			}

		}
		if(citac != 4){
			hra4.SetActive (false);
			tp4.transform.localPosition = new Vector3(7, 900, 0);
		}
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

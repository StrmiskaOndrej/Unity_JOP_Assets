using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

public class CameraSlerp : MonoBehaviour {
	
	public GameObject Pozice;
	public GameObject Kamera;
	public int SpeedOfTranslation;
	public int SpeedOfRotation;

    public GameObject[] pozice;
    public int citac = 0;
    public GameObject levaSipka;
    public GameObject pravaSipka;

    public float vzdalenost;
	public bool presunuto = false;




    // Use this for initialization

    void Start () {

        pozice = GameObject.FindGameObjectsWithTag("PoziceKamery").OrderBy(go => go.name).ToArray();

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

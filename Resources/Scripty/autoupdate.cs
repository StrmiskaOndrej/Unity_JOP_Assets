using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoupdate : MonoBehaviour {
    private string latestVersionString = "";
    public float thisVersionFloat = 1.0f;
    public string latestVersionTXT = "http://home.pf.jcu.cz/jop/version.txt";
    public GameObject panelUpdate;
    public GameObject updateButton;


    // Use this for initialization
    IEnumerator Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {

            WWW www = new WWW(latestVersionTXT);
            yield return www;
            latestVersionString = www.text;
            float latestVersionFloat;
            bool overeni = float.TryParse(latestVersionString, out latestVersionFloat);

            if (overeni)
            {


                if (latestVersionFloat > thisVersionFloat)
                {
                    updateButton.SetActive(true);
                }
                else {
                    panelUpdate.SetActive(false);
                }
            }
            else
            {
                panelUpdate.SetActive(false);
            }
        }
        else {
            panelUpdate.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void otevriWeb() {
        Application.OpenURL("http://home.pf.jcu.cz/jop");
    }
}

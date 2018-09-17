using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HlavniMenu : MonoBehaviour {
	private bool loadScene = false;
	private int scene;
	public Text loadingText;
	public Button buttonExit;
	public Button buttonInfo;
	public Button buttonSettings;
	public GameObject panelStmaveni;
	public Image panelExit;
	public Image panelSettings;
	public Image panelInfo;
	public Animation animaceInfo;
	public float rychlostInfo;
	public bool infoZobrazeno;
	public bool schovatInfo;
	public Animation animaceExit;
	public float rychlostExit;
	public bool exitZobrazeno;
	public bool schovatExit;
    public Text rozliseni;

    public Image panelUpdate;
    public Animation animaceUpdate;
    public float rychlostUpdate;
    public bool updateZobrazeno;
    public bool schovatUpdate;

    public Animation animaceSettings;
	public float rychlostSettings;
	public bool settingsZobrazeno;
	public bool schovatSettings;
	public Animator stmaveniAnimator;
	public GameObject nastaveni;

	public CursorMode cursorMode = CursorMode.Auto;
	public CursorMode force = CursorMode.ForceSoftware;
    public int pocetDeti;


    // Use this for initialization
    void Start () {
		animaceInfo["info_anim"].speed = rychlostInfo;
		animaceInfo.Play("info_anim");

		animaceExit["exit_anim"].speed = rychlostExit;
		animaceExit.Play("exit_anim");

		animaceSettings["settings_anim"].speed = rychlostSettings;
		animaceSettings.Play("settings_anim");

        animaceUpdate["update_anim"].speed = rychlostUpdate;
        animaceUpdate.Play("update_anim");


        Cursor.SetCursor(null, new Vector2(0,0), cursorMode);

        if (Application.platform == RuntimePlatform.WebGLPlayer) {
            panelExit.gameObject.SetActive(false);
            panelSettings.gameObject.SetActive(false);
        }


        pocetDeti = transform.childCount;
        }
	
	// Update is called once per frame
	void Update () {
        if (loadScene == true)
        {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }

            if (Application.platform == RuntimePlatform.WebGLPlayer && Screen.fullScreen)
            {
                panelExit.gameObject.SetActive(true);
            } else if (Application.platform == RuntimePlatform.WebGLPlayer && !Screen.fullScreen)
            {
                panelExit.gameObject.SetActive(false);
            }

        rozliseni.text = "Aktuální rozlišení: " + Screen.width + " : " + Screen.height;


		//info
		if(animaceInfo["info_anim"].time < 1 && infoZobrazeno){
			rychlostInfo = 2f;
		}else if(animaceInfo["info_anim"].time > 1 && infoZobrazeno){
			rychlostInfo = 0;
		}



		if(schovatInfo){
			if(animaceInfo["info_anim"].time > 0){
				rychlostInfo = -2;
			}
			if(animaceInfo["info_anim"].time < 0){
				rychlostInfo = 0;
				schovatInfo=false;
				infoZobrazeno = false;
                panelStmaveni.transform.SetSiblingIndex(pocetDeti-5);
                panelStmaveni.SetActive(false);
			}

		}
		animaceInfo["info_anim"].speed = rychlostInfo;

		//exit
		if(animaceExit["exit_anim"].time < 1 && exitZobrazeno){
			rychlostExit = 2f;
		}else if(animaceExit["exit_anim"].time > 1 && exitZobrazeno){
			rychlostExit = 0;
		}
		
		
		
		if(schovatExit){
			if(animaceExit["exit_anim"].time > 0){
				rychlostExit = -2;
			}
			if(animaceExit["exit_anim"].time < 0){
				rychlostExit = 0;
				schovatExit=false;
				exitZobrazeno = false;
                panelStmaveni.transform.SetSiblingIndex(pocetDeti - 5);
                panelStmaveni.SetActive(false);
			}
			
		}
		animaceExit["exit_anim"].speed = rychlostExit;

		//settings
		if(animaceSettings["settings_anim"].time < 1 && settingsZobrazeno){
			rychlostSettings = 2f;
		}else if(animaceSettings["settings_anim"].time > 1 && settingsZobrazeno){
			rychlostSettings = 0;
		}
		
		
		
		if(schovatSettings){
			if(animaceSettings["settings_anim"].time > 0){
				rychlostSettings = -2;
			}
			if(animaceSettings["settings_anim"].time < 0){
				rychlostSettings = 0;
				schovatSettings=false;
				settingsZobrazeno = false;
                panelStmaveni.transform.SetSiblingIndex(pocetDeti - 5);
                panelStmaveni.SetActive(false);
			}
			
		}
		animaceSettings["settings_anim"].speed = rychlostSettings;

        //update
        if (animaceUpdate["update_anim"].time < 1 && updateZobrazeno)
        {
            rychlostUpdate = 2f;
        }
        else if (animaceUpdate["update_anim"].time > 1 && updateZobrazeno)
        {
            rychlostUpdate = 0;
        }



        if (schovatUpdate)
        {
            if (animaceUpdate["update_anim"].time > 0)
            {
                rychlostUpdate = -2;
            }
            if (animaceUpdate["update_anim"].time < 0)
            {
                rychlostUpdate = 0;
                schovatUpdate = false;
                updateZobrazeno = false;
                panelStmaveni.transform.SetSiblingIndex(pocetDeti - 5);
                panelStmaveni.SetActive(false);
            }

        }
        animaceUpdate["update_anim"].speed = rychlostUpdate;


    }

	public void SpustOvladace()
	{
		scene = 1;
		spustit();
	}

	public void SpustKresleniCary()
	{
		scene = 2;
		spustit();
	}
	public void SpustKresleniAVybarvovani()
	{
		scene = 3;
		spustit();
	}
	public void SpustDoplnovaniAUpravaTextu()
	{
		scene = 4;
		spustit();
	}
	public void SpustPsaniNaKlavesnici()
	{
		scene = 6;
		spustit();
	}
	public void SpustPrehavaniZvuku()
	{
		scene = 5;
		spustit();
	}
	public void SpustKlikaniMysi()
	{
		scene = 8;
		spustit();
	}
	public void SpustTahaniVeci()
	{
		scene = 7;
		spustit();
	}
	public void spustit(){
		loadScene = true;
		loadingText.text = "Načítání...";
		StartCoroutine(LoadNewScene());
	}


	public void UkonciAplikaci()
	{
			Application.Quit();
	}

	IEnumerator LoadNewScene() {
		
		yield return new WaitForSeconds(1);
		AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        


        while (!async.isDone) {
			yield return null;
		}
	}

	public void zobrazInfo(){
        if (infoZobrazeno)
        {
            schovejInfo();
        }
        else
        {
            infoZobrazeno = true;
            panelStmaveni.SetActive(true);
            zatmavPanel();
            panelInfo.transform.transform.SetAsLastSibling();
        }
	}
	public void schovejInfo(){
		zesvetliPanel();
		schovatInfo = true;
	}
	public void zobrazExit(){
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Screen.SetResolution(Screen.width, Screen.height, false);
        }
        else
        {
            if (exitZobrazeno)
            {
                schovejExit();
            }
            else
            {
                exitZobrazeno = true;
                panelStmaveni.SetActive(true);
                zatmavPanel();

                panelExit.gameObject.transform.SetAsLastSibling();
            }
            
        }
	}
	public void schovejExit(){
		zesvetliPanel();
		schovatExit = true;
        
    }

    public void zobrazUpdate()
    {
        if (updateZobrazeno)
        {
            schovejUpdate();
        }
        else
        {
            updateZobrazeno = true;
            panelStmaveni.SetActive(true);
            zatmavPanel();
            panelUpdate.gameObject.transform.SetAsLastSibling();
        }
    }
    public void schovejUpdate()
    {
        zesvetliPanel();
        schovatUpdate = true;

    }

    public void zobrazSettings(){
        if (settingsZobrazeno)
        {
            schovejSettings();
        }
        else
        {
            settingsZobrazeno = true;
            panelStmaveni.SetActive(true);
            zatmavPanel();
            panelSettings.transform.SetAsLastSibling();
        }
	}
	public void schovejSettings(){
		zesvetliPanel();
		schovatSettings = true;
	}


	public void zatmavPanel(){
		stmaveniAnimator.SetBool("zatmaveno", true);
        panelStmaveni.transform.SetSiblingIndex(pocetDeti - 1);

    }
	public void zesvetliPanel(){
		stmaveniAnimator.SetBool("zatmaveno", false);
        

    }

	


	public void najetiMysi(int i){
		if(!loadScene){
			if(i == 0){
				loadingText.text = "Vyber hru";
			}else if(i == 1 && buttonExit.enabled == true){
				loadingText.text = "Ukončit hru";
			}else if(i == 2){
				loadingText.text = "Informace o hře";
			}else if(i == 3){
				loadingText.text = "Nastavení hry";
			}else if(i == 4){
				loadingText.text = "Klikání myší";
			}else if(i == 5){
				loadingText.text = "Tahání myší";
			}else if(i == 6){
				loadingText.text = "Kreslení čáry";
			}else if(i == 7){
				loadingText.text = "Kreslení a vybarvování";
			}else if(i == 8){
				loadingText.text = "Ovladače";
			}else if(i == 9){
				loadingText.text = "Psaní na klávesnici";
			}else if(i == 10){
				loadingText.text = "Doplňování a úprava textu";
			}else if(i == 11){
				loadingText.text = "Přehrávání zvuku";
			}else if (i == 12)
            {
                loadingText.text = "Aktualizovat hru";
            }
        }

	}
	

}

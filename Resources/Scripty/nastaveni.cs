using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class nastaveni : MonoBehaviour {
	public Toggle toggle800x600;
	public Toggle toggle1024x768;
	public Toggle toggle1280x720;
	public Toggle toggle1280x800;
	public Toggle toggle1366x768;
	public Toggle toggle1360x1024;
	public Toggle toggle1440x900;
	public Toggle toggle1680x1050;
    public Toggle toggle1920x1080;
    public Toggle toggle3840x2160;
    public Toggle toggleVOkne;
	public Toggle toggleCelaObrazovka;
	public bool zobrazeniFullScreen;

	public int widthTemp;
	public int heightTemp;
	public int widthVybrany;
	public int heightVybrany;
	public Text aktualniRozliseni;
	public Button exitButton;


	// Use this for initialization
	void Start () {
		widthTemp = Screen.width; // Screen.width = počet pixelů na šířku
		heightTemp = Screen.height; // Screen.width = počet pixelů na výšku
        widthVybrany = Screen.width;
		heightVybrany = Screen.height;

        if (((double)heightTemp / (double)widthTemp) >= 0.76){
			widthTemp = 1024;
			heightTemp = 768;
			widthVybrany = 1024;
			heightVybrany = 768;
            
		}
		aktualniRozliseni.text = "Aktuální rozlišení: " + widthTemp + " x " + heightTemp;
		nastavPuvodniHodnoty();	
		Screen.SetResolution(widthTemp, heightTemp, zobrazeniFullScreen);
	}

	public void nastavPuvodniHodnoty(){
		if(Screen.fullScreen){
			toggleCelaObrazovka.isOn = true;
			zobrazeniFullScreen = true;
		}else{
			toggleVOkne.isOn = true;
			zobrazeniFullScreen = false;
		}
		
		if(widthTemp == 800 && heightTemp == 600){
			toggle800x600.isOn = true;
		}else if(widthTemp == 1024 && heightTemp == 768){
			toggle1024x768.isOn = true;
		}else if(widthTemp == 1280 && heightTemp == 720){
			toggle1280x720.isOn = true;
		}else if(widthTemp == 1280 && heightTemp == 800){
			toggle1280x800.isOn = true;
		}else if(widthTemp == 1360 && heightTemp == 768){
			toggle1366x768.isOn = true;
		}else if(widthTemp == 1366 && heightTemp == 1024){
			toggle1360x1024.isOn = true;
		}else if(widthTemp == 1440 && heightTemp == 900){
			toggle1440x900.isOn = true;
		}else if(widthTemp == 1680 && heightTemp == 1050){
			toggle1680x1050.isOn = true;
        }else if (widthTemp == 1920 && heightTemp == 1080){
            toggle1920x1080.isOn = true;        
        }else if (widthTemp == 3840 && heightTemp == 2160){
            toggle3840x2160.isOn = true;
        }

    }
	public void zobrazeniVOkne(){
		zobrazeniFullScreen = false;
	}
	public void zobrazeniFullscreen(){
		zobrazeniFullScreen = true;
	}

	public void zmenRozliseniNa800x600(){
		widthVybrany = 800;
		heightVybrany = 600;
	}
	public void zmenRozliseniNa1024x768(){
		widthVybrany = 1024;
		heightVybrany = 768;
	}
	public void zmenRozliseniNa1280x720(){
		widthVybrany = 1280;
		heightVybrany = 720;
	}
	public void zmenRozliseniNa1280x800(){
		widthVybrany = 1280;
		heightVybrany = 800;
	}
	public void zmenRozliseniNa1366x768(){
		widthVybrany = 1366;
		heightVybrany = 768;
	}
	public void zmenRozliseniNa1360x1024(){
		widthVybrany = 1360;
		heightVybrany = 1024;
	}
	public void zmenRozliseniNa1440x900(){
		widthVybrany = 1440;
		heightVybrany = 900;
	}
	public void zmenRozliseniNa1680x1050(){
		widthVybrany = 1680;
		heightVybrany = 1050;
	}
    public void zmenRozliseniNa1920x1080(){
        widthVybrany = 1920;
        heightVybrany = 1080;
    }
    public void zmenRozliseniNa3840x2160(){
        widthVybrany = 3840;
        heightVybrany = 2160;
    }

    public void potvrdZmenu(){
		Screen.SetResolution(widthVybrany, heightVybrany, zobrazeniFullScreen);
		widthTemp = widthVybrany;
		heightTemp = heightVybrany;
		aktualniRozliseni.text = "Aktuální rozlišení: " + widthTemp + " x " + heightTemp;
//		webNastaveni();
//		nastavPuvodniHodnoty();

	}

	
	// Update is called once per frame
	void Update () {
	
	}
}

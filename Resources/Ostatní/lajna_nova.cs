using UnityEngine;
using System.Collections;

public class lajna_nova : MonoBehaviour {
	public string SortingLayerName = "Default"; 
	public int SortingOrder = 2;
	public Vector2 mousePos; // pozice myši
	public Vector2 startPos; // 1. pozice čáry
	public Vector2 endPos;   // Poslední potice čáry
	public LineRenderer line; // Komponenta LineRenderer, nutné přiřadit v Inspectoru
    public bool start; // Začala se čára tvořit?
	public bool isPressed; // Je tlačítko spuštěné?
	public bool konec; // Je čára ukončená?

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<LineRenderer> ().sortingLayerName = SortingLayerName; 
		gameObject.GetComponent<LineRenderer> ().sortingOrder = SortingOrder;	
	}
	
	// Update is called once per frame
	void Update () {
		if(!konec){ // Pokud není tvorba scriptu ukončená
		    var v3 = Input.mousePosition;  // Vytvoří se pomocná proměnná komponenty Vector3, která je nadefinována z pozice myši
		    v3.z = 8.5f; // Nastaví se vzdálenost od kamery
		    v3 = Camera.main.ScreenToWorldPoint(v3); // Pozice se upraví podle kamery 
		    mousePos = v3; // mousePos se nastaví z pomocné proměnné
		    if(Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0){ // Zjišťuje, zda je levé tlačítko myši stisknuté
                isPressed = true; 
			    if(start == false){ //Pokud ještě tvorba nezačala
				    start = true;			
				    startPos = mousePos; // Nadefinuje se 1. pozice čáry
				    line.positionCount = 1; // Nastaví se počet pozic čáry
                    line.SetPosition (0, startPos); // Nastaví se 1. pozice čáry				
                }
		    }
		    if(Input.GetMouseButtonUp(0)) { // Zjišťuje, zda je upuštěné levé tlačítko myši
                start = false;
			    isPressed = false;
			    konec = true;			
		    }
		    if(isPressed == true){ // Pokud je tlačítko stisknuté
			    endPos = mousePos; // Nadefinuje se konečná pozice čáry 
                line.positionCount = 2; // Čára se skládá ze dvou bodů
                line.SetPosition (1, endPos); // Nastaví se konečná pozice čáry
		    }
		}
	}
}

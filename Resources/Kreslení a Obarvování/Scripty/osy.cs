using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class osy : MonoBehaviour {
	public Vector2 mousePos; // Pozice myši
	public bool isPressed; // Je stisnuto levé tlačítko?
	public bool tvorim; // Tvořím lajnu?
	public GameObject objToSpawn; // Prefab ze kterého se bude čára tvořit
    public GameObject objekt1; // objekt k vytvoření
	public GameObject objekt2;
	public GameObject objekt3;
	public GameObject objekt4;
	public Vector2 pozice1;
	public Vector2 pozice2;
	public Vector2 pozice3;
	public Vector2 pozice4;
	public GameObject bublina;
    public GameObject bublinaHotovo;
    public int so = 2;
    public int pocetCar;

	public List<Vector2> pointsList; // seznam pozic, ve kterých čára byla
	public bool osaXAktivni;
	public bool osaYAktivni;
	public GameObject osaX;
	public GameObject osaY;
	public float vzdalenostX;
	public float vzdalenostY;
	// Use this for initialization
	void Start () {
		pointsList = new List<Vector2>(); // inicializace seznamu
	}
	
	// Update is called once per frame
	void Update () {
        var v3 = Input.mousePosition;  // Vytvoří se pomocná proměnná komponenty Vector3, která je nadefinována z pozice myši
        v3.z = 8.5f; // Nastaví se vzdálenost od kamery
        v3 = Camera.main.ScreenToWorldPoint(v3); // Pozice se upraví podle kamery 
        mousePos = v3; // mousePos se nastaví z pomocné proměnné

        vzdalenostX = mousePos.x;
		vzdalenostY = mousePos.y;


		if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        { //pokud je levé tlačítko myši stisknuté
            isPressed = true;
		}
		if(Input.GetMouseButtonUp(0)){ // Zjišťuje, zda je levé tlačítko myši stisknuté
            isPressed = false;
			tvorim = false;
            if (pocetCar >= 1) {
                bublinaHotovo.SetActive(true);
                bublina.SetActive(false);
            }
		}
		if(isPressed == true){ // Zjišťuje, zda je upuštěné levé tlačítko myši

            if (tvorim == false) //Pokud se již čára netvoří
            {
                tvorim = true; // čára se tvoří
                objekt1 = Instantiate(objToSpawn); // Vytvoří nový objekt z prefabu
                objekt1.transform.parent = gameObject.transform; //objekt se stane podobjektem objektu ke kterému je přiřazen tento scriptu
                objekt1.tag = "lajnaOsy"; // nastaví tag objektu

                objekt1.GetComponent<LineRenderer>().startColor = Color.blue; // nastaví první barvu čáry
                objekt1.GetComponent<LineRenderer>().endColor = Color.blue; // nastaví poslední barvu čáry
                objekt1.GetComponent<KreslimeLajnu>().SortingOrder = so;
			
                pointsList.RemoveRange(0,pointsList.Count); // Vymaže veškeré hodnoty v seznamu
				if(osaXAktivni){
					objekt2 = Instantiate(objToSpawn);
					objekt2.transform.parent = gameObject.transform;
					objekt2.tag = "lajnaOsy";
					Color zelena = new Color (0,0.5f,0);
                    objekt2.GetComponent<LineRenderer>().startColor = zelena;
                    objekt2.GetComponent<LineRenderer>().endColor = zelena;
                    objekt2.GetComponent<KreslimeLajnu>().SortingOrder = so;
                    pocetCar++;

				}

				if(osaYAktivni){
					objekt3 = Instantiate(objToSpawn);
					objekt3.transform.parent = gameObject.transform;
					objekt3.tag = "lajnaOsy";
					Color orange = new Color(1,0.7f,0);
                    objekt3.GetComponent<LineRenderer>().startColor = orange;
                    objekt3.GetComponent<LineRenderer>().endColor = orange;
                    objekt3.GetComponent<KreslimeLajnu>().SortingOrder = so;
                    pocetCar++;

                }
				if(osaXAktivni && osaYAktivni){
					objekt4 = Instantiate(objToSpawn);
					objekt4.transform.parent = gameObject.transform;
					objekt4.tag = "lajnaOsy";
                    objekt4.GetComponent<LineRenderer>().startColor = Color.red;
                    objekt4.GetComponent<LineRenderer>().endColor = Color.red;
                    objekt4.GetComponent<KreslimeLajnu>().SortingOrder = so;
					
				}
				so++;
		}
			if (!pointsList.Contains (mousePos)) // Pokud seznam neobsahuje pozici mousepos
			{
				pointsList.Add (mousePos); // Přidá se do seznamu pozice mousepos 
				pozice1 = mousePos; 
				objekt1.GetComponent<LineRenderer>().positionCount = pointsList.Count; // Nastaví se počet bodů v čáře, podle počtu hodnot v seznamu
				objekt1.GetComponent<LineRenderer>().SetPosition (pointsList.Count - 1, pozice1); //nastaví se poslední bod čáry podle aktuální pozice myši
				if(osaXAktivni){				
					pozice2.x = -(vzdalenostX);					  
					pozice2.y = mousePos.y;
					objekt2.GetComponent<LineRenderer>().positionCount = pointsList.Count;
                    objekt2.GetComponent<LineRenderer>().SetPosition (pointsList.Count - 1, pozice2);
				}
				if(osaYAktivni){				
					pozice3.x = mousePos.x;					  
					pozice3.y = -(vzdalenostY);
					objekt3.GetComponent<LineRenderer>().positionCount = pointsList.Count;
                    objekt3.GetComponent<LineRenderer>().SetPosition (pointsList.Count - 1, pozice3);
				}
				if(osaXAktivni && osaYAktivni){
					pozice4.x = -(vzdalenostX);				  
					pozice4.y = -(vzdalenostY);
					objekt4.GetComponent<LineRenderer>().positionCount = pointsList.Count;
                    objekt4.GetComponent<LineRenderer>().SetPosition (pointsList.Count - 1, pozice4);
				}
			}
		}

	}
	public void zmenX(){
		bublina.SetActive(false);
		if(osaXAktivni){
			osaXAktivni=false;
			osaX.SetActive(false);
		}else{
			osaXAktivni=true;
			osaX.SetActive(true);
		}
	}

	public void zmenY(){
		bublina.SetActive(false);
		if(osaYAktivni){
			osaYAktivni=false;
			osaY.SetActive(false);
		}else{
			osaYAktivni=true;
			osaY.SetActive(true);
		}
	}
	public void vycisti(){
		bublina.SetActive(true);
        bublinaHotovo.SetActive(false);
		pointsList.RemoveRange(0,pointsList.Count);
        pocetCar = 0;

		GameObject[] objs = GameObject.FindGameObjectsWithTag("lajnaOsy");
		for (int i=0; i<objs.Length; i++){
			Destroy(objs[i]);
		}
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class kresleni_script : MonoBehaviour {
	public Vector2 mousePos;
	private List<Vector2> pointsList;
	public bool isPressed;
	public bool tvorim;
	public Color vybranaBarva;
	public float tloustka;
	public int so = 2;
	public GameObject bublina;
    public GameObject bublinaHotovo;
    public int pocetCar;

    public bool tuzkaZapnuta;
	public bool gumaZapnuta;
	public bool lajnaZapnuta;
	public UnityEngine.UI.Image zobrazenaBarva;

	public GameObject objToSpawnTuzka;
	public GameObject objToSpawnLajna;
	public GameObject objekt;

	// Use this for initialization
	void Start () {
		pointsList = new List<Vector2>();
		vybranaBarva = Color.black;
		tloustka = 0.05f;		

	}
	
	// Update is called once per frame
	void Update () {
		var v3 = Input.mousePosition;
		v3.z = 8.5f;
		v3 = Camera.main.ScreenToWorldPoint(v3);
		
		mousePos = v3;
		zobrazenaBarva.color = vybranaBarva;
		if(Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0 && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
		{
			if(tuzkaZapnuta || lajnaZapnuta){
				isPressed = true;
			}
		}
		if(Input.GetMouseButtonUp(0)){
			isPressed = false;
			tvorim = false;
            if (pocetCar >= 2) {
                bublinaHotovo.SetActive(true);
                bublina.SetActive(false);
            }
		}
		if(isPressed == true){
			if(tuzkaZapnuta){
				if(tvorim == false)
				{
                    pocetCar++;
					objekt = Instantiate(objToSpawnTuzka);
					objekt.transform.parent = gameObject.transform;
					objekt.tag = "kreslimeTuzka";
					
                    objekt.GetComponent<KreslimeLajnu_s_colliderem>().line.startColor = vybranaBarva;
                    objekt.GetComponent<KreslimeLajnu_s_colliderem>().line.endColor = vybranaBarva;

                    objekt.GetComponent<KreslimeLajnu_s_colliderem>().line.startWidth = tloustka;
                    objekt.GetComponent<KreslimeLajnu_s_colliderem>().line.endWidth = tloustka;


                    objekt.GetComponent<KreslimeLajnu_s_colliderem>().SortingOrder = so;
					so++;
					tvorim = true;
					pointsList.RemoveRange(0,pointsList.Count);
				}
				if (!pointsList.Contains (mousePos)) 
				{
					pointsList.Add (mousePos);
					objekt.GetComponent<KreslimeLajnu_s_colliderem>().line.positionCount = pointsList.Count;
					objekt.GetComponent<KreslimeLajnu_s_colliderem>().line.SetPosition (pointsList.Count - 1, mousePos);



					if(pointsList.Count > 1){ // Pokud čára obsahuje aspoň 2 pozice
					objekt.GetComponent<KreslimeLajnu_s_colliderem>().objekt = Instantiate(objekt.GetComponent<KreslimeLajnu_s_colliderem>().colliderToSpawn); //Z objektu čáry vytvoří nový objekt
					objekt.GetComponent<KreslimeLajnu_s_colliderem>().objekt.GetComponent<kreslime_collider>().tloustka = tloustka; 
					objekt.GetComponent<KreslimeLajnu_s_colliderem>().objekt.transform.parent = objekt.transform; // nastaví druhý objekt jako dítě objektu objekt
					objekt.GetComponent<KreslimeLajnu_s_colliderem>().objekt.GetComponent<kreslime_collider>().startPos = pointsList[pointsList.Count - 2];	//Nstaví se startovní pozice			
					objekt.GetComponent<KreslimeLajnu_s_colliderem>().objekt.GetComponent<kreslime_collider>().endPos = pointsList[pointsList.Count -1]; //Nstaví se konečná pozice
                        objekt.GetComponent<KreslimeLajnu_s_colliderem>().objekt.GetComponent<kreslime_collider>().addColliderToLine(); //Vytvoří se Collider
					}
				}
			}
			if(lajnaZapnuta){
				if(tvorim == false)
				{
                    pocetCar++;
                    objekt = Instantiate(objToSpawnLajna);
					objekt.transform.parent = gameObject.transform;
					objekt.tag = "kreslimeLajna";
                    objekt.GetComponent<lajna_nova_s_colliderem>().line.startColor = vybranaBarva;
                    objekt.GetComponent<lajna_nova_s_colliderem>().line.endColor = vybranaBarva;
                    objekt.GetComponent<lajna_nova_s_colliderem>().tloustka = tloustka;;
                    objekt.GetComponent<lajna_nova_s_colliderem>().line.startWidth = tloustka;
                    objekt.GetComponent<lajna_nova_s_colliderem>().line.endWidth = tloustka;
                    objekt.GetComponent<lajna_nova_s_colliderem>().SortingOrder = so;
					so++;
					tvorim = true;
					objekt.GetComponent<lajna_nova_s_colliderem>().startPos = mousePos;
					objekt.GetComponent<lajna_nova_s_colliderem>().isPressed = true;
					objekt.GetComponent<lajna_nova_s_colliderem>().line.positionCount = 1;
					objekt.GetComponent<lajna_nova_s_colliderem>().line.SetPosition (0, mousePos);
				}


			}

		}
	}

	public void vycisti(){
        pocetCar = 0;
        bublinaHotovo.SetActive(false);
		GameObject[] objs1 = GameObject.FindGameObjectsWithTag("kreslimeTuzka");
		for (int i=0; i<objs1.Length; i++){
			Destroy(objs1[i]);
		}

		GameObject[] objs2 = GameObject.FindGameObjectsWithTag("kreslimeLajna");
		for (int i=0; i<objs2.Length; i++){
			Destroy(objs2[i]);
		}
		bublina.SetActive(true);
	}

	public void nastavTuzku(){
		bublina.SetActive(false);
		tuzkaZapnuta = true;
		lajnaZapnuta = false;
		gumaZapnuta = false;
	}
	public void nastavLajnu(){
		bublina.SetActive(false);
		tuzkaZapnuta = false;
		lajnaZapnuta = true;
		gumaZapnuta = false;
	}
	public void nastavGumu(){
		bublina.SetActive(false);
		tuzkaZapnuta = false;
		lajnaZapnuta = false;
		gumaZapnuta = true;
	}

	public void NastavCervenouBarvu(){
		vybranaBarva = new Color(1,0,0);
		
	}
	public void NastavCernouBarvu(){
		vybranaBarva = new Color(0,0,0);
		
	}
	public void NastavModrouBarvu(){
		vybranaBarva = new Color(0,0,1);
		
	}
	public void NastavZelenouBarvu(){
		vybranaBarva = new Color(0,1,0);
		
	}
	public void NastavZlutouBarvu(){
		vybranaBarva = new Color(1,1,0);
		
	}
	public void NastavHnedouBarvu(){
		vybranaBarva = new Color(0.5f,0.25f,0);
		
	}
	
	public void NastavSedouBarvu(){
		vybranaBarva = new Color(0.5f,0.5f,0.5f);
		
	}
	public void NastavRuzovouBarvu(){
		vybranaBarva = new Color(1,0.764f,0.796f);
		
	}
	public void NastavAquaBarvu(){
		vybranaBarva = new Color(0,1,1);
		
	}
	public void NastavOranzovouBarvu(){
		vybranaBarva = new Color(1,0.5f,0);
		
	}
	
	public void NastavTmZelenouBarvu(){
		vybranaBarva = new Color(0,0.392f,0);
		
	}
	public void NastavTmaveCervenouBarvu(){
		vybranaBarva = new Color(0.5f,0,0);
		
	}
	public void NastavFialovaBarvu(){
		vybranaBarva = new Color(1,0,1);
		
	}
	public void NastavSvSedaBarvu(){
		vybranaBarva = new Color(0.784f,0.784f,0.784f);
		
	}

	public void NastavTloustku1(){
		tloustka = 0.0125f;		
	}
	public void NastavTloustku2(){
		tloustka = 0.0250f;		
	}
	public void NastavTloustku3(){
		tloustka = 0.05f;		
	}
	public void NastavTloustku4(){
		tloustka = 0.1f;		
	}
}

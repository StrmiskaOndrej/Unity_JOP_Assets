using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mrkev : MonoBehaviour 
{
	public LineRenderer line;
	public bool isMousePressed;
	private List<Vector3> pointsList;
	private Vector2 mousePos;
	private Vector2 startPozice;
	public Material mat;
	public bool start = false;
	public bool vybrano = false;
	public bool konec = false;
	public bool pokracovani = false;
	public bool kolize = false;
	public string SortingLayerName = "Default";
	public int SortingOrder = 2;
	public bool kolizeKralik = false;
	public GameObject small;
	public Vector2 aPosition1 = new Vector2(0,0);
	public GameObject ButtonZnovu;
	public GameObject BublinaStart;
	public GameObject BublinaKolize;
	public GameObject BublinaKonec;
	public bool  firework = false;
	public ParticleSystem ohnostroj;
	public int scenar = 0;
	public int[] scenare = {0,1,2};

	public GameObject kralik;

	public GameObject vert1;
	public GameObject vert2;
	public GameObject vert3;
	public GameObject vert4;
	public GameObject vert5;
	public GameObject vert6;
	public GameObject vert7;
	public GameObject vert8;
	public GameObject vert9;
	public GameObject vert10;
	public GameObject vert11;
	public GameObject vert12;
	public GameObject vert13;
	public GameObject vert14;
	
	public GameObject hor1;
	public GameObject hor2;
	public GameObject hor3;
	public GameObject hor4;
	public GameObject hor5;
	public GameObject hor6;
	public GameObject hor7;
	public GameObject hor8;
	public GameObject hor9;
	public GameObject hor10;
	public GameObject hor11;
	public GameObject hor12;

	void Start () {
		reshuffleint(scenare);
		inicializace();
		
	}

	//	-----------------------------------	
	void Awake()
	{
		// Create line renderer component and set its property
		line = gameObject.AddComponent<LineRenderer>();
		line.material =  mat;
        line.positionCount = 1;
        line.startWidth = 0.15f;
        line.endWidth = 0.15f;
        line.useWorldSpace = true;	
		isMousePressed = false;
		pointsList = new List<Vector3>();
		gameObject.GetComponent<LineRenderer> ().sortingLayerName = SortingLayerName;
		gameObject.GetComponent<LineRenderer> ().sortingOrder = SortingOrder;
		startPozice = new Vector2(this.transform.position.x, this.transform.position.y);

	}

	public void inicializace(){
		if(scenare[scenar]==0){
		kralik.transform.localPosition = new Vector3(-0.62f, 2.51f,0);

			vert1.transform.localPosition = new Vector3(-4.565f, 3.344f,0);
			vert2.transform.localPosition = new Vector3(-4.565f, 3.918f,0);
			vert3.transform.localPosition = new Vector3(-4.565f, 2.631f,0);
			vert4.transform.localPosition = new Vector3(-2.044f, 2.414f,0);
			vert5.transform.localPosition = new Vector3(-4.565f, 4.65f,0);
			vert6.transform.localPosition = new Vector3(-2.044f, 4.655f,0);
			vert7.transform.localPosition = new Vector3(-2.044f, 2.92f,0);
			vert8.transform.localPosition = new Vector3(-3.67f, 2.518f,0);
			vert9.transform.localPosition = new Vector3(-2.044f, 3.565f,0);
			vert10.transform.localPosition = new Vector3(-2.044f, 3.905f,0);
			vert11.transform.localPosition = new Vector3(-2.784f, 2.42f,0);
			vert12.transform.localPosition = new Vector3(-3.67f, 3.172f,0);
			vert13.transform.localPosition = new Vector3(-3.67f, 1.772f,0);
			vert14.transform.localPosition = new Vector3(-3.67f, 2.518f,0);
			
			hor1.transform.localPosition = new Vector3(-4.19f, 5.017f,0);
			hor2.transform.localPosition = new Vector3(-2.421f, 2.065f,0);
			hor3.transform.localPosition = new Vector3(-2.403f, 5.017f,0);
			hor4.transform.localPosition = new Vector3(-4.95f, 2.274f,0);
			hor5.transform.localPosition = new Vector3(-5.158f, 2.271f,0);
			hor6.transform.localPosition = new Vector3(-3.771f, 5.017f,0);
			hor7.transform.localPosition = new Vector3(-4.2f, 4.28f,0);
			hor8.transform.localPosition = new Vector3(-3.463f, 4.28f,0);
			hor9.transform.localPosition = new Vector3(-3.143f, 5.017f,0);
			hor10.transform.localPosition = new Vector3(-3.31f, 3.549f,0);
			hor11.transform.localPosition = new Vector3(-3.151f, 4.28f,0);
			hor12.transform.localPosition = new Vector3(-3.151f, 3.549f,0);
			
		}
		if(scenare[scenar]==1){
			kralik.transform.localPosition = new Vector3(-0.59f, 4.21f,0);
			
			vert1.transform.localPosition = new Vector3(-4.1f, 3.92f,0);
			vert2.transform.localPosition = new Vector3(-4.1f, 3.68f,0);
			vert3.transform.localPosition = new Vector3(-4.81f, 2.97f,0);
			vert4.transform.localPosition = new Vector3(-1.91f, 2.414f,0);
			vert5.transform.localPosition = new Vector3(-4.86f, 4.65f,0);
			vert6.transform.localPosition = new Vector3(-1.91f, 4.655f,0);
			vert7.transform.localPosition = new Vector3(-3.34f, 3.05f,0);
			vert8.transform.localPosition = new Vector3(-4.81f, 2.449f,0);
			vert9.transform.localPosition = new Vector3(-1.91f, 3.16f,0);
			vert10.transform.localPosition = new Vector3(-1.91f, 3.905f,0);
			vert11.transform.localPosition = new Vector3(-2.65f, 3.21f,0);
			vert12.transform.localPosition = new Vector3(-3.34f, 2.42f,0);
			vert13.transform.localPosition = new Vector3(-4.81f, 1.772f,0);
			vert14.transform.localPosition = new Vector3(-2.65f, 3.91f,0);
			
			hor1.transform.localPosition = new Vector3(-4.48f, 5.017f,0);
			hor2.transform.localPosition = new Vector3(-2.27f, 2.065f,0);
			hor3.transform.localPosition = new Vector3(-2.27f, 5.017f,0);
			hor4.transform.localPosition = new Vector3(-3.02f, 2.065f,0);
			hor5.transform.localPosition = new Vector3(-3.67f, 2.065f,0);
			hor6.transform.localPosition = new Vector3(-3.73f, 5.017f,0);
			hor7.transform.localPosition = new Vector3(-5.21f, 4.28f,0);
			hor8.transform.localPosition = new Vector3(-4.46f, 3.32f,0);
			hor9.transform.localPosition = new Vector3(-2.99f, 5.017f,0);
			hor10.transform.localPosition = new Vector3(-3.01f, 4.28f,0);
			hor11.transform.localPosition = new Vector3(-3.74f, 4.28f,0);
			hor12.transform.localPosition = new Vector3(-3.74f, 4.28f,0);
			
		}
		if(scenare[scenar]==2){
			kralik.transform.localPosition = new Vector3(3.03f, 4.22f,0);
		
			vert1.transform.localPosition = new Vector3(-4.1f, 3.7f,0);
			vert2.transform.localPosition = new Vector3(-2.03f, 2.62f,0);
			vert3.transform.localPosition = new Vector3(-4.81f, 2.97f,0);
			vert4.transform.localPosition = new Vector3(-2.03f, 3.19f,0);
			vert5.transform.localPosition = new Vector3(-4.1f, 4.43f,0);
			vert6.transform.localPosition = new Vector3(-2.03f, 5.43f,0);
			vert7.transform.localPosition = new Vector3(-3.37f, 3.24f,0);
			vert8.transform.localPosition = new Vector3(-4.81f, 2.449f,0);
			vert9.transform.localPosition = new Vector3(-2.03f, 3.93f,0);
			vert10.transform.localPosition = new Vector3(-2.03f, 4.68f,0);
			vert11.transform.localPosition = new Vector3(-2.71f, 3.78f,0);
			vert12.transform.localPosition = new Vector3(-3.37f, 2.62f,0);
			vert13.transform.localPosition = new Vector3(-4.81f, 1.772f,0);
			vert14.transform.localPosition = new Vector3(-2.71f, 4.48f,0);
		
			hor1.transform.localPosition = new Vector3(-4.45f, 4.83f,0);
			hor2.transform.localPosition = new Vector3(-2.38f, 2.25f,0);
			hor3.transform.localPosition = new Vector3(-2.38f, 2.25f,0);
			hor4.transform.localPosition = new Vector3(-3.13f, 2.25f,0);
			hor5.transform.localPosition = new Vector3(-3.72f, 2.25f,0);
			hor6.transform.localPosition = new Vector3(-3.7f, 4.83f,0);
			hor7.transform.localPosition = new Vector3(-4.45f, 3.32f,0);
			hor8.transform.localPosition = new Vector3(-5.24f, 4.07f,0);
			hor9.transform.localPosition = new Vector3(-3.08f, 4.83f,0);
			hor10.transform.localPosition = new Vector3(-3.08f, 4.83f,0);
			hor11.transform.localPosition = new Vector3(-3.08f, 4.83f,0);
			hor12.transform.localPosition = new Vector3(-3.08f, 4.83f,0);
		}
	}

	void OnMouseDown(){
		if(vybrano==false){
			vybrano = true;

		}
		
	}

	void Update () 
	{
		if((vybrano==true || pokracovani == true) && !konec){
		// If mouse button down, remove old line and set its color to green
			isMousePressed = true;
			if(Input.GetMouseButtonDown(0) &&vybrano==true )
		{
			kolize = false;
            line.startColor = Color.white;
            line.endColor = Color.white;
                small.transform.position = this.transform.position;
			isMousePressed = true;
			line.positionCount = 0;
			pointsList.RemoveRange(0,pointsList.Count);

		}
		else if(Input.GetMouseButtonUp(0))
		{
				if(kolizeKralik && !kolize){
					konec = true;
                    line.startColor = Color.green;
                    line.endColor = Color.green;
                }
				pokracovani = false;
				vybrano = false;
				isMousePressed = false;

		}
			if(isMousePressed && konec == false)
		{
			var v3 = Input.mousePosition;
			v3.z = 8.5f;
			v3 = Camera.main.ScreenToWorldPoint(v3);

			mousePos = v3;

			
				
				if(start == false){
					start = true;
					line.positionCount = 1;
					line.SetPosition (0, startPozice);
					
				}


				small.transform.position = Vector2.MoveTowards(new Vector2(small.transform.position.x, small.transform.position.y), mousePos, 9 * Time.deltaTime);
				small.transform.localScale = new Vector3(0.2f,0.2f,0);

			if (!pointsList.Contains (mousePos)) 
			{
				pointsList.Add (mousePos);
				line.positionCount = pointsList.Count;
				line.SetPosition (pointsList.Count - 1, (Vector3)pointsList [pointsList.Count - 1]);

			}
		}
			if(kolize==true){
				BublinaKolize.SetActive(true);
				BublinaStart.SetActive(false);
			}else {
				BublinaKolize.SetActive(false);
				BublinaStart.SetActive(true);
			}
		}
		if(konec == true){
			BublinaKonec.SetActive(true);
			BublinaStart.SetActive(false);
			ButtonZnovu.SetActive(true);

			if(firework==false){
				ohnostroj.Emit(90);
				firework=true;
			
			}



		}
	}
	public void znovu(){
		BublinaKonec.SetActive(false);
		BublinaStart.SetActive(true);
		ButtonZnovu.SetActive(false);
		konec = false;
		kolizeKralik = false;
		line.positionCount = 1;
		line.SetPosition (0, startPozice);
		small.transform.localScale = new Vector3(0,0,0);
		small.transform.position = this.transform.position;
		firework=false;

		if(scenar <= 1){
			scenar++;
		}else{
			scenar = 0;
		}
		inicializace();

	}

	void reshuffleint(int[] texts)
	{
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < texts.Length; t++ )
		{
			int tmp = texts[t];
			int r = Random.Range(t, texts.Length);
			texts[t] = texts[r];
			texts[r] = tmp;
		}
	}

}
using UnityEngine;
using System.Collections;

public class mys : MonoBehaviour {
	public GameObject bublina5;
	public GameObject bublina5konec;
	public ParticleSystem ohnostroj;
	public UnityEngine.UI.Text textHorni;
	public UnityEngine.UI.Text textPrava;
	public int scenar = 0;
	public int[] scenare = {0,1,2};

	public GameObject syr;
    public float pozX;
    public float pozY;
    public float defaultX;
    public float defaultY;
    public int zobrazX;
	public int zobrazY;
	public Vector2 aPosition1 = new Vector2(0,0);
	public UnityEngine.UI.Slider horni;
	public UnityEngine.UI.Slider prava;
	public GameObject ButtonZnovu;

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
	
	// Use this for initialization
	void Start () {
		reshuffleint(scenare);
		inicializace();
        defaultX = this.transform.position.x;
        defaultY = this.transform.position.y;

        pozX = defaultX;
        pozY = defaultY;

	}
	public void inicializace(){
		if(scenare[scenar]==0){
			syr.transform.localPosition = new Vector3(-1.484f, 5.539f,0);
			vert1.transform.localPosition = new Vector3(-4.565f, 1.74f,0);
			vert2.transform.localPosition = new Vector3(-4.565f, 2.362f,0);
			vert3.transform.localPosition = new Vector3(-4.565f, 2.89f,0);
			vert4.transform.localPosition = new Vector3(-4.565f, 4.54f,0);
			vert5.transform.localPosition = new Vector3(-4.565f, 4.65f,0);
			vert6.transform.localPosition = new Vector3(-2.87f, 5.42f,0);
			vert7.transform.localPosition = new Vector3(-2.87f, 4.91f,0);
			vert8.transform.localPosition = new Vector3(-2.87f, 4.61f,0);
			vert9.transform.localPosition = new Vector3(-1.983f, 3.87f,0);
			vert10.transform.localPosition = new Vector3(-1.983f, 3.42f,0);
			vert11.transform.localPosition = new Vector3(-1.983f, 2.76f,0);
			vert12.transform.localPosition = new Vector3(-3.695f, 2.9f,0);
			vert13.transform.localPosition = new Vector3(-2.84f, 1.78f,0);
			vert14.transform.localPosition = new Vector3(-2.84f, 1.78f,0);

			hor1.transform.localPosition = new Vector3(-4.19f, 5.017f,0);
			hor2.transform.localPosition = new Vector3(-1.48f, 5.017f,0);
			hor3.transform.localPosition = new Vector3(-3.26f, 5.017f,0);
			hor4.transform.localPosition = new Vector3(-2.36f, 4.231f,0);
			hor5.transform.localPosition = new Vector3(-2.843f, 3.28f,0);
			hor6.transform.localPosition = new Vector3(-3.76f, 5.017f,0);
			hor7.transform.localPosition = new Vector3(-3.06f, 4.231f,0);
			hor8.transform.localPosition = new Vector3(-3.37f, 4.231f,0);
			hor9.transform.localPosition = new Vector3(-2.38f, 3.28f,0);
			hor10.transform.localPosition = new Vector3(-3.34f, 3.28f,0);
			hor11.transform.localPosition = new Vector3(-3.34f, 3.28f,0);
			hor12.transform.localPosition = new Vector3(-3.34f, 3.28f,0);

		}
		if(scenare[scenar]==1){
			syr.transform.localPosition = new Vector3(-2.44f, 2.94f,0);
			vert1.transform.localPosition = new Vector3(-4.565f, 1.74f,0);
			vert2.transform.localPosition = new Vector3(-4.565f, 2.362f,0);
			vert3.transform.localPosition = new Vector3(-4.565f, 2.89f,0);
			vert4.transform.localPosition = new Vector3(-2.03f, 2.56f,0);
			vert5.transform.localPosition = new Vector3(-2.87f, 5.42f,0);
			vert6.transform.localPosition = new Vector3(-2.87f, 5.42f,0);
			vert7.transform.localPosition = new Vector3(-2.03f, 2.94f,0);
			vert8.transform.localPosition = new Vector3(-2.87f, 4.68f,0);
			vert9.transform.localPosition = new Vector3(-3.67f, 3.9f,0);
			vert10.transform.localPosition = new Vector3(-3.67f, 3.4f,0);
			vert11.transform.localPosition = new Vector3(-2.84f, 2.5f,0);
			vert12.transform.localPosition = new Vector3(-3.67f, 2.74f,0);
			vert13.transform.localPosition = new Vector3(-2.84f, 1.78f,0);
			vert14.transform.localPosition = new Vector3(-2.84f, 2.91f,0);
			
			hor1.transform.localPosition = new Vector3(-1.48f, 5.017f,0);
			hor2.transform.localPosition = new Vector3(-1.48f, 5.017f,0);
			hor3.transform.localPosition = new Vector3(-1.48f, 5.017f,0);
			hor4.transform.localPosition = new Vector3(-2.51f, 4.31f,0);
			hor5.transform.localPosition = new Vector3(-2.843f, 3.28f,0);
			hor6.transform.localPosition = new Vector3(-4.04f, 5.02f,0);
			hor7.transform.localPosition = new Vector3(-4.685f, 5.02f,0);
			hor8.transform.localPosition = new Vector3(-4.023f, 4.28f,0);
			hor9.transform.localPosition = new Vector3(-2.38f, 3.28f,0);
			hor10.transform.localPosition = new Vector3(-3.31f, 3.28f,0);
			hor11.transform.localPosition = new Vector3(-5.19f, 5.02f,0);
			hor12.transform.localPosition = new Vector3(-4.22f, 4.28f,0);
			
		}

		if(scenare[scenar]==2){
			syr.transform.localPosition = new Vector3(-5.101f, 2.69f,0);
			vert1.transform.localPosition = new Vector3(-4.565f, 3.33f,0);
			vert2.transform.localPosition = new Vector3(-4.565f, 3.918f,0);
			vert3.transform.localPosition = new Vector3(-4.565f, 2.631f,0);
			vert4.transform.localPosition = new Vector3(-2.044f, 2.414f,0);
			vert5.transform.localPosition = new Vector3(-4.5649f, 4.65f,0);
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
			hor3.transform.localPosition = new Vector3(-2.406f, 5.017f,0);
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


	}
	
	// Update is called once per frame
	void Update () {
		aPosition1 = new Vector2(pozX,pozY);

		textHorni.text = ""+zobrazX;
		textPrava.text = ""+zobrazY;

		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition1, 5 * Time.deltaTime);
	}

	public void zmenX(float x){
		pozX = x + defaultX;
		zobrazX = Mathf.FloorToInt(x * 28.58f);
		

	}

	public void zmenY(float y){
		pozY = y + defaultY;
		zobrazY = Mathf.FloorToInt(y * 27.25f);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.name == "Syr")
		{
			syr.SetActive(false);
			bublina5.SetActive(false);
			bublina5konec.SetActive(true);
			ButtonZnovu.SetActive(true);
			ohnostroj.Emit(90);
		}

		
	}
	public void znovu(){
		bublina5.SetActive(true);
		bublina5konec.SetActive(false);
		ButtonZnovu.SetActive(false);
		syr.SetActive(true);
		horni.value = 0;
		prava.value = 0;
		this.transform.localPosition = new Vector3(-5.113998f,1.714f,0);
		if(scenar <= 1){
			scenar++;
		}else{
			scenar = 0;
		}
		inicializace();



        pozX = defaultX;
        pozY = defaultY;

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

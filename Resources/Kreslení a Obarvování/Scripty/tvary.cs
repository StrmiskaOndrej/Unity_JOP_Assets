using UnityEngine;
using System.Collections;

public class tvary : MonoBehaviour 
{

//    public new Renderer renderer;
	public Color barva;
	public GameObject hra;
	public float r;
	public float g;
	public float b;
	public bool hotovo = false;
	public bool inicializovano = false;

	// Use this for initialization
	void Start () 
    {
		inicializace();
		barva = Color.red;

	}

	void inicializace(){
		hra = GameObject.Find("Hra3");
		if(hra != null){
			inicializovano = true;
		}
	}
	void Update () {
		if(inicializovano == false){
			inicializace();
		}
	}

	public void overBarvu(){
		if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "hvezda" && ((r > 200 && g > 200 && b < 35)|| (r > 230 && g > 230 && b < 55))){
			hotovo = true;
		}
		if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "ctverec" && ((r < 35 && g < 50 && b > 170)||(r < 60 && g < 120 && b > 220)||(r < 30 && g < 110 && b > 180)||(r < 50 && g < 50 && b > 170)||(r < 10 && g > 240 && b > 240))){
			hotovo = true;
		}
		if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "obdelnik" && ((r > 90 && g > 50 && r < 150 && g < 90 && b < 20)||(r > 75 && g > 70 && r < 170 && g < 30 && b < 20))){
			hotovo = true;
		}
		if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "kruh" && ((r < 100 && g > 200 && b < 100)||(r < 30 && g > 100 && b < 30)||(r < 55 && g > 150 && b < 55)||(r < 10 && g > 95 && r < 10 ))){
			hotovo = true;
		}
		if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "trojuhelnik" && ((r > 200 && g < 55 && b < 35)||(r > 180 && g < 20 && b < 20)||(r > 120 && g < 1 && b < 1))){
			hotovo = true;
		}

	}
	void OnMouseDown(){
		if(hotovo == false){
			barva = hra.GetComponent<obarvovani_tvaru>().vybranaBarva;
			gameObject.transform.GetComponent<Renderer>().material.color = barva; 
			r = barva.r*255;
			g = barva.g*255;
			b = barva.b*255;
			overBarvu();
		}
	}

	public void zmenNaPuvodni(){
		r = 255;
		g = 255;
		b = 255;
		barva = new Color(r,g,b);
		gameObject.transform.GetComponent<Renderer>().material.color = barva; 

	}

}

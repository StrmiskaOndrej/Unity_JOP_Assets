using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class sporty : MonoBehaviour 
{
	public LineRenderer line;
	public bool isMousePressed;
	public Vector2 mousePos;
	public Vector2 startPos;
	public Vector2 endPos;
	public Material mat;
	public bool start = false;
	public bool vybrano = false;
	public bool konec = false;
	public float vzdalenost;
	public GameObject branka;
	public GameObject like;
	public GameObject small;

	public string SortingLayerName = "Default";
	public int SortingOrder = 2;


	//	-----------------------------------	
	void Awake()
	{
		// Create line renderer component and set its property
		line = gameObject.AddComponent<LineRenderer>();
		line.material =  mat;
		line.positionCount = 0;
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        line.useWorldSpace = true;
        line.startColor = Color.black;
        line.endColor = Color.black;
        isMousePressed = false;
		branka = GameObject.Find(this.name + "_b");
		like = GameObject.Find(this.name + "_l");
		small = GameObject.Find(this.name + "_s");


		gameObject.GetComponent<LineRenderer> ().sortingLayerName = SortingLayerName;
		gameObject.GetComponent<LineRenderer> ().sortingOrder = SortingOrder;

	}

	void OnMouseDown(){
			isMousePressed = true;
	}

	void Update () 
	{

		if(isMousePressed == true){

		if(Input.GetMouseButtonUp(0))
		{

				if(branka.transform.position.x + branka.GetComponent<branka>().xmax > endPos.x && 
				   branka.transform.position.x + branka.GetComponent<branka>().xmin < endPos.x && 
				   branka.transform.position.y + branka.GetComponent<branka>().ymax > endPos.y && 
				   branka.transform.position.y + branka.GetComponent<branka>().ymin < endPos.y){
					konec = true;
				}

			
				start = false;
				isMousePressed = false;
		}
		// Drawing line when mouse is moving(presses)
		if(isMousePressed && konec == false)
		{
			var v3 = Input.mousePosition;
			v3.z = 8.5f;
			v3 = Camera.main.ScreenToWorldPoint(v3);

			mousePos = v3;

			startPos = new Vector2(this.transform.position.x, this.transform.position.y);

			if(start == false){
				start = true;


				line.positionCount = 1;
				line.SetPosition (0, startPos);

			}
				endPos=mousePos;

//			gameObject.transform.position = mousePos;
				small.transform.position = mousePos;
				small.transform.localScale = new Vector3(0.3f,0.3f,0);

			line.positionCount = 2;
				line.SetPosition (1, endPos);

			}	
		}
		if(konec == true){

            like.GetComponent<SpriteRenderer>().enabled = true;
            line.startColor = Color.green;
            line.endColor = Color.green;
            //		line.SetPosition (1, branka.transform.position);
            //		small.transform.position = branka.transform.position;


        }
	}

}
using UnityEngine;
using System.Collections;

public class lajna_nova_s_colliderem : MonoBehaviour {
	public string SortingLayerName = "Default";
	public int SortingOrder = 2;
	public Vector2 mousePos;
	public Vector2 startPos;
	public Vector2 endPos;
	public float vzdalenost;
	public LineRenderer line;
	public bool start = false;
	public bool isPressed;
	public bool konec;
	public BoxCollider col;
	public GameObject hlavniScript;
	public float tloustka;
	// Use this for initialization
	void Start () {
		hlavniScript = GameObject.Find("Kresleni_script");
		gameObject.GetComponent<LineRenderer> ().sortingLayerName = SortingLayerName;
		gameObject.GetComponent<LineRenderer> ().sortingOrder = SortingOrder;
	}
	
	// Update is called once per frame
	void Update () {
		if(!konec){
			var v3 = Input.mousePosition;
			v3.z = 8.5f;
			v3 = Camera.main.ScreenToWorldPoint(v3);
			
			mousePos = v3;
			
			
			if(Input.GetMouseButtonDown(0))
			{
				isPressed = true;
				
				if(start == false){
					start = true;			
					startPos = mousePos;
                    line.positionCount = 1;
					line.SetPosition (0, startPos);				
				}
				
				
			}
			if(Input.GetMouseButtonUp(0)){
				
				start = false;
				isPressed = false;
				konec = true;
				addColliderToLine();
				
			}
			
			if(isPressed == true){
				endPos = mousePos;
				line.positionCount = 2;
				line.SetPosition (1, endPos);
				
			}
			
		}
	}
	
	private void addColliderToLine()
	{
		col = gameObject.AddComponent<BoxCollider> (); // Přidá k objektu komponentu Box Collider
		float lineLength = Vector3.Distance (startPos, endPos); // Zjistí délku čáry
		col.size = new Vector3 (lineLength, tloustka, 1f); // Nastaví velikost Collider
		Vector3 midPoint = (startPos + endPos)/2; // Nastaví střed Collideru
		col.center = new Vector3(0,0,0); 
		col.transform.position = midPoint; // Nastaví pozici Collideru
		// Následující řádky počítají úhel mez prní a poslední pozicí
		float angle = (Mathf.Abs (startPos.y - endPos.y) / Mathf.Abs (startPos.x - endPos.x));
		if((startPos.y<endPos.y && startPos.x>endPos.x) || (endPos.y<startPos.y && endPos.x>startPos.x))
		{
			angle*=-1;
		}
		angle = Mathf.Rad2Deg * Mathf.Atan (angle);
		if(!float.IsNaN(angle)){
			col.transform.Rotate (0, 0, angle);
		}
	}
	void OnMouseDown(){
		if(hlavniScript.GetComponent<kresleni_script>().gumaZapnuta){
			Destroy (this.gameObject);
		}
		
	}

}

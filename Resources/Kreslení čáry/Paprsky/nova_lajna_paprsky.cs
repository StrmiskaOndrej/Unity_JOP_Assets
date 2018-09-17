using UnityEngine;
using System.Collections;

public class nova_lajna_paprsky : MonoBehaviour {
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
	public GameObject paprsky;
	public float tloustka;
    public bool pS;
    public bool pD;
    public GameObject Hra6;
    public Color barvaSlunce;
    public Color barvaMraku;

    public Texture2D caraZlutaKurzor;
    public Texture2D caraModraKurzor;
    public Texture2D caraTmaveModraKurzor;

    public CursorMode cursorMode = CursorMode.Auto;
    // Use this for initialization
    void Start () {
        paprsky = GameObject.Find("Paprsky");
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

        if (lineLength < 0.05f)
        {
            lineLength = 0.05f;
        }
        if (tloustka < 0.06)
        {
            tloustka = 0.06f;
        }

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
	void OnMouseOver(){
        paprsky.GetComponent<paprsky>().naLajne = true;
        if (pS)
        {
            Cursor.SetCursor(caraZlutaKurzor, Vector2.zero, cursorMode);
        }
        else if (pD)
        {
            Cursor.SetCursor(caraTmaveModraKurzor, Vector2.zero, cursorMode);
        }
        else
        {
            Cursor.SetCursor(caraModraKurzor, Vector2.zero, cursorMode);
        }

    }
    void OnMouseExit()
    {
        paprsky.GetComponent<paprsky>().naLajne = false;

    }

    void OnMouseDown()
    {
        if (pS) {
            paprsky.GetComponent<paprsky>().zmenBarvu(barvaSlunce);
            paprsky.GetComponent<paprsky>().nastavPaprsek(1);

        } else if (pD) {
            paprsky.GetComponent<paprsky>().zmenBarvu(barvaMraku);
            paprsky.GetComponent<paprsky>().nastavPaprsek(2);
        }

    }

}

using UnityEngine;
using System.Collections;

public class paprsky_obloha : MonoBehaviour {
	public GameObject Hra6;
	public Color barva;
	public bool slunce;

	public CursorMode cursorMode = CursorMode.Auto;
	public CursorMode force = CursorMode.ForceSoftware;
	
	public Texture2D caraZlutaKurzor;
	public Texture2D caraModraKurzor;
	public Texture2D caraTmaveModraKurzor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		if(Hra6.activeInHierarchy && !Hra6.GetComponent<paprsky>().naLajne)
        {
			Hra6.GetComponent<paprsky>().zmenBarvu(barva);

            if (slunce)
            {
                Hra6.GetComponent<paprsky>().nastavPaprsek(1);
            }
            else {
                Hra6.GetComponent<paprsky>().nastavPaprsek(2);
            }

		}
	}
	void OnMouseOver() {
        if (Hra6.activeInHierarchy && !Hra6.GetComponent<paprsky>().naLajne)
        {
            if (slunce){
			Cursor.SetCursor(caraZlutaKurzor, Vector2.zero, cursorMode);
		}else{
			Cursor.SetCursor(caraTmaveModraKurzor, Vector2.zero, cursorMode);
		}

	}
    }
    void OnMouseExit(){
        if (Hra6.activeInHierarchy)
        {
            Cursor.SetCursor(caraModraKurzor, Vector2.zero, cursorMode);
        }
	}
}

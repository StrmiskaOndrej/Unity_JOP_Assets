using UnityEngine;
using System.Collections;

public class kreslime_collider : MonoBehaviour {
	public BoxCollider2D col;
	public Vector2 startPos;
	public Vector2 endPos;
	public GameObject hlavniScript;
	public float tloustka;
	// Use this for initialization
	void Start () {
		hlavniScript = GameObject.Find("Kresleni_script");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addColliderToLine()
	{
		col = gameObject.AddComponent<BoxCollider2D> ();
		float lineLength = Vector3.Distance (startPos, endPos); // length of line
		if(lineLength < 0.05f){
			lineLength = 0.05f;
		}
		if(tloustka < 0.06){
			tloustka = 0.06f;
		}
		col.size = new Vector3 (lineLength, tloustka, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
		Vector3 midPoint = (startPos + endPos)/2;
		//col.center = new Vector2(0,0);
		col.transform.position = midPoint; // setting position of collider object
		// Following lines calculate the angle between startPos and endPos
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
		if(hlavniScript!=null){
			if(hlavniScript.GetComponent<kresleni_script>().gumaZapnuta){
				Destroy (transform.parent.gameObject);
			}
		}
	}
}

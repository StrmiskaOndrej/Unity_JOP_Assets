using UnityEngine;
using System.Collections;

public class lajna_nova_tahem: MonoBehaviour {
	public string SortingLayerName = "Default";
	public int SortingOrder = 2;
	public Vector2 mousePos;
	public Vector2 startPos;
	public Vector2 endPos;
	public LineRenderer line;
	public bool konec;


	// Use this for initialization
	void Start () {
		gameObject.GetComponent<LineRenderer> ().sortingLayerName = SortingLayerName;
		gameObject.GetComponent<LineRenderer> ().sortingOrder = SortingOrder;
//		line = this.gameObject<LineRenderer>();

	
	}
	
	// Update is called once per frame
	void Update () {

		}





}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KreslimeLajnu_s_colliderem : MonoBehaviour {
	public string SortingLayerName = "Default";
	public int SortingOrder = 2;
	public Vector2 startPos;
	public Vector2 endPos;
	public LineRenderer line;
	public bool konec;
//	private List<Vector2> pointsList;
	public GameObject colliderToSpawn;
	public GameObject objekt;
	
	
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

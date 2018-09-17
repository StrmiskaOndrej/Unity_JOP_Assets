using UnityEngine;
using System.Collections;

public class kolej : MonoBehaviour {
	public string SortingLayerName = "Default";
	public int SortingOrder = 2;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<LineRenderer> ().sortingLayerName = SortingLayerName;
		gameObject.GetComponent<LineRenderer> ().sortingOrder = SortingOrder;	
	}
	
	// Update is called once per frame
	void Update () {

	}
}

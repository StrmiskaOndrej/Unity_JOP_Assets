using UnityEngine;
using System.Collections;

public class line_vrstva : MonoBehaviour {
	public string SortingLayerName = "Default";
	public int SortingOrder = 2;
	
	void Awake ()
	{
		gameObject.GetComponent<LineRenderer> ().sortingLayerName = SortingLayerName;
		gameObject.GetComponent<LineRenderer> ().sortingOrder = SortingOrder;
	}
}

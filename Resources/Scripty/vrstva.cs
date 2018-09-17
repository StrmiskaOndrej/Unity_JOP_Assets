using UnityEngine;
using System.Collections;

public class vrstva : MonoBehaviour {
	public string SortingLayerName = "Default";
	public int SortingOrder = 2;
	
	void Awake ()
	{
		gameObject.GetComponent<MeshRenderer> ().sortingLayerName = SortingLayerName;
		gameObject.GetComponent<MeshRenderer> ().sortingOrder = SortingOrder;
	}
}

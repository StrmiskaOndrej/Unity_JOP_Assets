using UnityEngine;
using System.Collections;

public class slovoNaZvire : MonoBehaviour {
	public string spatneSlovo;
	public string spravneSlovo;
	public string spravneSlovoV2;
	public float yPozice;
	public GameObject hra4;
	public int id;
	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnMouseDown() {
	if(transform.localPosition.y > yPozice && hra4.activeInHierarchy){
			hra4.GetComponent<zmenNaZvire>().aktivuj(id);
		}
	}
}

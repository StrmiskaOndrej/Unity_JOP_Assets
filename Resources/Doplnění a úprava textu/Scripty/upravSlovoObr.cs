using UnityEngine;
using System.Collections;

public class upravSlovoObr : MonoBehaviour {
	public string SpravneSlovo;
	public string SpatneSlovo;
	public UnityEngine.UI.InputField iF;
	public int poradi;
	public GameObject upravSlovo;

	// Use this for initialization
	void Start () {
		upravSlovo = GameObject.Find("Hra3");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void nastavCisloPole(){
		if(upravSlovo!=null){
			upravSlovo.GetComponent<upravSlovo>().nastavI(poradi);

		}
	}
}

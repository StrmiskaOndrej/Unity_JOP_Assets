using UnityEngine;
using System.Collections;

public class OtaceciPuzzle : MonoBehaviour {

	// Use this for initialization
	public bool end = true;
	public GameObject tedy;
	Kontrola_puzzle kp;
	void Start () {
	kp = (Kontrola_puzzle)tedy.gameObject.GetComponent(typeof(Kontrola_puzzle));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		
		this.transform.Rotate(0,0,90);
		if(this.transform.rotation.z != 0)
		{
		end = true;
		
		}
		else
		{
		end = false;
		}
		kp.Kontroluj();
	}

	public bool End {
		get {
			return this.end;
		}
		set {
			end = value;
		}
	}
}

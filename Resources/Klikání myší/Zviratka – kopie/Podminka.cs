using UnityEngine;
using System.Collections;

public class Podminka : MonoBehaviour {

	// Use this for initialization
     SpriteRenderer  objekt2;
	Vector3 puvodni_pozice;
	public GameObject obj1,obj2;
	void Start () {
//	objekt1 = (SpriteRenderer)this.GetComponent(typeof(SpriteRenderer));
	objekt2 = (SpriteRenderer)obj2.GetComponent(typeof(SpriteRenderer));
	puvodni_pozice = this.gameObject.transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public bool KontrolaPostupu()
	{
		if(objekt2.enabled == false)
		{
			this.transform.position = puvodni_pozice;
			return false;
		}
		else
		{
			return true;
		}
	}
}

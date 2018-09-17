using UnityEngine;
using System.Collections;

public class small_obj : MonoBehaviour {

	public GameObject obj;
	public GameObject branka;
	public BoxCollider2D kol;

	// Use this for initialization
	void Start () {
		obj = this.transform.parent.gameObject;
		branka = GameObject.Find(obj.name + "_b");




	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if(obj.GetComponent<sporty>() != null){
			obj.GetComponent<sporty>().start = true;
			obj.GetComponent<sporty>().isMousePressed = true;
		}
	}
//	void OnCollisionEnter2D (Collision2D col)
//	{
//		if(col.gameObject == branka)
//		{
//
//			kol.isTrigger = true;
//			obj.GetComponent<sporty>().konec = true;
//			obj.GetComponent<sporty>().start = false;
//			obj.GetComponent<sporty>().isMousePressed = false;
//
//		}
//
//		
//		
//	}
}

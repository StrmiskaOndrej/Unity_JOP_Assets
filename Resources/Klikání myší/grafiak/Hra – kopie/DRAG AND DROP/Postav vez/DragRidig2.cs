using UnityEngine;
using System.Collections;

public class DragRidig2 : MonoBehaviour {

	// Use this for initialization
	
	Vector3 screenPoint;
	Vector3 offset;
	Vector3 curScreenPoint;
	Vector3 curPosition;
    public GameObject spojeni;
	public SpringJoint sp;
	void Start () {
		spojeni = new GameObject();
	spojeni.AddComponent(typeof(Rigidbody));
	spojeni.gameObject.AddComponent(typeof(SpringJoint));
	spojeni.GetComponent<Rigidbody>().isKinematic = true;
	}
	
	
	void OnMouseDown () 
	{
		sp = (SpringJoint)spojeni.gameObject.GetComponent(typeof(SpringJoint));
		
		spojeni.transform.position = this.transform.position;
		sp.connectedBody = this.GetComponent<Rigidbody>();	
		this.GetComponent<Rigidbody>().drag = 10;
		sp.spring = 50;
		screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
		offset = this.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		/*
		Ray laser = new Ray();
		laser =	Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit myhit = new RaycastHit();
		if(Physics.Raycast(laser,out myhit))
		{
		
		
		}
		*/
	}
	
	void OnMouseDrag()
	{
	curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
    spojeni.transform.position = curPosition;	
		
	}
	
	void OnMouseUp()
	{
	sp.connectedBody = null;
		this.GetComponent<Rigidbody>().drag = 0;
	
		
	}
    // Update is called once per frame
    void Update(){
    }
}

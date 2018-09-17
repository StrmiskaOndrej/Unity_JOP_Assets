using UnityEngine;
using System.Collections;

public class DragDrop : MonoBehaviour {

	Vector3 screenPoint;
	Vector3 offset;
	Vector3 curScreenPoint;
	Vector3 curPosition;
	public float ZPozition;
	void Start()
	{
		
	}
	void OnMouseDown () 
	{
		if(this.enabled == true)
		{
		screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
		offset = this.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		}
			/*
		 * 
		Ray laser = new Ray();
		laser =	Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit myhit = new RaycastHit();
		if(Physics.Raycast(laser,out myhit))
		{
		Texture2D tex = (Texture2D)this.transform.gameObject.renderer.material.mainTexture;
		Color col = new Color(); 
		col.a =	(int)tex.GetPixel((int)myhit.textureCoord2.x, (int)myhit.textureCoord2.y).a;
		if(col.a > 0)
			{
			
			}
		}
		*/
	}
	
	void OnMouseDrag()
	{
		if(this.enabled == true)
		{
	curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
    transform.position = curPosition;
		}
		
	}



}

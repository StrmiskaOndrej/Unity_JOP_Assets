
using System.Collections;
using UnityEngine;

class drag_and_drop : MonoBehaviour
{

    Vector3 startPos;
//    public GameObject bublina;

	Vector3 screenPoint;
	Vector3 offset;
	Vector3 curScreenPoint;
	Vector3 curPosition;

    void Start()
    {
        startPos = transform.position;
    }

    public void Return()                //navrat na misto kde zacinal
    {
        transform.position = startPos;
//        bublina.SetActive(false);
    }

	void OnMouseDown () 
	{
		if(this.enabled == true)
		{
			screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
			offset = this.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		}
	}
   
//    void OnMouseDrag()                  //když táhnu myší tak počítá kam táhnu a bez zmeny z- souradnice hybe objektem
//    {
////        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
////        point.z = gameObject.transform.position.z;
////        gameObject.transform.position = point;
//
//
//
//
////		var v3 = Input.mousePosition;
////		v3.z = 7.7410f;
////		v3 = Camera.main.ScreenToWorldPoint(v3);
////		
////		transform.position = v3;
//
//        bublina.SetActive(true);
//    }

	void OnMouseDrag()
	{
		if(this.enabled == true)
		{
			curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = curPosition;
//			bublina.SetActive(true);
		}
		
	}
}

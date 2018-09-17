using UnityEngine;
using System.Collections;

public class channgeCursor : MonoBehaviour {

	// Use this for initialization
	public Cursor cur;
	public Texture2D texHand;
	public Texture2D texArrow;
//	Vector2 vect;
//	CursorMode cm;
	void Start () {

	}
	
	void OnMouseOver()
	{
//		Cursor.SetCursor(texHand, vect,CursorMode.Auto);
	}
	void OnMouseExit()
	{
//		Cursor.SetCursor(texArrow, vect,CursorMode.Auto);
	}
	// Update is called once per frame
	void Update () {
	
	}
}

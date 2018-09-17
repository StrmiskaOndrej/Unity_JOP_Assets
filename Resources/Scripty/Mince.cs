using UnityEngine;
using System.Collections;

public class Mince : MonoBehaviour {

	// Use this for initialization
	int mince;

	public TextMesh text3D;
//	GUITexture clone; 
	bool anim = false;
	float cas = 2.5f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(anim == true && cas > 0)
		{
			Animace();
			cas = cas - Time.deltaTime;
		}
		
		
//	textMince.text = getMince().ToString();	
	text3D.text = getMince().ToString();	
	}
	
	void Animace()
	{
	//clone.transform.Translate(new Vector3(-0.02f,0.02f,0));

	}
	public void setMince(int min)
	{
		
		//clone = (GUITexture)Instantiate(tex,tex.transform.position,tex.transform.rotation);
		
		if(min > getMince())
		{
		anim = true;
		cas = 2.5f;
		//clone.enabled = true;
		}
//		Destroy(clone,3);
		mince = min;
	}
	public int getMince()
	{
		return mince;
	}
	
	void OnGUI()
	{
		//GUI.skin = skin;
		
		//GUI.Label (new Rect (Screen.width / 35,Screen.height / 35,120,60),"     " + getMince());
	}
}

using UnityEngine;
using System.Collections;

public class mrkev_small : MonoBehaviour {
	
	public GameObject mrkev;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		mrkev.GetComponent<mrkev>().start = true;
		mrkev.GetComponent<mrkev>().pokracovani = true;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "Wall")
		{

			mrkev.GetComponent<mrkev>().kolize = true;
            mrkev.GetComponent<mrkev>().line.startColor = Color.red;
            mrkev.GetComponent<mrkev>().line.endColor = Color.red;
        }
		if(col.gameObject.name == "kralik")
		{
			if(!mrkev.GetComponent<mrkev>().kolize){
				mrkev.GetComponent<mrkev>().kolizeKralik = true;
				mrkev.GetComponent<mrkev>().konec = true;
                mrkev.GetComponent<mrkev>().line.startColor = Color.green;
                mrkev.GetComponent<mrkev>().line.endColor = Color.green;
            }
		}
		
		
	}
}

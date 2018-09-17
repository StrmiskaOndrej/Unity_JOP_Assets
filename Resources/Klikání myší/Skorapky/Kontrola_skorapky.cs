using UnityEngine;
using System.Collections;

public class Kontrola_skorapky : MonoBehaviour {

	// Use this for initialization
	public TextMesh texty;
	public ParticleSystem ohnostroj;
	public GameObject bublina1, bublinaOK, bublinaMezi;
    public Sprite happyTedy;
    public int podminka;
	bool konec = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	int i = (int)int.Parse(texty.text);
	if(i == podminka && konec == false)
		{
			konec = true;
			ohnostroj.Emit(90);
			bublina1.SetActive(false);
            bublinaMezi.SetActive(false);
			bublinaOK.SetActive(true);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = happyTedy;
        }	
		
	}
}

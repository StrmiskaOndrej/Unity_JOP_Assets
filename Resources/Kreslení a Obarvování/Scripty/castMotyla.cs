using UnityEngine;
using System.Collections;

public class castMotyla : MonoBehaviour {
	public GameObject script;
	public string potrebnaBarva;
	public bool barvaOK;
	public bool dira = false;
	public GameObject spojenyObjekt;

	// Use this for initialization
	void Start () {
		inicializace();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void inicializace(){
		if(potrebnaBarva == "bila"){
			barvaOK = true;
		}
		if(spojenyObjekt == null){
			dira = true;
		}

	}

	void OnMouseDown(){
		if(script.GetComponent<motyl_script>().kbelik){
			this.GetComponent<SpriteRenderer>().color = script.GetComponent<motyl_script>().vybranaBarva;

			nastavStringBarvu(script.GetComponent<motyl_script>().barvaNazev);

			if(!dira){
				spojenyObjekt.GetComponent<SpriteRenderer>().color = script.GetComponent<motyl_script>().vybranaBarva;
				spojenyObjekt.GetComponent<castMotyla>().nastavStringBarvu(script.GetComponent<motyl_script>().barvaNazev);

			}

		}

	}
	public void nastavStringBarvu(string bar){
		if(bar.Equals(potrebnaBarva)){
			barvaOK = true;
		}else{
			barvaOK = false;
		}

	}
}

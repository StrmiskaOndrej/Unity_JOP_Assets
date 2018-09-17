using UnityEngine;
using System.Collections;
using System.Linq;

public class zmenNaZvire : MonoBehaviour {
	public UnityEngine.UI.InputField iF;
	public GameObject inputfield;
	public UnityEngine.UI.Text vyhodnoceni ;
	public GameObject[] seznamSlov;
	public int zbyva = 8;
	public bool  firework = false;
	public ParticleSystem ohnostroj;
	public int aktivniSlovo;
	public GameObject BublinaStart;
	public GameObject BublinaSpravne;
	public GameObject BublinaKonec;
	public GameObject BublinaZbyva;
	public GameObject buttonZnovu;
	public float myTimer = 1.5f;
	public bool odpocet;



	// Use this for initialization
	void Start () {
		seznamSlov = GameObject.FindGameObjectsWithTag("slovoNaZvire").OrderBy( go => go.name ).ToArray();
		odsun ();
	}
	
	// Update is called once per frame
	void Update () {
		if(odpocet){
			if(myTimer > 0){
				myTimer -= Time.deltaTime;
			}else{
				BublinaSpravne.SetActive(false);
				BublinaZbyva.SetActive(true);
				vyhodnoceni.text = ""+zbyva;
				odpocet = false;
				myTimer = 1.5f;
			}
		}
	}

	public void aktivuj(int slovo){
		prisun();
		iF.text = seznamSlov[slovo].GetComponent<slovoNaZvire>().spatneSlovo;
		aktivniSlovo = slovo;

	}

	public void iField(string str){
		if(iF.text == seznamSlov[aktivniSlovo].GetComponent<slovoNaZvire>().spravneSlovo || iF.text == seznamSlov[aktivniSlovo].GetComponent<slovoNaZvire>().spravneSlovoV2){
			//seznamSlov[aktivniSlovo].GetComponent<Rigidbody2D>().freezeRotation = false;
			seznamSlov[aktivniSlovo].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

			zbyva--;
			BublinaStart.SetActive(false);
			BublinaZbyva.SetActive(false);
			iF.text = "";
			odsun ();
			vyhodnoceni.text = "";
				
			if(zbyva ==0){
				BublinaZbyva.SetActive(false);
				BublinaKonec.SetActive(true);					
				buttonZnovu.SetActive(true);

				if(firework==false){
					ohnostroj.Emit(90);
					firework=true;
				}
			}else{
				BublinaSpravne.SetActive(true);
				odpocet = true;

				}
		}
	}

	public void znovu(){
		BublinaKonec.SetActive(false);
		BublinaStart.SetActive(true);
		zbyva = 8;
		firework=false;
		myTimer = 1.5f;
		buttonZnovu.SetActive(false);
		for(int i = 0;i<seznamSlov.Length;i++){
			seznamSlov[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
			seznamSlov[i].transform.localEulerAngles = new Vector3(0,0,0);

		}
		seznamSlov[0].transform.localPosition = new Vector2(4.76f,0.74f);
		seznamSlov[1].transform.localPosition = new Vector2(7.42f,0.96f);
		seznamSlov[2].transform.localPosition = new Vector2(9.039f,0.75f);
		seznamSlov[3].transform.localPosition = new Vector2(8.14f,-0.935f);
		seznamSlov[4].transform.localPosition = new Vector2(6.09f,-0.59f);
		seznamSlov[5].transform.localPosition = new Vector2(5.45f,-1.62f);
		seznamSlov[6].transform.localPosition = new Vector2(3.64f,-0.31f);
		seznamSlov[7].transform.localPosition = new Vector2(7.1f,-2.35f);

	}
	void odsun(){
		inputfield.transform.localPosition = new Vector2(-15, 900);
		iF.enabled = false;
		iF.DeactivateInputField();
	}	
	
	void prisun(){
		inputfield.transform.localPosition = new Vector2(-15, 209);
		iF.enabled = true;		
		iF.Select();
	}	

}

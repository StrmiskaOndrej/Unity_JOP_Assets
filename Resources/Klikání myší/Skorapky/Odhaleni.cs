using UnityEngine;
using System.Collections;

public class Odhaleni : MonoBehaviour {

	// Use this for initialization
	
	
	public bool touch;
	public int body;
	Michani michacka;
	public GameObject skorapky;
	public ParticleSystem ohnostroj;
	GameObject minobj;
	public GameObject NexPozition;
    public TextMesh text3D;
    public int spravne;
    public GameObject bublina1, bublinaMezi;
    public bool odpocet;
    public float cas;
	public int pocet;
	
	public GameObject svicen2;
	//svicen sv;	
	
	void Start () {
	michacka = (Michani)skorapky.GetComponent(typeof(Michani));
		
	minobj = GameObject.FindGameObjectWithTag("Mince");

	pocet = michacka.GetPocet();
			
 	
		
	}

    // Update is called once per frame
    void Update() {
        if (odpocet) {
            if (cas > 0)
            {
                cas = cas - Time.deltaTime;
            }
            else {
                odpocet = false;
                touch = false;
                bublinaMezi.SetActive(false);
            }
        }

        PridavejSkorapky();

        if (touch == true && michacka.GetPocet() < 0 && !odpocet && michacka.spusteno)
		{

            michacka.SetPocet(pocet++);
			
			this.GetComponent<AudioSource>().Play();
			this.GetComponent<Animation>().Play();
            bublina1.SetActive(false);
            bublinaMezi.SetActive(true);
            spravne++;
            cas = 1f;
            odpocet = true;



        }
		else
		{
			
			touch = false;

        }
        text3D.text = "" + spravne;
    }
	
	void PridavejSkorapky()
	{
		if(michacka.GetPocet() > 3)
		{
			michacka.PocetKorabek = 3;
			
		}
		
		
	}
	
	
	void OnMouseDown()
	{
		//this.animation.Play("Ukaz");
		touch = true;

		
	}
}

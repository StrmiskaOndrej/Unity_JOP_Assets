using UnityEngine;
using System.Collections;

public class AllAsigned : MonoBehaviour {

    public bool[] slot = new bool[6] { false, false, false, false, false, false };
    public GameObject button;
    public int zbyva = 6;
    public bool konec;
    public GameObject bublinaStart;
    public GameObject bublinaOprava;
    public GameObject bublinaKonec;

    public bool firework = false;
    public ParticleSystem ohnostroj;

    public void AllFull(int[] par)
    {
        if(par[1] == 1)
            slot[par[0]] = true;
        else
            slot[par[0]] = false;
    }

    void Update()
    {
        if (slot[0] && slot[1] && slot[2] && slot[3] && slot[4] && slot[5] && !konec)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }

    public void vyhodnot() {
        bublinaStart.SetActive(false);
        button.SetActive(false);
        bublinaOprava.SetActive(false);
        if (zbyva == 0)
        {
            konec = true;           
            bublinaKonec.SetActive(true);
            ohnostroj.Emit(90);
        }
        else {
            bublinaOprava.SetActive(true);
        }
    }

    public void nastavVyhozi() {
        zbyva = 6;
    }
}

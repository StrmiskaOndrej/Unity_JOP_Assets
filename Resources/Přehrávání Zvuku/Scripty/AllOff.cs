using UnityEngine;
using System.Collections;

public class AllOff : MonoBehaviour
{

    public GameObject[] fajfky;

    //Vypne všechny fajfky a křížky

    public void Reset()
    {
        for (int i = 0; i < fajfky.Length; i++)
        {
            fajfky[i].SetActive(false);
        }
    }
}

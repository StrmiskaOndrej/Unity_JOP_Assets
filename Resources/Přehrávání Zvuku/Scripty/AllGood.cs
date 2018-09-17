using UnityEngine;
using System.Collections;

public class AllGood : MonoBehaviour
{
    //Sbírá informace ze šesti míst kam se přetahují věci, pokud jsou všechny true tak je hra dokončená


    //public ParticleSystem firework;
    public bool[] nas = new bool[6] { false, false, false, false, false, false };
    bool check;

    public void AddGood(int number)
    {
        nas[number] = true;
        if (nas[0] && nas[1] && nas[2] && nas[3] && nas[4] && nas[5] && check)
        {
            //firework.Play();
        }
    }

    public void Check()
    {
        check = true;
        if (nas[0] && nas[1] && nas[2] && nas[3] && nas[4] && nas[5] && check)
        {
            //firework.Play();
        }
    }
}

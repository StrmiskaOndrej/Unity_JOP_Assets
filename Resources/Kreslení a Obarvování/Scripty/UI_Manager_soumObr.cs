using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager_soumObr : MonoBehaviour {
    public UnityEngine.UI.Text tlacitkoText;

    public void zrusVAnimatorovi(Animator anim)
    {
        anim.SetBool("Zobrazeno", false);
    }

    public void povolVAnimatorovi(Animator anim)
    {
        anim.SetBool("Zobrazeno", true);
    }

    public void zmenVAnimatorovi(Animator anim)
    {
        if (anim.GetBool("Zobrazeno"))
        {
            tlacitkoText.text = "Příklady souměrných obrázků";
            anim.SetBool("Zobrazeno", false);

        }
        else
        {
            tlacitkoText.text = "Skrýt";
            anim.SetBool("Zobrazeno", true);
        }
    }
}
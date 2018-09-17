using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {
	public bool reseni;
	public bool napoveda;
	public GameObject pomocneBody;

	public UnityEngine.UI.Text tlacitkoText;
	
	public void zrusVAnimatorovi(Animator anim){
		anim.SetBool("Zobrazeno", false);
	}
	
	public void povolVAnimatorovi(Animator anim){
		anim.SetBool("Zobrazeno", true);
	}
	
	public void zmenVAnimatorovi(Animator anim){
		if(anim.GetBool("Zobrazeno")){
			if(reseni){
				tlacitkoText.text = "Zobrazit řešení";
			}else if(napoveda){
				tlacitkoText.text = "Zobrazit Nápovědu";
				pomocneBody.SetActive(false);
			}
			anim.SetBool("Zobrazeno", false);
			
		}else{
			if(reseni){
				tlacitkoText.text = "Skrýt řešení";
			}else if(napoveda){
				tlacitkoText.text = "Skrýt Nápovědu";
				pomocneBody.SetActive(true);
			}
			anim.SetBool("Zobrazeno", true);
		}
	}
}

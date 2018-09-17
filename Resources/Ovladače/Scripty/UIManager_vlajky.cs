using UnityEngine;
using System.Collections;

public class UIManager_vlajky : MonoBehaviour {
	public UnityEngine.UI.Text tlacitkoText;
	
	public void zrusVAnimatorovi(Animator anim){
		anim.SetBool("Zobrazeno", false);
	}
	
	public void povolVAnimatorovi(Animator anim){
		anim.SetBool("Zobrazeno", true);
	}
	
	public void zmenVAnimatorovi(Animator anim){
		if(anim.GetBool("Zobrazeno")){
			tlacitkoText.text = "Zobrazit Tahák";
			anim.SetBool("Zobrazeno", false);
			
		}else{
			tlacitkoText.text = "Skrýt Tahák";
			anim.SetBool("Zobrazeno", true);
		}
	}
}

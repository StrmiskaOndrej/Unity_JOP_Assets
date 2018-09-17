using UnityEngine;
using System.Collections;

public class Brnknuti : MonoBehaviour {

    //Struna u kytary

    AudioSource struna;
    SpriteRenderer obrazek;
    public Sprite[] strunaSprite;

    void Start()
    {
        struna = GetComponent<AudioSource>();
        obrazek = GetComponent<SpriteRenderer>();
    }

    void OnMouseEnter()         //zahrani
    {
        struna.Play();
    }
    void OnMouseOver () {       //zmena na cerveny
        obrazek.sprite = strunaSprite[1];
    }
    void OnMouseExit()          //zpatky na zluty
    {
        obrazek.sprite = strunaSprite[0];
    }



}

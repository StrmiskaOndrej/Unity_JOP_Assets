using UnityEngine;
using System.Collections;

public class colision : MonoBehaviour
{

    public string nameObj;
    bool isGood = false;
    GameObject otherObj;
    public GameObject fajfka;
    public GameObject krizek;
    public int[] parameters = new int[2] { 0, 0 };
    public GameObject bus;

    public bool isMoveable = false;
    public int countObjects = 0;



    public void Reset()
    {
        otherObj = null;
        isGood = false;
    }


    void Update()
    {
        if (otherObj != null)
            parameters[1] = 1;
        else
            parameters[1] = 0;

    //    bus.SendMessage("AllFull", parameters);
        bus.GetComponent<AllAsigned>().AllFull(parameters);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        countObjects++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        countObjects--;
        //otherObj = null;
    }

    void OnTriggerStay2D(Collider2D other)                          //když se ocitne v collideru něco s colliderem podá zprávu
    {
        if (!Input.GetMouseButton(0))                               //když pustíme myš tak začne kontrolovat 
        {
            otherObj = other.gameObject;
            if (countObjects < 2)
            {
                if (!isMoveable)                                        //prichyti ho aby se nehybal a byl uprostred (neplati u kostek)
                    otherObj.transform.position = transform.position;
                if (otherObj.name == nameObj)                   //jestli je objekt spravne
                {
                    isGood = true;
     //               bus.SendMessage("AddGood", parameters[0]);
                }
                else
                {
                    isGood = false;
                }
            }
            else
            {
                otherObj.GetComponent<drag_and_drop>().Return();
            }
        }
        if (other == null)
            otherObj = null;
    }

    public void Vyhodnoceni()                                       //byhodnoceni a navrat spatnych obrazku
    {
        if (otherObj != null)
        {
            if (!isGood)
            {
                otherObj.GetComponent<drag_and_drop>().Return();
                krizek.SetActive(true);
                fajfka.SetActive(false);
                Reset();
            }
            else
            {
                bus.GetComponent<AllAsigned>().zbyva--;
                fajfka.SetActive(true);
                krizek.SetActive(false);
            }
        }
        bus.GetComponent<AllAsigned>().vyhodnot();
    }
}

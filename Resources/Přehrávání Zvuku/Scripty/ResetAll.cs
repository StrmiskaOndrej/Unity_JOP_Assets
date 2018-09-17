using UnityEngine;
using System.Collections;

public class ResetAll : MonoBehaviour
{

        public GameObject[] slots1;
        public GameObject[] instruments1;
        public GameObject[] fajfky1;

    public GameObject[] slots2;
    public GameObject[] instruments2;
    public GameObject[] fajfky2;

    public GameObject[] slots3;
    public GameObject[] instruments3;
    public GameObject[] fajfky3;

    public GameObject[] slots4;
    public GameObject[] instruments4;
    public GameObject[] fajfky4;

    public int cameraPosition = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void Reset()
    {
        switch (cameraPosition)
        {
            case 2:
                for (int i = 0; i < slots1.Length; i++)
                {
                    slots1[i].SendMessage("Reset");
                }
                for (int i = 0; i < instruments1.Length; i++)
                {
                    instruments1[i].SendMessage("Return");
                }
                for (int i = 0; i < fajfky1.Length; i++)
                {
                    fajfky1[i].SetActive(false);
                }
                break;
            case 3:
                for (int i = 0; i < slots2.Length; i++)
                {
                    slots2[i].SendMessage("Reset");
                }
                for (int i = 0; i < instruments2.Length; i++)
                {
                    instruments2[i].SendMessage("Return");
                }
                for (int i = 0; i < fajfky2.Length; i++)
                {
                    fajfky2[i].SetActive(false);
                }
                break;
            case 4:
                for (int i = 0; i < slots4.Length; i++)
                {
                    slots4[i].SendMessage("Reset");
                }
                for (int i = 0; i < instruments4.Length; i++)
                {
                    instruments4[i].SendMessage("Return");
                }
                for (int i = 0; i < fajfky4.Length; i++)
                {
                    fajfky4[i].SetActive(false);
                }
                break;
            case 5:
                for (int i = 0; i < slots3.Length; i++)
                {
                    slots3[i].SendMessage("Reset");
                }
                for (int i = 0; i < instruments3.Length; i++)
                {
                    instruments3[i].SendMessage("Return");
                }
                for (int i = 0; i < fajfky3.Length; i++)
                {
                    fajfky3[i].SetActive(false);
                }
                break;
            default:
                break;
        }
    }
}

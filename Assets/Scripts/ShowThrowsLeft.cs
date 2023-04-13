using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowThrowsLeft : MonoBehaviour
{
    private GameObject TimePassed;
    private Text TimePassedText;
    private float TimePassedTime;
    private int godziny, minuty, sekundy, tempSek, ilosc_podzielna = 60;
    private string wynikCzasu;

    private GameObject ThrowLeft;
    private Text ThrowLeftText;
    private int ThrowsLeft, tempSize;

    void Awake()
    {
        TimePassed = GameObject.Find("GameTimePassed");
        TimePassedText = TimePassed.GetComponent<Text>();

        ThrowLeft = GameObject.Find("ThrowsLeft");
        ThrowLeftText = ThrowLeft.GetComponent<Text>();
    }

    void Update()
    {
        TimePassedTime = Time.fixedTime;
        TimePassedTime = (int)TimePassedTime;

        if(TimePassedTime >= ilosc_podzielna * ilosc_podzielna)
        {
            godziny = (int)TimePassedTime / (ilosc_podzielna * ilosc_podzielna);
            tempSek = (int)TimePassedTime - (godziny * ilosc_podzielna * ilosc_podzielna);
            minuty = tempSek / ilosc_podzielna;
            sekundy = tempSek - (minuty * ilosc_podzielna);
            wynikCzasu = godziny + "h " + minuty + "min " + sekundy + "sec";
        }
        else if (TimePassedTime > ilosc_podzielna && TimePassedTime < ilosc_podzielna * ilosc_podzielna)
        {
            minuty = (int)TimePassedTime / ilosc_podzielna;
            sekundy = (int)TimePassedTime - (minuty * ilosc_podzielna);
            wynikCzasu = minuty + "min " + sekundy + "sec";
        }
        else
        {
            wynikCzasu = TimePassedTime.ToString() + "sec";
        }
        TimePassedText.text = wynikCzasu;

        ThrowsLeft = GameObject.Find("EmptyToManageThemAll").GetComponent<ThrowCubes>().ThrowsLeft;
        ThrowLeftText.text = "Throws Left: " + ThrowsLeft.ToString();
    }
}



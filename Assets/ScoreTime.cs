using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTime : MonoBehaviour
{
    public int MinCount;
    public int SecCount;
    public float MilliCount;

    public GameObject MinDisplay;
    public GameObject SecDisplay;
    public GameObject MilliDisplay;

    void Start()
    {

        MinCount = PlayerPrefs.GetInt("MinSave");
        SecCount = PlayerPrefs.GetInt("SecSave");
        MilliCount = PlayerPrefs.GetFloat("MilliSave");


        if (SecCount <= 9)
        {
            SecDisplay.GetComponent<Text>().text = "0" + SecCount + ".";
        }
        else
        {
            SecDisplay.GetComponent<Text>().text = "" + SecCount + ".";
        }

        if (MinCount <= 9)
        {
            MinDisplay.GetComponent<Text>().text = "0" + MinCount + ":";
        }
        else
        {
            MinDisplay.GetComponent<Text>().text = "" + MinCount + ":";
        }

        MilliDisplay.GetComponent<Text>().text = "" + MilliCount;

        Laptimemange.RawTime = 0;
        Laptimemange.millcount = 0;
        Laptimemange.seccount = 0;
        Laptimemange.millcount = 0;

    }
}
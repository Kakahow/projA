using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laptimemange : MonoBehaviour
{
    public static int mincount;
    public static int seccount;
    public static float millcount;
    public static string MilliDisplay;

    public GameObject Minbox;
    public GameObject Secbox;
    public GameObject Millbox;

    public static float RawTime;

    // Update is called once per frame
    void Update()
    {
        millcount += Time.deltaTime * 10;

        RawTime += Time.deltaTime;


        MilliDisplay = millcount.ToString("F0");
        Millbox.GetComponent<Text>().text = "" + MilliDisplay;

        if (millcount >= 10)
        {
            millcount = 0;
            seccount += 1;
        }

        if (seccount <= 9)
        {
            Secbox.GetComponent<Text>().text = "0" + seccount + ".";
        }
        else
        {
            Secbox.GetComponent<Text>().text = "" + seccount + ".";
        }

        if (seccount >= 60)
        {
            seccount = 0;
            mincount += 1;
        }

        if (mincount <= 9)
        {
            Minbox.GetComponent<Text>().text = "0" + mincount + ":";
        }
        else
        {
            Minbox.GetComponent<Text>().text = "" + mincount + ":";
        }
        PlayerPrefs.SetInt("FinalMinSave", Laptimemange.mincount);
        PlayerPrefs.SetInt("FinalSecSave", Laptimemange.seccount);
        PlayerPrefs.SetFloat("FinalMilliSave", Laptimemange.millcount);
    }
}
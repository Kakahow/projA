using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChPoints : MonoBehaviour
{
    TextMeshProUGUI m_CheckPoint;
    public CarEntity targetObject;
    public TankEntity targetObject1;
    Material mText;

    void Update()
    {
        if (targetObject.Check() == true)
        {
            m_CheckPoint.color = Color.green;
        }
        else if (targetObject1.Check() == true)
        {
            m_CheckPoint.color = Color.green;
        }
    }
    public bool Goal1()
    {
        if (m_CheckPoint.color == Color.green)
        {
            return true;
        }
        else return false;
    }

    void Start()
    {
        m_CheckPoint = this.GetComponent<TextMeshProUGUI>();
        
    }
}

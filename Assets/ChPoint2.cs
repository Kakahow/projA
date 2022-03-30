using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChPoint2 : MonoBehaviour
{
    TextMeshProUGUI m_CheckPoint;
    public CarEntity targetObject;
    public TankEntity targetObject1;
    Material mText;
    // Start is called before the first frame update
    void Start()
    {
        m_CheckPoint = this.GetComponent<TextMeshProUGUI>();
    }
    public bool Goal2()
    {
        if (m_CheckPoint.color == Color.green)
        {
            return true;
        }
        else return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject.Check2() == true)
        {
            m_CheckPoint.color = Color.green;
        }
        else if (targetObject1.Check2() == true)
        {
            m_CheckPoint.color = Color.green;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parkingBlock2 : MonoBehaviour
{
    SpriteRenderer m_ParkRenderer;

    public CarEntity targetObject;


    void OnTriggerStay2D(Collider2D other)
    {
        if (targetObject.Check2() == true)
        {
            m_ParkRenderer.color = Color.green;
        }

    }


    void OnTriggerExit2D(Collider2D other)
    {
        m_ParkRenderer.color = Color.white;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_ParkRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

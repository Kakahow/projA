using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parkingblock : MonoBehaviour
{
    SpriteRenderer m_ParkRenderer;

    public CarEntity targetObject;
    public TankEntity targetObject1;

    
    void OnTriggerStay2D(Collider2D other)
    {
        if ( targetObject.Check() == true)
        {
            m_ParkRenderer.color = Color.green;
        }
        if (targetObject1.Check() == true)
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

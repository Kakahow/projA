using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingCmera2 : MonoBehaviour
{
    public TankEntity targetObject;
    public float MOVING_THRESHOLD = 10f;
    Camera m_Camera;
    float m_OrthographicSize;
    private void Start()
    {
        m_Camera = this.GetComponent<Camera>();
        m_OrthographicSize = m_Camera.orthographicSize;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        m_Camera.orthographicSize = m_OrthographicSize + targetObject.Velocity * 2f;
        

        Vector2 deltaPos = this.transform.position - targetObject.transform.position  ;
        

        if (deltaPos.magnitude > MOVING_THRESHOLD)
        {
            deltaPos.Normalize();

            Vector2 newPosition = new Vector2(targetObject.transform.position.x, targetObject.transform.position.y) + deltaPos * MOVING_THRESHOLD;
            this.transform.position = new Vector3(newPosition.x, newPosition.y, this.transform.position.z);

        }
       


    }
    
}

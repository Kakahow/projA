using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CarEntity : MonoBehaviour
{
    public GameObject wheelFrontRight;
    public GameObject wheelFrontLeft;
    public GameObject wheelBackRight;
    public GameObject wheelBackLeft;
    public GameObject parkingBlock;
    public GameObject parkingBlock2;
    public float Velocity { get { return m_Velocity; } }

    float m_FrontWheelAngle = 0;
    const float WHEEL_ANGLE_LIMIT = 40f;
    public float turnAngularVelocity = 20f;

    float m_Velocity = 0;
    public float acceleration = 1f;
    public float deceleration = 10f;
    public float maxVelocity = 40f;
    public float carLength = 1.14f;
    float m_DeltaMovement;


    [SerializeField] SpriteRenderer[] m_Renderers = new SpriteRenderer[5];


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))  //Speed up 
        {
            m_Velocity = Mathf.Min(maxVelocity, m_Velocity + Time.fixedDeltaTime * acceleration);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (m_Velocity > 0)
            {
                m_Velocity = Mathf.Max(0, m_Velocity - Time.fixedDeltaTime * deceleration);
            }
            if (m_Velocity < 0)
            {
                m_Velocity = Mathf.Min(0, m_Velocity + Time.fixedDeltaTime * deceleration);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))  //Back
        {
            m_Velocity = Mathf.Max(-20, m_Velocity - Time.fixedDeltaTime * deceleration);
        }


        m_DeltaMovement = m_Velocity * Time.fixedDeltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))  //Turn left
        {
            m_FrontWheelAngle = Mathf.Clamp(m_FrontWheelAngle + Time.fixedDeltaTime * turnAngularVelocity, -WHEEL_ANGLE_LIMIT, WHEEL_ANGLE_LIMIT);
            UpdateWheels();
        }

        if (Input.GetKey(KeyCode.RightArrow))  //Turn right
        {
            m_FrontWheelAngle = Mathf.Clamp(m_FrontWheelAngle - Time.fixedDeltaTime * turnAngularVelocity, -WHEEL_ANGLE_LIMIT, WHEEL_ANGLE_LIMIT);
            UpdateWheels();
        }

        this.transform.Rotate(0f, 0f, 1 / carLength * Mathf.Tan(Mathf.Deg2Rad * m_FrontWheelAngle) * m_DeltaMovement * Mathf.Rad2Deg);
        this.transform.Translate(Vector3.up * m_DeltaMovement);

    }


    // test
    void UpdateWheels()
    {
        Vector3 localEulerAngles = new Vector3(0f, 0f, m_FrontWheelAngle);
        wheelFrontLeft.transform.localEulerAngles = localEulerAngles;
        wheelFrontRight.transform.localEulerAngles = localEulerAngles;
    }

    private void Stop()
    {
        m_Velocity = 0;
    }

    void ChangeColor(Color color)
    {
        foreach (SpriteRenderer s in m_Renderers)
        {
            s.color = color;
        }
    }
    void ResetColor()
    {
        ChangeColor(Color.white);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Stop();
        ChangeColor(Color.red);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        Stop();
    }
    void OnCollisionExit2D(Collision2D other)
    {
        ResetColor();
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
     
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        CheckPoint checkPoint = other.gameObject.GetComponent<CheckPoint>();

        if (checkPoint != null)
        {
            ChangeColor(Color.green);
            this.Invoke("ResetColor", 0.5f);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.tag == "parkingBlock" )&& (Check() == true))
        {
            ChangeColor(Color.green);
        }
        else if ((other.gameObject.tag == "parkingBlock2") && (Check2() == true))
        {
            ChangeColor(Color.green);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        ResetColor();
        if (other.gameObject.tag == "FinishLine")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
   public  bool Check()
    {
        float[] Points = new float[8];
        Points[0] = wheelFrontLeft.transform.position.x - parkingBlock.transform.position.x;
        Points[1] = wheelFrontRight.transform.position.x - parkingBlock.transform.position.x;
        Points[2] = wheelFrontLeft.transform.position.y - parkingBlock.transform.position.y;
        Points[3] = wheelFrontRight.transform.position.y - parkingBlock.transform.position.y;
        Points[4] = wheelBackLeft.transform.position.y - parkingBlock.transform.position.y;
        Points[5] = wheelBackRight.transform.position.y - parkingBlock.transform.position.y;
        Points[6] = wheelBackLeft.transform.position.x - parkingBlock.transform.position.x;
        Points[7] = wheelBackRight.transform.position.x - parkingBlock.transform.position.x;
        float p1 = Points[0] + 0.95f;
        float p2 = Points[1] - 0.95f;
        float p3 = Points[2] - 1.275f;
        float p4 = Points[3] - 1.275f;
        float p5 = Points[4] + 1.275f;
        float p6 = Points[5] + 1.275f;
        float p7 = Points[6] + 0.95f;
        float p8 = Points[7] - 0.95f;

        if (p1 >= 0f  && p2 <= 0f && p3 <= 0f  && p4 <= 0f  && p5 >= 0f && p6 >= 0f && p7 >= 0f && p8 <= 0f )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Check2()
    {
        float[] Points = new float[8];
        Points[0] = wheelFrontLeft.transform.position.x - parkingBlock2.transform.position.x;
        Points[1] = wheelFrontRight.transform.position.x - parkingBlock2.transform.position.x;
        Points[2] = wheelFrontLeft.transform.position.y - parkingBlock2.transform.position.y;
        Points[3] = wheelFrontRight.transform.position.y - parkingBlock2.transform.position.y;
        Points[4] = wheelBackLeft.transform.position.y - parkingBlock2.transform.position.y;
        Points[5] = wheelBackRight.transform.position.y - parkingBlock2.transform.position.y;
        Points[6] = wheelBackLeft.transform.position.x - parkingBlock2.transform.position.x;
        Points[7] = wheelBackRight.transform.position.x - parkingBlock2.transform.position.x;
        float p1 = Points[0] - 1.5f;
        float p2 = Points[1] - 1.5f;
        float p3 = Points[2] - 0.66f;
        float p4 = Points[3] + 0.66f;
        float p5 = Points[4] - 0.66f;
        float p6 = Points[5] + 0.66f;
        float p7 = Points[6] + 1.5f;
        float p8 = Points[7] + 1.5f;

        if (p1 <= 0f  && p2 <= 0f  && p3 <= 0f  && p4 >= 0f  && p5 <= 0f  && p6 >= 0f && p7 >= 0f && p8 >= 0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

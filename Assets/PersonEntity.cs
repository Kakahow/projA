using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PersonEntity : MonoBehaviour
{
    float m_count = 1;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (m_count > 0 && m_count < 600)
        {
            gameObject.transform.position += new Vector3((1.9f * Time.deltaTime), 0, 0);
            m_count += 1;
        }
        if (m_count == 599)
        {
            m_count = -1;
            gameObject.transform.Rotate(new Vector3(0, 0, 180));
        }
        if (m_count < 0 && m_count > -600)
        {
            gameObject.transform.position += new Vector3((-1.9f * Time.deltaTime), 0, 0);
            m_count -= 1;
        }
        if (m_count == -599)
        {
            m_count = 1;
            gameObject.transform.Rotate(new Vector3(0, 0, 180));
        }
    }
}
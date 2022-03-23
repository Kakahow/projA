using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
   
    void OnTriggerExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Finished");
        }
    }
}


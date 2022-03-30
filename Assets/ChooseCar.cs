using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChooseCar : MonoBehaviour
{
    int a;
    public GameObject TankEntity;
    
    public void ChooseCarEntity()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        a = 1;
    }
    
    public void ChooseTankEntity()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //a = 2;
    }

    public bool CarChosen()
    {
        if (a == 1)
        {
            return true;
        }
        else return false;
    }
    public bool TankChosen()
    {
        if (a == 2)
        {
            return true;
        }
        else return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

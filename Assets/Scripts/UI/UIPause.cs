using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : MonoBehaviour
{
    public GameObject pause;
    public Spawner spawner;

    public void PauseOn() 
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        spawner.RemoveShapes();
    }
    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
    }
   
}

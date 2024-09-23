using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : MonoBehaviour
{
    public Spawner spawner;
    
    private void OnEnable()
    {
        Time.timeScale = 0f;
        spawner.RemoveShapes();
    }

    
    private void OnDisable()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Reload : MonoBehaviour
{
    public float Die = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Die = 1;
            Application.LoadLevel(Application.loadedLevel); 
        }
    }
}

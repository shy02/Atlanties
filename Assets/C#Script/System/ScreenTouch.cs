using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTouch : MonoBehaviour
{
    Touch touch;
    void Update()
    {
        if(Input.touchCount > 0){
            touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began){
            SceneManager.LoadScene("Loby");
        }
        }
    }
}

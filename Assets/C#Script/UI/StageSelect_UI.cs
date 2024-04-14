using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect_UI : MonoBehaviour
{
    public void Press_Stroy_Mode_btn(){
        SceneManager.LoadScene("StageSelect");
    }

    public void Press_Infinite_Mode_btn(){
        SceneManager.LoadScene("InfiniteMode");
    }

    public void Press_Back_Btn(){
        SceneManager.LoadScene("Loby");
    }
    public void Press_Back_Mode_Btn(){
        SceneManager.LoadScene("ModeSelect");
    }
}

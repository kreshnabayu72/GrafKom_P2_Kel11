using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] Camera levelCam;

    public void Tutorial(){
        SceneManager.LoadScene("Tutorial");
    }
    public void Asrama(){
        SceneManager.LoadScene("Asrama");
    }
    public void CCR(){
        SceneManager.LoadScene("CCR");
    }
    public void FMIPA(){
        SceneManager.LoadScene("FMIPA");
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    

    public void ToLevelSelection(){
        levelCam.enabled = true;
        mainCam.enabled = false;  
    }

    private void Start() {
        mainCam.enabled = true;
        levelCam.enabled = false;
    }
}

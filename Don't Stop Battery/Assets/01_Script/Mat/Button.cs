using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject oh;
    bool esc;
    public void Retry()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Menu(){
        SceneManager.LoadScene(0);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(esc == false){
                oh.SetActive(true);
                esc = true;
                Time.timeScale = 0;
            }
            else if(esc == true){
                oh.SetActive(false);
                esc = false;
                Time.timeScale = 1;
            }
        }
    }
}

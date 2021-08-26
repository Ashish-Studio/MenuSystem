using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCode : MonoBehaviour {

    [SerializeField] string StartGameScene;
    [SerializeField] GameObject OptionScreen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void StartGame()
    {
        SceneManager.LoadScene(StartGameScene);
    }

    public void OpenOptionGame()
    {
        OptionScreen.SetActive(true);
    }

    public void CloseOptionGame()
    {
        OptionScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour {
    public GameObject canvas;
    public bool speedUnlocked = false;
    public GameObject popupText;

    public void doExitGame() {
        Application.Quit();
    }

    public void unlockSpeed()
    {
      speedUnlocked = true;
      Debug.Log("Easter Egg Found");
      GameObject myPopupText = Instantiate(popupText);
      myPopupText.transform.SetParent(canvas.transform,false);
    }

    public void MenuButtonPress()
    {
        SceneLoader.Load("Main Menu");
    }

    public void OnLevel1ButtonPress()
    {
      SceneLoader.Load("Level 1");
    }

    public void OnLevel2ButtonPress()
    {
      SceneLoader.Load("Level 2");
    }
    public void OnLevel3ButtonPress()
    {
      SceneLoader.Load("Level 3");
    }
    public void OnLevel4ButtonPress()
    {
      SceneLoader.Load("Level 4");
    }
    public void OnLevel5ButtonPress()
    {
      SceneLoader.Load("Level 5");
    }
    public void OnLevel6ButtonPress()
    {
      SceneLoader.Load("Level 6");
    }
    public void OnLevel7ButtonPress()
    {
      SceneLoader.Load("Level 7");
    }
    public void OnLevel8ButtonPress()
    {
      SceneLoader.Load("Level 8");
    }
    public void OnLevel9ButtonPress()
    {
      SceneLoader.Load("Level 9");
    }
    public void OnLevel10ButtonPress()
    {
      SceneLoader.Load("Level 10");
    }
}

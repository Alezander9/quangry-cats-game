using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject menuButton;
    public GameObject resetButton; 
    public GameObject PopupWinBG;
    public GameObject PopupLoseBG;
    public GameObject popupResetButton;
    public GameObject popupMenuButton;
    public GameObject popupNextButton;
    public GameObject popupHomeButton;
    public GameObject popupWin;
    public GameObject popupLose;
    public GameObject levelName;
    public GameObject newCatButton;
    
    public bool levelOngoing = true;
    private GameObject playerManager;
    private GameObject myLevelName;



    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("PlayerManager");

        GameObject myMenuButton = Instantiate(menuButton);
        GameObject myResetButton = Instantiate(resetButton);
        myMenuButton.transform.SetParent(canvas.transform,false);
        myResetButton.transform.SetParent(canvas.transform,false);
        myMenuButton.GetComponent<Button>().onClick.AddListener(OnMenuButtonPress);
        myResetButton.GetComponent<Button>().onClick.AddListener(OnResetButtonPress);

        myLevelName = Instantiate(levelName);
        myLevelName.transform.SetParent(canvas.transform,false);
        myLevelName.GetComponent<TMPro.TextMeshProUGUI>().text = SceneManager.GetActiveScene().name;
        Invoke("removeLevelText", 1f);

        GameObject myNewCatButton = Instantiate(newCatButton);
        myNewCatButton.transform.SetParent(canvas.transform,false);
        myNewCatButton.GetComponent<Button>().onClick.AddListener(OnNewCatButtonPress);

    }

    void removeLevelText()
    {
        Destroy(myLevelName);
    }

    // Update is called once per frame
    void Update()
    {
        if (levelOngoing)
        {
            if (playerManager.GetComponent<playerSpawner>().outOfCats)
            {
                levelOngoing = false;
                levelFail();
            }
            else if(GameObject.FindWithTag("Enemy Rat")==null)
            {
                levelOngoing = false;
                levelWin();
            }
        }

        //Bugtesting mode
        // if (Input.GetKeyDown("r"))
        // {
        //     OnResetButtonPress();
        // }
        // if (Input.GetKeyDown("n"))
        // {
        //     OnNextButtonPress();
        // }
        // if (Input.GetKeyDown("m"))
        // {
        //     OnMenuButtonPress();
        // }
        // if (Input.GetKeyDown("k"))
        //     levelWin();
        // if (Input.GetKeyDown("l"))
        //     levelFail();
    }

    void levelWin()
    {
        Debug.Log("Level Win");
        GameObject myPopupBG = Instantiate(PopupWinBG);
        GameObject myPopupResetButton = Instantiate(popupResetButton);
        GameObject myPopupNextButton = Instantiate(popupNextButton);
        GameObject myPopupHomeButton = Instantiate(popupHomeButton);
        GameObject mypopupWin = Instantiate(popupWin);
        myPopupBG.transform.SetParent(canvas.transform,false);
        myPopupResetButton.transform.SetParent(canvas.transform,false);
        myPopupNextButton.transform.SetParent(canvas.transform,false);
        myPopupHomeButton.transform.SetParent(canvas.transform,false);
        mypopupWin.transform.SetParent(canvas.transform,false);

        myPopupResetButton.GetComponent<Button>().onClick.AddListener(OnResetButtonPress);
        myPopupNextButton.GetComponent<Button>().onClick.AddListener(OnNextButtonPress);
        myPopupHomeButton.GetComponent<Button>().onClick.AddListener(OnMenuButtonPress);
    }

    void levelFail()
    {
        Debug.Log("Level Lose");
        GameObject myPopupBG = Instantiate(PopupLoseBG);
        GameObject myPopupHomeButton = Instantiate(popupHomeButton);
        GameObject myPopupResetButton = Instantiate(popupResetButton);
        GameObject mypopupLose = Instantiate(popupLose);
        myPopupBG.transform.SetParent(canvas.transform,false);
        myPopupResetButton.transform.SetParent(canvas.transform,false);
        myPopupHomeButton.transform.SetParent(canvas.transform,false);

        mypopupLose.transform.SetParent(canvas.transform,false);
        myPopupHomeButton.GetComponent<Button>().onClick.AddListener(OnMenuButtonPress);

    }

    public void OnResetButtonPress()
    {
        Scene currentscene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(currentscene.name);
    }

    public void OnMenuButtonPress()
    {
        SceneLoader.Load("Main Menu");
    }

    public void OnNextButtonPress()
    {
        string currentSceneName = SceneManager.GetActiveScene().name; 
        int levelNumber = int.Parse(currentSceneName.Substring(6));
        if (levelNumber == 10)
        {
            SceneLoader.Load("End Screen");
        }
        else
        {
            SceneLoader.Load("Level " + (levelNumber+1).ToString());
        }
    }

    public void OnNewCatButtonPress()
    {
        GameObject.Find("PlayerManager").GetComponent<playerSpawner>().summonCatButton();
    }

}

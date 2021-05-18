using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    JsonController jsonController;
    public LevelGenerator levelGenerator;
    public GameObject NextLevelButton;
    public GameObject ResetLevelButton;
    public TMPro.TMP_Text bestTime;
    public TMPro.TMP_Text playText;
    private int numberOfPlays;

    List<GameObject> Boxes = new List<GameObject>();
    private static int _levelIndex = 1;

    void Start()
    {
        levelGenerator.GenerateLevel();
        jsonController = new JsonController();
        numberOfPlays = jsonController.GetNumberOfPlays(_levelIndex);
        string levelsTime = "Time to beat: " + jsonController.GetTime(_levelIndex);
        bestTime.text = levelsTime;
        string plays = "Level played " + numberOfPlays + " times so far.";
        playText.text = plays;

        foreach (GameObject Box in GameObject.FindGameObjectsWithTag("Box"))
        {
            Boxes.Add(Box);
        }

        TimerController.instance.BeginTimer();
    }

    void Update()
    {
        if(IsLevelComplete())
        {
            TimerController.instance.EndTimer();
            SetUpLevelInfo();
            NextLevel();
        }
    }

    bool IsLevelComplete()
    {
        foreach (GameObject Box in Boxes)
        {
            if(Box.GetComponent<Box>().GetOnHolder() == false)
            {
                return false;
            }
        }
        return true;
    }
 
    private void SetUpLevelInfo()
    {
        jsonController.SetLevel(_levelIndex);
        SetupBestTime();
        jsonController.SetTime(_levelIndex, TimerController.instance.GetTime());
        jsonController.SetSolved(_levelIndex, true);
        numberOfPlays = jsonController.GetNumberOfPlays(_levelIndex) + 1;
        jsonController.SetNumberOfPlays(_levelIndex, numberOfPlays);
        jsonController.outputJson(_levelIndex);
    }

    private void SetupBestTime()
    {
        if (jsonController.GetCheckTime(_levelIndex) == "999999")
        {
            jsonController.SetCheckTime(_levelIndex, TimerController.instance.GetCheckableTime());
        }
        int lastTime = System.Int32.Parse(jsonController.GetCheckTime(_levelIndex));
        int presentTime = System.Int32.Parse(TimerController.instance.GetCheckableTime());
        if(presentTime <= lastTime)
        {
            jsonController.SetCheckTime(_levelIndex, TimerController.instance.GetCheckableTime());
        }
    }
    public void NextLevel()
    {
        _levelIndex++;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextLevelChecked()
    {
        if(jsonController.GetSolved(_levelIndex + 1))
        {
            NextLevel();
        }
    }

    public void ResetLevel()
    {
        jsonController.SetNumberOfPlays(_levelIndex, numberOfPlays);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Menu");
    }
}

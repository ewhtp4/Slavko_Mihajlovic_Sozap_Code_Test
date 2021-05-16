using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    JsonController jsonController;
    public LevelGenerator levelGenerator;
    public GameObject NextLevelButton;
    public GameObject ResetLevelButton;
    public Text bestTime;
    public Text playText;
    private int numberOfPlays;

    List<GameObject> Boxes = new List<GameObject>();
    private static int _nextLevelIndex = 1;

    void Start()
    {
        levelGenerator.GenerateLevel();
        jsonController = new JsonController();
        numberOfPlays = jsonController.GetNumberOfPlays(_nextLevelIndex);
        string levelsTime = "Time to beat: " + jsonController.GetTime(_nextLevelIndex);
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
            Debug.Log("Number of Plays" + numberOfPlays);
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
        jsonController.SetLevel(_nextLevelIndex);
        jsonController.SetTime(_nextLevelIndex, TimerController.instance.GetTime());
        jsonController.SetSolved(_nextLevelIndex, true);
        numberOfPlays = jsonController.GetNumberOfPlays(_nextLevelIndex) + 1;
        jsonController.SetNumberOfPlays(_nextLevelIndex, numberOfPlays);
        jsonController.outputJson(_nextLevelIndex);
    }
    public void NextLevel()
    {
        string LevelName = "Level" + _nextLevelIndex;
        SceneManager.UnloadScene(LevelName);
        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }

    public void ResetLevel()
    {
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}

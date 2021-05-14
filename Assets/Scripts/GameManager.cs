using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject NextLevelButton;
    public GameObject ResetLevelButton;

    List<GameObject> BoxHolders = new List<GameObject>();
    List<GameObject> OccupiedHolders = new List<GameObject>();

    private static int _nextLevelIndex = 1;

    void Start()
    {
        foreach (GameObject BoxHolder in GameObject.FindGameObjectsWithTag("BoxHolder"))
        {
            BoxHolders.Add(BoxHolder);
            Debug.Log(BoxHolders.Count);
        }
    }

    void Update()
    {
        if (OccupiedHolders.Count == BoxHolders.Count)
        {
            Debug.Log(OccupiedHolders.Count);   
        }
        if(IsLevelComplete())
        {
            NextLevel();
        }
    }

    bool IsLevelComplete()
    {
        foreach (GameObject BoxHolder in BoxHolders)
        {
            if (!BoxHolder.GetComponent<BoxHolder>().GetOccupied())
            {
                return false;
            }
        }
        return true;
    }
 
    public void NextLevel()
    {
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

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonController : MonoBehaviour
{
    public TextAsset data;

    [System.Serializable]
    public class Level
    {
        public int level;
        public string time;
        public bool solved;
        public int numberOfPlays;
    }

    Level presentLevel = new Level();

    void Start()
    {
        presentLevel = JsonUtility.FromJson<Level>(data.text);
    }

    /******************Reading*******************/

    public string GetTime(int level)
    {
        string levelsTimer = "Timer" + level;
        string jsonTimer = PlayerPrefs.GetString(levelsTimer);
        return jsonTimer;
    }

    public bool GetSolved(int level)
    {
        string levelsSolved = "Solved" + level;
        string stringToBool = PlayerPrefs.GetString(levelsSolved);
        if (stringToBool == "true")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetNumberOfPlays(int level)
    {
        string levelsPlays = "LevelsPlays" + level;
        int jsonPlays = PlayerPrefs.GetInt(levelsPlays);
        return jsonPlays;
    }

    /*****************Writing*******************/

    public void SetTime(int level, string time)
    {
        presentLevel.time = time;
        string levelsTimer = "Timer" + level;
        PlayerPrefs.SetString(levelsTimer, presentLevel.time);
    }

    public void SetSolved(int level, bool solved)
    {
        string levelsSolved = "Solved" + level;
        presentLevel.solved = solved;
        string boolToString;
        if(solved)
        {
            boolToString = "true";
        }
        else
        {
            boolToString = "false";
        }
        PlayerPrefs.SetString(levelsSolved, boolToString);
    }

    public void SetLevel(int level)
    {
        presentLevel.level = level;
    }

    public void SetNumberOfPlays(int level, int plays)
    {
        string levelsPlays = "LevelsPlays" + level;
        Debug.Log("Plays" + plays);
        presentLevel.numberOfPlays = plays;
        PlayerPrefs.SetInt(levelsPlays, presentLevel.numberOfPlays);
    }

    public void outputJson(int level)
    {
        string directoryPath = Application.dataPath;
        string directory = "/Data/";
        string fileName = "level" + level + ".txt";
        string fullPath = directoryPath + directory + fileName;
        string stringOutput = JsonUtility.ToJson(presentLevel, true);
        File.WriteAllText(fullPath, stringOutput);
    }
}

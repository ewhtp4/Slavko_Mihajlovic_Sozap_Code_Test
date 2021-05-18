using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    JsonController jsonController;
    public TMPro.TMP_Dropdown dropdown;
    string dropdownText;

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    void Start()
    {
        jsonController = new JsonController();
    }

    void Update()
    {
        dropdownText = dropdown.options[dropdown.value].text;
        HandleInputData(dropdownText);
    }

    public void HandleInputData(string dropdownText)
    {

        if (dropdownText == "level 1")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (dropdownText == "level 2")
        {
            if (jsonController.GetSolved(2))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }
        if (dropdownText == "level 3")
        {
            if (jsonController.GetSolved(3))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
            }
        }
        if (dropdownText == "level 4")
        {
            if (jsonController.GetSolved(4))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
            }
        }
    }

    public void ResetSolvedLevels()
    {
        jsonController.SetSolved(2, false);
        jsonController.SetSolved(3, false);
        jsonController.SetSolved(4, false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public void Pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }



        Debug.Log("LEVEL " + PlayerPrefs.GetInt("levelsUnlocked") + "UNLOCKED");

    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(5);
    }

    public void LoadLevel3(int levelIndex)
    {
        SceneManager.LoadScene(7);
    }

    public void LoadLevel4(int levelIndex)
    {
        SceneManager.LoadScene(9);
    }


    public void LoadLevel5(int levelIndex)
    {
        SceneManager.LoadScene(9);
    }




    public void LoadLevel6(int levelIndex)
    {
        SceneManager.LoadScene(11);
    }
    public void LoadLevel7(int levelIndex)
    {
        SceneManager.LoadScene(13);
    }



    public void loadMainMenu(int levelIndex)
    {
        SceneManager.LoadScene(0);
    }
}

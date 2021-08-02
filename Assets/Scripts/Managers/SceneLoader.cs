using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    
    public static void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }
    
    public static void LoadSecondScene()
    {
        SceneManager.LoadScene(1);
    }
    
    public static void Exit()
    {
        Application.Quit();
    }
}
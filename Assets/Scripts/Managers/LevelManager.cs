using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] 
    private float scoreToWin;
    public static LevelManager Instance => instance;
    private static LevelManager instance;
    private int coinsCount = 0;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
    
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    public void AddScore(int score)
    {
        coinsCount += score;
        CheckFowWin();
    }

    private void CheckFowWin()
    {
        if (coinsCount == scoreToWin)
        {
            SceneLoader.LoadSecondScene();
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public int lives;

    public UnityEvent<string> onUpdateLives;
    public UnityEvent<string> onUpdateScore;
    public UnityEvent onGameOver;

    private void Awake()
    {
        instance = this;
    }

    private void OnValidate()
    {
        onUpdateLives?.Invoke($"Lives: {lives}");
    }

    public void AddLives(int value)
    {
        lives += value;
        if (lives <= 0)
        {
            onGameOver?.Invoke();
            lives = 0;
        }
        onUpdateLives?.Invoke($"Lives: {lives}");
    }
    
    public void AddScore(int value)
    {
        score += value;
        onUpdateScore?.Invoke($"Score: {score}");
    }
}
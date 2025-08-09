using UnityEngine;

public static class ScoreManager
{
    public static int score = 0;
    public static void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score atual: " + score);
    }
}
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "SO/PlayerStats")]
public class PlayerStats : ScriptableObject
{
  [SerializeField] private int _score;

  public int Score => _score;
  public event Action OnScoreUpdated;

  public void AddScore(int score)
  {
    _score += score;
    OnScoreUpdated?.Invoke();
  }

  public void ResetScore()
  {
    _score = 0;
  }
}
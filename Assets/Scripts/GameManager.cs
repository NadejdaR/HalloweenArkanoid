using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [Header("Lives")]
    [SerializeField] private int _maxLives = 5;
    [SerializeField] private int _startLives = 3;

    [Header("Autoplay")]
    [SerializeField] private bool _needAutoplay;
    
    private int _currentLives;

    public event Action OnLivesChanges;

    public int CurrentLives
    {
        get => _currentLives;
        set
        {
            _currentLives = value;

            if (_currentLives < 0)
                _currentLives = 0;

            if (_currentLives > _maxLives)
                _currentLives = _maxLives;
            
            OnLivesChanges?.Invoke();
        }
    }

    public int MaxLIves => _maxLives;

}
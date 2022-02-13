using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatManager : MonoBehaviour
{
  [SerializeField] private PlayerStats _playerStat;
  [SerializeField] private Text _scoreTxt;

  [Header("Life")]
  public int Life;
  [SerializeField] private GameObject _lifeImg;
  [SerializeField] private Transform _livesParent;

  private readonly List<GameObject> _currentLivesImg = new List<GameObject>();

  private void OnEnable()
  {
    _playerStat.OnScoreUpdated += UpdateScoreLbl;
  }

  private void OnDisable()
  {
    _playerStat.OnScoreUpdated -= UpdateScoreLbl;
  }

  private void Start()
  {
    InstantiateLives();
    _playerStat.ResetScore();
    UpdateScoreLbl();
  }

  private void Update()
  {
    UpdateTimeScale();
  }

  public void ReduceLife()
  {
    Life--;
    InstantiateLives();
  }

  public void AddLife()
  {
    Life++;
    InstantiateLives();
  }

  private void UpdateTimeScale()
  {
    if(UIManager.GameIsPaused)
      return;
  }

  private void InstantiateLives()
  {
    for (int i=0; i < Life; i++)
    {
      GameObject live = Instantiate(_lifeImg, _livesParent);
      _currentLivesImg.Add(live);
    }
  }

  private void UpdateScoreLbl()
  {
    _scoreTxt.text = $"Score: {_playerStat.Score}";
  }
}
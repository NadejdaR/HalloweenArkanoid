using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatManager : SingletonMonoBehaviour<PlayerStatManager>
{
  [SerializeField] private PlayerStats _playerStat;
  [SerializeField] private Text _scoreTxt;

  [Header("Life")]
  public int Life;
  [SerializeField] private GameObject _lifeImg;
  [SerializeField] private Transform _livesParent;
  
  [Header("Autoplay")]
  [SerializeField] private bool _needAutoplay;

  private readonly List<GameObject> _currentLivesImg = new List<GameObject>();
  public bool NeedAutoplay => _needAutoplay;

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
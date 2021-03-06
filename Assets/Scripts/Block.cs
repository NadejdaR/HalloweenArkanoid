using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
  [Header("Base Settings")]
  [SerializeField] private AudioClip _audioClip;
  [SerializeField] private Sprite[] _blockDestroySprite;
  [SerializeField] private PlayerStats _player;
  [SerializeField] private int _point;
  [SerializeField] private int _hits;
  [SerializeField] private SpriteRenderer _spriteRenderer;
  [SerializeField] private bool _isSecret;

  [Header("Pick Up")] 
  [SerializeField] private GameObject _pickUpPrefab;
  [Range(0f,100f)]
  [SerializeField] private float _pickUpChance;
  
  public static event Action OnCreated;
  public static event Action<Block> OnDestroyed;
  
  private void Start()
  {
    if (_hits == 0)
      return;
    OnCreated?.Invoke();

    if (_isSecret)
      _spriteRenderer.enabled = false;
  }

  private void OnDestroy()
  {
    if(_hits == 0)
      return;
    OnDestroyed?.Invoke(this);
  }

  private void OnCollisionEnter2D(Collision2D col)
  {
    if(!col.gameObject.CompareTag(Tags.Ball))
      return;
    
    if (_isSecret)
    {
      _spriteRenderer.enabled = true;
      _isSecret = false;
      return;
    }
    if (_hits > 1)
      GetHit(1);
    else if (_hits == 1)
    {
      _player.AddScore(_point);
      Destroy(gameObject);
      // OnDestroyed?.Invoke(this);
    }
    else if (_hits == 0)
      return;
    else
      GetHit(0);

    AudioManager.Instance.PlayOnShot(_audioClip);
    CreatePickUp();
  }

  private void GetHit(int i)
  {
    _hits--;
    _spriteRenderer.sprite = _blockDestroySprite[i];
  }

  private void CreatePickUp()
  {
    float randomChance = Random.Range(0.1f, 100f);
    if (_pickUpChance >= randomChance)
    {
      Instantiate(_pickUpPrefab, transform.position, Quaternion.identity);
    }
  }
}
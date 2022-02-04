using UnityEngine;

public class Block : MonoBehaviour
{
  [SerializeField] private AudioClip _audioClip;
  [SerializeField] private Sprite[] _blockDestroySprite;
  [SerializeField] private PlayerStats _player;
  [SerializeField] private int _point;
  [SerializeField] private int _hits;
  [SerializeField] private SpriteRenderer _spriteRenderer;

  private PlayerStatManager _statManager;
  private void OnCollisionEnter2D(Collision2D col)
  {
    if (_hits > 1)
    {
      GetHit(1);
    }
    else if (_hits == 1)
    {
      _player.AddScore(_point);
      Destroy(gameObject);
    }
    else if (_hits == 0)
    {
      return;
    }
    else
    {
      GetHit(0);
    }

    AudioManager.Instance.PlayOnShot(_audioClip);
  }

  private void GetHit(int i)
  {
    _hits--;
    _spriteRenderer.sprite = _blockDestroySprite[i];
  }
}
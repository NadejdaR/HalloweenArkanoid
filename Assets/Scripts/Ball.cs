using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
  [Header("Base Settings")] 
  [SerializeField] private Rigidbody2D _rb;
  [SerializeField] private float _speed;

  [Header("Pad Settings")] 
  [SerializeField] private Transform _padTransform;
  [SerializeField] private float _yOffsetFromPad;

  [Header("Audio")] 
  [SerializeField] private AudioSource _audioSource;

  [Header("Start Direction")] 
  [SerializeField] private int _xMin;
  [SerializeField] private int _xMax;
  [SerializeField] private int _yMin;
  [SerializeField] private int _yMax;

  private Vector2 _direction;
  public bool _isStarted;

  private void Start()
  {
    StartBallSet();
  }

  public void ResetBall()
  {
    _isStarted = false;
    StartBallSet();
  }

  private void StartBallSet()
  {
    if (_isStarted)
      return;

    MoveBallWithPad();

    if (Input.GetMouseButtonDown(0))
      StartBall();
  }

  private void OnCollisionEnter2D(Collision2D col)
  {
    _audioSource.Play();
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawRay(transform.position, _direction);
    Gizmos.color = Color.magenta;
    Gizmos.DrawRay(transform.position, _rb.velocity);
  }

  private void MoveBallWithPad()
  {
    Vector3 currentPosition = _padTransform.position;
    currentPosition.y += _yOffsetFromPad;
    transform.position = currentPosition;
  }

  private void StartBall()
  {
    _direction.x = Random.Range(_xMin, _xMax);
    _direction.y = Random.Range(_yMin, _yMax);

    _rb.velocity = _direction.normalized * _speed;
    _isStarted = true;
  }
}
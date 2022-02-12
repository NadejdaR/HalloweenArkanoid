using System;
using UnityEngine;

public class Pad : MonoBehaviour
{
  private Camera _mainCamera;
  private Transform _ballTransform;

  private void Start()
  {
    _mainCamera = Camera.main;
    _ballTransform = FindObjectOfType<Ball>().transform;
  }

  private void Update()
  {
    if (PlayerStatManager.Instance.NeedAutoplay)
      FollowWithBall();
    else
      FollowMouse();
  }

  private void FollowMouse()
  {
    if (UIManager.GameIsPaused) 
      return;

    Vector3 mousePosition = Input.mousePosition;
    Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(mousePosition);

    Vector3 currentPosition = transform.position;
    currentPosition.x = worldPosition.x;
    transform.position = currentPosition;
  }

  private void FollowWithBall()
  {
    Vector3 ballWorldPosition = _ballTransform.position;

    Vector3 currentPosition = transform.position;
    currentPosition.x = ballWorldPosition.x;
    transform.position = currentPosition;
  }
}
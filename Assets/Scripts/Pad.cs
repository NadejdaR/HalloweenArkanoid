using UnityEngine;

public class Pad : MonoBehaviour
{
  private Camera _mainCamera;

  private void Start()
  {
    _mainCamera = Camera.main;
  }

  private void Update()
  {
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
}
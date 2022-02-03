using UnityEngine;

public class Pad : MonoBehaviour
{
  private void Update()
  {
    Vector3 mousePosition = Input.mousePosition;
    if (Camera.main == null) return;
    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

    Vector3 currentPosition = transform.position;
    currentPosition.x = worldPosition.x;
    transform.position = currentPosition;
  }
}
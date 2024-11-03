using UnityEngine;

public static class CameraExtensions
{
    public static Vector2 ScreenToWorldPoint(this Camera camera, Vector2 screenPosition)
    {
        var result = new Vector2();
        result.x = 2 * screenPosition.x / camera.pixelWidth * camera.orthographicSize * camera.aspect - camera.orthographicSize * camera.aspect;
        result.y = 2 * screenPosition.y / camera.pixelHeight * camera.orthographicSize - camera.orthographicSize;
        return result;
    }
}

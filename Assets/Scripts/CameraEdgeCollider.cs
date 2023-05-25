using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEdgeCollider : MonoBehaviour
{
    private void Awake()
    {
        AddColliderToCamera();
    }

    void AddColliderToCamera()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Set Camera tag to 'MainCamera'");
            return;
        }

        Camera cam = Camera.main;

        if(!cam.orthographic)
        {
            Debug.LogError("Set camera to orthographic");
            return;
        }

        var edgeCollider = gameObject.GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : gameObject.GetComponent<EdgeCollider2D>();

        var leftBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        var leftTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        var rightTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        var rightBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

        var edgePoints = new[] { leftBottom, leftTop, rightTop, rightBottom, leftBottom };

        edgeCollider.points = edgePoints;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
        }
    }
}

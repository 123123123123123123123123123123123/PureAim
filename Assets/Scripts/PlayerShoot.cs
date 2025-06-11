using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Camera playerCam;
    public float shootDistance = 100f;
    public LayerMask targetLayer;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Linksklick
        {
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, shootDistance, targetLayer))
            {
                Debug.Log("Hit something: " + hit.collider.name);
                TargetBall target = hit.collider.GetComponent<TargetBall>();
                if (target != null)
                {
                    Debug.Log("Hit TargetBall detected!");
                    target.Hit();
                }
                else
                {
                    Debug.Log("Hit collider has no TargetBall component.");
                }
            }
        }
    }
}
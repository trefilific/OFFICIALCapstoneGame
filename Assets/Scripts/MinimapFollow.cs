using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public Transform target; // player

    void LateUpdate()
    {
        Vector3 newPos = target.position;
        newPos.y = transform.position.y; // keep height constant
        transform.position = newPos;

        // Optional: rotate with player (top-down yaw only)
        transform.rotation = Quaternion.Euler(90f, target.eulerAngles.y, 0f);  
    }
}

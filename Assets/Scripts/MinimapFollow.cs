using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public Transform target;
    public float height = 20f;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 newPos = target.position;
        newPos.y = height;

        transform.position = newPos;
    }
}

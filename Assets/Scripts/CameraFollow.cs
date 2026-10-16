
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public Vector3 offset = new Vector3(0, 12, -14);

    void LateUpdate()
    {
        if (player == null)
            return;

        transform.position = player.position + offset;

        transform.LookAt(player.position + Vector3.up);
    }
}

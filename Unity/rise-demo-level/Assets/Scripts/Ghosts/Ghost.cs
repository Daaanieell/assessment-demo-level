using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private Transform player;

    [Header("Offsets")]
    [SerializeField] private float height = 1;
    [SerializeField] private float offset = 2;
    void Update()
    {
        StayAtSide();
    }

    private void StayAtSide()
    {
        if (player)
        {
            Vector3 sidePosition = new Vector3(
                player.position.x + offset,
                player.position.y + height,
                player.position.z + -offset
                );
            transform.position = sidePosition;
        }
        else
        {
            Debug.LogWarning("no player object found");
        }
    }
}

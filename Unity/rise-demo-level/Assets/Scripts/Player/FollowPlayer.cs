using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float height = 10;

    void Update()
    {
        FollowPlayerPosition();
    }

    private void FollowPlayerPosition()
    {
        if (player)
        {
            Vector3 eagleEyePosition = new Vector3(player.position.x, player.position.y + height, player.position.z);
            transform.position = eagleEyePosition;
        }
        else
        {
            Debug.LogWarning("no player object found");
        }
    }
}

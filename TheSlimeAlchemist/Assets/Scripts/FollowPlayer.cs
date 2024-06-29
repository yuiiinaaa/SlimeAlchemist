using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform targetPlayer;  // Reference to the player's Transform component
    public Vector3 offset;

    Vector3 velocity = Vector3.zero;
    [Range(0, 1)]
    public float smoothTime;

    public Vector2 xLimit;
    public Vector2 yLimit;


    public void Awake(){
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player2").transform;
        //Debug.Log("Player: " + targetPlayer);
        Vector3 targetPosition = targetPlayer.position + offset;
        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}

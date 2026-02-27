using UnityEngine;
using UnityEngine.Events;

public class PlayerCollide : MonoBehaviour
{
    [SerializeField]
    private string obstacleTag = "Obstacle";
    [SerializeField]
    private string weedTag = "Weed";
    [SerializeField]
    private string JumpPowerUpTag = "JumpPowerUp";
    [SerializeField]
    private UnityEvent<Transform> onObstacleCollision;
    [SerializeField]
    private UnityEvent<Transform> onJumpPowerUpCollected;
    [SerializeField]
    private UnityEvent<Transform> onWeedCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(obstacleTag))
        {
            onObstacleCollision?.Invoke(transform);
        }
        else if (other.CompareTag(weedTag))
        {
            onWeedCollected?.Invoke(transform);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag(JumpPowerUpTag))
        {
            onJumpPowerUpCollected?.Invoke(transform);
            other.gameObject.SetActive(false);
        }
    }
}

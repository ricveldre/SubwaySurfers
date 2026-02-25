using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollide : MonoBehaviour
{
    [SerializeField]
    private string obstacleTag = "Obstacle";
    [SerializeField]
    private string weedTag = "Weed";
    [SerializeField]
    private UnityEvent<Transform> onObstacleCollision;
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
    }
}

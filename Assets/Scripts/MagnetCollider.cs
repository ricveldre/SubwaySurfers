using UnityEngine;

public class MagnetCollider : MonoBehaviour
{
    [SerializeField]
    private Transform character;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weed"))
        {
            CoinFollow coinFollow = other.GetComponent<CoinFollow>();
            if (coinFollow != null)
            {
                coinFollow.StartFollowing(character);
            }
        }
    }
}

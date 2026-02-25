using Mono.Cecil.Cil;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weed;
    private void OnEnable()
    {
        ActivateWeed();
    }
    private void ActivateWeed()
    {
        foreach (var weed in weed)
        {
            weed.SetActive(true);
        }
    }
}

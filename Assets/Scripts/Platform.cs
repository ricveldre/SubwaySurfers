using UnityEngine;
using System.Collections.Generic;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weed;
    private List<GameObject> powerUps = new List<GameObject>();
    private float colliderSize;
    public float ColliderSize => colliderSize;
    private void Awake()
    {
        colliderSize = GetComponent<Collider>().bounds.size.z * 0.5f;
    }
    private void OnEnable()
    {
        ActivateWeed();
    }
    public bool HasWeed()
    {
        return weed.Length > 0;
    }
    private void ActivateWeed()
    {
        foreach (var weed in weed)
        {
            weed.SetActive(true);
        }
    }
    public void AddPowerUp(GameObject powerUp)
    {
        if (weed.Length == 0) return;
        GameObject randomWeed = weed[Random.Range(0, weed.Length)];
        randomWeed.SetActive(false);
        powerUp.transform.SetParent(transform);
        powerUp.transform.localPosition = randomWeed.transform.localPosition;
        powerUps.Add(powerUp); 
    }
    private void OnDisable()
    {
        foreach (var powerUp in powerUps)
        {
            powerUp.SetActive(false);
        }
        powerUps.Clear();
    }
}

using UnityEngine;
using UnityEngine.Events;

public class WeedManager : MonoBehaviour
{
    private int weed;
    [SerializeField]
    private UnityEvent<string> onWeedChanged;
    public int Weed => weed;
    private void Awake()
    {
        weed = 0;
    }
    public void AddWeed(int amount)
    {
        weed += amount;
        onWeedChanged.Invoke(weed.ToString());
    }
    public void SetWeed(int amount)
    {
        weed = amount;
        onWeedChanged.Invoke(weed.ToString());
    }
}

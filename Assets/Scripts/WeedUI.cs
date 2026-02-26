using UnityEngine;
using UnityEngine.UI;

public class WeedUI : MonoBehaviour
{
    [SerializeField]
    private Text weedText;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string animationName = "Wiggle";
    public void UpdateWeedText(string weed)
    {
        animator.Play(animationName, 0, 0f);
        weedText.text = weed;
    }
}

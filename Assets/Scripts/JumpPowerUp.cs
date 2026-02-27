using UnityEngine;
using System.Collections;

public class JumpPowerUp : MonoBehaviour
{
    [SerializeField]
    private float jumpForceMultiplier = 1.5f;
    [SerializeField]
    private float duration = 5f;
    [SerializeField]
    private GameObject[] mangos;
    [SerializeField]
    private Character character;
    private float originalJumpForce;
    private Coroutine powerUpCoroutine;
    private void Awake()
    {
        originalJumpForce = character.JumpForce;
    }
    public void Activate()
    {
        originalJumpForce = character.JumpForce;
        character.JumpForce *= jumpForceMultiplier;
        powerUpCoroutine = StartCoroutine(DeactivateAfterDuration());
    }
    private void ActivateMangos(bool isActive)
    {
        foreach (var mango in mangos)
        {
            mango.SetActive(isActive);
        }
    }
    private IEnumerator DeactivateAfterDuration()
    {
        ActivateMangos(true);
        yield return new WaitForSeconds(duration);
        character.JumpForce = originalJumpForce;
        ActivateMangos(false);
    }
    public void Deactivate()
    {
        if (powerUpCoroutine != null)
        {
            StopCoroutine(powerUpCoroutine);
            powerUpCoroutine = null;
        }
        character.JumpForce = originalJumpForce;
        ActivateMangos(false);
    }
}

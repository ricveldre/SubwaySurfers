using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName ="Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string jumpAnimationName = "Jump";
    public string moveAnimationName = "Move";
    public string rolllAnimationName = "Roll";
    public string loseAnimationName = "Lose";
    public string runAnimationName = "Run";
}

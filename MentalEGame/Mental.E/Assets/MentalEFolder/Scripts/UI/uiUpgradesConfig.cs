using UnityEngine;

[CreateAssetMenu(
    fileName = "uiUpgradesConfig",
    menuName = "Scriptable Objects/uiUpgradesConfig"
)]
public class uiUpgradesConfig : ScriptableObject
{
    public Sprite[] sprites_update = new Sprite[10];
    public string[] sTextAmelioration = new string[10];
    public string[] sTitleAmelioration = new string[10];
    [Tooltip("jaune, rose, bleu")] public Color[] color_text = new Color[3];
    public int iNextUpgrade = 10;
}

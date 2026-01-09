using UnityEngine;

[CreateAssetMenu(fileName = "FoeStat", menuName = "Scriptable Objects/FoeStat")]
public class FoeStat : ScriptableObject
{
    public float initialMaxHP = 20;
    public float initialBulletDamage = 10;

    public float maxHP = 20;
    public float BulletDamage = 10; 
    public void Start()
    {
        maxHP = initialMaxHP;
        BulletDamage = initialBulletDamage;
    }

}

using UnityEngine;

[CreateAssetMenu(fileName = "FoeStat", menuName = "Scriptable Objects/FoeStat")]
public class FoeStat : ScriptableObject
{
    public float initialMaxHP;
    public float initialBulletDamage;
    public float initialBulletSpeed;

    public float maxHP;
    public float BulletDamage; 
    public float bulletSpeed; 
    public void Start()
    {
        maxHP = initialMaxHP;
        BulletDamage = initialBulletDamage;
        bulletSpeed = initialBulletSpeed;
    }

}

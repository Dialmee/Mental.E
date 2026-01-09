using UnityEngine;

[CreateAssetMenu(fileName = "FoeStat", menuName = "Scriptable Objects/FoeStat")]
public class FoeStat : ScriptableObject
{
    public float initialMaxHP = 20;
    public float initialBulletDamage = 10;
    public float initialBulletSpeed = 10;

    public float maxHP;
    public float BulletDamage; 
    public float bulletSpeed; 
    public void Start()
    {
        maxHP = initialMaxHP;
        BulletDamage = initialBulletDamage;
        bulletSpeed = -1*initialBulletSpeed;
    }

}

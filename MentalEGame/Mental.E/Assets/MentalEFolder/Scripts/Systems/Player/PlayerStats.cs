using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float hpMax = 2f;
    public float healthRegeneration = 0.2f;
    public float bulletDamages = 2f;
    public float bulletSpeed = 2f;
    public float bulletRange = 2f;
    public float fireRate = 2f;
    public float moveCd = 2f;
    [Tooltip("0 is forward, 1 is right, 2 is left, 3 is up, 4 is down")] public int[] nbBullets = new int[5] { 1, 0, 0, 0, 0 };

    private int _maxUpBullRange = 3;
    private int _upBullRange = 0;

    public bool upgradeMaxHp()
    {
        hpMax += 2f;
        return true;
    }

    public bool upgradeRegeneration()
    {
        healthRegeneration += 0.1f;
        return true;
    }

    public bool upgradeBullDamage()
    {
        bulletDamages += 1f;
        return true;
    }

    public bool upgradeBullSpeed()
    {
        bulletSpeed += 1f;
        return true;
    }

    public bool upgradeBullRange()
    {
        if (_upBullRange >= _maxUpBullRange)
            return false;

        _upBullRange += 1;
        bulletRange += 20f;
        return true;
    }

    public bool upgradeFireRate()
    {
        fireRate += 1f;
        return true;
    }

    public bool upgradeMoveCd()
    {
        moveCd -= 1f;
        return true;
    }

    public bool upgradeVertBullets()
    {
        int nbVerMax = 3;
        if (nbBullets[3] >= nbVerMax)
            return false;
        nbBullets[0] += 1;
        nbBullets[3] += 1;
        nbBullets[4] += 1;
        return true;
    }

    public bool upgradeHorBullets()
    {
        int nbHorMax = 3;
        if (nbBullets[3] >= nbHorMax)
            return false;
        nbBullets[0] += 1;
        nbBullets[1] += 1;
        nbBullets[2] += 1;
        return true;
    }
}

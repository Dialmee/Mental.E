using System.Collections.Generic;
using UnityEngine;
public class FoeShooting : MonoBehaviour
{
    [SerializeField] private FoeStat foeStats;
    [SerializeField] private FoeManager foeManager;
    [SerializeField] private SpawnAxe spawnAxe;
    [SerializeField] private LayerMask layerMask;
    private float fDamageInitial;
    private float fTimer = 0f;
    //private float fDamageInitial = 5;
    private void Start()
    {

        fDamageInitial = foeStats.BulletDamage;
    }
    private void Update()
    {
        if (spawnAxe.playerManager.playerMouvement.getiAxe() == spawnAxe.iAxe && !foeManager.bIsDead)
        {
            Transform transform = spawnAxe.WhatFoe(false, layerMask);
            fTimer += Time.deltaTime;
            if (transform != null)
            {
                if (fTimer > spawnAxe.playerManager.ps.fireRate)
                {
                    Shoot();
                    fTimer = 0f;
                }
                if (fDamageInitial != spawnAxe.playerManager.ps.bulletDamages * 0.5f)
                {
                    foreach (GameObject projectile in spawnAxe.GO_Projectil)
                    {
                        projectile.GetComponent<FoeProjectil>().iDamage = Mathf.RoundToInt(Mathf.Floor(fDamageInitial));
                    }
                }
            }
        }
        else if (foeManager.bIsDead)
        {
            bool bisActive = false;
            for (int i = 0; i < spawnAxe.GO_Projectil.Count; i++)
            {
                if (spawnAxe.GO_Projectil[i].activeInHierarchy)
                {
                    bisActive = true;
                }
            }
        }
    }
    private void Shoot()
    {
        CheckProjectilEnable();
        spawnAxe.GO_Projectil[spawnAxe.iCurrentProjectil].transform.position = transform.position;
        spawnAxe.GO_Projectil[spawnAxe.iCurrentProjectil].SetActive(true);
        spawnAxe.iCurrentProjectil += 1;
    }
    private void CheckProjectilEnable()
    {
        if (spawnAxe.iCurrentProjectil >= spawnAxe.GO_Projectil.Count && spawnAxe.GO_Projectil[0].activeInHierarchy)
        {
            spawnAxe.GO_Projectil.Add(Instantiate(spawnAxe.GO_Projectil[0], this.transform.position, Quaternion.identity, spawnAxe.ProjectileParent));
        }
        else if (spawnAxe.iCurrentProjectil >= spawnAxe.GO_Projectil.Count)
        {
            spawnAxe.iCurrentProjectil = 0;
        }
    }
}

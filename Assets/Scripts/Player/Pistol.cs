using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SparkGameCore;

public class Pistol : MonoBehaviour, IGunAtritube
{
    [SerializeField] GunType gunType;
    [SerializeField] GameObject gunModel;
    [SerializeField] GameObject firePoint;

    PoolSystem pool;

    public void Init()
    {
        pool = PoolSystem.GetInstance();
        gunModel.SetActive(false);
    }

    public void ActivateGun()
    {
        gunModel.SetActive(true);
    }

    public void DeactivateGun()
    {
        gunModel.SetActive(false);
    }

    public int Fire(BulletMod bulletMod)
    {
        throw new System.NotImplementedException();
    }

    public GunType GetGunType()
    {
        return gunType;
    }

}

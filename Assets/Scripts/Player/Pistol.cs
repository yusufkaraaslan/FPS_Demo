using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SparkGameCore;
using SparkGameCore.MainSystems;

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
        PoolObject poolObject = pool.GetObj("Bullet", firePoint.transform.position, firePoint.transform.rotation);
        
        if (poolObject == null)
        {
            return 0;
        }

        Bullet bullet = (Bullet)poolObject;
        bullet.FireStart(bulletMod);

        return 1;
    }

    public GunType GetGunType()
    {
        return gunType;
    }

}

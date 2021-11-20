using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SparkGameCore.MainSystems;
using SparkGameCore;

public class ShootGun : MonoBehaviour, IGunAtritube
{
    [SerializeField] GunType gunType;
    [SerializeField] GameObject gunModel;
    [SerializeField] GameObject firePoint;

    PoolSystem pool;

    [SerializeField] int bulletCount;
    [SerializeField] float maxAngle, minAngle;

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
        int bulletCounter = 0;
        for (int i = 0; i < bulletCount; i++)
        {
            if (FireBullet(bulletMod))
            {
                ++bulletCounter;
            } 
        }

        return bulletCounter;
    }

    public GunType GetGunType()
    {
        return gunType;
    }

    bool FireBullet(BulletMod bulletMod)
    {
        PoolObject poolObject = pool.GetObj("Bullet", firePoint.transform.position, 
            firePoint.transform.rotation * 
            Quaternion.Euler(Random.Range(minAngle,maxAngle), Random.Range(minAngle, maxAngle), Random.Range(minAngle, maxAngle)));

        if (poolObject == null)
        {
            return false;
        }

        Bullet bullet = (Bullet)poolObject;
        bullet.FireStart(bulletMod);

        return true;
    }

}

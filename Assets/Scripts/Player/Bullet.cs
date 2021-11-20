using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SparkGameCore;
using SparkGameCore.MainSystems;

public class Bullet : PoolObject
{
    BulletState state;
    bool redBullet;
    Material material;
    Color RestartColor;
    Vector3 RestartScale;

    [SerializeField] float MaxLifeTime;
    float CurrLifeEndTime;

    bool delayedExplosion, isDelayStart;
    [SerializeField] float explosionDelatTime;
    float currExplosionTime;

    [SerializeField] float bulletSpeed;

    PoolSystem pool;

    public override void initilaze()
    {
        base.initilaze();
        BulletInit();
    }

    public override void DespawnObj()
    {
        BulletRestart();
        base.DespawnObj();
    }

    public void FireStart(BulletMod bulletMod)
    {
        if (bulletMod.biggerBullet)
        {
            transform.localScale *= 2;
        }

        redBullet = bulletMod.redBullet;
        if (bulletMod.redBullet)
        {
            material.color = Color.red;
        }

        delayedExplosion = bulletMod.delayedExplosion;
        CurrLifeEndTime = Time.time + MaxLifeTime;
        state = BulletState.InAir;
    }

    void OnAir()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        if (Time.time >= CurrLifeEndTime)
        {
            DespawnObj();
        }
    }

    void BulletHit()
    {
        if (delayedExplosion)
        {
            if (!isDelayStart)
            {
                currExplosionTime = Time.time + explosionDelatTime;
                isDelayStart = true;
            }
            else if(Time.time >= currExplosionTime)
            {
                Explode();
            }
        }
        else
        {
            Explode();
        }
    }

    void BulletInit()
    {
        pool = PoolSystem.GetInstance();

        state = BulletState.InPool;
        material = GetComponent<Renderer>().material;

        RestartColor = material.color;
        RestartScale = transform.localScale;
    }

    void BulletRestart()
    {
        transform.localScale = RestartScale;
        material.color = RestartColor;
        isDelayStart = false;
    }

    void Explode()
    {
        pool.GetObj("BulletHit" + (redBullet ? "Red" : ""), transform);
        state = BulletState.InPool;
        DespawnObj();
    }

    private void Update()
    {
        switch (state)
        {
            case BulletState.InAir:
                OnAir();
                break;

            case BulletState.Hit:
                BulletHit();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Bullet")
        {
            state = BulletState.Hit;
        }
    }

}

public enum BulletState
{
    InPool,InAir,Hit
}
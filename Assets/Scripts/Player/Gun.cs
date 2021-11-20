using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject[] Guns;
    List<IGunAtritube> gun;
    IGunAtritube currGun;

    BulletMod bulletMod;
    [SerializeField] CountBoard bulletCount;
    GunType currGunType;

    public void Init()
    {
        //  Convert game object to IGunAtribute
        gun = new List<IGunAtritube>();

        foreach (GameObject item in Guns)
        {
            gun.Add(item.GetComponent<IGunAtritube>());
        }

        //  Init guns
        foreach (IGunAtritube item in gun)
        {
            item.Init();
        }

        currGunType = GunType.Pistol;
    }

    public void ActivateGun()
    {
        currGunType = GunType.Pistol;
        OpenCurrentGun();
    }

    public void DeactivateGun()
    {
        currGun.DeactivateGun();
    }

    public void NextGun()
    {
        //  TODO: use enum size
        if (currGunType == GunType.Shotgun)
        {
            currGunType = GunType.Pistol;
        }
        else
        {
            currGunType += 1;
        }

        OpenCurrentGun();
    }

    public void PrevGun()
    {
        //  TODO: use enum size
        if (currGunType == GunType.Pistol)
        {
            currGunType = GunType.Shotgun;
        }
        else
        {
            currGunType -= 1;
        }

        OpenCurrentGun();
    }

    public void Fire()
    {
        currGun.Fire(bulletMod);
    }

    void OpenCurrentGun()
    {
        if (currGun != null)
        {
            currGun.DeactivateGun();
        }

        foreach (IGunAtritube item in gun)
        {
            if (item.GetGunType() == currGunType)
            {
                item.ActivateGun();
                currGun = item;
                break;
            }
        }
    }

}

public interface IGunAtritube
{
    public void Init();
    public void ActivateGun();
    public void DeactivateGun();
    public int Fire(BulletMod bulletMod);
    public GunType GetGunType();
}

public class BulletMod
{
    public bool delayedExplosion;
    public bool biggerBullet;
    public bool redBullet;
}

public enum GunType
{
    Pistol,Shotgun
}
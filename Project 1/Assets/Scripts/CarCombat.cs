using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls all combat related to the player.
public class CarCombat : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnPt;
    [SerializeField] GameObject bulletPF;

    [SerializeField] float spread = 1f;
    [SerializeField] int bulletCount = 7;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireProj();
        }
    }

    // Fires Projectile
    private void FireProj()
    {
        Quaternion tempRot = bulletSpawnPt.rotation;

        for (int i = 0; i < bulletCount; i++)
        {
            float offset = (i - (bulletCount / 2) * spread);
            tempRot = Quaternion.Euler(bulletSpawnPt.eulerAngles.x, bulletSpawnPt.eulerAngles.y, bulletSpawnPt.eulerAngles.z + offset);

            Instantiate(bulletPF, bulletSpawnPt.position, tempRot);
        }

        //Instantiate(bulletPF, bulletSpawnPt.position, bulletSpawnPt.rotation);
    }
}

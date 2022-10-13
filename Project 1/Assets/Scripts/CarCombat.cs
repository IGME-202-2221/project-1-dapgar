using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controls all combat related to the player.
public class CarCombat : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnPt1;
    [SerializeField] Transform bulletSpawnPt2;

    [SerializeField] GameObject bulletPF;
    [SerializeField] Healthbar healthbar;

    [SerializeField] float spread = 1f;
    [SerializeField] int bulletCount = 7;

    [SerializeField] float health;

    public List<GameObject> bullets = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireProj(bulletSpawnPt1);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            FireProj(bulletSpawnPt2);
        }
    }

    // Fires Projectile
    private void FireProj(Transform bulletSpawnPt)
    {
        Quaternion tempRot = bulletSpawnPt.rotation;

        for (int i = 0; i < bulletCount; i++)
        {
            float offset = (i - (bulletCount / 2) * spread);
            tempRot = Quaternion.Euler(bulletSpawnPt.eulerAngles.x, bulletSpawnPt.eulerAngles.y, bulletSpawnPt.eulerAngles.z + offset);

            bullets.Add(Instantiate(bulletPF, bulletSpawnPt.position, tempRot));
        }

        //Instantiate(bulletPF, bulletSpawnPt.position, bulletSpawnPt.rotation);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }

        healthbar.SetHealth(health);
    }
}

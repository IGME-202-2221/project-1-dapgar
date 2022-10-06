using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls all projectile behavior
public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] float projSpeed;
    [SerializeField] int projDamage;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * projSpeed * Time.deltaTime);

        Destroy(gameObject, 4f);
    }
}

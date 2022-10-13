using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] Slider healthbar;

    public float hp;

    public void SetHealth(float health)
    {
        hp = health;
        healthbar.value = health;
    }
}

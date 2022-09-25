using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls all effects related to the car.
public class CarEffects : MonoBehaviour
{
    //----Variables----
    [Header("Script Variables")]
    [SerializeField] CarMovement carMovement;

    [Header("Trail Variables")]
    [SerializeField] TrailRenderer leftTireTrail;
    [SerializeField] TrailRenderer rightTireTrail;
    [SerializeField] ParticleSystem leftSmoke;
    [SerializeField] ParticleSystem rightSmoke;

    ParticleSystem.EmissionModule leftEM;
    ParticleSystem.EmissionModule rightEM;

    //----Methods----
    private void Start()
    {
        leftEM = leftSmoke.emission;
        rightEM = rightSmoke.emission;
    }

    // Update is called once per frame
    void Update()
    {
        EffectCheck();
    }

    // Checks drifting bool to activate skidmarks
    void EffectCheck()
    {
        if (carMovement.isDriftingRight || carMovement.isDriftingLeft)
        {
            leftTireTrail.emitting = true;
            rightTireTrail.emitting = true;

            leftEM.enabled = true;
            rightEM.enabled = true;;
        }
        else
        {
            leftTireTrail.emitting = false;
            rightTireTrail.emitting = false;

            leftEM.enabled = false;
            rightEM.enabled = false;
        }
    }
}

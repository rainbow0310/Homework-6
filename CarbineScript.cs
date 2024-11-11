using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbineScript : MonoBehaviour
{
    [SerializeField] Camera FPCamera; // FP = first person
    [SerializeField] float shootRange = 10f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) { 
            Shoot();
        }
    }
    private void PlayMuzzleFlash(){
        muzzleFlash.Play();
    }

    private void Shoot() {
            PlayMuzzleFlash();
            RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position,FPCamera.transform.forward, out hit , shootRange)) { 
            CreateHitImpact(hit);
           if (hit.collider.CompareTag("Enemy")) {
            Debug.Log("I hit an enemy!");
            }  
            else {
            Debug.Log("I hit an object!");
            }
        }
        else {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit) { 
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }
}

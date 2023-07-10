using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    public float timeBetweenFiring;
    private Camera mainCam;
    private Vector3 mousePos;
    private float timer;
    void Start()
    { 
        mainCam = Camera.main;
    }
    private void Update()
    {
        ApplyWeaponRotation();
        TryCalculateDelayBetweenFiring();
        TryShoot();
    }
    private void TryShoot()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
    private void TryCalculateDelayBetweenFiring()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
    }
    private void ApplyWeaponRotation()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}

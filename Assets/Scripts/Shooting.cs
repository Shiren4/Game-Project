using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public float timeBetweenFiring;
    private Camera mainCam;
    private float timer;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        ApplyWeaponRotation();
        TryShoot();
        TryCalculateDelayBetweenFiring();
    }

    private void TryShoot()
    {
        if (Input.GetMouseButton(0) && timer <= 0)
        {
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            timer = timeBetweenFiring;
        }
    }

    private void TryCalculateDelayBetweenFiring()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void ApplyWeaponRotation()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
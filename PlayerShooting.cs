using System.Collections;
using UnityEngine;
using TMPro;
public class PlayerShooting : MonoBehaviour
{
    public Transform bulletPoint;
    public float damage = 10f;
    public float range = 100f;
    public GameObject impactEffect;

    [Header("Ammo Settings")]
    [SerializeField] private int maxAmmo = 10;
    public int magazine = 30;
    public int ammo { get; private set; }
    bool isReloading = false;

    [Header("UI")]
    public TextMeshProUGUI ammoText;


    void Start()
    {
        ammo = maxAmmo;
        UpdateAmmoUI();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isReloading)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(ReloadDelay());
            Reload();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletPoint.transform.position, bulletPoint.transform.forward, out hit, range))
        {
            StartCoroutine(FireRate());
            Target target = hit.transform.GetComponent<Target>();

            if (ammo > 0 && magazine >= 0)
            {
                ammo--;
                UpdateAmmoUI();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGo, 2f);
            }
        }
    }

    void Reload()
    {
        if (magazine > 0 && ammo < maxAmmo)
        {
            int needed = maxAmmo - ammo;
            int taken = Mathf.Min(needed, magazine);
            ammo += taken;
            magazine -= taken;
            UpdateAmmoUI();
        }
    }

    IEnumerator ReloadDelay()
    {
        isReloading = true;
        yield return new WaitForSeconds(2.10f);
        isReloading = false;

    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(0.11f);
    }

    void UpdateAmmoUI()
    {
        if (ammoText != null)
        {
            ammoText.text = ammo + "/" + magazine;
        }
    }
}

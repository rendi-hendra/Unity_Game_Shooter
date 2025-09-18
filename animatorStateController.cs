using System.Collections;
using UnityEngine;

public class animatorStateController : MonoBehaviour
{
    Animator animator;
    public GameObject muzzleFlashObject;
    int ammo;
    int magazine;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerShooting playerShooting = GetComponentInParent<PlayerShooting>();
        ammo = playerShooting.ammo;
        magazine = playerShooting.magazine;

        if (Input.GetButtonDown("Fire1") && animator.GetBool("isShooting") && ammo > 1)
        {
            ammo--;
            Debug.Log(ammo);
            animator.SetTrigger("Fire");
            StartCoroutine(ShowMuzzleFlash());
        }

        else if (Input.GetButtonDown("Fire1") && animator.GetBool("isShooting") && ammo > 0 && ammo <= 1)
        {
            animator.SetBool("FireLast", true);
        }

        else
        {
            animator.SetBool("FireLast", false);
            animator.ResetTrigger("Fire");
        }

        if (Input.GetKeyDown(KeyCode.R) && magazine > 0 && ammo < 10)
        {
            animator.SetTrigger("Reload");
            StartCoroutine(Reload());
        }

    }

    IEnumerator Reload()
    {
        animator.SetBool("isShooting", false);
        yield return new WaitForSeconds(2.10f);
        animator.SetBool("isShooting", true);

    }

    IEnumerator ShowMuzzleFlash()
    {
        muzzleFlashObject.SetActive(true);
        yield return new WaitForSeconds(0.11f);
        muzzleFlashObject.SetActive(false);
    }
}

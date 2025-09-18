using UnityEngine;

public class Scope : MonoBehaviour
{
    Animator animator;
    private bool IsScoped = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            IsScoped = !IsScoped;
            animator.SetBool("Scoped", IsScoped);
        }
    }
}

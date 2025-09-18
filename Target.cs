using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public TextMeshPro textHealth;
    public Image healthBar;
    public Canvas healthCanvas;
    public Camera cam;

    void Update()
    {
        healthCanvas.transform.rotation = Quaternion.LookRotation(textHealth.transform.position - cam.transform.position);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.rectTransform.localScale = new Vector3(health / 50f, 1f, 1f);
        textHealth.text = health.ToString();
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

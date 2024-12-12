using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    private SceneManagement sceneChange;

    [Header("Sound")]
    [SerializeField] private AudioSource deathSFX;
    [SerializeField] private AudioSource hitSFX;

    [Header("UI Kalah")] //UI Menang Ada di Objective Counter
    [SerializeField] private GameObject uiKalah;

    [Header("Change Scene")] // Scene yang bakal dituju
    [SerializeField] private string NamaScene;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        uiKalah.SetActive(false);
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            hitSFX.Play();
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("Death");
                deathSFX.Play();
                GetComponent<Movement>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                dead = true;
                uiKalah.SetActive(true);
                Invoke("ChangeScene", 3f);
            }
        }
    }
    public void AddHealth(float _value)
    {
        if (currentHealth <= startingHealth)
        {
            currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
        }    
    
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(13, 14, true);
        //Debug.Log("Immune");
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Debug.Log("Immune Habis");
        Physics2D.IgnoreLayerCollision(13, 14, false);
    }

    private void ChangeScene()
    {
        SceneManagement.changeScene.ChangeScene(NamaScene);
    }
}

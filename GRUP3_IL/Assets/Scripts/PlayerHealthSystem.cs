using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;

public class PlayerHealthSystem : MonoBehaviour
{
    private bool isInvicible = false;
    private int maxHealth = 3;
    [SerializeField] int currentHealth;
    [SerializeField] CheckPointSystem checkPointSystem;
    [SerializeField] CinemachineVirtualCamera cinemachineCamera;
    public Image[] healthImage;
    public Sprite lostLifeSprite;
    Collider2D playerCollider;
    SpriteRenderer playerSprite;




    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int _damage)
    {
        if (currentHealth > 0 && !isInvicible)
        {
            isInvicible = true;
            playerSprite.DOColor(Color.red, 0.5f).SetLoops(3, LoopType.Yoyo).onStepComplete = () =>
            {
                playerSprite.color = Color.white;
                isInvicible = false;
            };
            healthImage[currentHealth - 1].sprite = lostLifeSprite;
            currentHealth -= _damage;
            // playerCollider.isTrigger = true;
            transform.position = checkPointSystem.currentCheckpoint.position;
            Debug.Log("Damage Taken | CurrentHealth :  " + currentHealth);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image playerHealth;
    public Text healthText;
    private float maxHealth;
    private int currentHealth;

    void Start()
    {
        maxHealth = GetComponent<Player>().MaxHP;
        currentHealth = GetComponent<Player>().HP;
        healthText.text = currentHealth + "/" + maxHealth;

        print("最大血量為：" + maxHealth);
        print("目前血量為：" + currentHealth);
    }

    void TakeDamge(int damage)
    {
        if(Input.GetKeyDown(KeyCode.H) && currentHealth > 0)
        {
            currentHealth -= damage;
            playerHealth.fillAmount = currentHealth / maxHealth;
            healthText.text = currentHealth + "/" + maxHealth;


            print("你被扣了25滴血");
            print("目前血量為：" + currentHealth);

            if(currentHealth <= 0)
            {
                Death();
            }
        }
    }

    void Death()
    {
        healthText.text = 0 + "/" + maxHealth;
        print("你已經死亡！");
        print("目前血量為：" + currentHealth);
    }

    void Update()
    {
        TakeDamge(150);
    }
}
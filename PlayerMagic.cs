using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagic : MonoBehaviour
{
    public Image playerMagic;
    public Text magicText;
    private float maxMagic;
    private int currentMagic;

    //自動恢復魔力
    private float time;


    void Start()
    {
        maxMagic = GetComponent<Player>().MaxMP;
        currentMagic = GetComponent<Player>().MP;
        magicText.text = currentMagic + "/" + maxMagic;

        print("最大魔力量：" + maxMagic);
        print("目前魔力量：" + currentMagic);
    }


    void TakeMagic(int amount)
    {
        if (Input.GetKeyDown(KeyCode.J) && currentMagic > 0)
        {
            currentMagic -= amount;
            playerMagic.fillAmount = currentMagic / maxMagic;
            magicText.text = currentMagic + "/" + maxMagic;

            print("你被扣了35滴魔力");
            print("目前魔力量" + currentMagic);

            if (currentMagic <= 0)
            {
                print("你已經沒有魔力");
            }
        }
    }

    //自動恢復魔力 TODO:魔力回覆會超過Max;
    void RestoreMagic()
    {
        if(currentMagic <= maxMagic)
        {
            currentMagic += 15;
            print("你已經恢復15滴魔力");
            playerMagic.fillAmount = currentMagic / maxMagic;
            magicText.text = currentMagic + "/" + maxMagic;
            time = 0;
        }
    }

    void Update()
    {
        TakeMagic(35);

        time += Time.deltaTime;
         if(time >= 5 && currentMagic <= maxMagic)
        {
            RestoreMagic();
        }
    }
}

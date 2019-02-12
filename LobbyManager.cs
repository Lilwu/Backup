using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public TextMesh playerName;

    public void EnterPlayerName(Text enterName)
    {
        playerName.text = enterName.text;
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Town");

        print("恭喜創建角色！");
        print("您的角色名稱為");
    }
}
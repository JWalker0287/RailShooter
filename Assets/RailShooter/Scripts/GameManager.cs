using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int ringsPassed = 0;
    public static GameManager game;
    public Text ringText;
    void Awake()
    {
        game = this;
    }

    void Update()
    {
        ringText.text = ringsPassed.ToString();
    }
}

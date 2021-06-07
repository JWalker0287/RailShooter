using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGameManager : MonoBehaviour
{
    GameManager game;
    void Start()
    {
        game = FindObjectOfType<GameManager>();
        if (game != null) Destroy(game.gameObject);
    }

}

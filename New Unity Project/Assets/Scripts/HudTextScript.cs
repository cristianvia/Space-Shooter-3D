using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudTextScript : MonoBehaviour
{
    //public Transform playerScore;
    public PlayerMovement myPlayerMovement;
    public Text hudText;
    PlayerMovement player;
    // Update is called once per frame
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        string hud = "Score: " + player.score.ToString("0") + "\n" +
            "HP: " + myPlayerMovement.life + "\n" +
            "Ammo: " + myPlayerMovement.ammo;
        hudText.text = hud;
        //hudText.text = playerPosition.position.z.ToString("0");
    }
}

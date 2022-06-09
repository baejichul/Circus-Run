using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigManager : MonoBehaviour
{
    // Path
    public string defaultResourceArtPath { get; set; } = "Art";
    public string defaultResourceGUIPath { get; set; } = "GUI";
    public string defaultResourceSoundPath { get; set; } = "Sound";

    // Score
    public string txtScoreNumber { get; set; } = "TxtScoreNumber";
    public string txtLastScoreNumber { get; set; } = "TxtLastScoreNumber";

    // AudioSource
    public string audSrcIntro { get; set; } = "Intro";
    public string audSrcPlay { get; set; } = "Play";
    public string audSrcJump { get; set; } = "Jump";
    public string audSrcLand { get; set; } = "Land";
    public string audSrcDie { get; set; } = "Die";
    public string audSrcCoin { get; set; } = "Coin";
    public string audSrcEnd { get; set; } = "End";

    // Scene
    public string mainSceneName { get; set; } = "CircusRun";

    // Player
    public Vector3 playerInitPos { get; set; } = new Vector3(-6.1f, -1.75f, 0);
    public float playerMovePosX { get; set; } = 0.01f;    
    public float playerMinPosX { get; set; } = -6.9f;
    public float playerMaxPosX { get; set; } = 7.1f;
    public Vector2 playerAddForce { get; set; } = new Vector2(0.0f, 75.0f);
    public float playerAddVelocity { get; set; } = 8.0f;

    // Hudle
    public float hudleMovePosX { get; set; } = 0.01f;
    public float hudleMinPosX { get; set; } = -25.0f;



}

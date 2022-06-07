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
    public Vector3 playerInitPos { get; set; } = new Vector3(-6.1f, -2.036812f, 0);
}

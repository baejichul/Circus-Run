using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudleFireRing : HudleManager
{
    protected override void Start()
    {
        _cfg = FindObjectOfType<ConfigManager>();
        _defaultHudlePosX = transform.parent.transform.position;
    }

    protected override void Update()
    {
        moveHudlePosX(transform.parent);
    }

    
}

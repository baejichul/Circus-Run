using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFireRing : CollisionManager
{
    protected override void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
        _defaultHudlePosX = transform.parent.transform.position;
    }

    protected override void Update()
    {
        moveHudlePosX(transform.parent);
    }

    
}

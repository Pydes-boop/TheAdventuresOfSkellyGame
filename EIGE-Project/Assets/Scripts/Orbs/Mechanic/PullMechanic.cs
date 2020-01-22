﻿using UnityEngine;

public class PullMechanic : OrbMechanic
{
    private GameObject hook;
    private GameObject current;

    private int cur = 0, cooldown = 20;

    public PullMechanic(GameObject hook)
    {
        this.hook = hook;
    }

    public override void holdingUpdate(PlayerManager player)
    {
        if (current == null && (Input.GetMouseButton(0) || Input.GetKey(KeyCode.LeftShift)) && cur <= 0)
        {
            Vector2 direction = Input.mousePosition;
            direction = Camera.main.ScreenToWorldPoint(direction);
            direction = (direction - (Vector2)player.transform.position).normalized;
            current = Object.Instantiate(hook, player.transform.position, Quaternion.Euler(0, 0, -Mathf.Atan2(direction.x / 2, direction.y / 2) * Mathf.Rad2Deg));
            current.GetComponent<HookBehavior>().origin = player;
            cur = cooldown;
        }
        if (current != null && !(Input.GetMouseButton(0) || Input.GetKey(KeyCode.LeftShift)))
        {
            Object.Destroy(current);
            current = null;
        }
        
        if (cur > 0) cur--;
    }

    public override void onPickup(PlayerManager player)
    {

    }

    public override void holdingFixedUpdate(PlayerManager player)
    {

    }

    public override void onDrop(PlayerManager player)
    {

    }
}

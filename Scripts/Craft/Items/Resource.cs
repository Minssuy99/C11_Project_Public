using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Resource : Item
{
    public ResourceType type;

    public override void Interaction()
    {
        PlayerController player = CharacterManager.Instance._player.controller;
        player.inventory.GetItem(this);
        Destroy(gameObject);
        player.interactionObject = null;
    }
}

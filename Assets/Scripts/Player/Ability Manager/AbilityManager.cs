using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    Transform player;

    public List<AbilitySO> abilities;

    List<AbilityTimer> activeAbility = new();
    private void Start()
    {
        player = GetComponentInChildren<Transform>();

        foreach (var w in abilities)
        {
            activeAbility.Add(new AbilityTimer {ability = w});
        }
    }

    private void Update()
    {
        foreach (var w in activeAbility)
        {
            w.Tick(player, Time.deltaTime);
        }
    }
}

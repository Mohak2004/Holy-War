using Unity.VisualScripting;
using UnityEngine;

public class AbilityTimer
{
    public AbilitySO ability;
    float timer = 0;

    public void Tick(Transform player, float time)
    {
        timer += time;

        if (timer > ability.cooldown)
        {
            ability.Activate(player);
            timer = 0;
        }
    }
}

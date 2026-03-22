using UnityEngine;

[CreateAssetMenu(fileName = "AbilitySO", menuName = "Scriptable Objects/AbilitySO")]
public abstract class AbilitySO : ScriptableObject
{
    public string a_name;
    public string description;
    public float cooldown;
    public float damage;
    public float knockback;

    public abstract void Activate(Transform owner);
}

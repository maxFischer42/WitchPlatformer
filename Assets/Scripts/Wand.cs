using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wand", menuName = "Weapons/Wand", order = 1)]
public class Wand : ScriptableObject
{
    public Element magicEffect;
    public int wandHealth;
    public float attackRate;
    public GameObject prefabToSpawn;
    public float timeTillDeSpawn;
    public float Speed;
}

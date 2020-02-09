using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FinnModel", menuName = "Characters/Finn model")]
public class FinnModel : CharacterModel
{
    public float verticalImpulse = 1f;
    public float horizontalSpeedAirFactor = 0.5f;
    public float ladderSpeed = 0.3f;
}

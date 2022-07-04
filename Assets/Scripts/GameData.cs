using System.Collections.Generic;
using StateMachine;
using UnityEngine;
[CreateAssetMenu(fileName = "Game Data", menuName = "Create Game Data", order = 0)]
public class GameData : ScriptableObject
{
    public float DurationTime;
    public float AimFOV;
    public float PersonFOV;
    public float RotationFactor;
    public float WeaponSoundSphereRadius;
    public List<EnemyStateMachine> Enemies = new List<EnemyStateMachine>();
    public float AdditionalRotationForce;
}
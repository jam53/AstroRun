using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerMovement", menuName = "PlayerMovement")]
public class PlayerMovement : ScriptableObject
{
    [Header("Parameters for RigidBody2D")]
    public float linearDrag;
    public float gravityScale;

    [Header("Parameters for PlatformerCharacter2D")]
    public float maxSpeed;
    public float jumpForce;
}

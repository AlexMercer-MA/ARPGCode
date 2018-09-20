using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : ActorMain
{
    public PlayerAnimation PlayerAnimation { get; set; }
    public PlayerBehaviour PlayerBehaviour { get; set; }
    public PlayerPropertyBasic PlayerPropertyBasic { get; set; }
    public PlayerPropertyExtra PlayerPropertyExtra { get; set; }
    public PlayerProperty PlayerProperty { get; set; }
    public PlayerAction PlayerAction { get; set; }
    public PlayerCombat PlayerCombat { get; set; }
    public PlayerEffect PlayerEffect { get; set; }
    
    public PlayerInput PlayerInput { get; set; }
    public CharacterController CharacterController { get; set; }

    private void Initiallized()
    {
        base.ActorAction = PlayerAction;
        base.ActorBehaviour = PlayerBehaviour;
        base.ActorPropertyBasic = PlayerPropertyBasic;
        base.ActorPropertyExtra = PlayerPropertyExtra;
        base.ActorProperty = PlayerProperty;
        base.ActorAction = PlayerAction;
        base.ActorCombat = PlayerCombat;
        base.ActorEffect = PlayerEffect;
    }

}
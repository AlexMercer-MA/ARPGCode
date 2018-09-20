using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActorBehaviour))]
[RequireComponent(typeof(ActorPropertyBasic))]
[RequireComponent(typeof(ActorPropertyExtra))]
[RequireComponent(typeof(ActorProperty))]
[RequireComponent(typeof(ActorAction))]
[RequireComponent(typeof(ActorAnimation))]

public abstract class ActorMain : MonoBehaviour {
    [HideInInspector]
    public ActorAnimation ActorAnimation { get; set; }
    [HideInInspector]
    public ActorBehaviour ActorBehaviour { get; set; }
    [HideInInspector]
    public ActorPropertyBasic ActorPropertyBasic { get; set; }
    [HideInInspector]
    public ActorPropertyExtra ActorPropertyExtra { get; set; }
    [HideInInspector]
    public ActorProperty ActorProperty { get; set; }
    [HideInInspector]
    public ActorAction ActorAction { get; set; }
    [HideInInspector]
    public ActorCombat ActorCombat { get; set; }
    [HideInInspector]
    public ActorEffect ActorEffect { get; set; }
}

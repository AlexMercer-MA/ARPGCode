using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActorBehaviour))]
[RequireComponent(typeof(ActorPropertiesBase))]
[RequireComponent(typeof(ActorPropertiesExtra))]
[RequireComponent(typeof(ActorPropertiesFinal))]
[RequireComponent(typeof(ActorAction))]
[RequireComponent(typeof(ActorAnimation))]

public class ActorMain : MonoBehaviour {
    public ActorBehaviour Behaviour { get; set; }
    public ActorPropertiesBase PropertiesBase { get; set; }
    public ActorPropertiesExtra PropertiesExtra { get; set; }
    public ActorPropertiesFinal PropertiesFinal { get; set; }
    public ActorAction Action { get; set; }
    public ActorAnimation Animation { get; set; }
}

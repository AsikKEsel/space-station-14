﻿using Content.Shared.FixedPoint;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Shared.Medical.Wounds.Components;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class WoundComponent : Component
{
    [AutoNetworkedField] public EntityUid ParentWoundable;

    [DataField("scarWound", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>)), AutoNetworkedField]
    public string? ScarWound;

    [DataField("hpDamage"), AutoNetworkedField]
    public FixedPoint2 HitpointDamage;

    [DataField("intDamage"), AutoNetworkedField]
    public FixedPoint2 IntegrityDamage;

    [DataField("severity"), AutoNetworkedField]
    public FixedPoint2 Severity = 100;

    //How many severity points per woundTick does this part heal passively
    [DataField("baseHealingRate"), AutoNetworkedField]
    public FixedPoint2 BaseHealingRate;

    //How many severity points per woundTick does this part heal ontop of the base rate
    [DataField("healingModifier"), AutoNetworkedField]
    public FixedPoint2 HealingModifier;

    //How much to multiply the Healing modifier
    [DataField("healingMultiplier"), AutoNetworkedField]
    public FixedPoint2 HealingMultiplier;

    [DataField("canHeal"), AutoNetworkedField]
    public bool CanHeal = true;

    [DataField("canHealInt"), AutoNetworkedField]
    public bool CanHealInt;
}

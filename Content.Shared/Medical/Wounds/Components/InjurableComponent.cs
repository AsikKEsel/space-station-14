﻿using Content.Shared.FixedPoint;
using Content.Shared.Medical.Wounds.Prototypes;
using Content.Shared.Medical.Wounds.Systems;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype.Set;

namespace Content.Shared.Medical.Wounds.Components;

[RegisterComponent, NetworkedComponent]
[Access(typeof(InjurySystem))]
public sealed class InjurableComponent : Component
{
    [DataField("injuries")] public List<Injury>? Injuries;

    [DataField("allowedTraumaTypes", customTypeSerializer: typeof(PrototypeIdHashSetSerializer<TraumaPrototype>))]
    public HashSet<string>? AllowedTraumaTypes;

    [DataField("traumaResistance")] public TraumaModifierSet? TraumaResistance;

    [DataField("traumaPenResistance")] public TraumaModifierSet? TraumaPenResistance;

    //How much health does this woundable have, when this reaches 0, it starts taking structural damage
    [DataField("maxHealth", required: true)]
    public FixedPoint2 MaxHealth;

    //How much health does this woundable have, when this reaches 0, it starts taking structural damage
    [DataField("health", required: true)] public FixedPoint2 Health;

    //How well is this woundable holding up, when this reaches 0 the entity is destroyed/gibbed!
    [Access(typeof(InjurySystem))] [DataField("maxStructure", required: true)]
    public FixedPoint2 MaxStructure;

    //How well is this woundable holding up, when this reaches 0 the entity is destroyed/gibbed!
    [Access(typeof(InjurySystem))] [DataField("structure", required: true)]
    public FixedPoint2 StructuralPool;
}

[DataRecord, NetSerializable, Serializable]
public record struct Injury(string InjuryId, FixedPoint2 Healed, FixedPoint2 Bleed)
{
    public Injury(string injuryId) : this(injuryId, FixedPoint2.Zero, FixedPoint2.Zero)
    {
    }
}

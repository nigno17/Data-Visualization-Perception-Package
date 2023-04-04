using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Perception.Randomization.Samplers;

[RequireComponent(typeof(Light))]
// Add this Component to any GameObject that you would like to be randomized. This class must have an identical name to
// the .cs file it is defined in.
public class CustomLightRandomizerTag : RandomizerTag {}

[Serializable]
[AddRandomizerMenu("CustomLightRandomizer")]
public class CustomLightRandomizer : Randomizer
{
    // Sample FloatParameter that can generate random floats in the [0,1) range. The range can be modified using the
    // Inspector UI of the Randomizer.
    public FloatParameter myIntensity = new()
    {
        value = new UniformSampler(0, 1)
    };
    public ColorRgbParameter myColor;

    protected override void OnIterationStart()
    {
        var tags = tagManager.Query<CustomLightRandomizerTag>();
        foreach (var tag in tags)
        {
            Light tagLight = tag.GetComponent<Light>();
            tagLight.intensity = myIntensity.Sample();
            tagLight.color = myColor.Sample();
        }
    }
}

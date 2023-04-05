using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Perception.Randomization.Samplers;

[Serializable]
[AddRandomizerMenu("SpawnObjectRandomizer")]
public class SpawnObjectRandomizer : Randomizer
{
    public CategoricalParameter<GameObject> prefabs;

    public Vector3Parameter spawnPos;

    private GameObject activeGO;

    protected override void OnIterationStart()
    {
        if (prefabs is not null)
        {
            activeGO = GameObject.Instantiate(prefabs.Sample(), spawnPos.Sample(), Quaternion.identity);
        }
    }

    protected override void OnIterationEnd()
    {
        GameObject.Destroy(activeGO);
        base.OnIterationEnd();
    }
}

using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Perception.Randomization.Samplers;

[Serializable]
[AddRandomizerMenu("SpawnObjectRandomizer")]
public class SpawnObjectRandomizer : Randomizer
{
    public GameObject [] ObjectsList;

    public Vector3 spawnPos = Vector3.zero;

    private GameObject activeGO;

    protected override void OnIterationStart()
    {
        if (ObjectsList.Length > 0)
        {
            activeGO = GameObject.Instantiate(ObjectsList[UnityEngine.Random.Range(0, ObjectsList.Length)], spawnPos, Quaternion.identity);
        }
    }

    protected override void OnIterationEnd()
    {
        GameObject.Destroy(activeGO);
        base.OnIterationEnd();
    }
}

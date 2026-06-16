using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSpawnZone : MonoBehaviour
{
    public Vector3 GenerateRandomVector3()
    {
        var nextTransform = transform.position;

        nextTransform.x = (UnityEngine.Random.Range(transform.position.x - transform.
        localScale.x * 0.5f, transform.position.x + transform.localScale.x * 0.5f));

        nextTransform.y = (UnityEngine.Random.Range(transform.position.y - transform.
        localScale.y * 0.5f, transform.position.y + transform.localScale.y * 0.5f));

        nextTransform.z = (UnityEngine.Random.Range(transform.position.z - transform.
        localScale.z * 0.5f, transform.position.z + transform.localScale.z * 0.5f));

        return nextTransform;
    }
}

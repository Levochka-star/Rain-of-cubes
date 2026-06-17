using Assets.Scripts;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _power = 25f;
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _upwardsModifier = 2f;

    private ForceMode _explosion = ForceMode.Impulse;

    public void Work(Vector3 explosionPosition)
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, _radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_power, explosionPosition, _radius, _upwardsModifier, _explosion);
            }
        }
    }
}
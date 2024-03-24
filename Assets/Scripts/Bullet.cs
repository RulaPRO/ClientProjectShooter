using Characters;
using Core.Services.Character.Implementation;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private int damage;
    private Quaternion direction;
    private float range;
    private CharacterFractionType ownerFraction;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    public Bullet SetOwnerFraction(CharacterFractionType fraction)
    {
        ownerFraction = fraction;

        return this;
    }

    public Bullet SetDirection(Quaternion value)
    {
        direction = value;

        return this;
    }

    public Bullet SetSpeed(float value)
    {
        speed = value;

        return this;
    }

    public Bullet SetDistance(float value)
    {
        range = value;

        return this;
    }

    public Bullet SetDamage(int value)
    {
        damage = value;

        return this;
    }

    private void Update()
    {
        transform.Translate(direction * Vector3.forward * speed * Time.deltaTime);
        if (Vector3.Distance(startPosition, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            if (ownerFraction != damageable.Fraction)
            {
                damageable.ApplyDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
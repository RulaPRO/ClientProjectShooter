using System;
using Characters;
using UnityEngine;

public class CharactersChecker : MonoBehaviour
{
    public Action<CharacterView> OnEnemyEnterInRange;
    public Action<CharacterView> OnEnemyExitFromRange;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerCharacterView>(out var component))
        {
            OnEnemyEnterInRange?.Invoke(component);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerCharacterView>(out var component))
        {
            OnEnemyExitFromRange?.Invoke(component);
        }
    }
}
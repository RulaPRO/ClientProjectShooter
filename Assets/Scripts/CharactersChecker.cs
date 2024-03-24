using System;
using Characters;
using UnityEngine;

public class CharactersChecker : MonoBehaviour
{
    public Action<GameObject> OnEnemyInRange;
    
    private void OnTriggerStay(Collider other)
    {
        //Debug.LogError(other.name);
        
        if (other.TryGetComponent<PlayerCharacterView>(out var component))
        {
            
            
            //Debug.LogError("KEK");
            OnEnemyInRange?.Invoke(other.gameObject);
        }
    }
}
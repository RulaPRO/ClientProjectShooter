using Core.Services.Character.Interfaces;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    private ICharacterService characterService;

    [Inject]
    public void Construct(ICharacterService characterService)
    {
        this.characterService = characterService;
    }

    private void Start()
    {
        var spawnEnemy = characterService.SpawnEnemy(gameObject.transform.position);
        spawnEnemy.CharacterView.transform.SetParent(transform);
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Core.Services.Character.Interfaces
{
    public interface ICharacterService
    {
        Dictionary<string, ICharacter> Characters { get; }
        ICharacter Player { get; }
        ICharacter SpawnPlayer(Vector3 position);
        ICharacter SpawnEnemy(Vector3 position);
    }
}
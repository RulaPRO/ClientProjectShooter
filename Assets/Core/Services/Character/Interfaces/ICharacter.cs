using Characters;
using UnityEngine;

namespace Core.Services.Character.Interfaces
{
    public interface ICharacter
    {
        string Sid { get; }
        CharacterView CharacterView { get; }
        IHealthService HealthService { get; }

        ICharacter SetView(CharacterView characterView);
        ICharacter SetPosition(Vector3 value);
    }
}
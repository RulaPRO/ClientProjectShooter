using Characters;
using Core.Services.Character.Implementation;
using UnityEngine;

namespace Core.Services.Character.Interfaces
{
    public interface ICharacter
    {
        string Sid { get; }
        CharacterFractionType Fraction { get; }
        CharacterView CharacterView { get; }
        IHealthService HealthService { get; }

        ICharacter SetFraction(CharacterFractionType characterView);
        ICharacter SetView(CharacterView characterView);
        ICharacter SetPosition(Vector3 value);
    }
}
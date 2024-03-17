using System.Collections.Generic;

namespace Core.Services.Character.Interfaces
{
    public interface ICharacterService
    {
        Dictionary<string, ICharacter> Characters { get; }
    }
}
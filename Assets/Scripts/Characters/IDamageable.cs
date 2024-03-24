using Core.Services.Character.Implementation;

namespace Characters
{
    public interface IDamageable
    {
        CharacterFractionType Fraction { get; }
        void ApplyDamage(int value);
    }
}
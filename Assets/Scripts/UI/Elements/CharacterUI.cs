using UnityEngine;

namespace UI.Elements
{
    public class CharacterUI : MonoBehaviour
    {
        [SerializeField] private HealthBarUI healthBarUI;

        public void Initialize(string id)
        {
            healthBarUI.Initialize(id);
        }
    }
}
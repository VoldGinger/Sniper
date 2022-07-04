using CustomInputSystem;
using UnityEngine;
namespace Health
{
    public class PlayerHealth : Damageable
    {
        [SerializeField] private PlayerHealthView _playerHealthView;
        
      
        public override void MakeDamage(int damage)
        {
            _health -= damage;
            _playerHealthView.SetHp(_health);

            if (_health <= 0)
            {
                EventSystem.InvokeEvent(EventSystem.OnHealthEnded);
            }
            
        }
    }
}

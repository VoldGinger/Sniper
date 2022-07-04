using UnityEngine;
namespace Health
{
    public abstract class Damageable : MonoBehaviour
    {
        protected int _health = 7;
       public abstract void MakeDamage(int damage);
        

    }
}

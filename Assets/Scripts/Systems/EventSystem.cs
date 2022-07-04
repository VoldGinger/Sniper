using System;
namespace CustomInputSystem
{
    public static class EventSystem
    {
        public static Action OnAimButtonDown;
        public static Action OnAimButtonUp;
        public static Action<int> OnShooted;
        public static Action OnBulletsEnded;
        public static Action Win;
        public static Action Lose;
        public static Action OnEnemyEnded;
        public static Action OnHealthEnded;
        public static void InvokeEvent(Action action)
        {
            action?.Invoke();
        }
        public static void InvokeEvent(Action<int> action, int value)
        {
            action?.Invoke(value);
        }

        public static void MakeAllEventsNull()
        {
            OnAimButtonDown = null;
            OnAimButtonUp = null;
            OnShooted = null;
            OnBulletsEnded = null;
            Win = null;
            Lose = null;
            OnEnemyEnded = null;
            OnHealthEnded = null;
        }

       
    }
}

using UnityEngine;
namespace CustomInputSystem
{
    public static class InputSystem
    {
        
        public static Vector3 StartDeltaPos;
        public static Vector3 GetTouchPosition()
        {
#if UNITY_EDITOR
            return Input.mousePosition;

#endif

#if UNITY_IPHONE || UNITY_ANDROID
            return Input.GetTouch(0).position;

#endif
        }


        
    }
}

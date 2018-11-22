
using UnityEngine;

public static class UtilityMethods
{
    public static void MoveUiElementToWorldPosition(RectTransform rectTransform, Vector3 worldPosition)
    {
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(worldPosition);
        rectTransform.position = screenPoint;
    }
    // 1 SmoothlyLook() takes two parameters: The Transform, which has to be rotated and the position where it wants to look.It returns a Quaternion, which is the new local
        //rotation for the Transform. It can also be called from any class without to have a reference to it beforehand.
    public static Quaternion SmoothlyLook(Transform fromTransform,
    Vector3 toVector3)
    {
        //2 This check makes sure that the method stops executing if the origin point and
            //destination are the same,
        if (fromTransform.position == toVector3)
        {
            return fromTransform.localRotation;
        }

        ////3 This blocks stores the current rotation and creates the target rotation for the
        //    Transform by using the LookRotation() method.
        Quaternion currentRotation = fromTransform.localRotation;
        Quaternion targetRotation = Quaternion.LookRotation(toVector3 -
        fromTransform.position);

        //4 makes the rotation interpolate, Slerp().
        return Quaternion.Slerp(currentRotation, targetRotation,
        Time.deltaTime * 10f);
    }
}
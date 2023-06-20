using System;
using UnityEngine;

namespace UniRx.Extensions
{
    public static partial class UniRxUiExtensions
    {
        public static IObservable<Vector3> Local_position_changes(this Transform transform) =>
            transform.ObserveEveryValueChanged(x => x.localPosition);
    }
}
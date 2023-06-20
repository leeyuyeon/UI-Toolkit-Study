using System;
using UniRx.Triggers;
using UnityEngine;

namespace UniRx.Extensions
{
    public static class UniRxTriggerExtensions
    {
        public static IObservable<bool> On_mouse_enter_or_exit_as_observable(this Component component) =>
            component.OnMouseEnterAsObservable().Select(_ => true).Merge(component.OnMouseExitAsObservable().Select(_ => false));
    }
}
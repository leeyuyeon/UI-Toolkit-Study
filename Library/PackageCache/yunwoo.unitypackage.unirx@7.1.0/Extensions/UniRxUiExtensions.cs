using System;
using System.Linq;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace UniRx.Extensions
{
    public static partial class UniRxUiExtensions
    {
        public static IObservable<string?> On_active_toggle_name_as_observable(this ToggleGroup toggle_group) =>
            toggle_group.Observe_every_value_distinct_until_changed(x => x.ActiveToggles().FirstOrDefault()?.name);

        public static IObservable<Button> On_click_as_observable_with_button(this Button button) => button.OnClickAsObservable().Select(x => button);

        public static IObservable<bool> On_enable_or_disable_as_observable(this Component component) =>
            component.OnEnableAsObservable().Select(x => true).Merge(component.OnDisableAsObservable().Select(x => false));

        public static IObservable<TProperty> Observe_every_value_distinct_until_changed<TSource, TProperty>
            (this TSource source, Func<TSource, TProperty> property_selector, FrameCountType frame_count_type = FrameCountType.Update, bool fast_destroy_check = false)
            where TSource : class => source.ObserveEveryValueChanged(property_selector, frame_count_type, fast_destroy_check).DistinctUntilChanged();

        public static IObservable<Toggle> Turn_on_as_observable(this Toggle toggle) =>
            toggle.OnValueChangedAsObservable().Where(x => x).Select(x => toggle);

        public static IObservable<Toggle> Turn_off_as_observable(this Toggle toggle) =>
            toggle.OnValueChangedAsObservable().Where(x => !x).Select(x => toggle);
    }
}
#if UNITY_EDITOR

using UnityEngine;

namespace Build1.UnityEGUI.PropertyList.ItemRenderers
{
    public sealed class StringItemRenderer : PropertyListItemRenderer<string>
    {
        public override void OnEGUI()
        {
            EGUI.Horizontally(() =>
            {
                EGUI.TextField(Item, EGUI.ButtonHeight02, TextAnchor.MiddleLeft, SetItem);

                TryRenderButton(ButtonType.Up, EGUI.ButtonHeight02);
                TryRenderButton(ButtonType.Down, EGUI.ButtonHeight02);
                TryRenderButton(ButtonType.Delete, EGUI.ButtonHeight02);
            });
        }
    }
}

#endif
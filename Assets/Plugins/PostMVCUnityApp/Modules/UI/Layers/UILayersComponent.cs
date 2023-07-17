using System.Collections.Generic;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Mediation;
using UnityEngine;

namespace Build1.PostMVC.Unity.App.Modules.UI.Layers
{
    [DisallowMultipleComponent]
    public sealed class UILayersComponent : UnityView
    {
        [SerializeField] private List<UILayerInfo> layers;

        [Inject] public IUILayersController UILayersController { get; set; }

        [PostConstruct]
        public void PostConstruct()
        {
            foreach (var layer in layers)
                UILayersController.RegisterLayer(layer.Id, layer.GameObject);
        }
    }
}
using UnityEngine;

namespace Build1.PostMVC.Unity.App.Modules.Agents
{
    public interface IAgentsController
    {
        T Create<T>() where T : MonoBehaviour;

        void Destroy<T>(T agent) where T : MonoBehaviour;
        void Destroy<T>(ref T agent) where T : MonoBehaviour;
    }
}
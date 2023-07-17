using System.Collections;
using UnityEngine;

namespace Build1.PostMVC.Unity.App.Modules.Coroutines
{
    public interface ICoroutineProvider
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void      StartCoroutine(IEnumerator routine, out Coroutine coroutine);

        void StopCoroutine(Coroutine routine);
        void StopCoroutine(ref Coroutine routine);
    }
}
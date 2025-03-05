using UnityEngine;

namespace App.Base
{
    public class ViewController : MonoBehaviour
    {
        protected virtual void Awake() {}

        private void OnEnable() => Bind();

        private void OnDisable() => Unbind();

        protected virtual void Bind(){}
        protected virtual void Unbind(){}
    }
}
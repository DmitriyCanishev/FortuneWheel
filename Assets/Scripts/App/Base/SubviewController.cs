namespace App.Base
{
    public class SubviewController<TParentView> : ViewController where TParentView : ViewController
    {
        private TParentView _parentView = null;

        protected TParentView ParentView { get; private set; }

        protected override void Bind()
        {
            base.Bind();
            ParentView = _parentView ??= GetComponentInParent<TParentView>();
        }

        protected override void Unbind()
        {
            base.Unbind();
            ParentView = null;
        }
    }
}
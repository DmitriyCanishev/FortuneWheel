namespace App.Base
{
    public class SubviewController<TParentView> : ViewController where TParentView : ViewController
    {
        private TParentView _parentView = null;

        protected TParentView ParentView => _parentView ??= GetComponentInParent<TParentView>();
    }
}
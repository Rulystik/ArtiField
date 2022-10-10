namespace UI.Menues.MenuStates
{
    public abstract class BaseStateMenu
    {
        protected IMenu _menu;

        protected BaseStateMenu(IMenu menu)
        {
            _menu = menu;
        }
        
        public virtual float Exit(float deley = 0f)
        {
            deley += _menu.Close(deley);
            return deley;
        }

        public virtual float Enter(float deley = 0f)
        {
            deley += _menu.Open(deley);
            return deley;
        }
    }
}
namespace AIE45_DelegatesEvents
{
    public delegate void OnClickEvent(Button _button);

    public class Button
    {
        private OnClickEvent? onClick;

        private ConsoleKeyInfo? buttonKey;

        public Button(ConsoleKey _key, char _keyCharacter)
        {
            onClick = null;
            buttonKey = new ConsoleKeyInfo(_keyCharacter, _key, false, false, false);
        }

        public void RegisterClickCallback(OnClickEvent _onClick)
        {
            if(onClick != null)
            {
                onClick += _onClick;
            }
            else
            {
                onClick = _onClick;
            }
        }

        public void UnregisterClickCallback(OnClickEvent _onClick)
        {
            if(onClick != null && _onClick != null)
            {
                onClick -= _onClick;
            }
            else
            {
                onClick = null;
            }
        }

        public void Update()
        {
            if(Console.KeyAvailable)
            {
                if(Console.ReadKey() == buttonKey)
                {
                    // ? is a null check.
                    // If onClick is null, it will pass over the line, otherwise it will call Invoke
                    onClick?.Invoke(this);
                }
            }
        }
    }
}

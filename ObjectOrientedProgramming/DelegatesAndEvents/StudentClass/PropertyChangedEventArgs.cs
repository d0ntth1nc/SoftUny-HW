using System;

namespace StudentClass
{
    public class PropertyChangedEventArgs : EventArgs
    {
        public string PropertyName { get; private set; }
        public dynamic OldValue { get; private set; }
        public dynamic NewValue { get; private set; }

        public PropertyChangedEventArgs(string propName, dynamic oldVal, dynamic newVal)
        {
            this.PropertyName = propName;
            this.OldValue = oldVal;
            this.NewValue = newVal;
        }
    }
}

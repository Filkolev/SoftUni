namespace Surfaces
{
    using System.Windows;

    public class PropertyHolder<PropertyType, HoldingType> where HoldingType : DependencyObject
    {
        private readonly DependencyProperty property;

        public PropertyHolder(string name, PropertyType defaultValue, PropertyChangedCallback propertyChangedCallback)
        {
            this.property =
                DependencyProperty.Register(
                    name,
                    typeof(PropertyType),
                    typeof(HoldingType),
                    new PropertyMetadata(defaultValue, propertyChangedCallback));
        }

        public DependencyProperty Property
        {
            get
            {
                return this.property;
            }
        }

        public PropertyType Get(HoldingType obj)
        {
            return (PropertyType)obj.GetValue(this.property);
        }

        public void Set(HoldingType obj, PropertyType value)
        {
            obj.SetValue(this.property, value);
        }
    }
}

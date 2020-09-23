using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace VendingMachineProject
{


    public class BooleanToVisibilityConverter : IValueConverter
    {
        //Set to true if you want to show control when boolean value is true
        //Set to false if you want to hide/collapse control when value is true
        private bool triggerValue = false;
        public bool TriggerValue
        {
            get { return triggerValue; }
            set { triggerValue = value; }
        }
        //Set to true if you just want to hide the control
        //else set to false if you want to collapse the control
        private bool isHidden;
        public bool IsHidden
        {
            get { return isHidden; }
            set { isHidden = value; }
        }

        private object GetVisibility(object value)
        {
            if (!(value is bool))
                return DependencyProperty.UnsetValue;
            bool objValue = (bool)value;
            if ((objValue && TriggerValue && IsHidden) || (!objValue && !TriggerValue && IsHidden))
            {
                return Visibility.Hidden;
            }
            if ((objValue && TriggerValue && !IsHidden) || (!objValue && !TriggerValue && !IsHidden))
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        private object GetBoolean(object value)
        {
            if (!(value is System.Windows.Visibility))
                return DependencyProperty.UnsetValue;
            Visibility objValue = (Visibility)value;
            return triggerValue && (objValue == (isHidden ? Visibility.Hidden : Visibility.Collapsed));
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetVisibility(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetBoolean(value);
        }
    }

    public class VisibilityToVisibilityConverter : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = (Visibility)value;
            Visibility output = v == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = (Visibility)value;
            Visibility output = v == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            return output;
        }
    }

    public class MultiBooleanToVisibilityConverter : IMultiValueConverter
    {
        //Set to true if you want to show control when boolean value is true
        //Set to false if you want to hide/collapse control when value is true
        private bool triggerValue = false;
        public bool TriggerValue
        {
            get { return triggerValue; }
            set { triggerValue = value; }
        }
        //Set to true if you just want to hide the control
        //else set to false if you want to collapse the control
        private bool isHidden;
        public bool IsHidden
        {
            get { return isHidden; }
            set { isHidden = value; }
        }

        public string LogicFunction { get; set; } = "AND";



        private object GetVisibility(bool value)
        {
            if ((value && TriggerValue && IsHidden) || (!value && !TriggerValue && IsHidden))
            {
                return Visibility.Hidden;
            }
            if ((value && TriggerValue && !IsHidden) || (!value && !TriggerValue && !IsHidden))
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!value.All(t => t is bool))
                return GetVisibility(false);

            var inputToVisibility = (bool)value[0];
            for (var i = 1; i < value.Length; i++)
            {
                switch (LogicFunction)
                {
                    case "AND":
                        inputToVisibility &= (bool)value[i];
                        break;
                    case "OR":
                        inputToVisibility |= (bool)value[i];
                        break;
                }
            }
            return GetVisibility(inputToVisibility);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MultiBooleanConverter : IMultiValueConverter
    {
        public bool IsInvert { get; set; } = false;

        public string LogicFunction { get; set; } = "AND";

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            //bool[] booleans = (bool[])value;
            if (value.Any(t => !(t is bool)))
                return null;

            bool inputToVisibility = (bool)value[0];

            for (int i = 1; i < value.Length; i++)
            {
                if (LogicFunction == "AND")
                    inputToVisibility &= (bool)value[i];
                if (LogicFunction == "OR")
                    inputToVisibility |= (bool)value[i];
            }
            return IsInvert ? !inputToVisibility : inputToVisibility;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }




    [ValueConversion(typeof(bool), typeof(bool))]
    public class NotOperation : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool)value);

        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool)value);
        }


    }

    public class EnumToBooleanConverter : IValueConverter
    {
        public bool IsReverse { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null || parameter is null)
                return IsReverse;
            return IsReverse ^ value.Equals(Enum.Parse(value.GetType(), parameter.ToString()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }


    public class EnumToVisibilityConverter : IValueConverter
    {
        public bool IsReverse { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (IsReverse ^ value.Equals(Enum.Parse(value.GetType(), parameter.ToString()))) ?
                 Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("in not valid");
        }
    }
}

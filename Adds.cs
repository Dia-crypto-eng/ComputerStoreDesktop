using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace ComputerStore
{
    public static class Adds
    {
        public static TargetType GetParent<TargetType>(DependencyObject o)
            where TargetType : DependencyObject
        {
            return o == null || o is TargetType ? (TargetType)o : GetParent<TargetType>(VisualTreeHelper.GetParent(o));
        }

        public static T FindVisualChild<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T && ((FrameworkElement)child).Name == name)
                {
                    return (T)child;
                }
                var childOfChild = FindVisualChild<T>(child, name);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }
            return null;
        }
    }
}

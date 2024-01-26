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
    }
}

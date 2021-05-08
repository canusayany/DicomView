using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CTCommunication.UIPage.Controls
{
    /// <summary>
    /// CB_Extend.xaml 的交互逻辑
    /// </summary>
    public partial class CB_Extend : UserControl
    {
        public CB_Extend()
        {
            InitializeComponent();
        }

        private void UserControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            CheckBox_Con.IsChecked = !CheckBox_Con.IsChecked;
        }
        public static readonly RoutedEvent CheckedEvent =
           EventManager.RegisterRoutedEvent("Checked",
            RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<bool>), typeof(CB_Extend));


        public event RoutedPropertyChangedEventHandler<bool> Checked
        {
            add
            {
                this.AddHandler(CheckedEvent, value);
            }
            remove
            {
                this.RemoveHandler(CheckedEvent, value);

            }
        }
        protected virtual void OnChecked(bool oldValue, bool newValue)
        {
            RoutedPropertyChangedEventArgs<bool> arg =
                new RoutedPropertyChangedEventArgs<bool>(oldValue, newValue, CheckedEvent);
            this.RaiseEvent(arg);

        }
    }
}

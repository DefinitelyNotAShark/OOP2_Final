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
using WPFShippingFinal.ViewModels;

namespace WPFShippingFinal.Views
{
    /// <summary>
    /// Interaction logic for ShippingServiceControl.xaml
    /// </summary>
    public partial class ShippingServiceControl : UserControl
    {
        public ShippingServiceControl()
        {
            InitializeComponent();

                InitializeComponent();
                ShippingServiceViewModel serviceModel = new ShippingServiceViewModel();
                this.DataContext = serviceModel;
            
        }
    }
}

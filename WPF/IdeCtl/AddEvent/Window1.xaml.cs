using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace samp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        // *** AddEvent: example
        private AppObject appobject;
        // ***
        public Window1()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            // *** AddEvent: example
            if (appobject == null)
            {
                appobject = new AppObject();
                basicIdeCtl1.AddExtensionWithEvents(".AppObject", appobject);
            }
            // ***
        }
    }
}

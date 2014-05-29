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

// *** Handler: example
using WinWrap.Basic;
// ***

namespace samp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        // *** Handler: example
        AppHandler apphandler;
        // ***

        public Window1()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            // *** AddExt: example
            if (apphandler == null)
            {
                Handler handler = basicIdeCtl1.CreateHandler("Sub AppHandlerChanged");
                apphandler = new AppHandler(handler);
                basicIdeCtl1.AddExtension(".AppHandler.", apphandler);
            }
            // ***
        }
    }
}

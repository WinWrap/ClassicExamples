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
// *** AddBasic: optional
using Microsoft.Win32;
using WinWrap.Basic;
using WinWrap.Basic.Classic;
// ***

namespace samp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // *** AddBasic: required
        private BasicNoUIObj basicNoUIObj = new BasicNoUIObj();
        // ***

        public MainWindow()
        {
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // *** AddBasic: required
            this.basicNoUIObj.DebugTrace += new EventHandler<TextEventArgs>(basicIdeObj_DebugTrace);

            this.miFileExit.Click += new RoutedEventHandler(miFileExit_Click);
            this.miTestRunMsgBox.Click += new RoutedEventHandler(miTestRunMsgBox_Click);
            this.miTestRunWait.Click += new RoutedEventHandler(miTestRunWait_Click);
            this.miTestRuntoError.Click += new RoutedEventHandler(miTestRunToError_Click);
            this.miTraceAction.Click += new RoutedEventHandler(miTraceToggle_Click);
            this.miTraceQuery.Click += new RoutedEventHandler(miTraceToggle_Click);
            this.miTraceActionEvent.Click += new RoutedEventHandler(miTraceToggle_Click);
            this.miTraceQueryEvent.Click += new RoutedEventHandler(miTraceToggle_Click);
            this.miTraceInternal.Click += new RoutedEventHandler(miTraceToggle_Click);
            this.miTraceExecution.Click += new RoutedEventHandler(miTraceToggle_Click);
            this.miTraceNone.Click += new RoutedEventHandler(miTraceNone_Click);
            this.miTraceAll.Click += new RoutedEventHandler(miTraceAll_Click);
            this.miTraceClear.Click += new RoutedEventHandler(miTraceClear_Click);
            // ***

            // *** AddBasic: required
            // replace with your Application/Server certificate's secret
            basicNoUIObj.Secret = new Guid("{00000000-0000-0000-0000-000000000000}");
            basicNoUIObj.Initialize();
            // ***

            // *** AddBasic: optional
            // turn on tracing
            basicNoUIObj.Trace(TraceConstants.All & ~TraceConstants.QueryEvent);
            // ***

            // *** AddBasic: recommended
            // manage the Basic object/control using this form
            basicNoUIObj.AttachToWindow(this, ManageConstants.All);
            // ***
        }

        private void basicIdeObj_DebugTrace(object sender, TextEventArgs e)
        {
            // *** AddBasic: not recommended (users are not interested in seeing this)
            // append the trace line to the trace output shown on the form
            if (txtTrace.Text.Length > 30000)
                txtTrace.Text = "";

            if (txtTrace.Text.Length > 0)
                txtTrace.AppendText("\r\n");

            txtTrace.AppendText(e.Text);
            txtTrace.ScrollToEnd();
            // ***
        }

        private void miFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void miTestRunMsgBox_Click(object sender, RoutedEventArgs e)
        {
            // *** AddBasic: test
            basicNoUIObj.RunFile("\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\\..\\..\\..\\msgbox.bas\"");
            // ***
        }

        private void miTestRunWait_Click(object sender, RoutedEventArgs e)
        {
            // *** AddBasic: test
            basicNoUIObj.RunFile("\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\\..\\..\\..\\wait.bas\"");
            // ***
        }

        private void miTestRunToError_Click(object sender, RoutedEventArgs e)
        {
            // *** AddBasic: test
            basicNoUIObj.RunThis("Error 1");
            // ***
        }

        private void miTraceToggle_Click(object sender, RoutedEventArgs e)
        {
            // *** AddBasic: test
            MenuItem mi = sender as MenuItem;
            mi.IsChecked = !mi.IsChecked;
            int categories = 0;
            for (int i = 0; i < 6; ++i)
                if (((MenuItem)miTrace.Items[i]).IsChecked)
                    categories |= (i < 4 ? 1 : 4) << i;

            basicNoUIObj.Trace((TraceConstants)categories);
            // ***
        }

        private void miTraceNone_Click(object sender, RoutedEventArgs e)
        {
            // *** AddBasic: test
            for (int i = 0; i < 6; ++i)
                ((MenuItem)miTrace.Items[i]).IsChecked = false;

            basicNoUIObj.Trace(TraceConstants.None);
            // ***
        }

        private void miTraceAll_Click(object sender, RoutedEventArgs e)
        {
            // *** AddBasic: test
            for (int i = 0; i < 6; ++i)
                ((MenuItem)miTrace.Items[i]).IsChecked = true;

            basicNoUIObj.Trace(TraceConstants.All);
            // ***
        }

        private void miTraceClear_Click(object sender, RoutedEventArgs e)
        {
            // *** AddBasic: test
            txtTrace.Text = "";
            // ***
        }
    }
}

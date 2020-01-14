using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ThreeWindows
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // here you take control
            MainWindow mw = new MainWindow();
            Window1 w1 = new Window1();
            Window2 w2 = new Window2();

            mw.Show();
            w1.Show();
            w2.Show();

        }
    }
}

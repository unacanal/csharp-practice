using System.Threading;
using System.Windows;

namespace WpfApplication2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread th1;
        Thread th2;
        Thread th3;
        private delegate void myDelegate(int theValue, int theMax);
        private void updateProgressbar(int theValue, int theMax)
        {
            if (theMax != 0)
            {
                proBar.Maximum = theMax;
            }
            proBar.Value = theValue;
        }

        private void myThread()
        {
            for (int i = 0; i < 100; i++)
            {
                this.Dispatcher.Invoke(new myDelegate(updateProgressbar), 
                    new object[] { i * 10, 100 });
                Thread.Sleep(500);
            }
            th1.Abort();
        }

        private delegate void myDelegate2(int theValue, int theMax);
        private void updateProgressbar2(int theValue, int theMax)
        {
            listBox.Items.Add(theValue.ToString());
            listBox.SelectedItem = listBox.Items[listBox.Items.Count - 1];
        }
        private void myThread2()
        {
            for (int i = 0; i < 100; i++)
            {
                this.Dispatcher.Invoke(new myDelegate2(updateProgressbar2), 
                    new object[] { i, 100 });
                Thread.Sleep(100);
            }
            th2.Abort();
        }

        private delegate void myDelegate3(int theValue, int theMax);
        private void updateProgressbar3(int theValue, int theMax)
        {
            listBox.Items.Add("2 > " + theValue.ToString());
            listBox.SelectedItem = listBox.Items[listBox.Items.Count - 1];
        }
        private void myThread3()
        {
            for (int i = 0; i < 100; i += 2)
            {
                this.Dispatcher.Invoke(new myDelegate3(updateProgressbar3),
                    new object[] { i, 50 });
                Thread.Sleep(50);
            }
            th3.Abort();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            th1 = new Thread(new ThreadStart(myThread));
            th2 = new Thread(new ThreadStart(myThread2));
            th3 = new Thread(new ThreadStart(myThread3));
            th1.Start();
            th2.Start();
            th3.Start();
        }
    }
}

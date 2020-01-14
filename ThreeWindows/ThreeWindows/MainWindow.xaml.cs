using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace ThreeWindows
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        delegate int myDelegate(Label label);
        private int SUM(Label label)
        {
            int sum = 0;
            
            for (int i = 0; i < 9999; i++)
            {
                sum += i;
                label.Dispatcher.Invoke(() => {                    
                    label.Content = sum.ToString();
                }); // lamda 식
                Thread.Sleep(300);
            }
            return sum;
        }

        void SumCallback(IAsyncResult iar) // I: Interface
        {
            // 대리자 함수가 끝났을 때 할 일
            AsyncResult ar = iar as AsyncResult; // as: 형 변환하는 역할, iar을 AR객체로 형변환
            myDelegate md = ar.AsyncDelegate as myDelegate;
            object obj = iar.AsyncState;
        }

        private void button_Click(object sender, RoutedEventArgs e) // 이벤트 발생할때 어떤 값을 주면 args안에 담겨서 옴 // sender: window form
        {
            myDelegate md = SUM; // 둘은 signature가 같기때문에 연결할 수 있음
            md.BeginInvoke(((Window1)Application.Current.Windows[1]).label1, SumCallback, "test"); // test는 쓰레기값...? 용도 잘모름
        }
    }
}

using System;
using System.Runtime.Remoting.Messaging;
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
            for (int i = 0; i < 99999; i++)
            {
                sum += i;

                /// label.Content = sum.ToString(); // 다른 쓰레드의 변수이기 때문에 cross thread 문제 발생
                label.Dispatcher.Invoke(() => { // invoke함수에서 무명함수를 호출하는데 그것이 label.Content를 업데이트함
                                                // Dispatcher는 따로 공부하기
                    label.Content = sum.ToString();
                }); // lamda 식

            }
            return sum;
        }

        void SumCallback(IAsyncResult iar) // I: Interface
        {
            // 대리자 함수가 끝났을 때 할 일
            AsyncResult ar = iar as AsyncResult; // as: 형 변환하는 역할, iar을 AR객체로 형변환
            myDelegate md = ar.AsyncDelegate as myDelegate;
            object obj = iar.AsyncState;
            //lbl2.Dispatcher.Invoke(() => {
            //    lbl2.Content = obj.ToString();
            //});
            //lbl3.Dispatcher.Invoke(() => {
            //    lbl3.Content = (md.EndInvoke(iar)).ToString();
            //});
        }

        private void button_Click(object sender, RoutedEventArgs e) // 이벤트 발생할때 어떤 값을 주면 args안에 담겨서 옴 // sender: window form
        {
            myDelegate md = SUM; // 둘은 signature가 같기때문에 연결할 수 있음
            md.BeginInvoke(label, SumCallback, "test"); // test는 쓰레기값...? 용도 잘모름
        }
    }
}

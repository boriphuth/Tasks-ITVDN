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
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.Integration;
using System.ComponentModel;
using System.Threading;

namespace Async_Sort
{
    public delegate void ButtonAction(object sender, SendStateEventArgs e);

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            RunController();


            handler1 = UpdateChart1;

            handler2 = UpdateChart2;
            button1.Click += button1_Click2;
            handler3 = UpdateChart3;
            button1.Click += button1_Click3;
        }

        public event ButtonAction SendStart;
        public event ButtonAction SendSort;

        Controller controller;

        ButtonAction handler1;
        ButtonAction handler2;
        ButtonAction handler3;

        private void RunController()
        {
            Run();
        }

        private void Run()
        {
            controller = new Controller(this);
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            SendStart(sender, null);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            chart1.ChartAreas.Add(new ChartArea("Default"));
            chart2.ChartAreas.Add(new ChartArea("Default"));
            chart3.ChartAreas.Add(new ChartArea("Default"));
            // Добавим линию, и назначим ее в ранее созданную область "Default"

            chart1.Series.Add(new Series("Series1"));
            chart1.Series["Series1"].ChartArea = "Default";
            chart1.Series["Series1"].ChartType = SeriesChartType.Column;

            chart2.Series.Add(new Series("Series1"));
            chart2.Series["Series1"].ChartArea = "Default";
            chart2.Series["Series1"].ChartType = SeriesChartType.Column;

            chart3.Series.Add(new Series("Series1"));
            chart3.Series["Series1"].ChartArea = "Default";
            chart3.Series["Series1"].ChartType = SeriesChartType.Column;
            // добавим данные линии
            int[] axisXData = new int[] { 0 };
            int[] axisYData = new int[] { 0 };
            chart1.Series["Series1"].Points.DataBindXY(axisXData, axisYData);

            int[] axisXData1 = new int[] { 0 };
            int[] axisYData1 = new int[] { 0 };
            chart2.Series["Series1"].Points.DataBindXY(axisXData1, axisYData1);

            int[] axisXData2 = new int[] { 0 };
            int[] axisYData2 = new int[] { 0 };
            chart3.Series["Series1"].Points.DataBindXY(axisXData2, axisYData2);
        }

        //----------------------------1-------------------------------------------------------
        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            bool pred = await controller.model.OnSendSort();
        }

        public void OnSendArray1(object sender, SendStateEventArgs e)
        {
            this.Dispatcher.Invoke(handler1, sender, e);
        }

        public void UpdateChart1(object sender, SendStateEventArgs e)
        {
            int[] axisXData = e.Positions as int[];
            int[] axisYData = e.State as int[];
            chart1.Series["Series1"].Points.DataBindXY(axisXData, axisYData);
            chart1.Invalidate();
        }

        //---------------------------2-----------------------------------------------------
        private async void button1_Click2(object sender, RoutedEventArgs e)
        {
            bool pred2 = await controller.model.OnSendSort2();
        }

        public void OnSendArray2(object sender, SendStateEventArgs e)
        {
            this.Dispatcher.Invoke(handler2, sender, e);

        }
        public void UpdateChart2(object sender, SendStateEventArgs e)
        {
            int[] axisXData1 = e.Positions as int[];
            int[] axisYData1 = e.State as int[];
            chart2.Series["Series1"].Points.DataBindXY(axisXData1, axisYData1);
        }

        //----------------------------3---------------------------------------------------------
        private async void button1_Click3(object sender, RoutedEventArgs e)
        {
            bool pred2 = await controller.model.OnSendSort3();
        }

        public void OnSendArray3(object sender, SendStateEventArgs e)
        {
            this.Dispatcher.Invoke(handler3, sender, e);
        }

        public void UpdateChart3(object sender, SendStateEventArgs e)
        {

            int[] axisXData = e.Positions as int[];
            int[] axisYData = e.State as int[];
            chart3.Series["Series1"].Points.DataBindXY(axisXData, axisYData);
        }
        
    }
}

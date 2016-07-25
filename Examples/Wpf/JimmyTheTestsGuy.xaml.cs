﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Maps;
using LiveCharts.Wpf;
using Wpf.Annotations;

namespace Wpf
{
   
    //This is Jimmy, be rude with him.

    public partial class JimmyTheTestsGuy : INotifyPropertyChanged
    {
        public JimmyTheTestsGuy()
        {
            InitializeComponent();

            Series = new SeriesCollection
            {
                new LineSeries {Values = new ChartValues<double> {1, 2, 3, 4, 5}},
                new LineSeries {Values = new ChartValues<double> {double.NaN, double.NaN, 3, 4, 5}}
            };

            DataContext = this;
        }

        public Path SelectedLand { get; set; }

        public SeriesCollection Series { get; set; }

        public List<SeriesCollection> Source { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //GeoMap.Restart();
        }

        private void GeoMap_OnLandClick(object sender, MapData mapData)
        {
            if (SelectedLand != null)
            {
                //lets clear the selection...
                //SelectedLand.Stroke = GeoMap.LandStroke;
                //SelectedLand.StrokeThickness = GeoMap.LandStrokeThickness;
            }

            SelectedLand = (Path) mapData.Shape;
            SelectedLand.Stroke = Brushes.CornflowerBlue;
            SelectedLand.StrokeThickness = 2;

            //GeoMap.MoveTo(mapData);
        }
    }
}

﻿using System;
using UIKit;
using SciChart.iOS.Charting;

namespace AddingSeries
{
    public partial class ViewController : UIViewController
    {
        private SCIChartSurface _surface;
        private XyDataSeries<Double, Double> _lineDataSeries;
        private XyDataSeries<Double, Double> _scatterDataSeries;


        private SCIFastLineRenderableSeries _lineRenderableSeries;
        private SCIXyScatterRenderableSeries _scatterRenderableSeries;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            _surface = new SCIChartSurface();
            _surface.TranslatesAutoresizingMaskIntoConstraints = true;
            _surface.Frame = this.View.Bounds;

            this.View.AddSubview(_surface);

            _surface.XAxes.Add(new SCINumericAxis());
            _surface.YAxes.Add(new SCINumericAxis());

            CreateDataSeries();
            CreateRenderableSeries();
        }

        void CreateDataSeries()
        {
            // Init line data series
            _lineDataSeries = new XyDataSeries<Double, Double>();
            for (var i = 0; i < 500; i++)
            {
                _lineDataSeries.Append(i, Math.Sin(i*0.1));
            }

            // Init scatter data series
            _scatterDataSeries = new XyDataSeries<Double, Double>();
            for (var i = 0; i < 500; i++)
            {
                _scatterDataSeries.Append(i, Math.Cos(i*0.1));
            }
        }

        void CreateRenderableSeries()
        {
            _lineRenderableSeries = new SCIFastLineRenderableSeries();
            _lineRenderableSeries.DataSeries = _lineDataSeries;


            _scatterRenderableSeries = new SCIXyScatterRenderableSeries();
            _scatterRenderableSeries.DataSeries = _scatterDataSeries;


            _surface.RenderableSeries.Add(_lineRenderableSeries);
            _surface.RenderableSeries.Add(_scatterRenderableSeries);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

}
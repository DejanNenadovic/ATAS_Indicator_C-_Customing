namespace ATAS.Indicators.Technical
{
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
	using System.Windows.Media;

	using ATAS.Indicators.Drawing;
	using ATAS.Indicators.Technical.Properties;

    using OFT.Attributes;

	[DisplayName("Custom Guppy")]
	[HelpLink("https://support.atas.net/knowledge-bases/2/articles/49353-guppy-multiple-moving-average")]
	public class GMMA : Indicator
	{
		#region Fields

		private readonly EMA _emaLong1 = new();
		private readonly EMA _emaLong2 = new();
		private readonly EMA _emaLong3 = new();
		private readonly EMA _emaLong4 = new();
		private readonly EMA _emaLong5 = new();
		private readonly EMA _emaLong6 = new();
        private readonly EMA _emaLong7 = new();
        private readonly EMA _emaLong8 = new();
        private readonly EMA _emaLong9 = new();
        private readonly EMA _emaLong10 = new();
        private readonly EMA _emaLong11 = new();
        private readonly EMA _emaLong12 = new();
        private readonly EMA _emaLong13 = new();
        private readonly EMA _emaLong14 = new();
        private readonly EMA _emaLong15 = new();
        private readonly EMA _emaLong16 = new();

        private readonly EMA _emaShort1 = new();
		private readonly EMA _emaShort2 = new();
		private readonly EMA _emaShort3 = new();
		private readonly EMA _emaShort4 = new();
		private readonly EMA _emaShort5 = new();
		private readonly EMA _emaShort6 = new();
        private readonly EMA _emaShort7 = new();
        private readonly EMA _emaShort8 = new();

        private readonly ValueDataSeries _renderLong1 = new("Long1");
		private readonly ValueDataSeries _renderLong2 = new("Long2");
		private readonly ValueDataSeries _renderLong3 = new("Long3");
		private readonly ValueDataSeries _renderLong4 = new("Long4");
		private readonly ValueDataSeries _renderLong5 = new("Long5");
		private readonly ValueDataSeries _renderLong6 = new("Long6");
        private readonly ValueDataSeries _renderLong7 = new("Long7");
        private readonly ValueDataSeries _renderLong8 = new("Long8");
        private readonly ValueDataSeries _renderLong9 = new("Long9");
        private readonly ValueDataSeries _renderLong10 = new("Long10");
        private readonly ValueDataSeries _renderLong11 = new("Long11");
        private readonly ValueDataSeries _renderLong12 = new("Long12");
        private readonly ValueDataSeries _renderLong13 = new("Long13");
        private readonly ValueDataSeries _renderLong14 = new("Long14");
        private readonly ValueDataSeries _renderLong15 = new("Long15");
        private readonly ValueDataSeries _renderLong16 = new("Long16");

        private readonly ValueDataSeries _renderShort1 = new("Short1");
		private readonly ValueDataSeries _renderShort2 = new("Short2");
		private readonly ValueDataSeries _renderShort3 = new("Short3");
		private readonly ValueDataSeries _renderShort4 = new("Short4");
		private readonly ValueDataSeries _renderShort5 = new("Short5");
		private readonly ValueDataSeries _renderShort6 = new("Short6");
        private readonly ValueDataSeries _renderShort7 = new("Short7");
        private readonly ValueDataSeries _renderShort8 = new("Short8");

        #endregion

        #region Properties

        [Display(ResourceType = typeof(Resources), Name = "ShortPeriod", GroupName = "Colors", Order = 50)]
		public Color ShortColor
		{
			get => _renderShort1.Color;
			set 
				{
				_renderShort1.Color = _renderShort2.Color =
				_renderShort4.Color = _renderShort5.Color = _renderShort6.Color = _renderShort7.Color =  Colors.Blue;

				_renderShort3.Color = Color.FromArgb(255,33, 150, 242);
				_renderShort8.Color = Colors.LightBlue;

            }
        }
        
		[Display(ResourceType = typeof(Resources), Name = "LongPeriod", GroupName = "Colors", Order = 60)]
		public Color LongColor
		{
			get => _renderLong1.Color;
			set 
				{
				_renderLong1.Color = _renderLong2.Color = _renderLong3.Color =
					_renderLong4.Color = _renderLong5.Color = _renderLong6.Color = _renderLong7.Color = _renderLong8.Color = _renderLong9.Color = _renderLong10.Color = _renderLong11.Color = _renderLong12.Color = _renderLong13.Color = _renderLong14.Color = _renderLong15.Color = Colors.DarkRed;

				_renderLong16.Color = Colors.Red;

            }
		}

		[Display(ResourceType = typeof(Resources), Name = "EmaPeriod1", GroupName = "ShortPeriod", Order = 100)]
		[Range(1, 10000)]
		public int EmaPeriod1
		{
			get => _emaShort1.Period;
			set
			{
				_emaShort1.Period = value;
				RecalculateValues();
			}
		}

		[Display(ResourceType = typeof(Resources), Name = "EmaPeriod2", GroupName = "ShortPeriod", Order = 110)]
		[Range(1, 10000)]
        public int EmaPeriod2
		{
			get => _emaShort2.Period;
			set
			{
				_emaShort2.Period = value;
				RecalculateValues();
			}
		}

		[Display(ResourceType = typeof(Resources), Name = "EmaPeriod3", GroupName = "ShortPeriod", Order = 120)]
		[Range(1, 10000)]
        public int EmaPeriod3
		{
			get => _emaShort3.Period;
			set
			{
				_emaShort3.Period = value;
				RecalculateValues();
			}
		}

		[Display(ResourceType = typeof(Resources), Name = "EmaPeriod4", GroupName = "ShortPeriod", Order = 130)]
		[Range(1, 10000)]
        public int EmaPeriod4
		{
			get => _emaShort4.Period;
			set
			{
				_emaShort4.Period = value;
				RecalculateValues();
			}
		}

		[Display(ResourceType = typeof(Resources), Name = "EmaPeriod5", GroupName = "ShortPeriod", Order = 140)]
		[Range(1, 10000)]
        public int EmaPeriod5
		{
			get => _emaShort5.Period;
			set
			{
				_emaShort5.Period = value;
				RecalculateValues();
			}
		}

		[Display(ResourceType = typeof(Resources), Name = "EmaPeriod6", GroupName = "ShortPeriod", Order = 150)]
		[Range(1, 10000)]
		public int EmaPeriod6
		{
			get => _emaShort6.Period;
			set
			{
				_emaShort6.Period = value;
				RecalculateValues();
			}
		}
        [Display(ResourceType = typeof(Resources), Name = "EmaPeriod7", GroupName = "ShortPeriod", Order = 160)]
        [Range(1, 10000)]
        public int EmaPeriod7
        {
            get => _emaShort7.Period;
            set
            {
                _emaShort7.Period = value;
                RecalculateValues();
            }
        }
        [Display(ResourceType = typeof(Resources), Name = "EmaPeriod8", GroupName = "ShortPeriod", Order = 170)]
        [Range(1, 10000)]
        public int EmaPeriod8
        {
            get => _emaShort8.Period;
            set
            {
                _emaShort8.Period = value;
                RecalculateValues();
            }
        }

        [Display(ResourceType = typeof(Resources), Name = "EmaPeriod1", GroupName = "LongPeriod", Order = 200)]
		[Range(1, 10000)]
        public int EmaLongPeriod1
		{
			get => _emaLong1.Period;
			set
			{
				_emaLong1.Period = value;
				RecalculateValues();
			}
		}

		[Display(ResourceType = typeof(Resources), Name = "EmaPeriod2", GroupName = "LongPeriod", Order = 210)]
		[Range(1, 10000)]
        public int EmaLongPeriod2
		{
			get => _emaLong2.Period;
			set
			{
				_emaLong2.Period = value;
				RecalculateValues();
			}
		}

		[Display(ResourceType = typeof(Resources), Name = "EmaPeriod3", GroupName = "LongPeriod", Order = 220)]
		[Range(1, 10000)]
        public int EmaLongPeriod3
		{
			get => _emaLong3.Period;
			set
			{
				_emaLong3.Period = value;
				RecalculateValues();
			}
		}

		[Display(ResourceType = typeof(Resources), Name = "EmaPeriod4", GroupName = "LongPeriod", Order = 230)]
		[Range(1, 10000)]
        public int EmaLongPeriod4
		{
			get => _emaLong4.Period;
			set
			{
				_emaLong4.Period = value;
				RecalculateValues();
			}
		}

		[Display(ResourceType = typeof(Resources), Name = "EmaPeriod5", GroupName = "LongPeriod", Order = 240)]
		[Range(1, 10000)]
        public int EmaLongPeriod5
		{
			get => _emaLong5.Period;
			set
			{
				_emaLong5.Period = value;
				RecalculateValues();
			}
		}

		[Display(ResourceType = typeof(Resources), Name = "EmaPeriod6", GroupName = "LongPeriod", Order = 250)]
		[Range(1, 10000)]
        public int EmaLongPeriod6
		{
			get => _emaLong6.Period;
			set
			{
				_emaLong6.Period = value;
				RecalculateValues();
			}
		}

        [Display(ResourceType = typeof(Resources), Name = "EmaPeriod7", GroupName = "LongPeriod", Order = 260)]
        [Range(1, 10000)]
        public int EmaLongPeriod7
        {
            get => _emaLong7.Period;
            set
            {
                _emaLong7.Period = value;
                RecalculateValues();
            }
        }
        [Display(ResourceType = typeof(Resources), Name = "EmaPeriod8", GroupName = "LongPeriod", Order = 270)]
        [Range(1, 10000)]
        public int EmaLongPeriod8
        {
            get => _emaLong8.Period;
            set
            {
                _emaLong8.Period = value;
                RecalculateValues();
            }
        }
        [Display(ResourceType = typeof(Resources), Name = "EmaPeriod9", GroupName = "LongPeriod", Order = 280)]
        [Range(1, 10000)]
        public int EmaLongPeriod9
        {
            get => _emaLong9.Period;
            set
            {
                _emaLong9.Period = value;
                RecalculateValues();
            }
        }
        [Display(ResourceType = typeof(Resources), Name = "EmaPeriod10", GroupName = "LongPeriod", Order = 290)]
        [Range(1, 10000)]
        public int EmaLongPeriod10
        {
            get => _emaLong10.Period;
            set
            {
                _emaLong10.Period = value;
                RecalculateValues();
            }
        }
        [Display(ResourceType = typeof(Resources), Name = "EmaPeriod11", GroupName = "LongPeriod", Order = 300)]
        [Range(1, 10000)]
        public int EmaLongPeriod11
        {
            get => _emaLong11.Period;
            set
            {
                _emaLong11.Period = value;
                RecalculateValues();
            }
        }
        [Display(ResourceType = typeof(Resources), Name = "EmaPeriod12", GroupName = "LongPeriod", Order = 310)]
        [Range(1, 10000)]
        public int EmaLongPeriod12
        {
            get => _emaLong12.Period;
            set
            {
                _emaLong12.Period = value;
                RecalculateValues();
            }
        }
        [Display(ResourceType = typeof(Resources), Name = "EmaPeriod13", GroupName = "LongPeriod", Order = 320)]
        [Range(1, 10000)]
        public int EmaLongPeriod13
        {
            get => _emaLong13.Period;
            set
            {
                _emaLong13.Period = value;
                RecalculateValues();
            }
        }
        [Display(ResourceType = typeof(Resources), Name = "EmaPeriod14", GroupName = "LongPeriod", Order = 330)]
        [Range(1, 10000)]
        public int EmaLongPeriod14
        {
            get => _emaLong14.Period;
            set
            {
                _emaLong14.Period = value;
                RecalculateValues();
            }
        }
        [Display(ResourceType = typeof(Resources), Name = "EmaPeriod15", GroupName = "LongPeriod", Order = 340)]
        [Range(1, 10000)]
        public int EmaLongPeriod15
        {
            get => _emaLong15.Period;
            set
            {
                _emaLong15.Period = value;
                RecalculateValues();
            }
        }
        [Display(ResourceType = typeof(Resources), Name = "EmaPeriod16", GroupName = "LongPeriod", Order = 350)]
        [Range(1, 10000)]
        public int EmaLongPeriod16
        {
            get => _emaLong16.Period;
            set
            {
                _emaLong16.Period = value;
                RecalculateValues();
            }
        }

        #endregion

        #region ctor

        public GMMA()
		{
			DenyToChangePanel = true;

			LongColor = DefaultColors.Red.Convert();
			ShortColor = DefaultColors.Blue.Convert();

			_emaShort1.Period = 1;
			_emaShort2.Period = 2;
			_emaShort3.Period = 3;
			_emaShort4.Period = 4;
			_emaShort5.Period = 5;
			_emaShort6.Period = 6;
            _emaShort7.Period = 7;
            _emaShort8.Period = 8;

            _emaLong1.Period = 20;
			_emaLong2.Period = 21;
			_emaLong3.Period = 22;
			_emaLong4.Period = 23;
			_emaLong5.Period = 24;
			_emaLong6.Period = 25;
            _emaLong7.Period = 26;
            _emaLong8.Period = 27;
            _emaLong9.Period = 28;
			_emaLong10.Period = 29; 
			_emaLong11.Period = 30; 
			_emaLong12.Period = 31; 
			_emaLong13.Period = 32;
            _emaLong14.Period = 33;
            _emaLong15.Period = 34;
            _emaLong16.Period = 35;

            DataSeries[0] = _renderShort1;
			DataSeries.Add(_renderShort2);
			DataSeries.Add(_renderShort3);
			DataSeries.Add(_renderShort4);
			DataSeries.Add(_renderShort5);
			DataSeries.Add(_renderShort6);
            DataSeries.Add(_renderShort7);
            DataSeries.Add(_renderShort8);

            DataSeries.Add(_renderLong1);
			DataSeries.Add(_renderLong2);
			DataSeries.Add(_renderLong3);
			DataSeries.Add(_renderLong4);
			DataSeries.Add(_renderLong5);
			DataSeries.Add(_renderLong6);
            DataSeries.Add(_renderLong7);
            DataSeries.Add(_renderLong8); 
			DataSeries.Add(_renderLong9); 
			DataSeries.Add(_renderLong10); 
			DataSeries.Add(_renderLong11);
            DataSeries.Add(_renderLong12); 
			DataSeries.Add(_renderLong13); 
			DataSeries.Add(_renderLong14); 
			DataSeries.Add(_renderLong15);
            DataSeries.Add(_renderLong16);

            DataSeries.ForEach(x => x.IsHidden = true);
		}

		#endregion

		#region Protected methods

		protected override void OnCalculate(int bar, decimal value)
		{
			_renderShort1[bar] = _emaShort1.Calculate(bar, value);
			_renderShort2[bar] = _emaShort2.Calculate(bar, value);
			_renderShort3[bar] = _emaShort3.Calculate(bar, value);
			_renderShort4[bar] = _emaShort4.Calculate(bar, value);
			_renderShort5[bar] = _emaShort5.Calculate(bar, value);
			_renderShort6[bar] = _emaShort6.Calculate(bar, value);
            _renderShort7[bar] = _emaShort7.Calculate(bar, value);
            _renderShort8[bar] = _emaShort8.Calculate(bar, value);

            _renderLong1[bar] = _emaLong1.Calculate(bar, value);
			_renderLong2[bar] = _emaLong2.Calculate(bar, value);
			_renderLong3[bar] = _emaLong3.Calculate(bar, value);
			_renderLong4[bar] = _emaLong4.Calculate(bar, value);
			_renderLong5[bar] = _emaLong5.Calculate(bar, value);
			_renderLong6[bar] = _emaLong6.Calculate(bar, value);
            _renderLong7[bar] = _emaLong7.Calculate(bar, value);
            _renderLong8[bar] = _emaLong8.Calculate(bar, value);
            _renderLong9[bar] = _emaLong9.Calculate(bar, value);
            _renderLong10[bar] = _emaLong10.Calculate(bar, value);
            _renderLong11[bar] = _emaLong11.Calculate(bar, value);
            _renderLong12[bar] = _emaLong12.Calculate(bar, value);
            _renderLong13[bar] = _emaLong13.Calculate(bar, value);
            _renderLong14[bar] = _emaLong14.Calculate(bar, value);
            _renderLong15[bar] = _emaLong15.Calculate(bar, value);
            _renderLong16[bar] = _emaLong16.Calculate(bar, value);
        }

		#endregion
	}
}
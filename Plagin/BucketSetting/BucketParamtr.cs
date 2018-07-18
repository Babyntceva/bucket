using BucketSetting.ExceptionFolder;

namespace BucketSetting
{
    public struct BucketParamtr
    {
        /// <summary>
        /// Диаметр дна
        /// </summary>
        private double _diameterOfTheBottom;

        /// <summary>
        /// Высота ведра
        /// </summary>
        private double _theHeightOfTheBucket;

        /// <summary>
        /// Диаметр горла
        /// </summary>
        private double _theDiameterOfTheThroat;

        /// <summary>
        /// Толщина стали
        /// </summary>
        private double _thicknessOfSteel;

        /// <summary>
        /// Толщина дужки
        /// </summary>
        private double _thicknessOfTheBow;

        /// <summary>
        /// Свойства диаметра дна
        /// </summary>
        public double DiameterOfTheBottom
        {
            get
            {
                return _diameterOfTheBottom;
            }
            set
            {
                if(value > 220 || value < 185)
                {
                    throw new DiameterOfTheBottomException();
                }
                _diameterOfTheBottom = value;
            }
        }

        /// <summary>
        /// Свойства высоты ведра
        /// </summary>
        public double TheHeightOfTheBucket
        {
            get
            {
                return _theHeightOfTheBucket;
            }
            set
            {
                if (value < 235 || 275 < value)
                {
                    throw new TheHeightOfTheBucketException();
                }
                _theHeightOfTheBucket = value;
            }
        }

        /// <summary>
        /// Свойства  диамтра горла
        /// </summary>
        public double TheDiameterOfTheThroat
        {
            get
            {
                return _theDiameterOfTheThroat;
            }
            set
            {
                if (value > 315 || 260 > value)
                {
                    throw new TheDiameterOfTheThroatException();
                }
                _theDiameterOfTheThroat = value;
            }
        }

        /// <summary>
        /// Свойство толщина стали
        /// </summary>
        public double ThicknessOfSteel
        {
            get
            {
                return _thicknessOfSteel;
            }
            set
            {
                if (value > 0.55 || 0.35 > value)
                {
                    throw new ThicknessOfSteelException();
                }
                _thicknessOfSteel = value;
            }
        }

        /// <summary>
        /// Свойство толщина дужки
        /// </summary>
        public double ThicknessOfTheBow
        {
            get
            {
                return _thicknessOfTheBow;
            }
            set
            {
                if(value > 1.2 || 0.5 > value)
                {
                    throw new ThicknessOfTheBowException();
                }
                _thicknessOfTheBow = value;
            }
        }
    }
}

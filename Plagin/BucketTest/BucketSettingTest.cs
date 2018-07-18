using NUnit.Framework;
using BucketSetting;
using BucketSetting.ExceptionFolder;

namespace BucketTest
{
    [TestFixture]
    public class BucketSettingTest
    {
        [Test]
        #region Тесты на диаметр дна ведра
        [TestCase(220,TestName ="Тест диаметра дна ведра с праельным значением")]
        public void SetDiametrOfTheBottomPositiveTest(double diametr)
        {
            var bucket = new BucketParamtr();
            bucket.DiameterOfTheBottom = diametr;
        }
        
        [TestCase(221,TestName ="Тест диаметра дна с больше заданным значением")]
        [TestCase(184,TestName ="Тест диаметра дна с меньше заданным значением")]
        public void SetDiamtrOfTheBottomNegativeTest(double diametr)
        {
            var bucket = new BucketParamtr();
            Assert.Throws<DiameterOfTheBottomException>(() =>
            bucket.DiameterOfTheBottom = diametr);
        }
        #endregion

        #region Тесты на диаметр горла ведра
        [TestCase(315, TestName = "Тест диаметра горла ведра с правельным значением")]
        public void SetTheDiametrOfTheTroadTestPositiv(double diametr)
        {
            var bucket = new BucketParamtr();
            bucket.TheDiameterOfTheThroat = diametr;
        }

        [TestCase(316, TestName = "Тест диаметра горла с больше заданным значением")]
        [TestCase(259, TestName = "Тест диаметра горла с меньше заданным значением")]
        public void SetTheDiametrOfTheThroadTestPositiv(double diametr)
        {
            var bucket = new BucketParamtr();
            Assert.Throws<TheDiameterOfTheThroatException>(() =>
            bucket.TheDiameterOfTheThroat = diametr);
        }
        #endregion

        #region Тесты на высоту ведра
        [TestCase(275, TestName = "Тест высоты ведра с правельным значением")]
        public void SetTheHeightOfTheBucketPositiveTest(double height)
        {
            var bucket = new BucketParamtr();
            bucket.TheHeightOfTheBucket = height;
        }

        [TestCase(276, TestName = "Тест высоты ведра больше заданным значением")]
        [TestCase(234, TestName = "Тест высоты ведра с меньше заданным значением")]
        public void SetTheHeightOfTheBucketNegativeTest(double height)
        {
            var bucket = new BucketParamtr();
            Assert.Throws<TheHeightOfTheBucketException>(() =>
            bucket.TheHeightOfTheBucket = height);
        }
        #endregion

        #region Тесты на толщину стали дна ведра
        [TestCase(0.35, TestName = "Тест толщины стали ведра с праельным значением")]
        public void SetThicknessOfSteel(double thickness)
        {
            var bucket = new BucketParamtr();
            bucket.ThicknessOfSteel = thickness;
        }

        [TestCase(0.34, TestName = "Тест толщины стали больше заданным значением")]
        [TestCase(0.56, TestName = "Тест толщины стали меньше заданным значением")]
        public void SetThicknessOfSteelNegativeTest(double thickness)
        {
            var bucket = new BucketParamtr();
            Assert.Throws<ThicknessOfSteelException>(() =>
            bucket.ThicknessOfSteel = thickness);
        }
        #endregion

        #region Тесты на толщину ободка дна ведра
        [TestCase(0.5, TestName = "Тест толщины ободка с правельным значением")]
        public void SetThicknessOfTheBowTest(double thickness)
        {
            var bucket = new BucketParamtr();
            bucket.ThicknessOfTheBow = thickness;
        }

        [TestCase(1.3, TestName = "Тест диаметра дна с больше заданным значением")]
        [TestCase(0.4, TestName = "Тест диаметра дна с меньше заданным значением")]
        public void SetThicknessOfTheBowNegativeTest(double thickness)
        {
            var bucket = new BucketParamtr();
            Assert.Throws<ThicknessOfTheBowException>(() =>
            bucket.ThicknessOfTheBow = thickness);
        }
        #endregion
    }
}

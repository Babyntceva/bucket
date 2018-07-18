using System;
using Kompas6API5;
using Kompas6Constants3D;
using BucketSetting;

namespace KompasProgram
{
    /// <summary>
    /// Класс построения детали
    /// </summary>
    public class ProgramKompas
    {
        /// <summary>
        /// Объект компаса
        /// </summary>
        private KompasObject _kompasObject;

        /// <summary>
        /// Обект 3D документа
        /// </summary>
        private ksDocument3D _ksDocument3D;

        /// <summary>
        /// Объект ведра
        /// </summary>
        private BucketParamtr _bucket = new BucketParamtr();

        /// <summary>
        /// Объект детали
        /// </summary>
        private ksPart _ksPart;

        /// <summary>
        /// Запись параметров
        /// </summary>
        /// <param name="setting"></param>
        public void SetParametr(BucketParamtr setting)
        {
            _bucket = setting;
        }

        /// <summary>
        /// Запуск компаса
        /// </summary>
        private void RunningTheCompas()
        {
            if(_kompasObject != null)
            {
                _kompasObject.Visible = true;
                _kompasObject.ActivateControllerAPI();
            }
            if(_kompasObject == null)
            {
                Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompasObject = (KompasObject)Activator.CreateInstance(type);
            }
        }

        /// <summary>
        /// Создание нового 3Д документа
        /// </summary>
        private void CreateNewDocument()
        {
            _ksDocument3D = (ksDocument3D)_kompasObject.Document3D();
            _ksDocument3D.Create();
        }

        /// <summary>
        /// Получение интерфеса компонента
        /// </summary>
        private void GetTheComponentInterface()
        {
            const int pTop_Part = -1;
            _ksPart = (ksPart)_ksDocument3D.GetPart(pTop_Part);
        }

        /// <summary>
        /// Создание эскиза окружности дна ведра
        /// </summary>
        /// <param name="part">Объект детали</param>
        /// <param name="ksEntityDrawDiameterOfTheBottom">Диаметр дна</param>
        /// <param name="ksEntityCircle">Круг</param>
        /// <param name="ksEntityPlaneOffset">Плоскать</param>
        private void CreatSkethDiametrOfBottom(ksPart part,
            ksEntity ksEntityCircle,double diametrDouble,
            short plane,double xCoord)
        {
            ksSketchDefinition ksSketchDefinition;
            ksDocument2D ksDocument2D;
            ksEntity ksEntityPlane;
            ksSketchDefinition = (ksSketchDefinition)
                ksEntityCircle.GetDefinition();
            ksEntityPlane = (ksEntity)
                part.GetDefaultEntity(plane);
            ksSketchDefinition.SetPlane(ksEntityPlane);
            ksEntityCircle.Create();
            ksDocument2D = (ksDocument2D)ksSketchDefinition.BeginEdit();
            ksDocument2D.ksCircle(xCoord, 0, diametrDouble, 1);
            ksSketchDefinition.EndEdit();
        }

        /// <summary>
        /// Создание окружности дна ведра
        /// </summary>
        /// <param name="part">Объект детали</param>
        /// <param name="ksEntityDrawDiameterOfTheBottom">Диаметр дна</param>
        /// <param name="ksEntityCircle">Круг</param>
        /// <param name="ksEntityPlaneOffset">Плоскать</param>
        private void CreatSkethDiametrOfBottomCut(ksPart part,
            ksEntity ksEntityCircle,ksEntity ksEntityPlaneOffSet,
            double diametrDouble)
        {
            double half = 2;
            ksSketchDefinition ksSketchDefinition;
            ksDocument2D ksDocument2D;
            diametrDouble -= _bucket.ThicknessOfSteel;
            ksSketchDefinition = (ksSketchDefinition)
                ksEntityCircle.GetDefinition();
            ksSketchDefinition.SetPlane(ksEntityPlaneOffSet);
            ksEntityCircle.Create();
            ksDocument2D = (ksDocument2D)ksSketchDefinition.BeginEdit();
            ksDocument2D.ksCircle(0, 0, diametrDouble/half, 1);
            ksSketchDefinition.EndEdit();
        }

        /// <summary>
        /// Расчёт угола наклона конуса 
        /// </summary>
        /// <param name="DiameterOfTheBottom">Диаметр дна</param>
        /// <param name="TheDiameterOfTheThroat">Диаметр горла</param>
        /// <param name="TheHeightOfTheBucket">Высота ведра</param>
        /// <returns>Возвращает угол наклона</returns>
        private double CuttingСorners(double DiameterOfTheBottom,
            double TheDiameterOfTheThroat,
            double TheHeightOfTheBucket)
        {
            double angleRadian;
            double baseOfTheCone;
            double catheter;
            double angle;
            double squareRoot = 2;
            double half = 2;
            double angleOfHalfACircle = 180;
            baseOfTheCone = Math.Sqrt(Math.Pow(TheHeightOfTheBucket,
                squareRoot)
                + Math.Pow(TheDiameterOfTheThroat
                - DiameterOfTheBottom, squareRoot));
            catheter = Math.Sqrt(Math.Pow(baseOfTheCone,
                squareRoot) 
                - Math.Pow(TheHeightOfTheBucket, squareRoot));
            angleRadian = TheHeightOfTheBucket / catheter;
             angle = (angleOfHalfACircle /
                (Math.PI * angleRadian)) / half;
            return Math.Round(angle, 1);
        }

        /// <summary>
        /// Выдавливание
        /// </summary>
        /// <param name="size">длина</param>
        /// <param name="ksEntity">эскиз</param>
        /// <param name="name">название</param>
        /// <param name="ksEntityExtrusion">выдавливание</param>
        private void Extrusion(double size, ksEntity ksEntity,
            string name,ksEntity ksEntityExtrusion)
        {
            double angle = CuttingСorners(_bucket.DiameterOfTheBottom,
                _bucket.TheDiameterOfTheThroat, _bucket.TheHeightOfTheBucket);
            const int  blueColor = 10046464;
            ksEntityExtrusion = (ksEntity)_ksPart.NewEntity(
                (int)Obj3dType.o3d_baseExtrusion);
            ksBaseExtrusionDefinition baseExtrusionDefinition =
                (ksBaseExtrusionDefinition)ksEntityExtrusion.GetDefinition();
            baseExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind,
                size, angle, true);
            baseExtrusionDefinition.SetSketch(ksEntity);
            ksEntityExtrusion.name = name;
            ksEntityExtrusion.useColor = 0;
            ksEntityExtrusion.SetAdvancedColor(blueColor, 0.9, 0.8,
                0.7, 0.6, 1, 0.4);
            ksEntityExtrusion.Create();
        }

        /// <summary>
        /// Сдвигаем плоскоть
        /// </summary>
        /// <param name="offset">сдвиг</param>
        /// <param name="plane">обект детали</param>
        /// <param name="ksEntityPlaneOffset">плоскость</param>
        private void CreatPlaneOffset(double offset, short plane,
            ksEntity ksEntityPlaneOffset)
        {
            ksEntity ksEntityPlaneXOY = (ksEntity)
                _ksPart.GetDefaultEntity(plane);
            ksPlaneOffsetDefinition ksPlaneOffsetDefinition =
                (ksPlaneOffsetDefinition)ksEntityPlaneOffset.GetDefinition();
            ksPlaneOffsetDefinition.SetPlane(ksEntityPlaneXOY);
            ksPlaneOffsetDefinition.direction = true;
            ksPlaneOffsetDefinition.offset = -offset;
            ksEntityPlaneOffset.Create();
        }

        /// <summary>
        /// Выдавливание вырезанием
        /// </summary>
        /// <param name="name">Название операции</param>
        /// <param name="ksEntityExtrusion">выдавливание</param>
        /// <param name="ksEntityDrawTwo">эскиз</param>
        /// <param name="size">Длина</param>
        private void ExstrusionCut(string name, ksEntity ksEntityExtrusion,
             ksEntity ksEntityDrawTwo,double size)
        {
            double angle = CuttingСorners(_bucket.DiameterOfTheBottom,
                _bucket.TheDiameterOfTheThroat, _bucket.TheHeightOfTheBucket);
            int grayColor = 2368548;
            ksCutExtrusionDefinition ksCutExtrusionDefinition =
                (ksCutExtrusionDefinition)ksEntityExtrusion.GetDefinition();
            ksCutExtrusionDefinition.SetSideParam(false,
                (short)End_Type.etBlind,
                size, angle, true);
            ksCutExtrusionDefinition.SetSketch(ksEntityDrawTwo);
            ksEntityExtrusion.name = name;
            ksEntityExtrusion.useColor = 0;
            ksEntityExtrusion.SetAdvancedColor(grayColor, 0.9, 0.8,
                0.7, 0.6, 1, 0.4);
            ksEntityExtrusion.Create();
        }

        /// <summary>
        /// Создать эскиз дуги
        /// </summary>
        /// <param name="part">объект детали</param>
        /// <param name="ksEntityDraw">название</param>
        private void CreatSketchMethod(ksPart part,
            ksEntity ksEntityDraw)
        {
            ksSketchDefinition _ksSketchDefinition;
            ksDocument2D _ksDocument2D;
            ksEntity ksEntityPlane;
            _ksSketchDefinition = (ksSketchDefinition)ksEntityDraw.
                GetDefinition();
            ksEntityPlane = (ksEntity)part.GetDefaultEntity
                ((short)Obj3dType.o3d_planeXOZ);
            _ksSketchDefinition.SetPlane(ksEntityPlane);
            ksEntityDraw.Create();
            _ksDocument2D = (ksDocument2D)_ksSketchDefinition.BeginEdit();
            _ksDocument2D.ksArcBy3Points(_bucket.TheDiameterOfTheThroat / 2
                , 0, 0, _bucket.DiameterOfTheBottom/2,
                _bucket.TheDiameterOfTheThroat / -2, 0, 1);
            _ksSketchDefinition.EndEdit();
        }

        /// <summary>
        /// Выдавливание по траектории
        /// </summary>
        /// <param name="entityEvolution">вырез кинматики</param>
        /// <param name="skechOne">Эскиз сечения</param>
        /// <param name="skechTwo">Эскиз траектории</param>
        /// <param name="ksEntityCollection"></param>
            private void KinematicExstrusion(ksEntity skechOne,
                ksEntity skechTwo)
        {
            ksEntity entityEvolution =
                (ksEntity)_ksPart.NewEntity((short)Obj3dType.o3d_baseEvolution);
            ksBaseEvolutionDefinition baseEvolutionDefinition =
                (ksBaseEvolutionDefinition)entityEvolution.GetDefinition();
            baseEvolutionDefinition.sketchShiftType = 1;
            baseEvolutionDefinition.SetSketch(skechOne);
            ksEntityCollection ksEntityCollection =
                (ksEntityCollection)baseEvolutionDefinition.PathPartArray();
            ksEntityCollection.Clear();
            ksEntityCollection.Add(skechTwo);
            entityEvolution.Create();
            
        }

        /// <summary>
        /// Построение детали
        /// </summary>
        public void Construct()
        {
            RunningTheCompas();
            CreateNewDocument();
            GetTheComponentInterface();
            _kompasObject.Visible = true;
            ksEntity ksEntityPlaneOffset = (ksEntity)_ksPart.NewEntity(
                (short)Obj3dType.o3d_planeOffset);
            ksEntity ksEntityCircle = (ksEntity)_ksPart.NewEntity(
                (short)Obj3dType.o3d_sketch);
            ksEntity ksEntityDraw = (ksEntity)_ksPart.NewEntity(
                (short)Obj3dType.o3d_sketch);
            ksEntity ksEntityDrawCircle = (ksEntity)_ksPart.NewEntity(
                (short)Obj3dType.o3d_sketch);
            ksEntity ksEntityDrawThree = (ksEntity)_ksPart.NewEntity(
                (short)Obj3dType.o3d_sketch);
            ksEntity ksEntityDrawTwo = (ksEntity)_ksPart.NewEntity(
               (short)Obj3dType.o3d_sketch);
            CreatSkethDiametrOfBottom(_ksPart, ksEntityDraw,
                _bucket.TheDiameterOfTheThroat/2,(short)Obj3dType.o3d_planeXOY,
                0);
            ksEntity ksEntityExtrusion = (ksEntity)_ksPart.NewEntity(
                (short)Obj3dType.o3d_cutExtrusion);
            Extrusion(_bucket.TheHeightOfTheBucket,
                ksEntityDraw, "Выдавливание", ksEntityExtrusion);
            CreatPlaneOffset(_bucket.ThicknessOfSteel,
                (short)Obj3dType.o3d_planeXOY,
                ksEntityPlaneOffset);
            CreatSkethDiametrOfBottomCut(_ksPart, ksEntityDrawTwo,
                ksEntityPlaneOffset, _bucket.TheDiameterOfTheThroat);
            ExstrusionCut("Выдавливание вырезанием", ksEntityExtrusion,
               ksEntityDrawTwo, _bucket.TheHeightOfTheBucket);
            CreatSketchMethod(_ksPart,ksEntityDrawThree);
            CreatSkethDiametrOfBottom(_ksPart, ksEntityDrawCircle,
                _bucket.ThicknessOfTheBow,
                (short)Obj3dType.o3d_planeXOY,_bucket.TheDiameterOfTheThroat/2);
            KinematicExstrusion(ksEntityDrawCircle, ksEntityDrawThree);
        }
    }
}

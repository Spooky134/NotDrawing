using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace NotDrawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<object> data;
        private readonly Assembly assembly;
        private Type type;
        private Type typeCircle;
        private readonly Type typeShape;
        private readonly Type typeLine;
        private readonly Type typeTriangle;
        private readonly Type typeRectangle;
        private  object obj;
        private readonly MethodInfo methodDraw;
        private readonly MethodInfo sFieldOne;
        private readonly MethodInfo sFieldTwo; 
        
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                assembly = Assembly.LoadFrom("../../../../NotShapes/bin/Debug/net5.0-windows/NotShapes.dll");
                typeShape = assembly.GetType("NotShapes.NotShape", true, true);
                obj = Activator.CreateInstance(typeShape);

                sFieldOne = typeShape.GetMethod("SetFirstPoint");
                sFieldTwo = typeShape.GetMethod("SetSecondPoint");

                methodDraw = typeShape.GetMethod("Draw");


                assembly = Assembly.LoadFrom("../../../../NotCircles/bin/Debug/net5.0-windows/NotCircles.dll");
                typeCircle = assembly.GetType("NotCircles.NotCircle", true, true);

                assembly = Assembly.LoadFrom("../../../../NotLines/bin/Debug/net5.0-windows/NotLines.dll");
                typeLine = assembly.GetType("NotLines.NotLine", true, true);

                assembly = Assembly.LoadFrom("../../../../NotTriangles/bin/Debug/net5.0-windows/NotTriangles.dll");
                typeTriangle = assembly.GetType("NotTriangles.NotTriangle", true, true);

                assembly = Assembly.LoadFrom("../../../../NotRectangles/bin/Debug/net5.0-windows/NotRectangles.dll");
                typeRectangle = assembly.GetType("NotRectangles.NotRectangle", true, true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            data = new List<object>();
            canvas.MouseMove -= Canvas_MouseMove;
        }
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            obj = Activator.CreateInstance(type);
            sFieldOne.Invoke(obj,new object[] { e.GetPosition(canvas) } );
        }
        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {   
            sFieldTwo.Invoke(obj, new object[] { e.GetPosition(canvas) });
            methodDraw.Invoke(obj, new object[] { canvas });
            data.Add(obj);
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //sFieldTwo.Invoke(obj, new object[] { e.GetPosition(this) });

            //methodDraw.Invoke(obj, new object[] { canvas });
            //if (canvas.Children.Count > 2)
            //{
            //    canvas.Children.RemoveAt(canvas.Children.C);
            //}
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radButon = (RadioButton)sender;
            switch(radButon.Name)
            {
                case "Bline":
                    {
                        type = typeLine;
                        break;
                    }
                case "Btriangle":
                    {
                        type = typeTriangle;
                        break;
                    }
                case "Brectangle":
                    {
                        type = typeRectangle;
                        break;
                    }
                case "Bcircle":
                    {
                        type = typeCircle;
                        break;
                    }
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            data.Clear();
            canvas.Children.Clear();
        }
       
        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            object[] newData;
            var formatter = new XmlSerializer(typeof(object[]), new[] {typeShape, typeLine,typeTriangle,typeRectangle,typeCircle });
            using var fs = new FileStream("Figures.xml", FileMode.OpenOrCreate);
            newData = (object[])formatter.Deserialize(fs);
            for (var i = 0; i < newData.Length; i++)
            {
                methodDraw.Invoke(newData[i], new object[] { canvas });
                data.Add(newData[i]);
            }
           
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var formatter = new XmlSerializer(typeof(List<object>), new[] {typeShape, typeLine, typeTriangle, typeRectangle, typeCircle });
            using var fs = new FileStream("Figures.xml", FileMode.OpenOrCreate);
                formatter.Serialize(fs, data);
        }
    }
}

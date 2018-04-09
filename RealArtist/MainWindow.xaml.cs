using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RealArtist
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
                   
        public double FirstCoordinateX { get; set; }                 //координаты первой точки
        public double FirstCoordinateY { get; set; }
        public double LastCoordinateX { get; set; }                  //координаты при отпускании кнопки мыши
        public double LastCoordinateY { get; set; }

        public string Shape { get; set; } = "noShape";                            //значение выбранной фигуры
        public SolidColorBrush DrawC { get; set; } = Brushes.Black;  //цвет рисуемых фигур
        public Color DrawBrushC { get; set; } = Colors.Black;        //цвет кисьти
        public double StrokeShape { get; set; } = 2;                 //толщина рисуемой фигуры

        public bool toggle { get; set; } = false;                    //включатель 
        public bool togglePolygon { get; set; } = false;             //включатель многоугольника
        public Point FirstPoint { get; set; }
        
        public void PenEraser_Click(object sender, RoutedEventArgs e)       //стирает нарисованное
        {
            Shape = "noShape";
            Album.DefaultDrawingAttributes.Height = 40;
            Album.DefaultDrawingAttributes.Width = 40;
            Album.DefaultDrawingAttributes.Color = Colors.White;           
        }

        private void BGray_Click(object sender, RoutedEventArgs e)      //меняет цвет кисти
        {
            Album.DefaultDrawingAttributes.Color = Colors.Gray;
            DrawBrushC = Colors.Gray;
            DrawC = Brushes.Gray;
        }

        private void BBlack_Click(object sender, RoutedEventArgs e)
        {
            Album.DefaultDrawingAttributes.Color = Colors.Black;
            DrawBrushC = Colors.Black;
            DrawC = Brushes.Black;
        }

        private void BWhite_Click(object sender, RoutedEventArgs e)
        {
            Album.DefaultDrawingAttributes.Color = Colors.White;
            DrawBrushC = Colors.White;
            DrawC = Brushes.White;
        }

        private void BREd_Click(object sender, RoutedEventArgs e)
        {
            Album.DefaultDrawingAttributes.Color = Colors.Red;
            DrawBrushC = Colors.Red;
            DrawC = Brushes.Red;
        }

        private void BOrange_Click(object sender, RoutedEventArgs e)
        {
            Album.DefaultDrawingAttributes.Color = Colors.Orange;
            DrawBrushC = Colors.Orange;
            DrawC = Brushes.Orange;
        }

        private void BYellow_Click(object sender, RoutedEventArgs e)
        {
            Album.DefaultDrawingAttributes.Color = Colors.Yellow;
            DrawBrushC = Colors.Yellow;
            DrawC = Brushes.Yellow;
        }

        private void BLawnGreen_Click(object sender, RoutedEventArgs e)
        {
            Album.DefaultDrawingAttributes.Color = Colors.LawnGreen;
            DrawBrushC = Colors.LawnGreen;
            DrawC = Brushes.LawnGreen;
        }

        private void BGreen_Click(object sender, RoutedEventArgs e)
        {
            Album.DefaultDrawingAttributes.Color = Colors.Green;
            DrawBrushC = Colors.Green;
            DrawC = Brushes.Green;
        }

        private void BAquamarine_Click(object sender, RoutedEventArgs e)
        {
            Album.DefaultDrawingAttributes.Color = Colors.Aquamarine;
            DrawBrushC = Colors.Aquamarine;
            DrawC = Brushes.Aquamarine;
        }

        private void BSkyBlue_Click(object sender, RoutedEventArgs e)
        {
            Album.DefaultDrawingAttributes.Color = Colors.DeepSkyBlue;
            DrawBrushC = Colors.DeepSkyBlue;
            DrawC = Brushes.DeepSkyBlue;
        }

        private void BBlue_Click(object sender, RoutedEventArgs e)
        {
            Album.DefaultDrawingAttributes.Color = Colors.Blue;
            DrawBrushC = Colors.Blue;
            DrawC = Brushes.Blue;
        }

        private void BPurple_Click(object sender, RoutedEventArgs e)
        {
            Album.DefaultDrawingAttributes.Color = Colors.Purple;
            DrawBrushC = Colors.Purple;
            DrawC = Brushes.Purple;
        }

        private void BPink_Click(object sender, RoutedEventArgs e)
        {
            Album.DefaultDrawingAttributes.Color = Colors.HotPink;
            DrawBrushC = Colors.HotPink;
            DrawC = Brushes.HotPink;
        }

        private void BSmall_Click(object sender, RoutedEventArgs e)     //устанавливает толщину кисти на минимальный
        {
            Album.DefaultDrawingAttributes.Height = 2;
            Album.DefaultDrawingAttributes.Width = 2;
            StrokeShape = 2;
        }

        private void BMiddle_Click(object sender, RoutedEventArgs e)     //устанавливает толщину кисти на средний   
        {
            Album.DefaultDrawingAttributes.Height = 10;
            Album.DefaultDrawingAttributes.Width = 10;
            StrokeShape = 10;
        }

        private void BBig_Click(object sender, RoutedEventArgs e)       //устанавливает толщину кисти на большой
        {
            Album.DefaultDrawingAttributes.Height = 20;
            Album.DefaultDrawingAttributes.Width = 20;
            StrokeShape = 20;
        }

        private void BOpacityPaper_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double tempValue = Convert.ToDouble(CopacityValue.Text);
                Album.Opacity = tempValue;
            }
            catch
            {
                MessageBox.Show("Не правильно введено значение, убедитесь, что стоит от 0,1 до 1\nПроверьте стоит ли запятая, а не точка");
            }
        }

        private void Brush_Click(object sender, RoutedEventArgs e)
        {
            Shape = "noShape";
            Album.DefaultDrawingAttributes.Color = DrawBrushC;
            try
            {
                int tempHeight = Convert.ToInt16(HeigthBrush.Text);
                int tempWidth = Convert.ToInt16(WidthBrush.Text);
                Album.DefaultDrawingAttributes.Height = tempHeight;
                Album.DefaultDrawingAttributes.Width = tempWidth;
            }
            catch
            {
                MessageBox.Show("Введите целые числа ниже Кисточки (H-высоту кисти и W-ширину кисти)");
            }

        }

        private void SizeOfAlbum_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int tempHeight = Convert.ToInt16(HeightAlbum.Text);
                int tempWidth = Convert.ToInt16(WidthAlbum.Text);
                Album.Height = tempHeight;
                Album.Width = tempWidth;
            }
            catch
            {
                MessageBox.Show("Введите целые числа ниже(H-высоту и W-ширину)");
            }
        }

        private void BLine_Click(object sender, RoutedEventArgs e)                      //определяет форму рисунка
        {
            Shape = "Line";        
        }
    
        private void Album_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)     //событие при отпускании кнопки мыши
        {
            toggle = false;
            //Album.UseCustomCursor = false;
        }

        private void Album_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FirstCoordinateX = e.GetPosition(Album).X;
            FirstCoordinateY = e.GetPosition(Album).Y;
            LastCoordinateX = e.GetPosition(Album).X;
            LastCoordinateY = e.GetPosition(Album).Y;

            FirstPoint= new Point(e.GetPosition(Album).X, e.GetPosition(Album).Y);
            FormSelection();
            toggle = true;
            /*if (e.LeftButton == MouseButtonState.Pressed)
            {

            }*/            
        }

        private void Album_PreviewMouseMove(object sender, MouseEventArgs e)                //собыьтие при перемещении мыши 
        {
            double X, Y;
            X = e.GetPosition(Album).X;
            Y = e.GetPosition(Album).Y;
            if (Shape == "noShape")
            {
                return;
            }
            if (toggle == false)
            {
                return;
            }                         
            
            if (Shape == "Line")                        //если фигура ЛИНИЯ
            {                
                FinishLine(X, Y);
            }
            if (Shape == "Circle")                      //если фигура КРУГ
            {
                FinishCircle(X, Y);               
            }
            if ((Shape== "Rectangle")||(Shape=="Ellipse"))
            {
                FinishShape(X, Y);               
            }
        }

        private void FormSelection()                                                    //вызов функции отвечающей за конкретныую форму
        {
            if (Shape != "noShape")
            {
                Album.UseCustomCursor = true;                
            }
            else
            {
                Album.UseCustomCursor = false;
            }
            switch (Shape)
            {
                case "Line":
                    Album.DefaultDrawingAttributes.Color = Colors.Transparent;
                    DrawLine();
                    break;
                case "Rectangle":
                    Album.DefaultDrawingAttributes.Color = Colors.Transparent;
                    DrawRectangle();
                    break;
                case "Ellipse":
                    Album.DefaultDrawingAttributes.Color = Colors.Transparent;
                    DrawEllipse();
                    break;
                case "Circle":
                    Album.DefaultDrawingAttributes.Color = Colors.Transparent;
                    DrawEllipse();
                    break;
                case "Polygon":
                    Album.DefaultDrawingAttributes.Color = Colors.Transparent;
                    if (togglePolygon == true)
                    {
                        FinishPolygon(FirstCoordinateX, FirstCoordinateY);
                    }
                    DrawPolygon();                  
                    break;
                default:
                    break;
            }
        }

        private void DrawLine()                     //рисует линию
        {
            Line myLine = new Line
            {
                Stroke = DrawC,
                X1 = FirstCoordinateX,      
                X2 = LastCoordinateX,
                Y1 = FirstCoordinateY,      
                Y2 = LastCoordinateY,
                StrokeThickness = StrokeShape
            };                   
            Album.Children.Add(myLine);
        }

        private void DrawRectangle()                            //рисует прямоугольник
        {
            Rectangle myRectangle = new Rectangle()
            {
                Stroke = DrawC,
                Margin = new Thickness(FirstCoordinateX, FirstCoordinateY, 0, 0),
                StrokeThickness = StrokeShape,
                Height = 0,
                Width =0
            };
            Album.Children.Add(myRectangle);
        }

        private void DrawEllipse()                             //рисует овал 
        {
            Ellipse myEllipse = new Ellipse()
            {
                Stroke = DrawC,
                Margin = new Thickness (FirstCoordinateX, FirstCoordinateY, 0, 0),
                StrokeThickness=StrokeShape, 
                Height=0,
                Width=0
            };
            Album.Children.Add(myEllipse);
        }

        private void DrawPolygon()
        {
            togglePolygon = true;
            Polygon myPolygon = new Polygon
            {
                Stroke = DrawC,
                StrokeThickness = StrokeShape                
            };
            /*Point point1 = new Point(FirstCoordinateX,FirstCoordinateY);         
            PointCollection myPointCollections = new PointCollection
            {
                point1
            };
            myPolygon.Points= myPointCollections;*/
            myPolygon.Points.Add(FirstPoint);
            
            Album.Children.Add(myPolygon);
        }


        private void FinishPolygon(double X, double Y)
        {
            Point point1 = new Point(X, Y);            
            Polygon newPolygon = (Polygon)Album.Children[Album.Children.Count - 1];            
            newPolygon.Points.Add(point1);
            
            /*double tempX, tempY;
            tempX = newPolygon.Points[0].X;
            tempY = newPolygon.Points[0].Y;
            if (((X>=(tempX-10.0))||(X<=(tempX+10.0)))&& ((Y >= (tempY - 10.0)) || (Y <= (tempY + 10.0))))
            {
                togglePolygon = false;               
            }    */       
        }

        private void FinishShape(double X, double Y)
        {
            Shape newShape = (Shape)Album.Children[Album.Children.Count - 1];       //Если фигура прямоугольник или ОВАЛ
            double tempX, tempY;
            if (((X) - FirstCoordinateX) > 0)
            {
                newShape.Width = (X) - FirstCoordinateX;
                tempX = FirstCoordinateX;
            }
            else
            {
                newShape.Width = FirstCoordinateX - X;
                tempX = X;
            }
            if (((Y) - FirstCoordinateY) > 0)
            {
                newShape.Height = (Y) - FirstCoordinateY;
                tempY = FirstCoordinateY;
            }
            else
            {
                newShape.Height = FirstCoordinateY - Y;
                tempY = Y;
            }
            newShape.Margin = new Thickness(tempX, tempY, 0, 0);
        }

        private void FinishLine(double X, double Y)
        {
            Line newLine = (Line)Album.Children[Album.Children.Count - 1];
            newLine.X2 = X;
            newLine.Y2 = Y;
        }

        private void FinishCircle(double X, double Y)
        {
            Ellipse newCircle = (Ellipse)Album.Children[Album.Children.Count - 1];
            double tempX, tempY, tempW, tempH;

            //определение диаметра круга

            tempW = 2 * Math.Abs((X) - FirstCoordinateX);
            tempH = 2 * Math.Abs((Y) - FirstCoordinateY);

            if (tempH >= tempW)                                     //определение диаметра круга
            {
                newCircle.Height = tempH;
                newCircle.Width = tempH;
                tempX = FirstCoordinateX - tempH / 2;
                tempY = FirstCoordinateY - tempH / 2;
            }
            else
            {
                newCircle.Width = tempW;
                newCircle.Height = tempW;
                tempX = FirstCoordinateX - tempW / 2;
                tempY = FirstCoordinateY - tempW / 2;
            }
            newCircle.Margin = new Thickness(tempX, tempY, 0, 0);      //определение координат круга, от краёв альбома
        }

        private void Pencil_Click(object sender, RoutedEventArgs e)             //выбор карандаша
        {
            Shape = "noShape";
            Album.DefaultDrawingAttributes.Color = DrawBrushC;
            Album.DefaultDrawingAttributes.Height = 2;
            Album.DefaultDrawingAttributes.Width = 2;           
        }

        private void Pipetka_Click(object sender, RoutedEventArgs e)            //выбор пипетки
        {
            Shape = "noShape";   
        }

        private void PaintOver_Click(object sender, RoutedEventArgs e)          //выбор закраски
        {
            Shape = "noShape";
        }

        private void BRectangle_Click(object sender, RoutedEventArgs e)         //выбор рисования прямоугольника
        {
            Shape = "Rectangle";            
        }

        private void BEllipse_Click(object sender, RoutedEventArgs e)           //выбор рисования овала
        {
            Shape = "Ellipse";
        }

        private void BCircle_Click(object sender, RoutedEventArgs e)            //выбор рисования круга
        {
            Shape = "Circle";
        }

        private void BPolygon_Click(object sender, RoutedEventArgs e)
        {
            Shape = "Polygon";            
        }

        private void BClear_Click(object sender, RoutedEventArgs e)
        {
            Album.Children.Clear();
            Album.Strokes.Clear();
        }

        private void SaveP_Click(object sender, RoutedEventArgs e)
        {
            /*string path = "MyPicture.bin";
            if (File.Exists("MyPicture.bin"))
            {
                path.IndexOf('.');
            }*/
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            using (FileStream fs = new FileStream("MyPicture.bin", FileMode.Create))
            {
                Album.Strokes.Save(fs);                
            }
        }

        private void OpenP_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();

            using (FileStream fs = new FileStream("MyPicture.bin", FileMode.Open, FileAccess.Read))
            {
                StrokeCollection sc = new StrokeCollection(fs);
                Album.Strokes=sc;
            }
        }

        private void SelectO_Click(object sender, RoutedEventArgs e)
        {
            Album.EditingMode = InkCanvasEditingMode.Select;
        }

        private void RightP_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Album_MouseRightButtonDown(object sender, MouseButtonEventArgs e)      //отмена последнего рисования
        {
            

        }
    }

}


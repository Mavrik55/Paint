using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;



namespace Splines
{
    public partial class Form1 : Form
    {
        // массив в который будут заносится управляющие точки
        private float[,] DrawingArray = new float[64, 2];

        // количество точек
        private int count_points = 0;

        // размеры окна 
        double ScreenW, ScreenH;

        // отношения сторон окна визуализации
        // для корректного перевода координат мыши в координаты, 
        // принятые в программе 

        private float devX;
        private float devY;

        // вспомогательные переменные для построения линий от курсора мыши к координатным осям 
        float lineX, lineY; 

        // текущение координаты курсора мыши 
        float Mcoord_X = 0, Mcoord_Y = 0; 


        /*
         * Состояние захвата вершины мышью (при редактированиее)
         */

        int captured = -1; // -1 означает что нет захваченой, иначе - номер указывает на элемент массива, хранящий захваченную вершину
        
        
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();

          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация бибилиотеки glut 
            Glut.glutInit();
            // инициализация режима экрана 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            // установка цвета очистки экрана (RGBA) 
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            // активация проекционной матрицы 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очистка матрицы 
            Gl.glLoadIdentity();

            // определение параметров настройки проекции, в зависимости от размеров сторон элемента AnT. 
            if ((float)AnT.Width <= (float)AnT.Height)
            {
                ScreenW = 500.0;
                ScreenH = 500.0 * (float)AnT.Height / (float)AnT.Width;

                Glu.gluOrtho2D(0.0, ScreenW, 0.0, ScreenH);
            }
            else
            {
                ScreenW = 500.0 * (float)AnT.Width / (float)AnT.Height;
                ScreenH = 500.0;

                Glu.gluOrtho2D(0.0, 500.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 500.0);
            }

            // сохранение коэфицентов, которые нам необходимы для перевода координат указателя в оконной системе, в координаты 
            // принятые в нашей OpenGL сцене 
            devX = (float)ScreenW / (float)AnT.Width;
            devY = (float)ScreenH / (float)AnT.Height;

            // установка объектно-видовой матрицы 
            Gl.glMatrixMode(Gl.GL_MODELVIEW); 
            RenderTime.Start();

            comboBox1.SelectedIndex = 0;
        }

        // фукнция визуализации текста 
        private void PrintText2D(float x, float y, string text)
        {
            // устанавливаем позицию вывода растровых символов 
            // в переданных координатах x и y. 
            Gl.glRasterPos2f(x, y);

            // в цикле foreach перебираем значения из массива text, 
            // который содержит значение строки для визуализации 
            foreach (char char_for_draw in text)
            {
                // визуализируем символ c, с помощью функции glutBitmapCharacter, используя шрифт GLUT_BITMAP_9_BY_15. 
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_8_BY_13, char_for_draw);
            }
        } 

        // функция отрисовки, вызываемая событием таймера
        private void Draw()
        {
            // количество сегментов при расчете сплайна
            int N = 30;

            // вспомогательные переменные для расчета сплайна
            double X, Y;
            
            
            // n = count_points+1 означает что мы берем все созданные контрольные 
            // точки + ту, которая следует за мышью, для создания интерактивности приложения
            int eps = 4, i, j, n = count_points+1, first;
            double xA, xB, xC, xD, yA, yB, yC, yD, t;
            double a0, a1, a2, a3, b0, b1, b2, b3;

          
            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            // очищение текущей матрицы 
            Gl.glLoadIdentity();

            // утснаовка черного цвета 
            Gl.glColor3f(0, 0, 0);

            // помещаем состояние матрицы в стек матриц 
            Gl.glPushMatrix();

            Gl.glPointSize(5.0f);
            Gl.glBegin(Gl.GL_POINTS);

            Gl.glVertex2d(0, 0);

            Gl.glEnd();
            Gl.glPointSize(1.0f);

            PrintText2D(devX * Mcoord_X + 0.2f, (float)ScreenH - devY * Mcoord_Y + 0.4f, "[ x: " + (devX * Mcoord_X).ToString() + " ; y: " + ((float)ScreenH - devY * Mcoord_Y).ToString() + "]"); 


            // выполняем перемещение в прострастве по осям X и Y 

            // выполняем цикл по контрольным точкам
        for (i = 0; i < n; i++)
            {
                
            // сохраняем координаты точки (более легкое представления кода)
                X = DrawingArray[i, 0];
                Y = DrawingArray[i, 1];

            // если точка выделена (перетаскивается мышью)
                if (i == captured)
                {
                    // для ее отрисовки будут использоватся более толстые линии
                    Gl.glLineWidth(3.0f);
                }
                
                // начинаем отрисвку точки (квадрат)
                Gl.glBegin(Gl.GL_LINE_LOOP); 
                
                Gl.glVertex2d(X - eps, Y - eps);
                Gl.glVertex2d(X + eps, Y - eps);
                Gl.glVertex2d(X + eps, Y + eps);
                Gl.glVertex2d(X - eps, Y + eps);

                Gl.glEnd();
                
                // если была захваченная точка - необходимо вернуть толщину линий
                if (i == captured)
                {
                    // возвращаем прежнее значение
                    Gl.glLineWidth(1.0f);
                }
            }

           
            // дополнительный цикл по всем контрольным точкам - 
            // подписываем их координаты и номер
            for (i = 0; i < n; i++)
            {
                // координаты точки
                X = DrawingArray[i, 0];
                Y = DrawingArray[i, 1];
                // выводим подпись рядом с точкой
                PrintText2D((float)(X - 20), (float)(Y - 20), "P " + i.ToString() + ": " + X.ToString() + ", " + Y.ToString());
            }
            
            // начинает отрисовку кривой
            Gl.glBegin(Gl.GL_LINE_STRIP); 
            
            // используем все точки -1 (т,к. алгоритм "зацепит" i+1 точку
            for (i = 1; i < n-1; i++)
            {
                // реализация представленного в теоретическом описании алгоритма для калькуляции сплайна
                first = 1;
                xA = DrawingArray[i - 1, 0];
                xB = DrawingArray[i, 0];
                xC = DrawingArray[i + 1, 0];
                xD = DrawingArray[i + 2, 0];

                yA = DrawingArray[i - 1, 1];
                yB = DrawingArray[i, 1];
                yC = DrawingArray[i + 1, 1];
                yD = DrawingArray[i + 2, 1];

                a3 = (-xA + 3 * (xB - xC) + xD) / 6.0;

                a2 = (xA - 2 * xB + xC) / 2.0;

                a1 = (xC - xA) / 2.0;

                a0 = (xA + 4 * xB + xC) / 6.0;

                b3 = (-yA + 3 * (yB - yC) + yD) / 6.0;

                b2 = (yA - 2 * yB + yC) / 2.0;

                b1 = (yC - yA) / 2.0;

                b0 = (yA + 4 * yB + yC) / 6.0;

               // отрисовка сегментов 

                for (j = 0; j <= N; j++)
                {
                    // параметр t на отрезке от 0 до 1
                    t = (double)j / (double)N;

                    // генерация координат
                    X = (((a3 * t + a2) * t + a1) * t + a0);
                    Y = (((b3 * t + b2) * t + b1) * t + b0);

                    // и установка вершин
                    if (first == 1)
                    {
                        first = 0;
                        Gl.glVertex2d(X, Y);
                    }
                    else
                        Gl.glVertex2d(X, Y);

                }
               
            }
            Gl.glEnd();

           
            // завершаем рисование
            Gl.glFlush();

            // сигнал для обновление элемента реализующего визуализацию. 
            AnT.Invalidate();

        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                // созраняем координаты мыши 
                Mcoord_X = e.X;
                Mcoord_Y = e.Y;

                // вычисляем параметры для будующей дорисовке линий от указателя мыши к координатным осям. 
                lineX = devX * e.X;
                lineY = (float)(ScreenH - devY * e.Y);

                DrawingArray[count_points, 0] = lineX;
                DrawingArray[count_points, 1] = lineY;
            }
            else
            {
                // обычное протоколирование координат, для подсвечивания вершины в случае наведения
                // созраняем координаты мыши 
                Mcoord_X = e.X;
                Mcoord_Y = e.Y;

                // вычисляем параметры для будующей дорисовке линий от указателя мыши к координатным осям. 

                float _lastX = lineX;
                float _lastY = lineY;

                lineX = devX * e.X;
                lineY = (float)(ScreenH - devY * e.Y);

                if (captured != -1)
                {
                    DrawingArray[captured, 0] -= _lastX-lineX;
                    DrawingArray[captured, 1] -= _lastY-lineY;
                }

                

            }
            
        }

        private void AnT_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Mcoord_X = e.X;
                Mcoord_Y = e.Y;

                lineX = devX * e.X;
                lineY = (float)(ScreenH - devY * e.Y);

                DrawingArray[count_points, 0] = lineX;
                DrawingArray[count_points, 1] = lineY;

                count_points++;
            }
        }

        private void RenderTime_Tick(object sender, EventArgs e)
        {
            // обработка "тика" таймера - вызов функции отрисовки
            Draw();
        }

        private void AnT_MouseDown(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                Mcoord_X = e.X;
                Mcoord_Y = e.Y;

                lineX = devX * e.X;
                lineY = (float)(ScreenH - devY * e.Y);

                for (int ax = 0; ax < count_points; ax++)
                {
                    if (lineX < DrawingArray[ax, 0] + 5 && lineX > DrawingArray[ax, 0] - 5 && lineY < DrawingArray[ax, 1] + 5 && lineY > DrawingArray[ax, 1] - 5)
                    {
                        captured = ax;
                        break;
                    }
                }
            }
        }

        private void AnT_MouseUp(object sender, MouseEventArgs e)
        {
            captured = -1;
        }
    }

}

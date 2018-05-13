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


namespace GeometricTransformation
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            // инициализация для работы с openGL
            AnT.InitializeContexts();
        }

        // массив вершин создаваемого геометрического объекта
        private float[,] GeomObject = new float[32, 3];
        // счеткик его вершин
        private int count_elements = 0;

        // событие загрузки формы окна
        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация OpenGL, много раз комментированная ранее
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            
            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();


            Glu.gluPerspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 200);


            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_DEPTH_TEST);
          

            // пирамида для визуализации (4 точки)

            GeomObject[0, 0] = -0.7f;
            GeomObject[0, 1] = 0;
            GeomObject[0, 2] = 0;

            GeomObject[1, 0] = 0.7f;
            GeomObject[1, 1] = 0;
            GeomObject[1, 2] = 0;

            GeomObject[2, 0] = 0.0f;
            GeomObject[2, 1] = 0;
            GeomObject[2, 2] = 1.0f;

            GeomObject[3, 0] = 0;
            GeomObject[3, 1] = 0.7f;
            GeomObject[3, 2] = 0.3f;

            // количество вершин рассматриваемого геометричекого объекта
            count_elements = 4;
            // устанавливаем ось X по умолчанию
            comboBox1.SelectedIndex = 0;

            // начало визуализации (активируем таймер)
            RenderTimer.Start();
        }

        // функция отрисовки 
        private void Draw()
        {

            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            // очищение текущей матрицы 
            Gl.glLoadIdentity();

            // утснаовка черного цвета 
            Gl.glColor3f(0, 0, 0);

            // помещаем состояние матрицы в стек матриц 
            Gl.glPushMatrix();

            // перемещаем камеру для более хорошего обзора объекта
            Gl.glTranslated(0, 0, -7);
            // поворачиваем ее на 15 градусов
            Gl.glRotated(15, 1, 1, 0);

            // помещаем состояние матрицы в стек матриц 
            Gl.glPushMatrix();

            // начинаем отрисовку объекта
                Gl.glBegin(Gl.GL_LINE_LOOP);

                // геометрические данные ме бырем из массива GeomObject
                // рисуем основание с помощью зацикленной линии
                    Gl.glVertex3d(GeomObject[0, 0], GeomObject[0, 1], GeomObject[0, 2]);
                    Gl.glVertex3d(GeomObject[1, 0], GeomObject[1, 1], GeomObject[1, 2]);
                    Gl.glVertex3d(GeomObject[2, 0], GeomObject[2, 1], GeomObject[2, 2]);

                // завершаем отрисовку примитивов
                Gl.glEnd();

                // рисуем линии от вершин основания к вершине пирамиды
                Gl.glBegin(Gl.GL_LINES);

                Gl.glVertex3d(GeomObject[0, 0], GeomObject[0, 1], GeomObject[0, 2]);
                Gl.glVertex3d(GeomObject[3, 0], GeomObject[3, 1], GeomObject[3, 2]);

                Gl.glVertex3d(GeomObject[1, 0], GeomObject[1, 1], GeomObject[1, 2]);
                Gl.glVertex3d(GeomObject[3, 0], GeomObject[3, 1], GeomObject[3, 2]);

                Gl.glVertex3d(GeomObject[2, 0], GeomObject[2, 1], GeomObject[2, 2]);
                Gl.glVertex3d(GeomObject[3, 0], GeomObject[3, 1], GeomObject[3, 2]);
                
                // завершаем отрисовку примитивов
                Gl.glEnd();

            // возвращаем состояние матрицы
            Gl.glPopMatrix();

            // возвращаем состояние матрицы
            Gl.glPopMatrix();

            // отрисовываем геометрию
            Gl.glFlush();

            // обновляем состояние элемента
            AnT.Invalidate();
        }

        // фнукция масштабирования
        private void CreateZoom(float coef, int os)
        {
            // создаем матрицу
            float[,] Zoom3D = new float[3, 3];

            Zoom3D[0, 0] = 1;
            Zoom3D[1, 0] = 0;
            Zoom3D[2, 0] = 0;

            Zoom3D[0, 1] = 0;
            Zoom3D[1, 1] = 1;
            Zoom3D[2, 1] = 0;

            Zoom3D[0, 2] = 0;
            Zoom3D[1, 2] = 0;
            Zoom3D[2, 2] = 1;

            // устанавливаем коэфицент масштабирования для необходимой (выбранной и переданной в качестве параметра) оси
            Zoom3D[os, os] = coef;
            
            // вызываем функцию для выполнения умножения матриц, представляющих собой координта вершин геометрического объекта 
            // на созданную в данной функции матрицу
            multiply(GeomObject, Zoom3D);

        }

        // перенос
        private void CreateTranslate(float translate, int os)
        {
            // в виду простоты данного алгоритма, мы упростили его обработку - 
            // достаточно прибавить изменение (перенос) в координатах объекта по выбраной и переданной оси
            for (int ax = 0; ax < count_elements; ax++)
            {
                // обновление координат (для выбранной оси)
                GeomObject[ax, os] += translate;
            }
        }

        // реализация поворота
        private void CreateRotate(float angle, int os)
        {
           // массив, который будет содержать матрицу
            float[,] Rotate3D = new float[3, 3];

            // в зависимости от оси, матрицы будут координально различатся,
            // поэтому создаем необходимую матрицу в зависимости от оси, используя switch
            switch (os)
            {
                case 0: // вокруг оси Х
                    {
                        Rotate3D[0, 0] = 1;
                        Rotate3D[1, 0] = 0;
                        Rotate3D[2, 0] = 0;

                        Rotate3D[0, 1] = 0;
                        Rotate3D[1, 1] = (float)Math.Cos(angle);
                        Rotate3D[2, 1] = (float)-Math.Sin(angle);

                        Rotate3D[0, 2] = 0;
                        Rotate3D[1, 2] = (float)Math.Sin(angle);
                        Rotate3D[2, 2] = (float)Math.Cos(angle);
                        break;
                    }
                case 1: // вокруг оси Y
                    {
                        Rotate3D[0, 0] = (float)Math.Cos(angle);
                        Rotate3D[1, 0] = 0;
                        Rotate3D[2, 0] = (float)Math.Sin(angle);

                        Rotate3D[0, 1] = 0;
                        Rotate3D[1, 1] = 1;
                        Rotate3D[2, 1] = 0;

                        Rotate3D[0, 2] = (float)-Math.Sin(angle);
                        Rotate3D[1, 2] = 0;
                        Rotate3D[2, 2] = (float)Math.Cos(angle);
                        break;
                    }
                case 2: // вокруг оси Z
                    {
                        Rotate3D[0, 0] = (float)Math.Cos(angle);
                        Rotate3D[1, 0] = (float)-Math.Sin(angle);
                        Rotate3D[2, 0] = 0;

                        Rotate3D[0, 1] = (float)Math.Sin(angle);
                        Rotate3D[1, 1] = (float)Math.Cos(angle);
                        Rotate3D[2, 1] = 0;

                        Rotate3D[0, 2] = 0;
                        Rotate3D[1, 2] = 0;
                        Rotate3D[2, 2] = 1;
                        break;
                    }
            }

            // вызываем функцию для выполнения умножения матриц, представляющих собой координта вершин геометрического объекта 
            // на созданную в данной функции матрицу
            multiply(GeomObject, Rotate3D);

        }

        // функция умножения матриц
        private void multiply(float[,] obj, float[,] matrix)
        {
            // временные переменные
            float res_1, res_2, res_3;

            // проходим циклом по всем координатам (представляющие собой матрицу A [x,y,z])
            // и умножаем каждую матрицу на матрицу B (переданную)
            // результат сразу заносим в массив геометрии

            for (int ax = 0; ax < count_elements; ax++)
            {
                res_1 = (obj[ax, 0] * matrix[0, 0] + obj[ax, 1] * matrix[0, 1] + obj[ax, 2] * matrix[0, 2]);
                res_2 = (obj[ax, 0] * matrix[1, 0] + obj[ax, 1] * matrix[1, 1] + obj[ax, 2] * matrix[1, 2]);
                res_3 = (obj[ax, 0] * matrix[2, 0] + obj[ax, 1] * matrix[2, 1] + obj[ax, 2] * matrix[2, 2]);

                obj[ax, 0] = res_1;
                obj[ax, 1] = res_2;
                obj[ax, 2] = res_3;

            }

        }

        

        // собтыие таймера - вызов отрисовки
        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            // функция отрсовки
            Draw();
        }

     
        // обработка событий от клавиатуры - нажание (клавиша зажата!)
        private void AnT_KeyDown(object sender, KeyEventArgs e)
        {
            // Z и X отвечают за масштабирование
            if (e.KeyCode == Keys.Z)
            {
                // вызов функции, в которой мы реализуем масштабирование - передаем коэфичент масштабирования и выбранную ось в окне программы
                CreateZoom(1.05f, comboBox1.SelectedIndex);
            }
            if (e.KeyCode == Keys.X)
            {
                // вызов функции, в которой мы реализуем масштабирование - передаем коэфичент масштабирования и выбранную ось в окне программы
                CreateZoom(0.95f, comboBox1.SelectedIndex);
            }
            
            // W и S отвечают за перенос
            if (e.KeyCode == Keys.W)
            {
                // вызов функции, в которой мы реализуем перенос - передаем значение перемещения и выбранную ось в окне программы
                CreateTranslate(0.05f, comboBox1.SelectedIndex);
            }
            if (e.KeyCode == Keys.S)
            {
                // вызов функции, в которой мы реализуем перенос - передаем значение перемещения и выбранную ось в окне программы
                CreateTranslate(-0.05f, comboBox1.SelectedIndex);
            }

            // A и D отвечают за поворот
            if (e.KeyCode == Keys.A)
            {
                // вызов функции, в которой мы реализуем поворот - передаем значение для поворота и выбранную ось
                CreateRotate(0.05f, comboBox1.SelectedIndex);
            }
            if (e.KeyCode == Keys.D)
            {
                CreateRotate(-0.05f, comboBox1.SelectedIndex);
            }

           
        }

        // дополнительное событие для элемента comboBox - если произошло
        // изменение его значения - утсановить фокус в элемент AnT
        // чтобы избежать перехват события нажатия клавиши данным элементом
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // устанавливаем фокус в AnT
            AnT.Focus();
        }

    }
}

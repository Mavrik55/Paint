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

namespace My_Paint
{
    public partial class Form1 : Form

    {
        // массив в который будут заносится управляющие точки
        private float[,] DrawingArray = new float[64, 2];

        // количество точек
        private int count_points = 0;
        private int max_point = 62;

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
         * Состояние захвата вершины мышью (при редактировании)
         */

        int captured = -1; // -1 означает что нет захваченой, иначе - номер указывает на элемент массива, хранящий захваченную вершину




    
        public Form1()
        {
            InitializeComponent();



            // инициализация элемента SimpleOpenGLControl (AnT)
            AnT.InitializeContexts();
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);








            //
               System.Drawing.Color backColor = AnT.BackColor;
               Gl.glClearColor((float)backColor.R / 255.0f,
            (float)backColor.G / 255.0f, (float)backColor.B / 255.0f, 1.0f);
        }

        private anEngine ProgrammDrawingEngine;
        
        // текущий активный слой
        private int ActiveLayer = 0;
        
        // счетчик слоев
        private int LayersCount = 1;

        // счетчик всех создаваемых слоев для генерации имен
        private int AllLayrsCount = 1;


       

        private void Form1_Load(object sender, EventArgs e)
        {
          
          
            // Glut.glutInit();
            // Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_SINGLE); не забыть
            
            // устанавливаем цвет очистки окна 
            Gl.glClearColor(255, 255, 255, 1);

            // устанавливаем порт вывода, основываясь на размерах элемента управления AnT 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            // устанавливаем проекционную матрицу 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очищаем ее 
            Gl.glLoadIdentity();


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

            devX = (float)ScreenW / (float)AnT.Width;
            devY = (float)ScreenH / (float)AnT.Height;
            
            Glu.gluOrtho2D(0.0, AnT.Width, 0.0, AnT.Height);

            // переходим к объектно-видовой матрице 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);

           
            RenderTimer.Start();
            comboBox1.SelectedIndex = 0;

            // добавление элемента, отвечающего за управления главным слоем в объект LayersControl
            Слои.Items.Add("Главный слой", true);



        }

        // событие Tick таймера
        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            // вызываем функция рисования
            Drawing();
        }

        // функция рисования
        private void Drawing()
        {
            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            // очищение текущей матрицы 
            Gl.glLoadIdentity();
            // утснаовка черного цвета 
            Gl.glColor3f(0, 0, 0);

            // визуализация изображения из движка
            ProgrammDrawingEngine.SwapImage();
            ProgrammDrawingEngine.SetColor(color1.BackColor);

            // дожидаемся завершения визуализации кадра 
            Gl.glFlush();
            // сигнал для обновление элемента реализующего визуализацию. 
            AnT.Invalidate();
        }

        // функция обработчик события движения мыши (событие MouseMove для элемента AnT)

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
             int eps = 4, i, j, n = count_points + 1, first;
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
            /* Gl.glBegin(Gl.GL_LINE_STRIP);

             // используем все точки -1 (т,к. алгоритм "зацепит" i+1 точку
             for (i = 1; i < n - 1; i++)
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

             }*/
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
                    DrawingArray[captured, 0] -= _lastX - lineX;
                    DrawingArray[captured, 1] -= _lastY - lineY;
                }
            }
        }


        private void AnT_MouseClick(object sender, MouseEventArgs e)
        {
            if (count_points == max_point)
                return;

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






        private void AnT_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ProgrammDrawingEngine.Drawing(e.X, AnT.Height - e.Y);
        
        
            captured = -1;
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




        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // устанавливаем стандартную кисть 4х4
            ProgrammDrawingEngine.SetStandartBrush(14);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // устанавливаем специальную кисть


         
           
                                                      
         


           ProgrammDrawingEngine.SetSpecialBrush(*); 
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // установить кисть из файла
            ProgrammDrawingEngine.SetBrushFromFile("brush-1.bmp");
        }

        // обмен значений цветов
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // временное хранение цвтеа элемента color1
            Color tmp = color1.BackColor;
            
            // замена:
            color1.BackColor = color2.BackColor;
            color2.BackColor = tmp;

            // передача нового цвета в ядро растрового редактора
            ProgrammDrawingEngine.SetColor(color1.BackColor);
        }

        // функция установки нового цвета, с помощью диалогового окна выбора цвета
        private void color1_MouseClick(object sender, MouseEventArgs e)
        {
            // если цвет успешно выбран
            if (changeColor.ShowDialog() == DialogResult.OK)
            {
                // установить данный цвет
                color1.BackColor = changeColor.Color;
                // и передать его в класс anEngine для установки активным цветом текущего слоя
                ProgrammDrawingEngine.SetColor(color1.BackColor);
            }
        }

        // функция добавления слоя
        private void добавитьСлойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // счетчик созданных слоев
            LayersCount ++;
            // счетчик всех создаваемых слоев, для генерации имени
            AllLayrsCount++;

            // вызываем функцию добавления слоя в движке графического редактора
            ProgrammDrawingEngine.AddLayer();

            // добавляем слой, генерирую имя "Слой №" в объекте LayersControl.
            // обязательно после функции  ProgrammDrawingEngine.AddLayer();,
            // иначе произойдет попытка установки активного цвета, для еще не существующего цвета
            int AddingLayerNom = Слои.Items.Add("Слой " + AllLayrsCount.ToString(), false);

            // выделяем его
            Слои.SelectedIndex = AddingLayerNom;
            
            // устанавливаем его как активный
            ActiveLayer = AddingLayerNom;
            
        }

        // функция удаления слоя
        private void удалитьСлойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // запрашиваем подтверждение действия, с помощью MessageBox
            DialogResult res = MessageBox.Show("Будет удален текущий активный слой, действительно продолжить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // если пользователь нажал кнопку "ДА" в окне подтверждения
            if(res == DialogResult.Yes)
            {
                // если удаляемый слой - начальный
                if (ActiveLayer == 0)
                {
                    // сообщаем о возможности удаления
                    MessageBox.Show("Вы не можете удалить нулевой слой.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else // иначе
                {
                    // уменьшаем значение счетчика слоев
                    LayersCount--;

                    // сохраняем номер удаляемого слоя, т.к. SelectedIndex измениться полсе операций в LayersControl
                    int LayerNomForDel = Слои.SelectedIndex;
                    
                    // удаляем запись в элементе LayerControl (с индексом LayersControl.SelectedIndex - текущим выделенным слоем)
                    Слои.Items.RemoveAt(LayerNomForDel);

                    // устанавливаем выделенный слоем - нулевой (главный слой)
                    Слои.SelectedIndex = 0;
                    // помечаем активный слой - нулевой
                    ActiveLayer = 0;
                    // помечаем галочкой нулевой слой
                    Слои.SetItemCheckState(0, CheckState.Checked);
                    // вызываем функцию удаления слоя в движке программы 
                    ProgrammDrawingEngine.RemoveLayer(LayerNomForDel);
                }
            }
        }
        
        // данная функция будет обрабатывать изменения значения элементов LayersControl
        private void LayersControl_SelectedValueChanged(object sender, EventArgs e)
        {
            // если отметили новый слой, необходимо снять галочку выделения со старого
            if (Слои.SelectedIndex != ActiveLayer)
            {
                // если выделенный индекс является корректным ( больше либо равен нулю и входит в диапазон элементов)
                if (Слои.SelectedIndex != -1 && ActiveLayer < Слои.Items.Count)
                {
                    // снимаем галочку с предыдущего активного слоя
                    Слои.SetItemCheckState(ActiveLayer, CheckState.Unchecked);
                    // сохраняем новый индекс выделенного элемента
                    ActiveLayer = Слои.SelectedIndex;
                    // помечаем галочкой новый активный слой
                    Слои.SetItemCheckState(Слои.SelectedIndex, CheckState.Checked);
                    // посылаем сигнал движку программы, об изменении активного слоя
                    ProgrammDrawingEngine.SetActiveLayerNom(ActiveLayer);
                }
            }
        }
        // создание начального слоя 

           // зададим новый параметр в гамме


        
        // дублирование создания слоя
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            добавитьСлойToolStripMenuItem_Click(sender, e);
        }

        // дублирование удаления слоя
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            удалитьСлойToolStripMenuItem_Click(sender, e);
        }

        // обработка кнопки "стерка" на левой панели инструментов
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            // установка кисти-стерки
            ProgrammDrawingEngine.SetSpecialBrush(1);
        }

        // дублирование устанвоки кисти "карандаш" из меню "рисование"
        private void карандашToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // вызываем уже существующую функцию
            toolStripButton1_Click(sender, e);
        }
        
        // дублирование устанвоки кисти "кисть" из меню "рисование"
        private void кистьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // вызываем уже существующую функцию
            toolStripButton3_Click(sender, e);
        }

        // дублирование установки кисти "стерка" из меню "рисование"
        private void стеркаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // вызываем уже существующую функцию
            toolStripButton6_Click(sender, e);
        }

        // функция создания нового проекта для рисования
        private void читсыйПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // ><xXx><

           
                // вызываем диалог подтверждения
                DialogResult reslt = MessageBox.Show("В данный момент проект уже начат, сохранить изменения перед закрытием проекта?", "Внимание!", MessageBoxButtons.YesNoCancel);

                // если отказ пользователя
                switch (reslt)
                {
                    case DialogResult.No:
                        {
                            // просто создаем чистый проект
                            ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);

                            // очищаем информацию о добавляемых ранее слоях
                            Слои.Items.Clear();
                            // по новой инициализируем нулевой слой:

                            // текущий активный слой
                            ActiveLayer = 0;
                            // счетчик слоев
                            LayersCount = 1;
                            // счетчик всех создаваемых слоев для генерации имен
                            AllLayrsCount = 1;
                            // добавлние элемента, отвечающего за управления главным слоем в объект LayersControl
                            Слои.Items.Add("Главный слой", true);

                            break;
                        }

                    case DialogResult.Cancel:
                        {
                            // возвращаемся
                            return;
                        }
                   
                    case DialogResult.Yes:
                        {
                            // открываем окно сохранения файла, и если имя файла указано и DialogResult вернуло сигнал об успешном нажатии кнопки ОК
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                // получаем результирующее изображение слоя
                                Bitmap ToSave = ProgrammDrawingEngine.GetFinalImage();

                                // сохраняем используя имя файла указанное в диалоговом окне сохранения файла
                                ToSave.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                                // сохранили - начинаем новый проект:

                                // создаем новый объект "движка" программы
                                ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);

                                // очищаем информацию о добавляемых ранее слоях
                                Слои.Items.Clear();
                                // по новой инициализируем нулевой слой:

                                // текущий активный слой
                                ActiveLayer = 0;
                                // счетчик слоев
                                LayersCount = 1;
                                // счетчик всех создаваемых слоев для генерации имен
                                AllLayrsCount = 1;
                                // добавлние элемента, отвечающего за управления главным слоем в объект LayersControl
                                Слои.Items.Add("Главный слой", true);

                                
                            }
                            else
                            {
                                // если сохранение не заврешилось нормально (скорее всего пользователь закрыл окно сохранения файла
                                // возвращаемся в проект
                                return;
                            }

                            break;

                        }
                }
            
        }

     
        // обработка нажатия кнопки "сохранить" в меню "файл"
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // открываем окно сохранения файла, и если имя файла указано и DialogResult вернуло сигнал об успешном нажатии кнопки ОК
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // получаем результирующее изображение слоя
                Bitmap ToSave = ProgrammDrawingEngine.GetFinalImage();
                // сохраняем используя имя файла указанное в диалоговом окне сохранения файла
                ToSave.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

      
        }
        
        // загрузка изображения в рабочую область программы
        private void изФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
                // вызываем диалог подтверждения
                DialogResult reslt = MessageBox.Show("В данный момент проект уже начат, сохранить изменения перед закрытием проекта?", "Внимание!", MessageBoxButtons.YesNoCancel);

                // если отказ пользователя
                switch (reslt)
                {
                    case DialogResult.No:
                        {
                            // просто создаем проект подгружая изображения
                            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                // проверяем существование файла
                                if (System.IO.File.Exists(openFileDialog1.FileName))
                                {
                                    // загружаем изображение в экземпляр класса Bitmap 
                                    Bitmap ToLoad = new Bitmap(openFileDialog1.FileName);

                                    // если размер изображения не корректен
                                    if (ToLoad.Width > AnT.Width || ToLoad.Height > AnT.Height)
                                    {
                                        // сообщаем пользователю об ошибке
                                        MessageBox.Show("Извините, но размер изображения превышает размеры области рисования", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        // возвращаемся и функции
                                        return;
                                    }

                                    // если размер был меньше области редактирования программы

                                    // создаем новый экземпляр класса anEngine
                                    ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);
                                    // копируем изображение в нижний левый угол рабочей области
                                    ProgrammDrawingEngine.SetImageToMainLayer(ToLoad);

                                    // очищаем информацию о добавляемых ранее слоях
                                    Слои.Items.Clear();
                                    // по новой инициализируем нулевой слой:
                                    
                                    // текущий активный слой
                                    ActiveLayer = 0;
                                    // счетчик слоев
                                    LayersCount = 1;
                                    // счетчик всех создаваемых слоев для генерации имен
                                    AllLayrsCount = 1;
                                    // добавление элемента, отвечающего за управления главным слоем в объект LayersControl
                                    Слои.Items.Add("Главный слой", true);


                                }
                            }
                            break;
                        }

                    case DialogResult.Cancel:
                        {
                            // возвращаемся
                            // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // =++=++=++=++= \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\ \\
                            return;
                        }
                    
                    case DialogResult.Yes:
                        {
                            // открываем окно сохранения файла, и если имя файла указано и DialogResult вернуло сигнал об успешном нажатии кнопки ОК
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                // получаем результирующее изображение слоя
                                Bitmap ToSave = ProgrammDrawingEngine.GetFinalImage();

                                // сохраняем используя имя файла указанное в диалоговом окне сохранения файла
                                ToSave.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                                // сохранили - начинаем новый проект:

                                // просто создаем проект подгружая изображения
                                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    // проверяем существование файла
                                    if (System.IO.File.Exists(openFileDialog1.FileName))
                                    {
                                        // загружаем изображение в экземпляр класса Bitmap 
                                        Bitmap ToLoad = new Bitmap(openFileDialog1.FileName);

                                        // если размер изображения не корректен
                                        if (ToLoad.Width > AnT.Width || ToLoad.Height > AnT.Height)
                                        {
                                            // сообщаем пользователю об ошибке
                                            MessageBox.Show("Извините, но размер изображения превышает размеры области рисования", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            // возвращаемся и функции
                                            return;
                                        }

                                        // если размер был меньше области редактирования программы
                                        // существовование файла true 
                                        // создаем новый экземпляр класса anEngine
                                        ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);
                                        // копируем изображение в нижний левый угол рабочей области
                                        ProgrammDrawingEngine.SetImageToMainLayer(ToLoad);

                                        // очищаем информацию о добавляемых ранее слоях
                                        Слои.Items.Clear();
                                        // по новой инициализируем нулевой слой:
                                    

                                        // текущий активный слой
                                        ActiveLayer = 0;
                                        // счетчик слоев
                                        LayersCount = 1;
                                        // счетчик всех создаваемых слоев для генерации имен
                                        AllLayrsCount = 1;
                                        // добавление элемента, отвечающего за управления главным слоем в объект LayersControl
                                        Слои.Items.Add("Главный слой", true);
                                
                                    }
                                }
                                break;

                            }
                            else
                            {
                                return;
                            }


                           


                        }
                }
     
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AnT_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void LayersControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void color1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void AnTp(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}


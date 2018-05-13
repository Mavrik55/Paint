﻿using System;
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
        public Form1()
        {
            InitializeComponent();

             
            // инициализация элемента SimpleOpenGLControl (AnT)
            AnT.InitializeContexts();
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
          
         
       

            // устанавливаем цвет очистки окна 
            Gl.glClearColor(255, 255, 255, 1);

            // устанавливаем порт вывода, основываясь на размерах элемента управления AnT 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            // устанавливаем проекционную матрицу 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очищаем его 
            Gl.glLoadIdentity();

            
            Glu.gluOrtho2D(0.0, AnT.Width, 0.0, AnT.Height);

            // переходим к объектно-видовой матрице 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);

           
            RenderTimer.Start();

            
            // добавление элемента, отвечающего за управления главным слоем в объект LayersControl
            Слои.Items.Add("Главный слой", true);


        }

        // событие Tick таймера
        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            // вызываем функцию рисования
  
            Drawing();
        }

        // функция рисования
        private void Drawing()
        {
            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            // очищение текущей матрицы 
            Gl.glLoadIdentity();
            // установка черного цвета 
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
        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                ProgrammDrawingEngine.Drawing(e.X, AnT.Height - e.Y);
        }

        private void AnT_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ProgrammDrawingEngine.Drawing(e.X, AnT.Height - e.Y);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // устанавливаем стандартную кисть 4х4
            ProgrammDrawingEngine.SetStandartBrush(4);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // устанавливаем специальную кисть
            ProgrammDrawingEngine.SetSpecialBrush(0);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // установить кисть из файла
            ProgrammDrawingEngine.SetBrushFromFile("pencil bmp.bmp");
        }

        // для окончания отрисовки
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
       
            Color tmp = color1.BackColor;
            
            // замена:
            color1.BackColor = color2.BackColor;
            color2.BackColor = tmp;

          
            ProgrammDrawingEngine.SetColor(color1.BackColor);
        }
        //также заменяeте цвет в основном реестре
        // функция установки нового цвета, с помощью диалогового окна выбора цвета
        private void color1_MouseClick(object sender, MouseEventArgs e)
        {
          
            if (changeColor.ShowDialog() == DialogResult.OK)
            {
                
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

            // добавляем слой, генерирую имя "Слой №228" в объекте LayersControl.
            // обязательно после функции  ProgrammDrawingEngine.AddLayer();,
            // иначе произойдет попытка установки активного цвета, для еще не существующего цвета
            int AddingLayerNom = Слои.Items.Add("Слой " + AllLayrsCount.ToString(), false);

            //выделяем его
            
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
                    // сообщаем о невозможности удаления
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
         
        // дублирование создания слоя
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            добавитьСлойToolStripMenuItem_Click(sender, e);
        }

        //дублирование удаления слоя
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


        
        // дублирование установки кисти "карандаш" из меню "рисование"
        private void карандашToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // вызываем следующую функцию
            toolStripButton1_Click(sender, e);
        }

        // дублирование установки кисти "кисть" из меню "рисование"
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
           
                // вызываем диалог подтверждения
                DialogResult reslt = MessageBox.Show("В данный момент проект уже начат, сохранить изменения перед закрытием проекта?", "Внимание!", MessageBoxButtons.YesNoCancel);

                //если отказ пользователя
                switch (reslt)
                {
                    case DialogResult.No:
                        {
                            // просто создаем чистый проект
                            //StoryFliping
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
                            // добавление элемента, отвечающего за управления главным слоем в объект LayersControl
                            Слои.Items.Add("Главный слой", true);
                        // Максимальное разрешение
                      
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
                                //счетчик слоев
                                LayersCount = 1;
                                // счетчик всех создаваемых слоев для генерации имен
                                AllLayrsCount = 1;
                                // добавление элемента, отвечающего за управления главным слоем в объект LayersControl
                                Слои.Items.Add("Главный слой", true);

                                
                            }
                            else
                            {
                                // если сохранение не завершилось нормально (скорее всего пользователь закрыл окно сохранения файла
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
                            // просто создаем объект подгружая изображения
                            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                //проверяем существование слоя
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
                                    //счетчик слоев
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

                                //сохранили - начинаем новый проект
                              

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

                                        //если размер области программирование не равен

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

        private void LayersControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void AnT_Load(object sender, EventArgs e)
        {

        }
       
        private void Вернуть_Click(object sender, EventArgs e)
        {
            // Gl.point flushOpenGLlibrary
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {

        }

        private void рисованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

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
        public Form1()
        {
            InitializeComponent();


          
            AnT.InitializeContexts();
        }

        private anEngine ProgrammDrawingEngine;
        
     
        private int ActiveLayer = 0;
        
 
        private int LayersCount = 1;

     
        private int AllLayrsCount = 1;


       

        private void Form1_Load(object sender, EventArgs e)
        {
    

           
            Gl.glClearColor(255, 255, 255, 1);
            
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

         
            Gl.glMatrixMode(Gl.GL_PROJECTION);
           
            Gl.glLoadIdentity();

       
            Glu.gluOrtho2D(0.0, AnT.Width, 0.0, AnT.Height);

           
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);

           
            RenderTimer.Start();

            
        
            Слои.Items.Add("Главный слой", true);


        }

      
        private void RenderTimer_Tick(object sender, EventArgs e)
        {
          
            Drawing();
        }

       
        private void Drawing()
        {
         
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
           
            Gl.glLoadIdentity();
           
            Gl.glColor3f(0, 0, 0);

           
            ProgrammDrawingEngine.SwapImage();
            ProgrammDrawingEngine.SetColor(color1.BackColor);

        
            Gl.glFlush();
         
            AnT.Invalidate();
        }

      
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
          
            ProgrammDrawingEngine.SetStandartBrush(4);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
         
            ProgrammDrawingEngine.SetSpecialBrush(0);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
          
            ProgrammDrawingEngine.SetBrushFromFile("brush-1.bmp");
        }

      
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
            Color tmp = color1.BackColor;
            
        
            color1.BackColor = color2.BackColor;
            color2.BackColor = tmp;

          
            ProgrammDrawingEngine.SetColor(color1.BackColor);
        }

      
        private void color1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (changeColor.ShowDialog() == DialogResult.OK)
            {
              
                color1.BackColor = changeColor.Color;
                
                ProgrammDrawingEngine.SetColor(color1.BackColor);
            }
        }

        private void добавитьСлойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            LayersCount ++;
            
            AllLayrsCount++;

          
            ProgrammDrawingEngine.AddLayer();

           
            int AddingLayerNom = Слои.Items.Add("Слой " + AllLayrsCount.ToString(), false);

            
            Слои.SelectedIndex = AddingLayerNom;

           
            ActiveLayer = AddingLayerNom;
            
        }

      
        private void удалитьСлойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DialogResult res = MessageBox.Show("Будет удален текущий активный слой, действительно продолжить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

      
            if(res == DialogResult.Yes)
            {
               
                if (ActiveLayer == 0)
                {
                  
                    MessageBox.Show("Вы не можете удалить нулевой слой.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else 
                {
                   
                    LayersCount--;

                    //LayerNomForDel = Слои.SelectedIndex #1;
                    //LayerNomForDel = Слои.SelectedIndex #2;
                    //LayerNomForDel = Слои.SelectedIndex #2;
                    int LayerNomForDel = Слои.SelectedIndex;
                    
          
                    Слои.Items.RemoveAt(LayerNomForDel);

              
                    Слои.SelectedIndex = 0;
                    
                    ActiveLayer = 0;
                    
                    Слои.SetItemCheckState(0, CheckState.Checked);
               
                    ProgrammDrawingEngine.RemoveLayer(LayerNomForDel);
                }
            }
        }

        
        private void LayersControl_SelectedValueChanged(object sender, EventArgs e)
        {
   
            if (Слои.SelectedIndex != ActiveLayer)
            {
               
                if (Слои.SelectedIndex != -1 && ActiveLayer < Слои.Items.Count)
                {
               
                    Слои.SetItemCheckState(ActiveLayer, CheckState.Unchecked);
                  
                    ActiveLayer = Слои.SelectedIndex;
                
                    Слои.SetItemCheckState(Слои.SelectedIndex, CheckState.Checked);
                  
                    ProgrammDrawingEngine.SetActiveLayerNom(ActiveLayer);
                }
            }
        }

     
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            добавитьСлойToolStripMenuItem_Click(sender, e);
        }

      
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            удалитьСлойToolStripMenuItem_Click(sender, e);
        }

   
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            
            ProgrammDrawingEngine.SetSpecialBrush(1);
        }

       
        private void карандашToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            toolStripButton1_Click(sender, e);
        }

        
        private void кистьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            toolStripButton3_Click(sender, e);
        }

      
        private void стеркаToolStripMenuItem_Click(object sender, EventArgs e)
      
        {
       
        
            toolStripButton6_Click(sender, e);
        }

      
        private void читсыйПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
               
                DialogResult reslt = MessageBox.Show("В данный момент проект уже начат, сохранить изменения перед закрытием проекта?", "Внимание!", MessageBoxButtons.YesNoCancel);

            
                switch (reslt)
                {
                    case DialogResult.No:
                    {

                        ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);


                        Слои.Items.Clear();

                       
                        
                            ActiveLayer = 0;
               
                            LayersCount = 1;
                            
                            AllLayrsCount = 1;
                           
                            Слои.Items.Add("Главный слой", true);

                            break;
                        }

                    case DialogResult.Cancel:
                        {
                            //return
                            return;
                        }

                    case DialogResult.Yes:
                        {
                           
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                      
                            
                                Bitmap ToSave = ProgrammDrawingEngine.GetFinalImage();

                               
                                ToSave.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                                ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);

                                
                                Слои.Items.Clear();
                            
                                ActiveLayer = 0;
                             
                                LayersCount = 1;
                           
                                AllLayrsCount = 1;
                               
                                Слои.Items.Add("Главный слой", true);

                                
                            }
                            else
                            {
                                
                                return;
                            }

                            break;

                        }
                }
            
        }

       
     
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
            
                Bitmap ToSave = ProgrammDrawingEngine.GetFinalImage();
                
                ToSave.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

       
        private void изФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
              
                DialogResult reslt = MessageBox.Show("В данный момент проект уже начат, сохранить изменения перед закрытием проекта?", "Внимание!", MessageBoxButtons.YesNoCancel);

             
                switch (reslt)
                {
                    case DialogResult.No:
                        {
                           
                            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                               
                                if (System.IO.File.Exists(openFileDialog1.FileName))
                                {
                                    
                                    Bitmap ToLoad = new Bitmap(openFileDialog1.FileName);

                                 
                                    if (ToLoad.Width > AnT.Width || ToLoad.Height > AnT.Height)
                                    {
                                       
                                        MessageBox.Show("Извините, но размер изображения превышает размеры области рисования", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                      
                                        return;
                                    }

                                
              
                                    ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);
                
                                    ProgrammDrawingEngine.SetImageToMainLayer(ToLoad);

                             
                                    Слои.Items.Clear();
                          
                                    
                          
                                    ActiveLayer = 0;
                  
                                    LayersCount = 1;
                                
                                    AllLayrsCount = 1;
                                  
                                    Слои.Items.Add("Главный слой", true);


                                }
                            }
                            break;
                        }

                    case DialogResult.Cancel:
                        {
                        
                            return;
                        }

                    case DialogResult.Yes:
                    {
                       
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                   
                            Bitmap ToSave = ProgrammDrawingEngine.GetFinalImage();

                            ToSave.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                        
                            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                            
                                if (System.IO.File.Exists(openFileDialog1.FileName))
                                {
                                
                                    Bitmap ToLoad = new Bitmap(openFileDialog1.FileName);

                                  
                                    if (ToLoad.Width > AnT.Width || ToLoad.Height > AnT.Height)
                                    {
                              
                                        MessageBox.Show("Извините, но размер изображения превышает размеры области рисования", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                          
                                        return;
                                    }
                                    
                                    
                                    ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);
                         
                                    ProgrammDrawingEngine.SetImageToMainLayer(ToLoad);

                                    Слои.Items.Clear();
                               
                                    ActiveLayer = 0;
                             
                                    LayersCount = 1;
                             
                                    AllLayrsCount = 1;
                                   
                                    Слои.Items.Add("Главный слой", true);

                                }
                            }
                            break;


                        }
                        else
                        {
                            return;
                        }


//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\\
                    }
                }
            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Application.Exit();
            
        }

        private void AnT_Load(object sender, EventArgs e)
        {

        }

        private void слоиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LayersControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void color1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void color2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void обАвтореToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

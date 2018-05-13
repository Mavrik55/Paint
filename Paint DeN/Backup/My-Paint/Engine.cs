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

using System.Collections;
using System.IO;


                                                                                                                          

namespace My_Paint
{

    public class anBrush
    {
        public Bitmap myBrush;

                              
       
        private bool IsErase = false;

       
        public bool IsBrushErase()
        {
            return IsErase;
        }
                                 
        public anBrush(int Value, bool Special)
        {
            if (!Special)
            {

                myBrush = new Bitmap(Value, Value);

                for (int ax = 0; ax < Value; ax++)
                    for (int bx = 0; bx < Value; bx++)
                        myBrush.SetPixel(0, 0, Color.Black);
                
                                                                                               
                IsErase = false;
            }
            else
            {
                //myBrush.SetPixel(2, 4, Color.Black)

                switch (Value)
                {
                       
                    default:
                        {
                            myBrush = new Bitmap(5, 5);

                            for (int ax = 0; ax < 5; ax++)
                                for (int bx = 0; bx < 5; bx++)
                                    myBrush.SetPixel(ax, bx, Color.Red);

                            myBrush.SetPixel(0, 2, Color.Black);
                            myBrush.SetPixel(1, 2, Color.Black);

                            myBrush.SetPixel(2, 0, Color.Black);
                            myBrush.SetPixel(2, 1, Color.Black);
                            myBrush.SetPixel(2, 2, Color.Black);
                            myBrush.SetPixel(2, 3, Color.Black);
                            myBrush.SetPixel(2, 4, Color.Black);

                            myBrush.SetPixel(3, 2, Color.Black);
                            myBrush.SetPixel(4, 2, Color.Black);

                                                                      
                            IsErase = false;

                            break;
                        }
                    case 1: 
                        {
                         
                          
                            myBrush = new Bitmap(15, 15);

                            for (int ax = 0; ax < Value; ax++)
                                for (int bx = 0; bx < Value; bx++)
                                    myBrush.SetPixel(0, 0, Color.Black);

                          
                            IsErase = true;
                            break;
                        }
                }                          

            }

        }

                                        
        public anBrush(string FromFile)
        {
         
            string path = Directory.GetCurrentDirectory();
      
            path += "\\" + FromFile;
            NewMethod(path);
        }

        private void NewMethod(string path)
        {

            //кисть из BMP
            myBrush = new Bitmap(55,35);
         
        }
    }                            
                                 






    


    public class anLayer
    {
                                     
        public int Width, Heigth;

                             
        private int[,,] DrawPlace;
                                                                           
      
        private bool isVisible;

                                                                                                                
        private Color ActiveColor;

  

        public int[, ,] GetDrawingPlace()
        {                                 
            return DrawPlace;
        }

       
        private int ListNom;

        public int now_element { get; private set; }

        public anLayer(int s_W, int s_H)
        {
 
            Width = s_W;                                                                            
            Heigth = s_H;


            DrawPlace = new int[Width, Heigth, 4];
            

            for (int ax = 0; ax < Width; ax++)
            {
                for (int bx = 0; bx < Heigth; bx++)
                {
            
                    DrawPlace[ax, bx, 3] = 1;
                }
            }
                                            
           
            isVisible = true;
                                         
            
            ListNom = Gl.glGenLists(1);
                         
            ActiveColor = Color.Black;
        }

             public void SetVisibility(bool visiblityState)
        {
            isVisible = visiblityState;
        }

              public bool GetVisibility()
        {
            return isVisible;
        }

      
        public void SetColor(Color NewColor)
        {
            ActiveColor = NewColor;
        }

       
        public Color GetColor()
        {
           
            return ActiveColor;
        }

        
        public void Draw(anBrush BR, int x, int y)
        {
            
            
            
            int real_pos_draw_start_x = x - BR.myBrush.Width / 2;
            int real_pos_draw_start_y = y - BR.myBrush.Height / 2;

        
            if (real_pos_draw_start_x < 0)
                real_pos_draw_start_x = 0;

            if (real_pos_draw_start_y < 0)
                real_pos_draw_start_y = 0;

         
            int boundary_x = real_pos_draw_start_x + BR.myBrush.Width;
            int boundary_y = real_pos_draw_start_y + BR.myBrush.Height;
            
            
            if(boundary_x > Width)
                boundary_x = Width;

            if(boundary_y > Heigth)
                boundary_y = Heigth;

            //счетчик
            int count_x = 0, count_y = 0;

             
            for (int ax = real_pos_draw_start_x; ax < boundary_x; ax++, count_x++)
            {
                count_y = 0;
                for (int bx = real_pos_draw_start_y; bx < boundary_y; bx++, count_y++)
                {
                   
                    if (BR.IsBrushErase())
                    {
                       
                        Color ret = BR.myBrush.GetPixel(count_x, count_y);

                        //not red
                        if (!(ret.R == 255 && ret.G == 0 && ret.B == 0))
                        {
                            
                            DrawPlace[ax, bx, 3] = 1;
                        }
                        
                    }
                    else
                    {
                     
                        Color ret = BR.myBrush.GetPixel(count_x, count_y);
                        if (!(ret.R == 255 && ret.G == 0 && ret.B == 0))
                        {
                           

                            DrawPlace[ax, bx, 0] = ActiveColor.R;
                            DrawPlace[ax, bx, 1] = ActiveColor.G;
                            DrawPlace[ax, bx, 2] = ActiveColor.B;
                            DrawPlace[ax, bx, 3] = 0;
                        }
                    }

                

                    

                }
            }

        }

        
        public void ClearList()
        {
           
            if (Gl.glIsList(ListNom) == Gl.GL_TRUE)
            {
           
                Gl.glDeleteLists(ListNom,1);
            }
        }

        public void CreateNewList()
        {
      
            if (Gl.glIsList(ListNom) == Gl.GL_TRUE)
            {
                
                Gl.glDeleteLists(ListNom,1);
               
                ListNom = Gl.glGenLists(1);
            }

   
            Gl.glNewList(ListNom, Gl.GL_COMPILE);
            RenderImage(false);

            Gl.glEndList();
        }


        public void RenderImage(bool FromList)
        {

            if (FromList)
            {
                //GKalian
                Gl.glCallList(ListNom);

            }
            else
            {

                int count = 0;


                for (int ax = 0; ax < Width; ax++)
                {
                    for (int bx = 0; bx < Heigth; bx++)
                    {


                        if (DrawPlace[ax, bx, 3] != 1)
                        {

                            count++;
                        }
                    }
                }



                for (int ax = 0; ax < Width; ax++)
                {
                    for (int bx = 0; bx < Heigth; bx++)
                    {

                        if (DrawPlace[ax, bx, 3] != 1)

                        {
                            
                            //НЕ РАБОТАЕТ!!!
                  
                            arr_date_vertex[now_element * 2] = ax;
                            arr_date_vertex[now_element * 2 + 1] = bx;


                            arr_date_colors[now_element * 3] = (float)DrawPlace[ax, bx, 0] / 255.0f;
                            arr_date_colors[now_element * 3 + 1] = (float)DrawPlace[ax, bx, 1] / 255.0f;
                            arr_date_colors[now_element * 3 + 2] = (float)DrawPlace[ax, bx, 2] / 255.0f;
                        
                            now_element++;

                        }
                    }
                }



           

                Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
                Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);

            }
                Gl.glColorPointer(3, Gl.GL_FLOAT, 0, arr_date_colors);
                Gl.glVertexPointer(2, Gl.GL_INT, 0, arr_date_vertex);

              
                Gl.glDrawArrays(Gl.GL_POINTS, 0, count);

              
                Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
                Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);
               
            }
        }


    }



   
    public class anEngine
    {
       
        private int picture_size_x , picture_size_y;

        
        private int scroll_x, scroll_y;

      
        private int screen_width, screen_height;

       
        private int ActiveLayerNom;

        
        private ArrayList Layers = new ArrayList();

        
        private My_Paint.anBrush standartBrush;
        private My_Paint.anLayer standartLayer;

    

      
        private Color LastColorInUse;

        
        public anEngine(int size_x, int size_y, int screen_w, int screen_h)
        {
           
            
            picture_size_x = size_x;
            picture_size_y = size_y;

            screen_width = screen_w;
            screen_height = screen_h;

          
            scroll_x = 0;
            scroll_y = 0;

            
            Layers.Add( new anLayer(picture_size_x, picture_size_y) );

           
            ActiveLayerNom = 0;

                       standartBrush = new anBrush(3,false);
        }
 
    
    
         
        public Bitmap GetFinalImage()
        {
         
            Bitmap resaultBitmap = new Bitmap(picture_size_x, picture_size_y);

           
            for (int ax = 0; ax < Layers.Count; ax++)
            {
                
                int [,,] tmp_layer_data = ((anLayer)Layers[ax]).GetDrawingPlace();

              
                for (int a = 0; a < picture_size_x; a++)
                {
                    for(int b = 0; b < picture_size_y; b++)
                    {
                       
                        if (tmp_layer_data[a, b, 3] != 1)
                        {
                        
                            resaultBitmap.SetPixel(a,b, Color.FromArgb(tmp_layer_data[a, b, 0], tmp_layer_data[a, b, 1], tmp_layer_data[a, b, 2]));
                        }
                        else
                        {
                            if (ax == 0) 
                            {
                                
                                resaultBitmap.SetPixel(a, b, Color.FromArgb(255, 255, 255));
                            }
                        }
                    }
                }

            }

            
            resaultBitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

           
            return resaultBitmap;
        }
        
       
        
        public void SetImageToMainLayer(Bitmap layer)
        {
            
            layer.RotateFlip(RotateFlipType.Rotate180FlipX);
            
                        
            for (int ax = 0; ax < layer.Width; ax++)
            {
                for (int bx = 0; bx < layer.Height; bx++)
                {
                   
                    SetColor(layer.GetPixel(ax,bx));
                    
                    Drawing(ax, bx);
                }
            }
        }


        
        public void SetActiveLayerNom(int nom)
        {
            
           
            ((anLayer)Layers[ActiveLayerNom]).CreateNewList();

           
            ((anLayer)Layers[nom]).SetColor( ((anLayer)Layers[ActiveLayerNom]).GetColor() );

           
            ActiveLayerNom = nom;
        }

        
        public void SetStandartBrush(int SizeB)
        {
            standartBrush = new anBrush(SizeB, false);
        }

      
        public void SetSpecialBrush(int Nom)
        {
            standartBrush = new anBrush(Nom, true);
        }

      
        public void SetBrushFromFile(string FileName)
        {
            standartBrush = new anBrush(FileName);
        }

    

        
        public void SetWisibilityLayerNom(int nom, bool visible)
        {
            
        }

        
        public void Drawing(int x, int y)
        {
            
            ((anLayer)Layers[ActiveLayerNom]).Draw(standartBrush, x, y);
        }

     
        public void SetColor(Color NewColor)
        {
            ((anLayer)Layers[ActiveLayerNom]).SetColor(NewColor);
            LastColorInUse = NewColor;
        }

        //визуализация
        public void SwapImage()
        {
            
            for(int ax = 0; ax < Layers.Count; ax++)
            {
             
                if(ax == ActiveLayerNom)
                {
                   
                    ((anLayer)Layers[ax]).RenderImage(false);
                }
                else
                {
               
                    ((anLayer)Layers[ax]).RenderImage(true);
                }
            }
        }

       
        public void AddLayer()
        {
          
            int AddingLayer = Layers.Add(new anLayer(picture_size_x, picture_size_y));
          
            SetActiveLayerNom(AddingLayer);
        }
        
        public void RemoveLayer(int nom)
        {
                    if (nom < Layers.Count && nom >= 0)
            {
                
                SetActiveLayerNom(0);

                ((anLayer)Layers[nom]).ClearList();
                Layers.RemoveAt(nom);
            }
        }


    }


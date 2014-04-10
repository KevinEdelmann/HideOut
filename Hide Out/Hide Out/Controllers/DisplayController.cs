﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HideOut.Entities;
using HideOut.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace HideOut.Controllers
{
    class DisplayController
    {

        int xPosition = 0;
        int yPosition = 100;
        int xSize = 8;
        int ySize = 12;
        int yOffset = 2;
        int xOffset = 4;


       //  public static readonly int SPRITE_SIZE = 50;
        List<Display> displays;
            
        private Texture2D fontTexture;

        private Texture2D loseGameTexture;
        private Texture2D hungerTexture;
        private Texture2D thirstTexture;
        private Texture2D winGameTexture;
        Rectangle sizingRectangle;
        public bool hasLost = false;
        public bool hasWon = false;
        public bool displayLevel = false;
        public int level = 1;

        private Color backgroundColor = Color.CornflowerBlue;

        public void lose()
        {
            hasLost = true;
        }
        public void win()
        {
            hasWon = true;

        }
        public DisplayController()
        {

        }

       
            //thePlayer.rectangleBounds = new Point(SPRITE_SIZE, SPRITE_SIZE);
           
      

        public void Update(GameTime gameTime)
        {
   
        }


        public void drawStats(int hunger, int thirst, SpriteBatch sb)
        {
            for (int i = 0; i < hunger; i++)
            {
                sb.Draw(hungerTexture, new Rectangle(20 * i, 0, 20, 20), Color.White);
            }

            for (int i = 0; i < thirst; i++)
            {
                sb.Draw(thirstTexture, new Rectangle(20 * i, 25, 20, 20), Color.White);
            }


        }

        public void Draw(SpriteBatch sb)
        {
            //sb.Draw(thePlayer.sprite, thePlayer.screenRectangle, Color.White);

            Rectangle source = new Rectangle(100, 100, 211, 40);

            //sb.Draw(thePlayer.sprite, thePlayer.screenRectangle, source, Color.White);
           // sb.Draw(fontTexture, source, sizingRectangle, Color.White);
         
            //sb.Draw(fontTexture, new Rectangle(xPosition, yPosition, 211, 40), sizingRectangle, Color.White);

 



            xPosition = 0;
             yPosition = 100;
            xSize = 8;
             ySize = 12;
             yOffset = 2;
             xOffset = 4;

            int wid = 200;
            int len = 200;
            int xPos = HideOutGame.SCREEN_WIDTH / 2 - wid / 2;
            int yPos = HideOutGame.SCREEN_HEIGHT / 2 - len / 2;
            int offset = 25;

            if (displayLevel)
            {
                //xPos += 400;
                //yPos -= 100;

                xPos -= 200;
                yPos -= 70;


                displayString("Level " + this.level.ToString(), xPos, yPos - offset, sb, backgroundColor);
                switch (level)
                {

                    case 1:
                        {
                            displayString("Collect all the coins to pass each level", 0, 400 - offset, sb, backgroundColor);
                            
                            
                        }
                        break;

                    case 2:
                        {
                            displayString("Your food and thirst reduce over time", 0, 400 - offset, sb, backgroundColor);
                            displayString("Water fountains restore thirst", 00, 420 - offset, sb, backgroundColor);
                            displayString("Apples restore health", 0, 440 - offset, sb, backgroundColor);
                            displayString("Press ENTER to start", 0, 460 - offset, sb, backgroundColor);
                        }
                        break;

                    case 3:
                        {
                            displayString("Do not let the police catch you", 0, 400 - offset, sb, backgroundColor);
                            displayString("Hide inside bushes or inside other obstacles", 00, 420 - offset, sb, backgroundColor);
                            displayString("to avoid them", 0, 440 - offset, sb, backgroundColor);

                            displayString("Candy bars with also give you a speed boost", 0, 480 - offset, sb, backgroundColor);
                            
                        }
                        break;
                        
                
                }
            }
             if (hasLost)
             {
                 sb.Draw(loseGameTexture, new Rectangle(xPos, yPos, wid, len), Color.White);
                 displayString("Game Over", xPos, yPos - offset, sb, backgroundColor);
             }
             else
             {
                 if (hasWon)
                 {
                     sb.Draw(winGameTexture, new Rectangle(xPos, yPos, wid, len), Color.White);
                     displayString("Congratulations!", xPos, yPos - offset, sb, backgroundColor);
                 }
             }



            //good for testing
            //sb.Draw(fontTexture, new Rectangle(xPosition, yPosition, xSize, ySize), new Rectangle(2 + (xSize * xOffset), 1 + (ySize * yOffset), xSize, ySize), Color.White);

            for (int i = 0; i < displays.Count(); i++)
            {
                String currentString = displays[i].text;
                displayString(currentString, displays[i].x, displays[i].y, sb, backgroundColor);
                
            }

        }
        public void displayString(String currentString, int xPos, int yPos, SpriteBatch sb, Color c)
        {

            for (int ii = 0; ii < currentString.Length; ii++)
            {
                String workingString = currentString.Substring(ii, 1);
                //workingString.First().
                char workingChar = currentString[ii];

                //double result = char.GetNumericValue(displays[i].text, ii);

                //Console.WriteLine("Result: " + result);
                if (workingChar == ' ')
                {
                    //do nothing, this is a gap


                }
                else
                {
                    if (Char.IsLetter(workingChar))
                    {
                        int result = char.ToUpper(workingChar) - 64;
                        xPosition = xPos + (xSize * ii);
                        yPosition = yPos;
                        yOffset = 1;//hard coded as caps right now
                        xOffset = result - 1;//for letters

                        sb.Draw(fontTexture, new Rectangle(xPosition, yPosition, xSize, ySize), new Rectangle(2 + (xSize * xOffset), 1 + (ySize * yOffset), xSize, ySize), c);


                    }
                    else
                    {
                        if (Char.IsNumber(workingChar))
                        {
                            int result = Convert.ToInt32(workingString);
                            if (result > -1)//TODO: handle negatives?
                            {
                                xPosition = xPos + (xSize * ii);
                                yPosition = yPos;
                                yOffset = 2;//numbers
                                xOffset = result;//for numbers

                                sb.Draw(fontTexture, new Rectangle(xPosition, yPosition, xSize, ySize), new Rectangle(2 + (xSize * xOffset), 1 + (ySize * yOffset), xSize, ySize), c);
                            }
                        }
                        else
                        {
                            //handle symbols, punctuations, other special cases here

                        }
                    }
                }

            }
        }
        public void addDisplay(int xx, int yy, String text)
        {
            displays.Add(new Display(xx, yy, text));
        }

        public void LoadContent(ContentManager cm)
        {
            //Start by loading all textures
            //playerTexture = cm.Load<Texture2D>("player.png");
            fontTexture = cm.Load<Texture2D>("basicFont.png");

            winGameTexture = cm.Load<Texture2D>("victory.png");

           loseGameTexture = cm.Load<Texture2D>("gameOver.png");


           thirstTexture = cm.Load<Texture2D>("waterBottle.png");

           hungerTexture = cm.Load<Texture2D>("apple.png");


            sizingRectangle = new Rectangle(0, 0, 211, 40);
            displays = new List<Display>();
            //addDisplay(0, 0,


            //testing
            //displays.Add(new Display(0, 0, "12S red"));

            //Then assign textures to NPCs depending on their tag
           // thePlayer.sprite = playerTexture; 
            
        }


    }
}

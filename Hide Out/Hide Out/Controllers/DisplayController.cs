﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HideOut.Entities;
using HideOut.Primitives;
using HideOut.BmFont;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace HideOut.Controllers
{
    class DisplayController
    {
        /*
        int xPosition = 0;
        int yPosition = 100;
        int xSize = 8;
        int ySize = 12;
        int yOffset = 2;
        int xOffset = 4;
        */

       //  public static readonly int SPRITE_SIZE = 50;
        List<Display> displays;
            
        private Texture2D hungerTexture;
        private Texture2D thirstTexture;
        Rectangle sizingRectangle;
        public bool hasLost = false;
        public bool hasWon = false;
        public bool displayLevel = false;
        public int level = 1;
        public static readonly int MaxDisplayStatCount = 50;
        public int displayStatCount = MaxDisplayStatCount;

        FontFile fontFile;
        Texture2D fontTexture;
        FontRenderer fontRenderer;

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
            displayStatCount--;
            if (displayStatCount < 0)
                displayStatCount = MaxDisplayStatCount;
            for (int i = 0; i < hunger; i++)
            {
                if (hunger > 3 || displayStatCount < MaxDisplayStatCount / 2)
                    sb.Draw(hungerTexture, new Rectangle(20 * i, 0, 20, 20), Color.White);
            }

            for (int i = 0; i < thirst; i++)
            {
                if (thirst > 3 || displayStatCount < MaxDisplayStatCount / 2)
                    sb.Draw(thirstTexture, new Rectangle(20 * i, 25, 20, 20), Color.White);
            }


        }

        // displayString("Game Over", xPos, yPos - offset, sb, backgroundColor);

        private void displayString(String text, int xx, int yy, SpriteBatch sb)
        {

            fontRenderer.DrawText(sb, xx, yy, text);
        }

        public void Draw(SpriteBatch sb)
        {
            //sb.Draw(thePlayer.sprite, thePlayer.screenRectangle, Color.White);

            Rectangle source = new Rectangle(100, 100, 211, 40);

            //sb.Draw(thePlayer.sprite, thePlayer.screenRectangle, source, Color.White);
           // sb.Draw(fontTexture, source, sizingRectangle, Color.White);
         
            //sb.Draw(fontTexture, new Rectangle(xPosition, yPosition, 211, 40), sizingRectangle, Color.White);

            int xPos = HideOutGame.SCREEN_WIDTH / 2;
            int yPos = HideOutGame.SCREEN_HEIGHT / 2;
            int offset = 30;

            if (displayLevel)
            {
                //fontRenderer.DrawText(sb, xPos - offset, yPos - offset, "Level " + this.level.ToString());
                 displayString("Level " + this.level.ToString(), 0, 50, sb);

                // xPos -= 200;
                // yPos -= 70;

                
                switch (level)
                {

                    case 1:
                        {
                            displayString("Collect all the coins to pass each level", 0, HideOutGame.SCREEN_HEIGHT - 40 - offset, sb);
                            displayString("Don't let your hunger or thirst hit zero!", 0, HideOutGame.SCREEN_HEIGHT - 10 - offset, sb);
                        }
                        break;

                    case 2:
                        {
                            displayString("Do not let the police catch you!", 0, HideOutGame.SCREEN_HEIGHT - 100 - offset, sb);
                            displayString("Hide inside bushes or behind trees", 0, HideOutGame.SCREEN_HEIGHT - 70 - offset, sb);
                        }
                        break;
                        
                
                } 
            }
             if (hasLost)
             {
                 //sb.Draw(loseGameTexture, new Rectangle(xPos - wid/2, yPos - len/2, wid, len), Color.White);
                 //fontRenderer.DrawText(sb, xPos - wid/2, yPos - len/2 - offset, "You Lose...");
                  displayString("Game Over", xPos - offset, yPos, sb);
             }
             else
             {
                 if (hasWon)
                 {
                     //sb.Draw(winGameTexture, new Rectangle(xPos - wid/2, yPos - len/2, wid, len), Color.White);
                     //fontRenderer.DrawText(sb, xPos - wid/2, yPos - len/2 - offset, "You Win!");
                      displayString("You Win! Congratulations", xPos - offset, yPos, sb);
                 }
             }



            //good for testing
            //sb.Draw(fontTexture, new Rectangle(xPosition, yPosition, xSize, ySize), new Rectangle(2 + (xSize * xOffset), 1 + (ySize * yOffset), xSize, ySize), Color.White);
            /*
            for (int i = 0; i < displays.Count(); i++)
            {
                String currentString = displays[i].text;
                displayString(currentString, displays[i].x, displays[i].y, sb, backgroundColor);
                
            }
             */

        }
        /*
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
        */
        public void addDisplay(int xx, int yy, String text)
        {
            displays.Add(new Display(xx, yy, text));
        }

        public void LoadContent(ContentManager cm)
        {
            //Start by loading all textures
            //playerTexture = cm.Load<Texture2D>("player.png");
            // fontTexture = cm.Load<Texture2D>("basicFont.png");

           thirstTexture = cm.Load<Texture2D>("waterBottle.png");

           hungerTexture = cm.Load<Texture2D>("apple.png");

            
            string fontFilePath = Path.Combine(cm.RootDirectory, "Fonts/font.fnt");
            fontFile = FontLoader.Load(fontFilePath);
            fontTexture = cm.Load<Texture2D>("Fonts/font_0.png");
            fontRenderer = new FontRenderer(fontFile, fontTexture);


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

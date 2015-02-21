namespace EnvironmentSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EnvironmentSystem.Interfaces;
    using EnvironmentSystem.Models;

    public class ConsoleRenderer : IRenderer
    {
        private readonly int consoleWidth;
        private readonly int consoleHeight;

        private char[,] consoleMatrix;

        public ConsoleRenderer(int consoleWidth, int consoleHeight)
        {
            this.consoleWidth = consoleWidth;
            this.consoleHeight = consoleHeight;
            this.InitializeConsole();
        }

        public void EnqueueForRendering(IRenderable obj)
        {
            char[,] objImage = obj.ImageProfile;

            int imageRows = objImage.GetLength(0);
            int imageCols = objImage.GetLength(1);

            Point objTopLeft = obj.Bounds.TopLeft;

            int lastRow = Math.Min(objTopLeft.Y + imageRows, this.consoleHeight);
            int lastCol = Math.Min(objTopLeft.X + imageCols, this.consoleWidth);

            for (int row = objTopLeft.Y; row < lastRow; row++)
            {
                for (int col = objTopLeft.X; col < lastCol; col++)
                {
                    if (row >= 0 && row < consoleHeight &&
                        col >= 0 && col < consoleWidth)
                    {
                        consoleMatrix[row, col] = 
                            objImage[row - objTopLeft.Y, col - objTopLeft.X];
                    }
                }
            }
        }

        public void RenderAll()
        {
            Console.SetCursorPosition(0, 0);
            StringBuilder scene = new StringBuilder();
            for (int row = 0; row < this.consoleHeight; row++)
            {
                for (int col = 0; col < this.consoleWidth; col++)
                {
                    scene.Append(this.consoleMatrix[row, col]);
                }
            }

            Console.WriteLine(scene.ToString());
        }

        public void ClearQueue()
        {
            for (int row = 0; row < this.consoleHeight; row++)
            {
                for (int col = 0; col < this.consoleWidth; col++)
                {
                    this.consoleMatrix[row, col] = ' ';
                }
            }
        }

        private void CleanConsole()
        {
            for (int row = 0; row < this.consoleHeight; row++)
            {
                for (int col = 0; col < this.consoleWidth; col++)
                {
                    this.consoleMatrix[row, col] = ' ';
                }
            }
        }

        private void InitializeConsole()
        {
            this.consoleMatrix = new char[this.consoleHeight, this.consoleWidth];

            Console.SetWindowSize(this.consoleWidth, this.consoleHeight);
            Console.SetBufferSize(this.consoleWidth, this.consoleHeight);
        }
    }
}

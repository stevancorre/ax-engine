﻿using System;
using System.IO;
using System.Drawing;

using Ax.Engine.Utils;
using Ax.Engine.Core.Rendering;

namespace Ax.Engine.ECS.Components
{
    public sealed class AnimatedSpriteComponent : Component
    {
        public enum RenderMode
        {
            Simple,
            Resize
        }

        public Bitmap[] frames;
        public RectInt sourceRect;

        /// <summary>
        ///  Delay between two animation frame update in milliseconds
        /// </summary>
        public float animationDelay;

        public RenderMode renderMode;

        private RectInt destRect;

        private DateTime lastFrameRendered;
        private int currentFrame;

        public int Width
        {
            get => sourceRect.Width;
            set => sourceRect.Width = value;
        }

        public int Height
        {
            get => sourceRect.Height;
            set => sourceRect.Height = value;
        }

        public override void Init()
        {
            sourceRect = new RectInt(0, 0, 8, 8);
            destRect = new RectInt(0, 0, 8, 8);

            lastFrameRendered = DateTime.Now;
        }

        public override void Update()
        {
            if ((DateTime.Now - lastFrameRendered).TotalMilliseconds >= animationDelay)
            {
                currentFrame = (currentFrame + 1) % frames.Length;
                lastFrameRendered = DateTime.Now;
            }

            destRect.position = (Vector2Int)Transform.position;
            destRect.size = (Vector2Int)((Vector2)sourceRect.size * Transform.scale);
        }

        public override void Render(SurfaceRenderer renderer)
        {
            Bitmap frame = frames[currentFrame];
            for (int y = 0; y < frame.Height; y++)
            {
                for (int x = 0; x < frame.Width; x++)
                {
                    Color pixel = frame.GetPixel(x, y);
                    if (pixel.A == 0) { continue; } // todo: implement alpha threshold

                    renderer.Render(new RgbSurfaceItem(pixel), destRect.X + x, destRect.Y + y);
                }
            }
        }

        public void ImportSheet(string folder, Vector2Int frameSize)
        {
            string[] rawFrames = Directory.GetFiles(folder);
            frames = new Bitmap[rawFrames.Length];

            for (int i = 0; i < frames.Length; i++)
            {
                using Bitmap bmp = (Bitmap)Image.FromFile(rawFrames[i]);
                frames[i] = new Bitmap(bmp, frameSize.x, frameSize.y);
            }
        }
    }
}

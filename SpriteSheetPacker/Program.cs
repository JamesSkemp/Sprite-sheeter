﻿using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace SpriteSheetPacker {
    class Program {
        static void Main(string[] args){
            //CreateSpriteSheet(@"C:\temp\Sprites\Player32_full");

            SplitSheet(@"C:\temp\Sprites\player32_full.png");
        }

        private static void SplitSheet(string inFile){
            var spriteList = ImageSplitter.Split(inFile, 32);

            var fileInfo = new FileInfo(inFile);
            var sprites = spriteList as Bitmap[] ?? spriteList.ToArray();
            var newPath = Path.Combine(fileInfo.DirectoryName, Path.GetFileNameWithoutExtension(inFile));
            if (Directory.Exists(newPath))
                Directory.Delete(newPath, true);

            Directory.CreateDirectory(newPath);

            for (int i = 0; i < sprites.Count(); i++)
                sprites[i].Save(Path.Combine(newPath, i + fileInfo.Extension));
        }

        private static void CreateSpriteSheet(string folder){
            var dir = new DirectoryInfo(folder);
            var files = Directory.GetFiles(folder);
            var image = ImageCombinator.Combine(files);
            image.Save(Path.Combine(folder, dir.Name + ".png"), ImageFormat.Png);
        }
    }
}
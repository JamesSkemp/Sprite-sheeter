﻿using System;
using SpriteSheetPacker.ImageManipulation;
using SpriteSheetPacker.MappingFileFormats;

namespace SpriteSheetPacker {
    class Program{
        private static string _status;
        private static SpriteSheetPack.SpriteSheetPacker _spriteSheetManager;

        static void Main(string[] args){
            //_spriteSheetManager = new SpriteSheetPack.SpriteSheetPacker(new VerticalFrameListCombiner());
            _spriteSheetManager = new SpriteSheetPack.SpriteSheetPacker(new SquareFrameListCombiner());
            

            ConsoleKeyInfo cki;
            do {
                Console.Clear();
                Console.WriteLine(_status);
                DisplayMenu();
                cki = Console.ReadKey(false);
                switch (cki.KeyChar) {
                    case '1':
                        CombineAllInFolder();
                        break;
                    case '2':
                        CombineFromSubFolders();
                        break;
                    case '3':
                        SplitSheet();
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape && cki.Key != ConsoleKey.Q);
        }

        private static void DisplayMenu() {
            Console.WriteLine();
            Console.WriteLine("Sprite sheet packer");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Options:");
            Console.WriteLine("1. Combine all images in ONE folder to spritesheet");
            Console.WriteLine("2. Combine all images in all subfolders of entered path");
            Console.WriteLine("3. Split an image into all its 32x32 components");
            Console.WriteLine("\nPress Escape or q to exit\n");
            Console.Write("Enter option: ");
        }

        private static void CombineAllInFolder() {
            Console.Write("\n Enter input path: ");
            string inputpath = Console.ReadLine();
            Console.Write("\n Enter output path: ");
            string outputpath = Console.ReadLine();
            _spriteSheetManager.PackImagesInFolder(inputpath, outputpath, new PList());
            _status = "Created new sheet in " + outputpath;
        }

        private static void CombineFromSubFolders(){
            Console.Write("\n Enter path: ");
            string path = Console.ReadLine();
            _spriteSheetManager.PackImagesFromSubfolders(path, new PList());
            _status = "Created new sheet @ " + path;
        }

        private static void SplitSheet() {
            Console.Write("\n Enter input image path: ");
            string inputpath = Console.ReadLine();
            string newPath = _spriteSheetManager.SplitImage(inputpath, 32);
            _status = "Created new folder with images in " + newPath;
        }
    }
}

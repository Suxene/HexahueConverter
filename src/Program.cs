using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Hexahue
{
    class Program
    {
        static void Main(string[] args)
        {
            var (BLACK, WHITE, MAGENTA, YELLOW, BLUE, CYAN, GRAY, RED, GREEN) = (Color.FromName("Black").ToArgb(), Color.FromName("White").ToArgb(), Color.FromName("Magenta").ToArgb(), Color.FromName("Yellow").ToArgb(), Color.FromName("Blue").ToArgb(), Color.FromName("Cyan").ToArgb(), Color.FromName("Gray").ToArgb(), Color.FromName("Red").ToArgb(), Color.FromName("Lime").ToArgb());
            var map1 = new Dictionary<(int, int, int, int, int, int), char>()
            {
                {(MAGENTA, RED, GREEN, YELLOW, BLUE, CYAN), 'a' },
                {(RED, MAGENTA, GREEN, YELLOW, BLUE, CYAN), 'b' },
                {(RED, GREEN, MAGENTA, YELLOW, BLUE, CYAN), 'c' },
                {(RED, GREEN, YELLOW, MAGENTA, BLUE, CYAN), 'd' },
                {(RED, GREEN, YELLOW, BLUE, MAGENTA, CYAN), 'e' },
                {(RED, GREEN, YELLOW, BLUE, CYAN, MAGENTA), 'f' },
                {(GREEN, RED, YELLOW, BLUE, CYAN, MAGENTA), 'g' },
                {(GREEN, YELLOW, RED, BLUE, CYAN, MAGENTA), 'h' },
                {(GREEN, YELLOW, BLUE, RED, CYAN, MAGENTA), 'i' },
                {(GREEN, YELLOW, BLUE, CYAN, RED, MAGENTA), 'j' },
                {(GREEN, YELLOW, BLUE, CYAN, MAGENTA, RED), 'k' },
                {(YELLOW, GREEN, BLUE, CYAN, MAGENTA, RED), 'l' },
                {(YELLOW, BLUE, GREEN, CYAN, MAGENTA, RED), 'm' },
                {(YELLOW, BLUE, CYAN, GREEN, MAGENTA, RED), 'n' },
                {(YELLOW, BLUE, CYAN, MAGENTA, GREEN, RED), 'o' },
                {(YELLOW, BLUE, CYAN, MAGENTA, RED, GREEN), 'p' },
                {(BLUE, YELLOW, CYAN, MAGENTA, RED, GREEN), 'q' },
                {(BLUE, CYAN, YELLOW, MAGENTA, RED, GREEN), 'r' },
                {(BLUE, CYAN, MAGENTA, YELLOW, RED, GREEN), 's' },
                {(BLUE, CYAN, MAGENTA, RED, YELLOW, GREEN), 't' },
                {(BLUE, CYAN, MAGENTA, RED, GREEN, YELLOW), 'u' },
                {(CYAN, BLUE, MAGENTA, RED, GREEN, YELLOW), 'v' },
                {(CYAN, MAGENTA, BLUE, RED, GREEN, YELLOW), 'w' },
                {(CYAN, MAGENTA, RED, BLUE, GREEN, YELLOW), 'x' },
                {(CYAN, MAGENTA, RED, GREEN, BLUE, YELLOW), 'y' },
                {(CYAN, MAGENTA, RED, GREEN, YELLOW, BLUE), 'z' },
                {(BLACK, WHITE, WHITE, BLACK, BLACK, WHITE), '.' },
                {(WHITE, BLACK, BLACK, WHITE, WHITE, BLACK), ',' },
                {(WHITE, WHITE, WHITE, WHITE, WHITE, WHITE), ' ' },
                {(BLACK, BLACK, BLACK, BLACK, BLACK, BLACK), ' ' },
                {(BLACK, GRAY, WHITE, BLACK, GRAY, WHITE), '0' },
                {(GRAY, BLACK, WHITE, BLACK, GRAY, WHITE), '1' },
                {(GRAY, WHITE, BLACK, BLACK, GRAY, WHITE), '2' },
                {(GRAY, WHITE, BLACK, GRAY, BLACK, WHITE), '3' },
                {(GRAY, WHITE, BLACK, GRAY, WHITE, BLACK), '4' },
                {(WHITE, GRAY, BLACK, GRAY, WHITE, BLACK), '5' },
                {(WHITE, BLACK, GRAY, GRAY, WHITE, BLACK), '6' },
                {(WHITE, BLACK, GRAY, WHITE, GRAY, BLACK), '7' },
                {(WHITE, BLACK, GRAY, WHITE, BLACK, GRAY), '8' },
                {(BLACK, WHITE, GRAY, WHITE, BLACK, GRAY), '9' }
            };
            var map2 = new Dictionary<char, int[]>()
            {
                {'a', new int[]{MAGENTA, RED, GREEN, YELLOW, BLUE, CYAN} },
                {'b', new int[]{RED, MAGENTA, GREEN, YELLOW, BLUE, CYAN} },
                {'c', new int[]{RED, GREEN, MAGENTA, YELLOW, BLUE, CYAN} },
                {'d', new int[]{RED, GREEN, YELLOW, MAGENTA, BLUE, CYAN} },
                {'e', new int[]{RED, GREEN, YELLOW, BLUE, MAGENTA, CYAN} },
                {'f', new int[]{RED, GREEN, YELLOW, BLUE, CYAN, MAGENTA} },
                {'g', new int[]{GREEN, RED, YELLOW, BLUE, CYAN, MAGENTA} },
                {'h', new int[]{GREEN, YELLOW, RED, BLUE, CYAN, MAGENTA} },
                {'i', new int[]{GREEN, YELLOW, BLUE, RED, CYAN, MAGENTA} },
                {'j', new int[]{GREEN, YELLOW, BLUE, CYAN, RED, MAGENTA} },
                {'k', new int[]{GREEN, YELLOW, BLUE, CYAN, MAGENTA, RED} },
                {'l', new int[]{YELLOW, GREEN, BLUE, CYAN, MAGENTA, RED} },
                {'m', new int[]{YELLOW, BLUE, GREEN, CYAN, MAGENTA, RED} },
                {'n', new int[]{YELLOW, BLUE, CYAN, GREEN, MAGENTA, RED} },
                {'o', new int[]{YELLOW, BLUE, CYAN, MAGENTA, GREEN, RED} },
                {'p', new int[]{YELLOW, BLUE, CYAN, MAGENTA, RED, GREEN} },
                {'q', new int[]{BLUE, YELLOW, CYAN, MAGENTA, RED, GREEN} },
                {'r', new int[]{BLUE, CYAN, YELLOW, MAGENTA, RED, GREEN} },
                {'s', new int[]{BLUE, CYAN, MAGENTA, YELLOW, RED, GREEN} },
                {'t', new int[]{BLUE, CYAN, MAGENTA, RED, YELLOW, GREEN} },
                {'u', new int[]{BLUE, CYAN, MAGENTA, RED, GREEN, YELLOW} },
                {'v', new int[]{CYAN, BLUE, MAGENTA, RED, GREEN, YELLOW} },
                {'w', new int[]{CYAN, MAGENTA, BLUE, RED, GREEN, YELLOW} },
                {'x', new int[]{CYAN, MAGENTA, RED, BLUE, GREEN, YELLOW} },
                {'y', new int[]{CYAN, MAGENTA, RED, GREEN, BLUE, YELLOW} },
                {'z', new int[]{CYAN, MAGENTA, RED, GREEN, YELLOW, BLUE} },
                {'.', new int[]{BLACK, WHITE, WHITE, BLACK, BLACK, WHITE} },
                {',', new int[]{WHITE, BLACK, BLACK, WHITE, WHITE, BLACK} },
                {' ', new int[]{WHITE, WHITE, WHITE, WHITE, WHITE, WHITE} },
                {'0', new int[]{BLACK, GRAY, WHITE, BLACK, GRAY, WHITE} },
                {'1', new int[]{GRAY, BLACK, WHITE, BLACK, GRAY, WHITE} },
                {'2', new int[]{GRAY, WHITE, BLACK, BLACK, GRAY, WHITE} },
                {'3', new int[]{GRAY, WHITE, BLACK, GRAY, BLACK, WHITE} },
                {'4', new int[]{GRAY, WHITE, BLACK, GRAY, WHITE, BLACK} },
                {'5', new int[]{WHITE, GRAY, BLACK, GRAY, WHITE, BLACK} },
                {'6', new int[]{WHITE, BLACK, GRAY, GRAY, WHITE, BLACK} },
                {'7', new int[]{WHITE, BLACK, GRAY, WHITE, GRAY, BLACK} },
                {'8', new int[]{WHITE, BLACK, GRAY, WHITE, BLACK, GRAY} },
                {'9', new int[]{BLACK, WHITE, GRAY, WHITE, BLACK, GRAY} }
            };
            Console.WriteLine("1) Decode\n2) Encode");
            var choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.Write("Filepath : ");
                string filePath = Console.ReadLine();
                Bitmap image = new Bitmap(filePath);
                for (int y = 0; y < image.Height; y += 3)
                {
                    for (int x = 0; x < image.Width; x += 2)
                    {
                        var map = ( image.GetPixel(x, y).ToArgb(), image.GetPixel(x + 1, y).ToArgb(), image.GetPixel(x, y + 1).ToArgb(), image.GetPixel(x + 1, y + 1).ToArgb(), image.GetPixel(x, y + 2).ToArgb(), image.GetPixel(x + 1, y + 2).ToArgb() );
                        Console.Write(map1[map]);
                    }
                }
                Console.WriteLine("Decoding ended.");
                Console.ReadKey();
            }
            if (choice == 2)
            {
                Console.WriteLine("Enter the text to decode :");
                var texte = Console.ReadLine().ToLower();
                Console.WriteLine("Enter the filepath : ");
                string filePath = Console.ReadLine();
                var image = new Bitmap((texte.Count() * 2 < 800 ? texte.Count() * 2 : 800), (texte.Count() * 2 / 800 + 1) * 3 );
                Console.WriteLine(image.Height);
                Console.WriteLine(image.Width);
                int l = 0;
                for(int y = 0; y < image.Height; y += 3)
                {
                    for(int x = 0; x < image.Width; x += 2)
                    {
                        List<Color> map = new List<Color>();
                        try
                        {
                            var chr = texte[l];
                            map = map2[chr].Select(x => Color.FromArgb(x)).ToList();
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            map = new List<Color>() { Color.White, Color.White, Color.White, Color.White, Color.White, Color.White };
                        }
                        finally
                        {
                            l++;
                            int i = 0;
                            for(int w = 0; w < 3; w++)
                            {
                                for(int v = 0; v < 2; v++)
                                {
                                    Color color = map[i];
                                    image.SetPixel(x + v, y + w, color);
                                    i++;
                                }
                            }
                        }

                    }
                }
                image.Save(filePath);
                Console.WriteLine("Decoding ended.");
                Console.ReadKey();
            }
        }
    }
}

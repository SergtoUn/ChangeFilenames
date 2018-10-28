using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeFilenames
{
    class Program
    {
        static void Main(string[] args)
        {

            DirectoryInfo di = new DirectoryInfo("D:\\Lessons\\InfoSec\\Lynda Become an IT Security Specialist\\");

            DirectoryInfo[] diArr = di.GetDirectories();

            foreach (DirectoryInfo dri in diArr)
            {
                RenFile(dri.FullName);


            }
            //   Console.WriteLine(Path.GetDirectoryName(DirName));

            //   FileCopy(DirName);


            // Get an array of file names as strings rather than FileInfo objects.
            // Use this method when storage space is an issue, and when you might
            // hold on to the file name reference for a while before you try to access
            // the file.


            Console.ReadKey();
        }

        static void RenFile(string DirName)
        {
            string[] fn = System.IO.Directory.GetFiles(DirName, "*.mp4");
            foreach (string s in fn)
            {
                // Create the FileInfo object only when needed to ensure
                // the information is as current as possible.
                string FileName = Path.GetFileNameWithoutExtension(s);
                string p = Path.GetDirectoryName(s);
                string ext = Path.GetExtension(s);
                char[] FileChar = FileName.ToCharArray();
                Console.WriteLine("{0}", s);

                char[] num = new char[6];
                char[] CharPart = new char[FileChar.Length - 7];

                Array.Copy(FileChar, FileChar.GetUpperBound(0) - 5, num, 0, 6);
                Array.Copy(FileChar, 0, CharPart, 0, FileChar.Length - 7);
                string numstr = String.Concat(num);
                string CharString = String.Concat(CharPart);
                string NewName = String.Concat(numstr, "-", CharString, ext);
                NewName = String.Concat(p, "\\", NewName);

                Console.WriteLine("{0}", NewName);

                try
                {
                    if (!File.Exists(s))
                    {
                        Console.WriteLine("File {0} does not exist!", Path.GetFileName(s));
                    }

                    int i = 0;

                    while (File.Exists(NewName))
                    {
                        File.Move(NewName, String.Concat(Path.GetDirectoryName(NewName), i.ToString(), "_", Path.GetFileName(NewName)));
                    }

                    File.Move(s, NewName);

                    if (!File.Exists(NewName))
                    {
                        Console.WriteLine("Created file {0} does not exist!", Path.GetFileName(NewName));
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }




            }
        }

    }
}

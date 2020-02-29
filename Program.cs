using System;
using System.IO;

namespace Document_Merger
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 3)
        {
            Console.WriteLine("DocumentMerger2 <input_file_1><input_file_2> ... <input_file_n><output_file>");
            Console.WriteLine("Supply text files to merger followed by what you want to name the resulting merged text file as command line arguments.");
            System.Environment.Exit(1);
            // This will stop the execution of the program
        }
            else
        {
            StreamWriter sw = null;
            try
            {
                // This will create a new, merged file with the specified name and location for writing operations
                sw = new StreamWriter(args[args.Length - 1] + ".txt file cannot be found.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The " + args[args.Length - 1] + ".txt file cannot be found.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The directory cannot be found.");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive specified in merged file's path is invalid");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The merged file's path exceeds the maximum supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create " +args[args.Length - 1] + ".txt file.");
            }
            catch (IOException)
            {
                Console.WriteLine("An IO exception occured while creating " + args[args.Length - 1] + ".txt file.");
            }


            for(int i=0; i<args.Length -1; ++i)
            {
                StreamReader sr = null;
                try
                {
                    sr = new StreamReader(args[i] + ".txt");

                    sr.BaseStream.Seek(0, SeekOrigin.Begin);                
                }
                catch (FileNotFoundException)
                {
                Console.WriteLine("The " + args[i] + ".txt file cannot be found.");
                }
                catch (DirectoryNotFoundException)
                {
                Console.WriteLine("The directory cannot be found.");
                }
                catch (DriveNotFoundException)
                {
                Console.WriteLine("The drive specified in merged file's path is invalid");
                }
                catch (PathTooLongException)
                {
                Console.WriteLine("the merged file's path exceeds the maximum supported path length.");
                }
                catch (UnauthorizedAccessException)
                {
                Console.WriteLine("You do not have permission to read" + args[i] + ".txt file.");
                }
                catch (IOException)
                {
                Console.WriteLine("An IO exception occured while opening" + args[i] + ".txt file.");
                }

                string str = sr.ReadLine();

                while (str != null)
                {
                    sw.WriteLine(str);
                    str = sr.ReadLine();                
                }

                sr.Close();
            }
                sw.Flush();
                sw.Close();
            }
        }
    }
}

using System.Text;

DirectoryInfo my_di = new DirectoryInfo(@"C:\Users\erikk\Desktop\CSharpCollection\FileStream_StreamWR_BinaryWR");

Console.WriteLine(my_di.FullName);
Console.WriteLine(my_di.Name);
Console.WriteLine(my_di.Parent);
Console.WriteLine(my_di.Attributes);
Console.WriteLine(my_di.CreationTime);

DirectoryInfo di_data = new DirectoryInfo(@"C:\Users\erikk\Desktop\CSharpCollection\FileStream_StreamWR_BinaryWR\");

string[] customers =
{
    "Bob Smith",
    "Sally Smith",
    "Robert Smith"
};

string textFilePath = @"C:\Users\erikk\Desktop\CSharpCollection\FileStream_StreamWR_BinaryWR\Textfile1.txt";     // @ needs to be there otherwise I had to type \\

File.WriteAllLines(textFilePath, customers);

foreach(string cust in File.ReadAllLines(textFilePath))
{
    Console.WriteLine($"Customer: {cust}");
}

FileInfo[] txtFiles = di_data.GetFiles("*.txt", SearchOption.AllDirectories);       // Stores Textfile.txt in a FileInfo-array

Console.WriteLine($"Matches: {0}",
    txtFiles.Length);

foreach(FileInfo fi in txtFiles)
{
    Console.WriteLine(fi.Name);
    Console.WriteLine(fi.Length);
}

Console.WriteLine();



// FileStream

string textFilePath2 = @"C:\Users\erikk\Desktop\CSharpCollection\FileStream_StreamWR_BinaryWR\Textfile2.txt";        // Overwrites file from before

FileStream fs = File.Open(textFilePath2, FileMode.Create);

string randomString = "This is a random string";

byte[] rsByteArray = Encoding.Default.GetBytes(randomString);

fs.Write(rsByteArray, 0, rsByteArray.Length);       // Writes the byte-array of randomstring to destination specified in FileStream

// Read
fs.Position = 0;

byte[] fileByteArray = new byte[rsByteArray.Length];

for (int i = 0; i < rsByteArray.Length; i++)
{
    fileByteArray[i] = (byte)fs.ReadByte();     // Reads from Textfile.txt and stores it in byte-array 
}

Console.WriteLine(Encoding.Default.GetString(fileByteArray));       // Outputs the byte-array

fs.Close();

Console.WriteLine();



// StreamWriter & StreamReader - Best for strings

string textFilePath3 = @"C:\Users\erikk\Desktop\CSharpCollection\FileStream_StreamWR_BinaryWR\Textfile3.txt";

StreamWriter sw = File.CreateText(textFilePath3);

sw.WriteLine("This is a random string from StreamWriter");
sw.WriteLine("sentence");
sw.WriteLine("This is another sentence");

sw.Close();

StreamReader sr = File.OpenText(textFilePath3);

Console.WriteLine("Peek : {0}", Convert.ToChar(sr.Peek()));     // Prints the beginning of the file

Console.WriteLine("1st String: {0}", sr.ReadLine());    // Read next line

Console.WriteLine("Everything : {0}", sr.ReadToEnd());  // Read it all

sr.Close();

Console.WriteLine();



// Binary Writer & Binary Reader

string textFilePath4 = @"C:\Users\erikk\Desktop\CSharpCollection\FileStream_StreamWR_BinaryWR\Textfile4.txt";

FileInfo datFile = new FileInfo(textFilePath4);

BinaryWriter bw = new BinaryWriter(datFile.OpenWrite());

string randText = "Random text";
int myAge = 31;
double height = 175;

bw.Write(randText);
bw.Write(myAge);
bw.Write(height);

bw.Close();

BinaryReader br = new BinaryReader(datFile.OpenRead());

Console.WriteLine(br.ReadString());
Console.WriteLine(br.ReadInt32());
Console.WriteLine(br.ReadDouble());

br.Close();

Console.ReadLine(); 




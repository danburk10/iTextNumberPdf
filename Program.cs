using iTextSharp.text;
using iTextSharp.text.pdf;



internal class Program
{
    private static void Main(string[] args)
    {
        void AddPageNumber(string fileIn, string fileOut)
        {
            byte[] bytes = File.ReadAllBytes(fileIn);
            Font blackFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
            using (MemoryStream stream = new MemoryStream())
            {
                PdfReader reader = new PdfReader(bytes);
                using (PdfStamper stamper = new PdfStamper(reader, stream))
                {
                    int pages = reader.NumberOfPages;
                    for (int i = 1; i <= pages; i++)
                    {
                        ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(i.ToString(), blackFont), 568f, 15f, 0);
                    }
                }
                bytes = stream.ToArray();
            }
            File.WriteAllBytes(fileOut, bytes);
        }


        // Check if arguments were provided
        if (args.Length >= 2)
        {
            string inputFile = args[0];
            string outputFile = args[1];

            // Call the AddPageNumber function with provided input and output paths
            AddPageNumber(inputFile, outputFile);

            Console.WriteLine("Page numbers added to the PDF.");
        }
        else
        {
            Console.WriteLine("Usage: Program.exe input.pdf output.pdf");
        }

    }
}
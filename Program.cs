using iTextSharp.text;
using iTextSharp.text.pdf;
// using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;



internal class iTextNumberPdf
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


        AddPageNumber("C:\\Users\\dan\\Downloads\\test.pdf", "C:\\Users\\dan\\Downloads\\test.out.pdf");
        /* 
        if (args[0] = 2 && args[1] != null && args[2] != null)
        {
            AddPageNumber(args[1], args[2] "C:\\Users\\dan\\Downloads\\2023-06 ELD driver log.out.pdf");
        }
        */
    }
}
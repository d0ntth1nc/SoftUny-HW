using Novacode;
using System.Drawing;

namespace WordDocumentGenerator
{
    class Generator
    {
        static void Main(string[] args)
        {
            string fileName = @"softuni_oop_game_contest.docx";
            var doc = DocX.Create(fileName);

            // Header
            string headerText = "SoftUni OOP Game Contest";
            var headerFormat = new Formatting();
            headerFormat.FontFamily = new FontFamily("Tahoma");
            headerFormat.Size = 18D;
            headerFormat.Position = 12;
            var header = doc.InsertParagraph(headerText, false, headerFormat);
            header.Alignment = Alignment.center;

            // Image
            string imgPath = "rpg-game.png";
            var imgParagraph = doc.InsertParagraph();
            var drawingImg = System.Drawing.Image.FromFile(imgPath);
            var documentImg = doc.AddImage(imgPath);
            var pic = documentImg.CreatePicture();
            int newWidth = (int)doc.PageWidth - (int)(doc.MarginLeft + doc.MarginRight);
            int ratio = drawingImg.Width / drawingImg.Height;

            pic.Width = newWidth;
            pic.Height = newWidth / ratio;
            imgParagraph.InsertPicture(pic);
            doc.InsertParagraph("\n");

            // Text
            var textFormat = new Formatting();
            textFormat.FontFamily = new FontFamily("Tahoma");
            textFormat.Size = 10D;
           
            var p = doc.InsertParagraph();
            p.InsertText("SoftUni is organizing a contest for the best ", false, textFormat);

            textFormat.Bold = true;
            p.InsertText("role playing game", false, textFormat);

            textFormat.Bold = false;
            p.InsertText(" from the OOP teamwork projects. The winning teams will receive a ", false, textFormat);

            textFormat.UnderlineStyle = UnderlineStyle.singleLine;
            textFormat.Bold = true;
            p.InsertText("grand prize", false, textFormat);

            textFormat.UnderlineStyle = UnderlineStyle.none;
            textFormat.Bold = false;
            p.InsertText("!\nThe game should be:", false, textFormat);

            // List
            var list = doc.AddList("Properly structured and follow all good OOP practices", 0, ListItemType.Bulleted);
            doc.AddListItem(list, "Awesome");
            doc.AddListItem(list, "..Very Awesome");
            doc.InsertList(list);
            doc.InsertParagraph("\n");

            // Table
            const int TABLE_WIDTH = 3;
            const int TABLE_HEIGHT = 4;
            var table = doc.AddTable(TABLE_HEIGHT, TABLE_WIDTH);
            table.Alignment = Alignment.center;
            for (int row = 0; row < table.RowCount; row++)
            {
                for (int col = 0; col < table.ColumnCount; col++)
                {
                    table.Rows[row].Cells[col].Paragraphs[0].Alignment = Alignment.center;
                    if (row == 0)
                    {
                        table.Rows[row].Cells[col].FillColor = System.Drawing.Color.MediumBlue;
                        switch (col)
                        {
                            case 0:
                                table.Rows[row].Cells[col].Paragraphs[0].Append("Team");
                                break;
                            case 1:
                                table.Rows[row].Cells[col].Paragraphs[0].Append("Game");
                                break;
                            case 2:
                                table.Rows[row].Cells[col].Paragraphs[0].Append("Points");
                                break;
                        }
                    }
                    else
                    {
                        table.Rows[row].Cells[col].Paragraphs[0].Append("-");
                    }
                }
            }
      

            doc.InsertTable(table);

            try
            {
                doc.Save();
            }
            catch (System.IO.IOException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}

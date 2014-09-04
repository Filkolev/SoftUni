/* Write a program to generate a PDF document called Deck-of-Cards.pdf and print in it a standard deck of 52 cards, 
following one after another. Each card should be a rectangle holding its face and suit. A few examples are shown below:
A ♠		2 ♥		Q ♦		K ♣		J ♦		9 ♦		7 ♠
You are free to choose the size of each card, the spacing between the cards, how many cards to put in each line, etc. 
Note: you will need to use an external Java library for creating PDF documents. Find some in Internet. 
Put your JAR files in a folder called "lib" (this is a standard approach in Java projects) and reference them in the build path .*/

import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;

import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Chunk;
import com.itextpdf.text.Document;
import com.itextpdf.text.DocumentException;
import com.itextpdf.text.Element;
import com.itextpdf.text.Font;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPCell;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

public class _09_GeneratePDF {
	
	public static void main(String[] args) throws DocumentException, IOException {
		
// Program will create a file called Deck.pdf in the main folder (Homewrok1-Intro-Java).
// An example file is added there, called ExampleDeck.pdf
		
		Document document = new Document();
		try {
			PdfWriter.getInstance(document, new FileOutputStream("Deck.pdf"));
		} catch (FileNotFoundException e) {			
			e.printStackTrace();
		} catch (DocumentException e) {			
			e.printStackTrace();
		}
		
		document.open(); 
		BaseFont baseFont = BaseFont.createFont("times.ttf", BaseFont.IDENTITY_H, true);		
		
		Paragraph header = new Paragraph("STANDARD DECK OF 52 CARDS");
		header.setAlignment(Element.ALIGN_CENTER);
		document.add(header);
		
		document.add(Chunk.NEWLINE);		
		
		PdfPTable table = new PdfPTable(4);
        
		Font black = new Font(baseFont, 40f, 0, BaseColor.BLACK);
        	Font red = new Font(baseFont, 40f, 0, BaseColor.RED);
		
		String[] colors = {"\u2660", "\u2665", "\u2666", "\u2663"};
		String[] values = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
		
		for (int value = 0; value < 13; value++) {
			for (int color = 0; color < 4; color++) {
				
				Paragraph card = new Paragraph();
				
				if (color == 0 || color == 3) {
					card = new Paragraph(values[value] + colors[color], black);					
				}
				else {
					card = new Paragraph(values[value] + colors[color], red);
				}
				
				PdfPCell cell = new PdfPCell(card);
				cell.setVerticalAlignment(Element.ALIGN_MIDDLE);
				cell.setHorizontalAlignment(Element.ALIGN_CENTER);
				cell.setFixedHeight(150f);
				table.addCell(cell);			    
			}
		}		
		
	    	document.add(table);
		document.close();
	}
}

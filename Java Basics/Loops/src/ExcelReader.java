import java.io.File;
import java.io.FileInputStream;
import java.util.HashMap;
import java.util.Iterator;
import java.util.SortedSet;
import java.util.TreeSet;

import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

/* Problem 11
 * You are given an Excel file Incomes-Report.xlsx holding an incomes report.
 * Each office puts in this Excel file all their incomes
 * (office, date, description, income, 20% VAT, total income).
 * Your task is to read the report and to calculate the
 * incomes sub-totals for each office (with VAT).
 * Order the offices alphabetically. Print the result at
 * the console in format town Total -> incomes.
 * Finally calculate and print the grand total
 * (the sum of all incomes in all offices).
 */
public class ExcelReader {

	public static void main(String[] args) {
		// TODO : u need xmlbeans to run this app
		readSheetWithFormula();
	}
	
	public static void readSheetWithFormula()
	{
	    try
	    {
	        FileInputStream file = new FileInputStream(new File("Incomes-Report.xlsx"));
	        XSSFWorkbook workbook = new XSSFWorkbook(file);
	        XSSFSheet sheet = workbook.getSheetAt(0);
	        Iterator<Row> rowIterator = sheet.iterator();
	        //Skip first row
	        rowIterator.next();
	        
	        HashMap<String, Double> townIncomingPair = new HashMap<String, Double>();
	        while (rowIterator.hasNext())
	        {
	            Row row = rowIterator.next();
	            String office = row.getCell(0).getStringCellValue();
	            Double incoming = row.getCell(5).getNumericCellValue();
	            
	            if (townIncomingPair.containsKey(office)) {
	            	double totalIncoming = townIncomingPair.get(office);
	            	totalIncoming += incoming;
	            	townIncomingPair.replace(office, totalIncoming);
	            } else {
	            	townIncomingPair.put(office, incoming);
            	}
	        }
	        file.close();
	        
	        printResult(townIncomingPair);
	    }
	    catch (Exception e)
	    {
	        e.printStackTrace();
	    }
	}
	
	private static void printResult(HashMap<String, Double> townIncomingPair) {
		SortedSet<String> keys = new TreeSet<String>(townIncomingPair.keySet());
		double grandTotalIncoming = 0;
		for (String key : keys) {
			double incoming = townIncomingPair.get(key);
			grandTotalIncoming += incoming;
			System.out.printf("%s Total -> %.2f\n", key, incoming);
		}
		System.out.printf("Grand Total -> %.2f", grandTotalIncoming);
	}
}

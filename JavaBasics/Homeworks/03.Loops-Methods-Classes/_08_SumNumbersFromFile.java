import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;


/* Write a program to read a text file "Input.txt" holding a sequence 
 * of integer numbers, each at a separate line. Print the sum of the 
 * numbers at the console. Ensure you close correctly the file in case 
 * of exception or in case of normal execution. In case of exception (e.g. 
 * the file is missing), print "Error" as a result. */

public class _08_SumNumbersFromFile {
	public static void main(String[] args) throws IOException {
		try {
			
			// Change content of file in main project directory to check results
			FileReader fileReader = new FileReader("_08_input.txt");
			BufferedReader textReader = new BufferedReader(fileReader);
			
			long sum = 0;
			
			String lineContent = textReader.readLine().trim();
			
			while (lineContent != "" && lineContent != null) {
				sum += Integer.parseInt(lineContent);
				lineContent = textReader.readLine();
			};
			
			System.out.println(sum);
			
			textReader.close();
			
		} catch (FileNotFoundException e) {
			System.out.println("The file you requested wasn't found!");
		} 		
	}
}

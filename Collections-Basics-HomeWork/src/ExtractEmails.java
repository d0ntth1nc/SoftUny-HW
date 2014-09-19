import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/*
 * Write a program to extract all email addresses from given text.
 * The text comes at the first input line.
 * Print the emails in the output, each at a separate line.
 * Emails are considered to be in format <user>@<host>
 */
public class ExtractEmails {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String text = scanner.nextLine();
		Pattern pattern = Pattern.compile("[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+");
		Matcher matcher = pattern.matcher(text);
	    while (matcher.find()) {
	        System.out.println(matcher.group());
	    }
	}

}

import java.math.BigDecimal;
import java.util.Locale;
import java.util.Scanner;
import java.util.Stack;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class SimpleExpression {
	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String line = scanner.nextLine();
		Matcher numbersMatcher = Pattern.compile("([0-9]*\\.[0-9]+|[0-9]+)").matcher(line);
		Matcher operatorsMatcher = Pattern.compile("\\+|\\-").matcher(line);
		
		Stack<Double> numbers = new Stack<>();
		while (numbersMatcher.find()) {
			numbers.push(Double.parseDouble(numbersMatcher.group()));
		}
		
		Stack<String> operators = new Stack<>();
		while (operatorsMatcher.find()) {
			operators.push(operatorsMatcher.group());
		}
		
		BigDecimal sum = BigDecimal.ZERO;
		while (numbers.size() > 0) {
			double num = numbers.pop();
			if (operators.size() > 0) {
				if (operators.pop().equals("-")){
					num *= -1;
				}
			}
			sum = sum.add(new BigDecimal(num));
		}
		System.out.print(sum.toPlainString());
	}
}

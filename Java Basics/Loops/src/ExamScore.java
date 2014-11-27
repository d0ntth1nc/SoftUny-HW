import java.util.Collection;
import java.util.Scanner;
import java.util.TreeMap;


public class ExamScore {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		scanner.nextLine();
		scanner.nextLine();
		scanner.nextLine();
		
		TreeMap<Integer, TreeMap<String, Double>> examScores = new TreeMap<>();
		String currentData = scanner.nextLine();
		while (!currentData.startsWith("-")) {
			String[] dataArray = currentData.split("\\W*\\|\\W*");
			String studentName = dataArray[1];
			int score = Integer.parseInt(dataArray[2]);
			double grade = Double.parseDouble(dataArray[3]);
			
			if (!examScores.containsKey(score)) {
				examScores.put(score, new TreeMap<>());
			}
			examScores.get(score).put(studentName, grade);
			
			currentData = scanner.nextLine();
		}
		
		for (Integer examScore : examScores.keySet()) {
			System.out.printf("%d -> [", examScore);
			
			String names = String.join(", ", examScores.get(examScore).keySet());
			System.out.print(names + "]; ");
			
			double sum = 0;
			double count = 0;
			Collection<Double> values = examScores.get(examScore).values();
			for (double grade : values) {
				count++;
				sum += grade;
			}
			
			sum /= count;
			
			System.out.printf("avg=%.2f\n", sum);
		}
	}

}

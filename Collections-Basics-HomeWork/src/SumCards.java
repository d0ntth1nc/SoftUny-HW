import java.util.Scanner;


public class SumCards {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String cardsLine = scanner.nextLine();
		String[] cards = cardsLine.split(" ");
		int totalPoints = 0;
		int prevCardPoints = getPoints(cards[0]);
		int occurences = 0;
		for (String card : cards) {
			int thisCardPoints = getPoints(card);
			
			if (thisCardPoints == prevCardPoints) {
				occurences++;
			} else {
				occurences = 1;
			}
			
			if (occurences == 1) {
				totalPoints += thisCardPoints;
			} else if (occurences == 2) {
				totalPoints += prevCardPoints + thisCardPoints * 2;
			} else if (occurences > 2) {
				totalPoints += thisCardPoints * 2;
			}
			
			prevCardPoints = thisCardPoints;
		}
		System.out.println(totalPoints);
	}

	private static int getPoints(String card) {
		char cardRank = card.charAt(0);
		if (cardRank == 'A') {
			return 15;
		} else if (cardRank == 'K') {
			return 14;
		} else if (cardRank == 'Q') {
			return 13;
		} else if (cardRank == 'J') {
			return 12;
		} else {
			return Integer.parseInt(card.substring(0, card.length() - 1));
		}
	}

}

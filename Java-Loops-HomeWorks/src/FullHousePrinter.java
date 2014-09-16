import java.util.Locale;

/*
 * In most Poker games, the "full house" hand is
 * defined as three cards of the same face +
 * two cards of the same face, other than the first,
 * regardless of the card's suits. The cards faces are
 * "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q",
 * "K" and "A". The card suits are "♣", "♦", "♥" and "♠".
 * Write a program to generate and
 * print all full houses and print their number.
 */
public class FullHousePrinter {

	public static void main(String[] args) {

		Locale.setDefault(Locale.ROOT);

		String[] ranks = { "2", "3", "4", "5", "6", "7",
				"8", "9", "10", "J", "Q", "K", "A" };
		char[] suits = { '\u2660', '\u2665', '\u2666', '\u2663' };
		int count = 0;

		// 3 Pair
		for (String rank : ranks) {
			for (int i = 0; i < suits.length; i++) {
				for (int j = i + 1; j < suits.length; j++) {
					for (int j2 = j + 1; j2 < suits.length; j2++) {
						// 2 Pair
						for (String secondRank : ranks) {
							if (secondRank.equals(rank)) {
								continue;
							}
							for (int k = 0; k < suits.length; k++) {
								for (int k2 = k + 1; k2 < suits.length; k2++) {
									count++;
									System.out.printf("%s%c %s%c %s%c %s%c %s%c",
											rank, suits[i], rank, suits[j], rank, suits[j2],
											secondRank, suits[k], secondRank, suits[k2]);
									System.out.println();
								}
							}
						}
					}
				}
			}
		}
		
		System.out.println(count);
	}
}
import java.util.Locale;

/*
 * In most Poker games, the "full house" hand is
 * defined as three cards of the same face +
 * two cards of the same face, other than the first,
 * regardless of the card's suits.
 * The cards faces are "2", "3", "4", "5",
 * "6", "7", "8", "9", "10", "J", "Q", "K" and
 * "A". The card suits are "♣", "♦", "♥" and "♠".
 * A special card "Joker" (denoted as "*") is
 * used as wildcard and can replace any other card.
 * Jokers do not have a suite. Jokes can be used several times in
 * a hand. Write a program to generate and 
 * print all full houses and print their number.
 */
public class FullHouseWithJockers {
	
	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		String[] ranks = { "2", "3", "4", "5", "6", "7",
				"8", "9", "10", "J", "Q", "K", "A" };
		char[] suits = { '\u2660', '\u2665', '\u2666', '\u2663' };
		
		int count = 0;
		for (String rank : ranks) {
			// Pair of 3 cards
			for (int i = 0; i < suits.length; i++) {
				for (int j = i + 1; j < suits.length; j++) {
					for (int j2 = j + 1; j2 < suits.length; j2++) {
						
						//Pair of 2 cards
						for (String secondRank : ranks) {
							if (secondRank.equals(rank)) {
								continue;
							}
							for (int k = 0; k < suits.length; k++) {
								for (int k2 = k + 1; k2 < suits.length; k2++) {
									
									//Check for jockers
									for (int n = 0; n < Math.pow(2, 5); n ++) {
										count++;
										
										//Save current hand
										String[] cards = new String[] {
												rank + suits[i],
												rank + suits[j],
												rank + suits[j2],
												secondRank + suits[k],
												secondRank + suits[k2]
										};
										//Check for jockers and insert them
										for (int m = 0; m < 5; m++) {
											int num = ((1 << m) & n) >> m;
											if (num == 1) {
												cards[m] = "*";
											}
										}
										
										
										for (String card : cards) {
											System.out.printf("%s ", card);
										}
										System.out.println();
									}
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


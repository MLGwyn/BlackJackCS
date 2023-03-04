using System;
using System.Collections.Generic;

namespace BlackJackCS
{
    class Cards
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public string Rank { get; set; }
        public int Points { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var suits = new List<string>() { "♥️", "♣️", "♦️", "♠️" };
            var ranks = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            var points = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

            var index = 0;

            var deckOfCards = new List<Cards>();

            foreach (var currentSuit in suits)
            {
                foreach (var currentRank in ranks)
                {
                    var newCard = new Cards();
                    newCard.Name = $"{currentRank} of {currentSuit}";
                    newCard.Suit = currentSuit;
                    newCard.Rank = currentRank;
                    newCard.Points = points[index];
                    index++;
                    deckOfCards.Add(newCard);
                }
            }

            var numberOfCards = deckOfCards.Count;
            for (var rightIndex = numberOfCards - 1; rightIndex > 0; rightIndex--)
            {
                var randomNumberGenerator = new Random(); //create a new random number generator object
                var leftIndex = randomNumberGenerator.Next(rightIndex); //generate a new random number between 0 and rightIndex and save that number as leftIndex
                var leftCard = deckOfCards[leftIndex]; // create temporary leftCard, which saves a copy of the original card at [leftIndex]
                var rightCard = deckOfCards[rightIndex]; // create temporary leftCard, which saves a copy of the original card at [leftIndex]
                deckOfCards[rightIndex] = leftCard; // replace the card at [rightIndex] with leftCard
                deckOfCards[leftIndex] = rightCard; // replace the card at [leftIndex] with rightCard
            }

            var playerHand = new List<Cards>();
            var dealerHand = new List<Cards>();
            // var cardToMove;

            playerHand.Add(deckOfCards[deckOfCards.Count - 1]);
            deckOfCards.RemoveAt(deckOfCards.Count - 1);

            dealerHand.Add(deckOfCards[deckOfCards.Count - 1]);
            deckOfCards.RemoveAt(deckOfCards.Count - 1);

            playerHand.Add(deckOfCards[deckOfCards.Count - 1]);
            deckOfCards.RemoveAt(deckOfCards.Count - 1);

            dealerHand.Add(deckOfCards[deckOfCards.Count - 1]);
            deckOfCards.RemoveAt(deckOfCards.Count - 1);

            var playerHandValue = 0;
            foreach (var card in playerHand)
            {
                playerHandValue += card.Points;
            }

            // var dealerHandValue = dealerHand[0].Points + dealerHand[1].Points;

            var dealerHandValue = 0;
            foreach (var card in dealerHand)
            {
                dealerHandValue += card.Points;
            }

            Console.WriteLine();
            Console.WriteLine($"You have {playerHand.Count} cards. They are: ");
            foreach (var card in playerHand)
            {
                Console.WriteLine(card.Name);
            }
            Console.WriteLine($"Your hand is worth {playerHandValue} points. ");
            // Console.WriteLine($"Dealer hand is worth {dealerHandValue} points. ");
            // Console.WriteLine($"Dealer has {dealerHand.Count} cards. ");
            // Console.WriteLine($"There are {deckOfCards.Count} cards in the deck. ");

            Console.WriteLine();
            Console.WriteLine("Would you like to (H)it or (S)tand? ");

            string response = Console.ReadLine().ToUpper();

            while (response == "H")
            {
                playerHand.Add(deckOfCards[deckOfCards.Count - 1]);
                deckOfCards.RemoveAt(deckOfCards.Count - 1);
                Console.WriteLine($"You have {playerHand.Count} cards. They are: ");
                foreach (var card in playerHand)
                {
                    Console.WriteLine(card.Name);
                }
                playerHandValue = 0;
                foreach (var card in playerHand)
                {
                    playerHandValue += card.Points;
                }
                Console.WriteLine($"Your hand is worth {playerHandValue} points. ");
                if (playerHandValue > 21)
                {
                    Console.WriteLine($"BUST! You have over 21 points. Dealer wins. ");
                    break;
                }
                else
                if (playerHandValue == 21)
                {
                    Console.WriteLine("You've hit BLACKJACK!.\n\nAction goes to dealer.\n ");
                    break;
                };
                Console.WriteLine();
                Console.WriteLine("Would you like to (H)it or (S)tand? ");

                response = Console.ReadLine().ToUpper();


            }
            if (response == "S")
            {
                Console.WriteLine($"Player Stands with hand worth {playerHandValue} points.\n\nPlayers turn is over.\n\nAction goes to dealer.\n ");
            }
            Console.WriteLine("Dealer has ");
            foreach (var card in dealerHand)
            {
                Console.WriteLine(card.Name);
            }
            Console.WriteLine($"\nDealers hand is worth {dealerHandValue} points.\n ");
            while (dealerHandValue < 17)
            {
                dealerHand.Add(deckOfCards[deckOfCards.Count - 1]);
                deckOfCards.RemoveAt(deckOfCards.Count - 1);
                Console.WriteLine("\nDealer has added another card.\nDealers hand is now ");
                foreach (var card in dealerHand)
                {
                    Console.WriteLine(card.Name);
                }
                dealerHandValue = 0;
                foreach (var card in dealerHand)
                {
                    dealerHandValue += card.Points;
                }
                Console.WriteLine($"Dealers hand is worth {dealerHandValue} points.\n ");
                if (dealerHandValue > 21)
                {
                    Console.WriteLine($"BUST! Dealer has over 21 points.\nPlayer wins.\n ");
                    break;
                }
                else
                if (dealerHandValue == 21)
                {
                    Console.WriteLine("Dealer hit BLACKJACK!.\n\nDealer wins.\n ");
                    break;
                };
            }












            // Console.WriteLine($"Players hand is\n-{deckOfCards[0].Name} -\n -and-\n-{deckOfCards[1].Name} - ");
            // Console.WriteLine($"There are {deckOfCards.Count} cards in the deck.");






        }
    }
}

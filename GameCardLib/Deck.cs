﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCardLib
{
    public class Deck
    {
        #region fields
        private Stack<Card> cards;
        private int deckMultiplier;
        #endregion
        #region Properties
        public int Count
        {
            get { return cards.Count; }
        }
        #endregion
        #region Methods()
        #region Constructors
        public Deck() :this(1)
        {
        }
        public Deck(int deckMultiplier)
        {
            this.deckMultiplier = deckMultiplier;
            cards = new Stack<Card>();
            FillDeckWithCards();
            Shuffle();
        }
        #endregion
        public bool DiscardCards(int quantity)
        {
            for (int i = quantity; i > 0; i--)
            {
                cards.Pop();
            }
            return true;
        }
        public Card DrawNextCard()
        {
            return cards.Pop();
        }

        private bool FillDeckWithCards()
        {
            foreach (int deck in Enumerable.Range(1,deckMultiplier))
            {
                foreach (EnumSuite suite in Enum.GetValues(typeof(EnumSuite)))
                {
                    foreach (int value in Enum.GetValues(typeof(EnumValue)))
                    {
                        Card card = new Card(value, suite);
                        cards.Push(card);
                    }
                }
            }
            return true;
        }
        //utilities?
        public void Shuffle()
        {
            Random rnd = new Random();
            cards = new Stack<Card>(cards.OrderBy(x => rnd.Next()));
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Card card in cards)
            {
                stringBuilder.AppendFormat("{0}, ", card.ToStringShort);
            }
            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            return stringBuilder.ToString();
        }

        public Card Peek() => cards.Peek();
        public Card Pop() => cards.Pop();
        #endregion
    }
}

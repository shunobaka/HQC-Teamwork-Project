﻿// <summary>Contains the Printer class.</summary>
//-----------------------------------------------------------------------
// <copyright file="Printer.cs" company="Bulls-And-Cows-1">
//     Everything is copyrighted.
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows.Messages
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Contracts;

    /// <summary>
    /// Printer class.
    /// </summary>
    public class Printer : IPrinter
    {
        /// <summary>
        /// Score board.
        /// </summary>
        private const string ScoreBoardText = "Scoreboard:";

        /// <summary>
        /// Text format.
        /// </summary>
        private const string FormatText = "  {0,7} | {1}";

        /// <summary>
        /// Guessed text format.
        /// </summary>
        private const string GuessesText = "  {0,7} | {1}";

        /// <summary>
        /// Name string constant.
        /// </summary>
        private const string NameText = "Name";

        /// <summary>
        /// Current position text.
        /// </summary>
        private const string CurrentPositionFormatText = "{0}| {1}";

        /// <summary>
        /// Empty scoreboard text.
        /// </summary>
        private const string EmptyScoreBoardText = "Scoreboard is empty!";

        /// <summary>
        /// Number looks like text.
        /// </summary>
        private const string NumberLooksLikeText = "The number looks like ";

        /// <summary>
        /// Point constant.
        /// </summary>
        private const string PointText = ".";

        /// <summary>
        /// Dash constant.
        /// </summary>
        private const string DashText = "-";

        /// <summary>
        /// Initializes a new instance of the <see cref="Printer" /> class.
        /// </summary>
        /// <param name="messageFactory">MessageFactory instance.</param>
        public Printer(MessageFactory messageFactory)
        {
            this.MessageFactory = messageFactory;
        }

        /// <summary>
        /// Gets a factory.
        /// </summary>
        /// <value>A MessageFactory.</value>
        public MessageFactory MessageFactory { get; private set; }

        /// <summary>
        /// Prints the message with parameters.
        /// </summary>
        /// <param name="messageType">Message type.</param>
        /// <param name="parameter">Integer Number.</param>
        /// <param name="secondParameter">INTERGER NUMBER.</param>
        public void PrintMessage(MessageType messageType, int parameter = 0, int secondParameter = 0)
        {
            var message = this.MessageFactory.MakeMessage(messageType, parameter, secondParameter);
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints the message without parameters.
        /// </summary>
        /// <param name="messageType">Type of message.</param>
        public void PrintMessage(MessageType messageType)
        {
            var message = this.MessageFactory.MakeMessage(messageType);
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints the message with parameters.
        /// </summary>
        /// <param name="messageType">Message type.</param>
        /// <param name="parameter">Integer number.</param>
        public void PrintMessage(MessageType messageType, int parameter)
        {
            var message = this.MessageFactory.MakeMessage(messageType, parameter);
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints Leaderboard.
        /// </summary>
        /// <param name="leaderBoard">IList of player score.</param>
        public void PrintLeaderBoard(IList<PlayerScore> leaderBoard)
        {
            Console.WriteLine();
            if (leaderBoard.Count > 0)
            {
                Console.WriteLine(ScoreBoardText);
                int currentPosition = 1;
                Console.WriteLine(FormatText, GuessesText, NameText);
                this.PrintDashedLine(40);

                foreach (var currentPlayerInfo in leaderBoard)
                {
                    Console.WriteLine(CurrentPositionFormatText, currentPosition, currentPlayerInfo);
                    this.PrintDashedLine(40);
                    currentPosition++;
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(EmptyScoreBoardText);
            }
        }

        /// <summary>
        /// Printing helping numbers.
        /// </summary>
        /// <param name="helpingNumber">Chars array.</param>
        public void PrintHelpingNumber(char[] helpingNumber)
        {
            Console.Write(NumberLooksLikeText);

            foreach (char ch in helpingNumber)
            {
                Console.Write(ch);
            }

            Console.Write(PointText);
            Console.WriteLine();
        }

        /// <summary>
        /// Congratulation Message is printed.
        /// </summary>
        /// <param name="cheatAttemptCounter">Integer number.</param>
        /// <param name="guessAttemptCounter">Second Integer number.</param>
        public void PrintCongratulationMessage(int cheatAttemptCounter, int guessAttemptCounter)
        {
            if (cheatAttemptCounter == 0)
            {
                this.PrintMessage(MessageType.Congratulation, guessAttemptCounter);
            }
            else
            {
                this.PrintMessage(MessageType.CheatCongratulation, guessAttemptCounter, cheatAttemptCounter);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Dash printing.
        /// </summary>
        /// <param name="dashesForPrint">Number of Dashes.</param>
        private void PrintDashedLine(int dashesForPrint)
        {
            for (int i = 0; i < dashesForPrint; i++)
            {
                Console.Write(DashText);
            }

            Console.WriteLine();
        }
    }
}

﻿using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui
{
    /// <summary>
    /// Animals main screen.
    /// </summary>
    public sealed class AnimalsScreen : Screen
    {
        #region Properties And Ctor

        private IDataService _dataService;
        private MammalsScreen _mammalsScreen;
        private ISettingsService _settingsService;
        private ISettings _settings;

        public AnimalsScreen(
            IDataService dataService,
            MammalsScreen mammalsScreen,
            ISettingsService settingsService,
            ISettings settings)
        {
            _dataService = dataService;
            _mammalsScreen = mammalsScreen;
            _settingsService = settingsService;
            _settings = settings;
        }

        #endregion Properties And Ctor

        #region Public Methods

        /// <inheritdoc/>
        public override void Show()
        {
            while (true)
            {
                Console.ForegroundColor = _settingsService.Settings._animalScreenForegroundColor;
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine("Your available choices are:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Mammals");
                Console.WriteLine("2. Save to file");
                Console.WriteLine("3. Read from file");
                Console.Write("Please enter your choice: ");

                string? choiceAsString = Console.ReadLine();
                Console.ResetColor();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    AnimalsScreenChoices choice = (AnimalsScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case AnimalsScreenChoices.Mammals:
                            _mammalsScreen.Show();
                            break;

                        case AnimalsScreenChoices.Read:
                            ReadFromFile();
                            break;

                        case AnimalsScreenChoices.Save:
                            SaveToFile();
                            break;

                        case AnimalsScreenChoices.Exit:
                            Console.WriteLine("Going back to parent menu.");
                            return;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        #endregion // Public Methods

        #region Private Methods

        private void SaveToFile()
        {
            try
            {
                Console.Write("Save data to file: ");
                var fileName = Console.ReadLine();
                if (fileName is null)
                {
                    throw new ArgumentNullException(nameof(fileName));
                }

                // Save text colors to settings before saving to file
                _dataService.Write(fileName);
                Console.WriteLine("Data saving to: '{0}' was successful.", fileName);
            }
            catch
            {
                Console.WriteLine("Data saving was not successful.");
            }
        }

        private void ReadFromFile()
        {
            try
            {
                Console.Write("Read data from file: ");
                var fileName = Console.ReadLine();
                if (fileName is null)
                {
                    throw new ArgumentNullException(nameof(fileName));
                }

                _dataService.Read(fileName);
                Console.WriteLine("Data reading from: '{0}' was successful.", fileName);

            }
            catch
            {
                Console.WriteLine("There is an error");
            }

            #endregion // Private Methods

        }
    }
}

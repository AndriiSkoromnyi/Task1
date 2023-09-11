﻿using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals
{
    /// <summary>
    /// Very basic cat class.
    /// </summary>
    public class Cat : MammalBase, ICat
    {
        #region Public Methods


        public override void Display()

        {
            Console.WriteLine($"My name is: {Name}, my age is: {Age}, My weight is: {Weight} kg, I am a {Color}, also I love {FoodPreference}");

            Console.WriteLine((HasOwner ? "Yes, I have an owner" : "No, I don't have an owner"));
        }

        /// <inheritdoc/>
        public override void Copy(IAnimal animal)
        {
            if (animal is ICat cat)
            {
                base.Copy(animal);
                Color = cat.Color;
                HasOwner = cat.HasOwner;
            }
        }

        #endregion // Public Methods

        #region Ctors And Properties

        /// <inheritdoc/>
        public string Color { get; set; }
        public int Weight { get; set; }
        public bool HasOwner { get; set; }
        public string FoodPreference { get; set; }
        public string TypeOfCat { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="age">Age</param>
        /// <param name="color">Color</param>
        /// <param name="weight">Weight</param>
        /// <param name="typeOfCat">Type of cat</param>
        /// 

        public Cat(string name, int age, int weight, string color, bool hasOwner, string foodPreference, string typeOfCat) : base(name, age, MammalSpecies.Cat)
        {
            Color = color;
            Weight = weight;
            HasOwner = hasOwner;
            FoodPreference = foodPreference;
            TypeOfCat = typeOfCat;
        }

        #endregion // Ctors And Properties
    }
}

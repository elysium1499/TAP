using System;
using System.Text.RegularExpressions;       //usata per il match
using System.Diagnostics;						//per assert

namespace Esercizio1
{
	class Person
	{
		private static long nextSocialSN;
		private static readonly String validName = @"[A-Z][a-z]+( [A-Z][a-z]+)*";   //la stringa del match richiede la @ prima della stringa
		public readonly String name;
		public readonly String surname;
		public readonly long socialSN; // social security number
		private Person spouse; // optional :)

		// private auxiliary static methods for validation and security social number
		// generation

		private static Object requireNonNull(Object o)
		{
			if (o == null)
				throw new ArgumentNullException();
			return o;
		}

		private static String requireValidName(String name)
		{
			Regex reg = new Regex(validName);       //usato per creare il match
			Match m = reg.Match(name);              //usato per vedere se la stringa appartiene  questo match
			if (!m.Success)
				throw new ArgumentNullException();
			return name;
		}

		private static long nextSocial()
		{
			if (nextSocialSN < 0)
				throw new ArgumentNullException();
			return Person.nextSocialSN++;
		}

		// public static methods to change the civil status of couples

		public static void join(Person p1, Person p2)
		{
			if (p1.spouse != null || p2.spouse != null || p1 == p2)
				throw new ArgumentNullException();
			p1.spouse = p2;
			p2.spouse = p1;
		}

		public static void divorce(Person p1, Person p2)
		{
			Person.requireNonNull(p1);
			if (p1 != p2.spouse)
				throw new ArgumentNullException(); ;
			p1.spouse = null;
			p2.spouse = null;
		}

		// constructor

		public Person(String name, String surname)
		{
			this.name = Person.requireValidName(name);
			this.surname = Person.requireValidName(surname);
			this.socialSN = Person.nextSocial();
		}

		// instance methods

		public Person getSpouse()
		{
			return this.spouse;
		}

		public bool isSingle()
		{       //da boolean (java) a bool (c#)
			return this.spouse == null;
		}

	}
	public class Test
    {
		public static void Main(String[] args)
		{
			Person guido = new Person("Guido", "Guerrieri");

			Console.WriteLine("Nome e' Guido?: " + (guido.name == "Guido"));
			Console.WriteLine("Cognome e' Guerrieri?: " + (guido.surname == "Guerrieri"));
			Console.WriteLine("socialSN di guido e' 0?: " + (guido.socialSN == 0));
			Console.WriteLine("Guido è single?: " + guido.isSingle());
			Person lorenza = new Person("Lorenza", "Delle Foglie");
			Console.WriteLine("socialSN e' 1?: " + (lorenza.socialSN == 1));
			Console.WriteLine("Nome e' Guido?: " + (lorenza.name == "Lorenza"));
			Console.WriteLine("Cognome e' Guerrieri?: " + (lorenza.surname == "Delle Foglie"));
			Console.WriteLine("Guido è single?: " + lorenza.isSingle());
			Person.join(lorenza, guido);
			Console.WriteLine("Guido e Lorenza si sposano");
			Console.WriteLine("Giodo e Lorenza sono sposati?: " + (lorenza.getSpouse() == guido && guido.getSpouse() == lorenza));
			Person.divorce(guido, lorenza);
			Console.WriteLine("Guido e Lorenza divorziano");
			Console.WriteLine("Lorenza è single?: " + lorenza.isSingle());
			Console.WriteLine("Guido è single?: " + guido.isSingle());

			// Questo e' quello che chiede la prof ASSERT -- using System.Diagnostics;//

			Debug.Assert(guido.name.Equals("Guido"));
			Debug.Assert(guido.surname.Equals("Guerrieri"));
			Debug.Assert(guido.socialSN == 0);
			Debug.Assert(guido.isSingle());
			Debug.Assert(lorenza.socialSN == 1);
			Debug.Assert(lorenza.name.Equals("Lorenza"));
			Debug.Assert(lorenza.surname.Equals("Delle Foglie"));
			Debug.Assert(lorenza.isSingle());
			Person.join(lorenza, guido);
			Debug.Assert(lorenza.getSpouse() == guido && guido.getSpouse() == lorenza);
			Debug.Assert(!lorenza.isSingle() && !guido.isSingle());
			Person.divorce(guido, lorenza);
			Debug.Assert(lorenza.isSingle());
			Debug.Assert(guido.isSingle());
		}
	}
}

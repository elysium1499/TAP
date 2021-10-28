using System;
using System.Text.RegularExpressions;		//usata per il match

namespace Esercizio1
{
    class Person
    {
		private static long nextSocialSN;
		private static readonly String validName = @"[A-Z][a-z]+( [A-Z][a-z]+)*";	//la stringa del match richiede la @ prima della stringa
		public readonly String name;
		public readonly String surname;
		public readonly long socialSN; // social security number
		private Person spouse; // optional :)

		// private auxiliary static methods for validation and security social number
		// generation

		private static Object requireNonNull(Object o) {
			if (o == null)
				throw new ArgumentNullException();
			return o;
		}

		private static String requireValidName(String name) {
			Regex reg = new Regex(validName);		//usato per creare il match
			Match m = reg.Match(name);				//usato per vedere se la stringa appartiene  questo match
			if (!m.Success)
				throw new ArgumentNullException();
			return name;
		}

		private static long nextSocial() {
			if (nextSocialSN < 0)
				throw new ArgumentNullException();
			return Person.nextSocialSN++;
		}

		// public static methods to change the civil status of couples

		public static void join(Person p1, Person p2) {
			if (p1.spouse != null || p2.spouse != null || p1 == p2)
				throw new ArgumentNullException();
			p1.spouse = p2;
			p2.spouse = p1;
		}

		public static void divorce(Person p1, Person p2) {
			Person.requireNonNull(p1);
			if (p1 != p2.spouse)
				throw new ArgumentNullException(); ;
			p1.spouse = null;
			p2.spouse = null;
		}

		// constructor

		public Person(String name, String surname) {
			this.name = Person.requireValidName(name);
			this.surname = Person.requireValidName(surname);
			this.socialSN = Person.nextSocial();
		}

		// instance methods

		public Person getSpouse() {
			return this.spouse;
		}

		public bool isSingle() {		//da boolean (java) a bool (c#)
			return this.spouse == null;
		}

		}
}

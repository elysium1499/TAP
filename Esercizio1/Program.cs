using System;

namespace Esercizio1
{
    class Person
    {
		private static long nextSocialSN;
		private readonly String validName = "[A-Z][a-z]+( [A-Z][a-z]+)*";
		public sealed String name;
		public sealed String surname;
		public sealed long socialSN; // social security number
		private Person spouse; // optional :)

		// private auxiliary static methods for validation and security social number
		// generation

		private static Object requireNonNull(Object o) {
			if (o == null)
				throw;
			return o;
		}

		private static String requireValidName(String name) {
			if (!name.matches(Person.validName))
				throw;
			return name;
		}

		private static long nextSocialSN() {
			if (Person.nextSocialSN < 0)
				throw;
			return Person.nextSocialSN++;
		}

		// public static methods to change the civil status of couples

		public static void join(Person p1, Person p2) {
			if (p1.spouse != null || p2.spouse != null || p1 == p2)
				throw;
			p1.spouse = p2;
			p2.spouse = p1;
		}

		public static void divorce(Person p1, Person p2) {
			Person.requireNonNull(p1);
			if (p1 != p2.spouse)
				throw;
			p1.spouse = null;
			p2.spouse = null;
		}

		// constructor

		public Person(String name, String surname) {
			this.name = Person.requireValidName(name);
			this.surname = Person.requireValidName(surname);
			this.socialSN = Person.nextSocialSN();
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

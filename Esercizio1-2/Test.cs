using System;
using System.Diagnostics;                       //per assert

namespace Esercizio1_2
{
	public class Test
	{
		public static void Main(String[] args)
		{
			Person guido = new Person("Guido", "Guerrieri");

			Console.WriteLine("Nome e' Guido?: " + (guido.name.Equals("Guido")));
			Console.WriteLine("Cognome e' Guerrieri?: " + (guido.surname.Equals("Guerrieri")));
			Console.WriteLine("socialSN di guido e' 0?: " + (guido.socialSN == 0));
			Console.WriteLine("Guido è single?: " + guido.isSingle());
			Person lorenza = new Person("Lorenza", "Delle Foglie");
			Console.WriteLine("socialSN e' 1?: " + (lorenza.socialSN == 1));
			Console.WriteLine("Nome e' Guido?: " + (lorenza.name.Equals("Lorenza")));
			Console.WriteLine("Cognome e' Guerrieri?: " + (lorenza.surname.Equals("Delle Foglie")));
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

			CreditAccount guidoAcc = CreditAccount.newOfBalanceOwner(10_00, guido);
			CreditAccount lorenzaAcc = CreditAccount.newOfLimitBalanceOwner(-500_00, 100_00, lorenza);
			(guidoAcc.id).Equals(0);

			Console.WriteLine((guidoAcc.id).Equals(0));
			Console.WriteLine(guidoAcc.owner.Equals(guido));
			Console.WriteLine(guidoAcc.getBalance().Equals(10_00));
			Console.WriteLine(guidoAcc.getLimit().Equals(0));
			Console.WriteLine(lorenzaAcc.id.Equals(1));
			Console.WriteLine(lorenzaAcc.owner.Equals(lorenza));
			Console.WriteLine(lorenzaAcc.getBalance().Equals(100_00));
			Console.WriteLine(lorenzaAcc.getLimit().Equals(-500_00));
			Console.WriteLine(guidoAcc.deposit(100_00).Equals(110_00));
			Console.WriteLine(lorenzaAcc.deposit(200_00).Equals(300_00));
			Console.WriteLine(guidoAcc.withdraw(110_00).Equals(0));
			lorenzaAcc.setLimit(100_00);
			Console.WriteLine(lorenzaAcc.withdraw(200_00).Equals(100_00));

			Debug.Assert(guidoAcc.owner.Equals(guido));
			Debug.Assert(guidoAcc.getBalance().Equals(10_00));
			Debug.Assert(guidoAcc.getLimit().Equals(0));
			Debug.Assert(lorenzaAcc.id.Equals(1));
			Debug.Assert(lorenzaAcc.owner.Equals(lorenza));
			Debug.Assert(lorenzaAcc.getBalance().Equals(100_00));
			Debug.Assert(lorenzaAcc.getLimit().Equals(-500_00));
			Debug.Assert(guidoAcc.deposit(100_00).Equals(110_00));
			Debug.Assert(lorenzaAcc.deposit(200_00).Equals(300_00));
			Debug.Assert(guidoAcc.withdraw(110_00).Equals(0));
			lorenzaAcc.setLimit(100_00);
			Debug.Assert(lorenzaAcc.withdraw(200_00).Equals(100_00));
		}
	}
}
